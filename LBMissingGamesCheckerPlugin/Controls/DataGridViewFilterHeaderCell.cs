namespace LBMissingGamesCheckerPlugin.Controls
{
    public class DataGridViewFilterHeaderCell : DataGridViewColumnHeaderCell
    {
        private readonly Image filterIcon = Properties.Resources.filter;
        private readonly DataGridView ownedGamesGridView;
        private readonly DataGridView missingGamesGridView;
        private readonly CheckedListBox clbFilterOptions;
        private readonly GroupBox gbFilterOptions;
        private readonly PlatformSelectionForm form;

        public DataGridViewFilterHeaderCell(DataGridViewColumnHeaderCell oldHeaderCell, DataGridView ownedGamesGridView, DataGridView missingGamesGridView, CheckedListBox clbFilterOptions, GroupBox gbFilterOptions, PlatformSelectionForm form)
            : base()
        {
            this.Value = oldHeaderCell.Value;
            this.ownedGamesGridView = ownedGamesGridView;
            this.missingGamesGridView = missingGamesGridView;
            this.clbFilterOptions = clbFilterOptions;
            this.gbFilterOptions = gbFilterOptions;
            this.form = form;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            int iconHeight = cellBounds.Height - 4;
            int iconWidth = (filterIcon.Width * iconHeight) / filterIcon.Height;
            int iconX = cellBounds.Right - iconWidth - 5;
            int iconY = cellBounds.Y + (cellBounds.Height - iconHeight) / 2;
            graphics.DrawImage(filterIcon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.X >= this.Size.Width - filterIcon.Width - 5)
            {
                Point screenPosition = Cursor.Position;
                var gridView = this.DataGridView;
                Point clientPosition = gridView.PointToClient(screenPosition);
                clientPosition.X += (gbFilterOptions.Width - 20);
                clientPosition.Y = gridView.Location.Y + 20;
                ShowFilterOptions(this.OwningColumn, clientPosition);
            }
        }

        public bool IsIconClicked(int x)
        {
            int iconWidth = (filterIcon.Width * this.Size.Height) / filterIcon.Height;
            int iconX = this.Size.Width - iconWidth - 5;
            return x >= iconX && x <= iconX + iconWidth;
        }

        private void ShowFilterOptions(DataGridViewColumn column, Point clickPosition)
        {
            clbFilterOptions.Items.Clear();

            // Set the form properties for the current view and column
            form.CurrentGridView = this.DataGridView;
            form.CurrentColumn = column;

            var key = (form.CurrentGridView.Name, form.CurrentColumn.HeaderText);
            if (form.ColumnCheckedItems.ContainsKey(key))
            {
                var checkedItems = form.ColumnCheckedItems[key];
                foreach (var (item, isChecked) in checkedItems)
                {
                    clbFilterOptions.Items.Add(item, isChecked);
                }
            }

            gbFilterOptions.Location = new Point(clickPosition.X, clickPosition.Y);
            gbFilterOptions.Visible = true;

            form.UpdateSelectAllState();
        }
    }
}
