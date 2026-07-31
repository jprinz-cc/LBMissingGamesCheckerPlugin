using LBMissingGamesCheckerPlugin.Models;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        private async void GetAllPlatformGames(IPlatform selectedPlatform, string platformToCheck)
        {
            // Disable form btns and reset for new load
            Invoke((Action)(() =>
            {
                confirmButton.Enabled = false;
                clbColumnSelection.Enabled = false;
                btnOwnedExportOptions.Enabled = false;
                btnMissingExportOptions.Enabled = false;
                lblOwnedGamesCount.Text = "0";
                lblMissingGamesCount.Text = "0";
            }));

            DebugTxt("Starting GetAllPlatformGames via SQLite...");
            HashSet<int> ownedGameIds = new HashSet<int>();

            // Capture UI state on the main thread before background tasks
            bool filterReleasedOnly = chkReleasedOnly.Checked;
            string selectedRegion = cmbRegionFilter.SelectedItem?.ToString() ?? "All Regions";
            bool includeEmptyRegions = chkIncludeEmptyRegions.Checked;

            if (selectedPlatform == null)
            {
                DebugTxt("selectedPlatform is null.");
                return;
            }

            try
            {
                DebugTxt($"Filter by Released: {filterReleasedOnly} | Region: {selectedRegion} | Include Empty: {includeEmptyRegions}");

                // Clear lists of populated data
                ownedGames = new ConcurrentBag<IGame>();
                missingGames = new ConcurrentBag<MetadataDbGame>();

                DebugTxt("Fetching Owned Games from LaunchBox API...");
                var ownedGamesList = await Task.Run(() => selectedPlatform.GetAllGames(true, true));

                if (ownedGamesList != null)
                {
                    await Task.Run(() =>
                    {
                        foreach (var game in ownedGamesList)
                        {
                            // ALWAYS add to the exclusion list IF IT HAS AN ID 
                            if (game.LaunchBoxDbId.HasValue && game.LaunchBoxDbId != 0)
                            {
                                ownedGameIds.Add(game.LaunchBoxDbId.Value);
                            }

                            // Process EVERYTHING for the visual Owned grid (even unscraped games)

                            // Check Released filter
                            bool passesReleased = !filterReleasedOnly || game.ReleaseType == "Released";

                            // Evaluate Region Logic cleanly
                            bool passesRegion;
                            if (string.IsNullOrWhiteSpace(game.Region))
                            {
                                // The game has NO region. Only pass it if the user checked the safety net box!
                                passesRegion = includeEmptyRegions;
                            }
                            else
                            {
                                // The game HAS a region. Pass it if they want "All", or if it matches their specific choice.
                                passesRegion = (selectedRegion == "All Regions") || game.Region.Contains(selectedRegion, StringComparison.OrdinalIgnoreCase);
                            }

                            // Only add to the visual display list if it passes both optional filters
                            if (passesReleased && passesRegion)
                            {
                                ownedGames.Add(game);
                            }
                        }
                    });
                }
                DebugTxt($"ownedGames Count (Filtered): {ownedGames.Count}");

                DebugTxt("Fetching Platform Games from SQLite DB...");
                var repo = new Data.MetadataRepository();
                var platformGames = await repo.GetGamesForPlatformAsync(platformToCheck);

                if (platformGames.Count > 0)
                {
                    // Filter out games already own, and apply the 'Released' and 'Region' filters
                    var filteredMissing = await Task.Run(() =>
                    {
                        return platformGames
                            .Where(dbGame => dbGame.LaunchBoxDbId.HasValue && !ownedGameIds.Contains(dbGame.LaunchBoxDbId.Value))
                            .Where(dbGame => !filterReleasedOnly || dbGame.ReleaseType == "Released")
                            .Where(dbGame =>
                                string.IsNullOrWhiteSpace(dbGame.Region)
                                    ? includeEmptyRegions
                                    : (selectedRegion == "All Regions" || dbGame.Region.Contains(selectedRegion, StringComparison.OrdinalIgnoreCase))
                            )
                            .ToList();
                    });

                    missingGames = new ConcurrentBag<MetadataDbGame>(filteredMissing);
                    DebugTxt($"missingGames Count (Filtered): {missingGames.Count}");
                }
                else
                {
                    // Add final "NoPlatformFound" message row
                    DebugTxt("Adding error to missingGames List...");
                    var noPlatformErrorList = new List<MetadataDbGame>
            {
                new MetadataDbGame("NoPlatformFound", string.Empty, string.Empty, string.Empty, null, null, null,
                    $"The selected platform '{platformToCheck}' was not found in the LaunchBox DB.", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty),
                new MetadataDbGame("=====================", string.Empty, string.Empty, string.Empty, null, null, null,
                    "=====================", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty)
            };

                    missingGames = new ConcurrentBag<MetadataDbGame>(noPlatformErrorList);
                    DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: NoPlatformFound");
                }

                DebugTxt("Populating Game Lists!");
                PopulateGameList(ownedGames, missingGames);
            }
            catch (Exception ex)
            {
                LogException(ex);
                Invoke((Action)(() => confirmButton.Enabled = true));
            }
        }

        // Populate the GridViews with the game lists
        private async void PopulateGameList(ConcurrentBag<IGame> ownedGames, ConcurrentBag<MetadataDbGame> missingGames)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // Suspend layout to prevent unnecessary redraws
                    DebugTxt("Suspending ownedGamesGridView...");
                    ownedGamesGridView.SuspendLayout();

                    DebugTxt("Suspending missingGamesGridView...");
                    missingGamesGridView.SuspendLayout();

                    DebugTxt("Suspending noPlatformGridView...");
                    noPlatformGridView.SuspendLayout();

                    DebugTxt("Clearing data containers...");
                    ownedGamesDisplayData.Clear();
                    missingGamesDisplayData.Clear();
                    noPlatformErrorDisplayData.Clear();
                    ownedGamesBindingSource.Clear();
                    missingGamesBindingSource.Clear();
                    noPlatformBindingSource.Clear();
                    FilteredOwnedGameList.Clear();
                    DebugTxt("Clearing data containers completed!");
                }));
            }
            else
            {
                // Suspend layout to prevent unnecessary redraws
                DebugTxt("Suspending ownedGamesGridView...");
                ownedGamesGridView.SuspendLayout();

                DebugTxt("Suspending missingGamesGridView...");
                missingGamesGridView.SuspendLayout();

                DebugTxt("Suspending noPlatformGridView...");
                noPlatformGridView.SuspendLayout();

                DebugTxt("Clearing data containers...");
                ownedGamesDisplayData.Clear();
                missingGamesDisplayData.Clear();
                noPlatformErrorDisplayData.Clear();
                ownedGamesBindingSource.Clear();
                missingGamesBindingSource.Clear();
                noPlatformBindingSource.Clear();
                FilteredOwnedGameList.Clear();
                DebugTxt("Clearing data containers completed!");
            }

            try
            {
                DebugTxt("Loading ownedGamesDisplayData...");
                var ownedGamesList = await Task.Run(() =>
                {
                    return ownedGames.OrderBy(game => game.Title)
                    .Select(game => new GameDisplayData(new MetadataDbGame(
                        game.Title, game.Developer, game.Publisher, game.Region, (DateTime?)game.ReleaseDate,
                        (float?)game.CommunityStarRating, (int?)game.CommunityStarRatingTotalVotes,
                        game.Platform, game.ReleaseType, game.GenresString, game.GetAllAlternateNames(),
                        game.MaxPlayers, game.LaunchBoxDbId, game.VideoUrl, game.WikipediaUrl
                    ))).ToList();
                });
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        ownedGamesDisplayData = new BindingList<GameDisplayData>(ownedGamesList);
                    }));
                }
                else
                {
                    ownedGamesDisplayData = new BindingList<GameDisplayData>(ownedGamesList);
                }
                DebugTxt($"ownedGamesDisplayData loaded! {ownedGamesDisplayData.Count}");

                try
                {
                    // Bind missingGames data to GridView                
                    if (missingGames != null && missingGames.Any() && missingGames.First()?.LaunchBoxDbId != null && missingGames.First().LaunchBoxDbId != 0)  // If the selectedPlatform returned games from the local db
                    {
                        DebugTxt("Loading missingGamesDisplayData...");
                        DebugTxt($"missingGames first LBID: {missingGames.First().LaunchBoxDbId}");
                        var missingGamesList = await Task.Run(() =>
                        {
                            return missingGames.OrderBy(game => game.Title)
                            .Select(game => new GameDisplayData(game)).ToList();
                        });
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                missingGamesDisplayData = new BindingList<GameDisplayData>(missingGamesList);
                            }));
                        }
                        else
                        {
                            missingGamesDisplayData = new BindingList<GameDisplayData>(missingGamesList);
                        }
                        DebugTxt("Loading missingGamesDisplayData completed!");
                    }
                    else if (missingGames != null && missingGames.Any() && missingGames.First()?.LaunchBoxDbId == 0)  // If the selectedPlatform was not found in the LaunchBoxDb
                    {
                        DebugTxt("Loading noPlatformErrorDisplayData...");
                        var errorList = await Task.Run(() =>
                        {
                            return missingGames.Reverse().Select(item => new NoPlatformErrorData(
                                    item.Title,
                                    item.Platform,
                                    item.LaunchBoxDbId
                                )).ToList();
                        });
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                noPlatformErrorDisplayData = new BindingList<NoPlatformErrorData>(errorList);
                            }));
                        }
                        else
                        {
                            noPlatformErrorDisplayData = new BindingList<NoPlatformErrorData>(errorList);
                        }
                        DebugTxt("Loading noPlatformErrorDisplayData completed!");
                    }
                    else if (missingGames == null)
                    {
                        DebugTxt("Loading missingGamesDisplayData did NOT complete, missingGames is null!");
                        return;
                    }
                    DebugTxt("Loading DisplayData completed!");
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }

                try
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            DebugTxt($"Binding ownedGamesBindingSource with {ownedGamesDisplayData.Count} ownedGamesDisplayData elements...");
                            ownedGamesBindingSource.DataSource = ownedGamesDisplayData;
                            OriginalOwnedGameList = ownedGamesDisplayData;
                            lblOwnedGamesCount.Text = ownedGamesDisplayData.Count > 0 ? ownedGamesDisplayData.Count.ToString() : "0";
                            btnOwnedExportOptions.Enabled = true;
                            LoadFilterOptions(ownedGamesGridView);
                        }));
                    }
                    else
                    {
                        DebugTxt($"Binding ownedGamesBindingSource with {ownedGamesDisplayData.Count} ownedGamesDisplayData elements...");
                        ownedGamesBindingSource.DataSource = ownedGamesDisplayData;
                        OriginalOwnedGameList = ownedGamesDisplayData;
                        lblOwnedGamesCount.Text = ownedGamesDisplayData.Count > 0 ? ownedGamesDisplayData.Count.ToString() : "0";
                        btnOwnedExportOptions.Enabled = true;
                        LoadFilterOptions(ownedGamesGridView);
                    }
                    DebugTxt("Binding ownedGamesBindingSource completed!");
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }

                try
                {
                    DebugTxt("Starting missingGames or noPlatform binding...");
                    if (missingGamesDisplayData != null && missingGamesDisplayData.Any() && !string.IsNullOrEmpty(missingGamesDisplayData.FirstOrDefault()?.LaunchBoxDbId) && missingGamesDisplayData.First().LaunchBoxDbId != "0")
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt($"Binding missingGamesBindingSource with {missingGamesDisplayData.Count} missingGamesDisplayData elements...");
                                missingGamesGridView.Visible = true;
                                noPlatformGridView.Visible = false;
                                missingGamesBindingSource.DataSource = missingGamesDisplayData;
                                OriginalMissingGameList = missingGamesDisplayData;
                                LoadFilterOptions(missingGamesGridView);
                            }));
                        }
                        else
                        {
                            DebugTxt($"Binding missingGamesBindingSource with {missingGamesDisplayData.Count} missingGamesDisplayData elements...");
                            missingGamesGridView.Visible = true;
                            noPlatformGridView.Visible = false;
                            missingGamesBindingSource.DataSource = missingGamesDisplayData;
                            OriginalMissingGameList = missingGamesDisplayData;
                            LoadFilterOptions(missingGamesGridView);
                        }

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblMissingGamesCount.Text = missingGamesDisplayData.Count.ToString();
                                btnMissingExportOptions.Enabled = true;
                                DebugTxt($"missingGames.Count: {missingGamesDisplayData.Count}");
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            lblMissingGamesCount.Text = missingGamesDisplayData.Count.ToString();
                            btnMissingExportOptions.Enabled = true;
                            DebugTxt($"missingGames.Count: {missingGamesDisplayData.Count}");
                            lblCongrats.Visible = false;
                            pbCongrats.Visible = false;
                        }



                        DebugTxt("Binding missingGamesBindingSource completed!");
                    }
                    else if (noPlatformErrorDisplayData != null && noPlatformErrorDisplayData.Any() && noPlatformErrorDisplayData.First() != null && noPlatformErrorDisplayData.First().LaunchBoxDbId != null && noPlatformErrorDisplayData.First().LaunchBoxDbId == "0")
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt($"Binding noPlatformBindingSource with {noPlatformErrorDisplayData.Count} noPlatformErrorDisplayData elements...");
                                noPlatformGridView.Visible = true;
                                missingGamesGridView.Visible = false;
                                noPlatformBindingSource.DataSource = noPlatformErrorDisplayData;
                                lblMissingGamesCount.Text = "0";
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            DebugTxt($"Binding noPlatformBindingSource with {noPlatformErrorDisplayData.Count} noPlatformErrorDisplayData elements...");
                            noPlatformGridView.Visible = true;
                            missingGamesGridView.Visible = false;
                            noPlatformBindingSource.DataSource = noPlatformErrorDisplayData;
                            lblMissingGamesCount.Text = "0";
                            lblCongrats.Visible = false;
                            pbCongrats.Visible = false;
                        }
                        DebugTxt("Binding noPlatformBindingSource completed!");
                    }
                    else if (missingGamesDisplayData != null && !missingGamesDisplayData.Any())
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt("There are no Missing Games! Congrats!");
                                missingGamesGridView.Visible = true;
                                noPlatformGridView.Visible = false;
                                lblCongrats.Visible = true;
                                pbCongrats.Visible = true;
                                pbCongrats.BringToFront();
                            }));
                        }
                        else
                        {
                            DebugTxt("There are no Missing Games! Congrats!");
                            missingGamesGridView.Visible = true;
                            noPlatformGridView.Visible = false;
                            lblCongrats.Visible = true;
                            pbCongrats.Visible = true;
                            pbCongrats.BringToFront();
                        }
                    }
                    else if (missingGamesDisplayData == null && NoPlatformErrorDisplayData == null || missingGamesDisplayData != null && !missingGamesDisplayData.Any() && ownedGamesDisplayData != null && !ownedGamesDisplayData.Any())
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt("Neither missingGames/noPlatform binding occured!");
                                DebugTxt(true);
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            DebugTxt("Neither missingGames/noPlatform binding occured!");
                            DebugTxt(true);
                            lblCongrats.Visible = false;
                            pbCongrats.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }

                // DataGridViews are processed
                DebugTxt("GridViews Processed!");
            }
            catch (Exception ex)
            {
                DebugTxt($"An exception happened processing the GridViews: {ex.Message}");
                LogException(ex);
            }
            finally
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        // Apply column visibility based on clbColumnSelection's check states
                        DebugTxt($"Apply column visibility to {clbColumnSelection.Items.Count} columns.");
                        UpdateColumnVisibility();

                        DebugTxt("Resuming ownedGamesGridView...");
                        ownedGamesGridView.ResumeLayout();

                        DebugTxt("Resuming missingGamesGridView...");
                        missingGamesGridView.ResumeLayout();

                        DebugTxt("Resuming noPlatformGridView...");
                        noPlatformGridView.ResumeLayout();

                        confirmButton.Enabled = true;
                        clbColumnSelection.Enabled = true;
                    }));
                }
                else
                {
                    // Apply column visibility based on clbColumnSelection's check states
                    DebugTxt($"Apply column visibility to {clbColumnSelection.Items.Count} columns.");
                    UpdateColumnVisibility();
                    DebugTxt("Resuming ownedGamesGridView...");
                    ownedGamesGridView.ResumeLayout();

                    DebugTxt("Resuming missingGamesGridView...");
                    missingGamesGridView.ResumeLayout();

                    DebugTxt("Resuming noPlatformGridView...");
                    noPlatformGridView.ResumeLayout();

                    confirmButton.Enabled = true;
                    clbColumnSelection.Enabled = true;
                }
                // Calculate Completion Statistics
                if (OriginalOwnedGameList != null && OriginalMissingGameList != null)
                {
                    DebugTxt("Calculating Completion Statistics...");
                    int ownedCount = OriginalOwnedGameList.Count;
                    int missingCount = OriginalMissingGameList.Count;
                    int totalGames = ownedCount + missingCount;

                    if (totalGames > 0)
                    {
                        double percentage = Math.Round((double)ownedCount / totalGames * 100, 1);
                        lblCompletionStats.Text = $"Platform Completion: {percentage}% ({ownedCount} / {totalGames} Games)";

                        // Color coding based on Completion Percentage
                        if (percentage >= 80)
                        {
                            // 80%+ Complete (Very few missing) -> Green
                            lblCompletionStats.ForeColor = Color.LightGreen;
                        }
                        else if (percentage >= 30)
                        {
                            // 30% to 79% Complete -> Yellow
                            lblCompletionStats.ForeColor = Color.Gold;
                        }
                        else
                        {
                            // 0% to 29% Complete (Mostly missing) -> Red
                            lblCompletionStats.ForeColor = Color.LightCoral;
                        }

                        lblCompletionStats.Visible = true;
                    }
                    DebugTxt("Calculated Completion Statistics!");
                }
                DebugTxt("Resuming GridViews completed!");
            }
        }

        private void LoadFilterOptions(DataGridView dgv)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<DataGridView>(LoadFilterOptions), new object[] { dgv });
                return;
            }

            var uniqueValues = new HashSet<string>();
            var checkedItems = new List<(string Item, bool IsChecked)>();

            // Find the matching column in the GridView
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.HeaderText == "Developer" || column.HeaderText == "Publisher" || column.HeaderText == "Region" ||
                    column.HeaderText == "CommunityStarRating" || column.HeaderText == "ReleaseType" || column.HeaderText == "Genres" || column.HeaderText == "MaxPlayers")
                {
                    if (column.HeaderText == "Region")
                    {
                        uniqueValues = dgv.Rows.Cast<DataGridViewRow>()
                            .SelectMany(row => row.Cells[column.Index].Value?.ToString().Split(new[] { ',' }, StringSplitOptions.None))
                            .Select(value => value.Trim())
                            .ToHashSet();
                    }
                    else if (column.HeaderText == "Genres")
                    {
                        uniqueValues = dgv.Rows.Cast<DataGridViewRow>()
                            .SelectMany(row => row.Cells[column.Index].Value?.ToString().Split(new[] { ';' }, StringSplitOptions.None))
                            .Select(value => value.Trim())
                            .ToHashSet();
                    }
                    else if (column.HeaderText == "CommunityStarRating")
                    {
                        var ratingBuckets = new Dictionary<string, (float Min, float Max)>
                        {
                            { "0-1", (0f, 1f) },
                            { "1-2", (1f, 2f) },
                            { "2-3", (2f, 3f) },
                            { "3-4", (3f, 4f) },
                            { "4-5", (4f, 5f) }
                        };

                        var ratings = dgv.Rows.Cast<DataGridViewRow>()
                            .Select(row => row.Cells[column.Index].Value?.ToString())
                            .Where(value => float.TryParse(value, out _))
                            .Select(value => float.Parse(value))
                            .ToList();
                        if (uniqueValues != null && uniqueValues.Any()) uniqueValues.Clear();
                        foreach (var bucket in ratingBuckets)
                        {
                            if (ratings.Any(rating => rating >= bucket.Value.Min && rating < bucket.Value.Max))
                            {
                                uniqueValues.Add(bucket.Key);
                            }
                        }
                    }
                    else
                    {
                        uniqueValues = dgv.Rows.Cast<DataGridViewRow>()
                            .Select(row => row.Cells[column.Index].Value?.ToString())
                            .Select(value => value?.Trim())
                            .ToHashSet();

                        // Add empty value explicitly if it exists
                        if (dgv.Rows.Cast<DataGridViewRow>().Any(row => string.IsNullOrEmpty(row.Cells[column.Index].Value?.ToString())))
                        {
                            uniqueValues.Add(string.Empty);
                        }

                    }

                    checkedItems = new List<(string Item, bool IsChecked)>();
                    foreach (var value in uniqueValues)
                    {
                        clbFilterOptions.Items.Add(value, true);
                        checkedItems.Add((value, true));
                    }
                    var key = (dgv.Name, column.HeaderText);
                    ColumnCheckedItems[key] = checkedItems;
                }
            }
        }
    }
}