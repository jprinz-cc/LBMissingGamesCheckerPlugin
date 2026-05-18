![mgc-header](https://github.com/user-attachments/assets/fe33a7bd-86a4-43c0-a5a9-bb92de84e50a)
## Overview

Missing Games Checker (MGC) is a LaunchBox plugin designed to help users identify missing games in their collection based on platform metadata. It provides an easy-to-use interface that lets you view owned and missing games, and export the results.

![Version](https://img.shields.io/github/v/release/jprinz-cc/LBMissingGamesCheckerPlugin?include_prereleases)
![Commit-Activity](https://img.shields.io/github/commit-activity/t/jprinz-cc/LBMissingGamesCheckerPlugin)
![License](https://img.shields.io/github/license/jprinz-cc/LBMissingGamesCheckerPlugin)

---
![announcing](https://github.com/user-attachments/assets/244300db-4430-4333-866d-3fd4568a0c40)  
**VERSION 2.0 IS HERE! The SQLite & Quality-of-Life Update!** 
MGC has been completely rebuilt from the ground up to utilize LaunchBox's modern SQLite database. Gone are the heavy XML parsers and loading bars. V2.0 brings instant load times, a highly optimized 1.3MB footprint, and powerful new collector tools!

### What's New in Version 2.0
* **Lightning Fast SQLite Integration:** Queries that used to take seconds now take milliseconds. Instant filtering and zero UI lockups.
* **Automated "Shadow Platform" Wishlists:** You can now export your missing games directly into LaunchBox! MGC automatically creates an isolated "[Platform] Wishlists" category in your sidebar, populated with your missing games. 
* **Native 3D Box Art Scraping:** Wishlist platforms automatically inherit the `Scrape As` property of the parent console, allowing you to instantly download 3D Box Art and Clear Logos for games you don't even own yet!
* **"Purist" Regional Filtering:** Only collect North American or European releases? Use the new Region Filter to hide global releases you don't care about. Includes a safety net to include/exclude games with missing region metadata. Also included is a new Select All/None option in the column filtering.
* **Right-Click Quick Actions:** Right-click any missing game in the grid to instantly search eBay for physical copies or copy the title to your clipboard.
---
## Instructions for Using the Missing Games Checker (MGC) v2.0
### Requirements
1. LaunchBox **v13.19 or higher**. *(v13.18 and lower should use MGC v1.2)*
2. Games in LaunchBox
3. The `LBMissingGamesCheckerPlugin.dll` file

### Installation and Usage
1. **Install the Plugin**
   - Download the latest 2.0 release of the MGC plugin from this repository.
   - Make sure LaunchBox is closed.
   - Place the `LBMissingGamesCheckerPlugin.dll` file into the **LaunchBox\Plugins** folder.
      - *Or if you have a folder already for the MGC plugin, replace the one that is there with the new version.*

2. **Access the Plugin**
   - Launch LaunchBox, then access the **Tools** menu and find **Missing Games Checker(v2.0)**.

3. **Using the Plugin**
   - Select a platform from the dropdown menu and click **Check It!**.
   - MGC will instantly display a list of games you own and a list of games missing from your collection based on the LaunchBox metadata.
   - You can export the lists to a CSV file, or use the Missing Games export button to generate a LaunchBox Wishlist Platform!

### New Features!
4. **Filtering & Options**
   - **Export Missing Games to LaunchBox:** Use the new Export feature for the Missing Games list to *safely* save a new "[Platform] Wishlists" category in your sidebar. From here you can download metadata and media for games you don't even have yet! Delete the platform direct from LaunchBox or override it with a new Wishlist based on filters!
   - **Regional Filtering:** Use the Region dropdown to strict-filter missing games (e.g., North America only). Toggle the "Include games with unknown regions" checkbox to catch database entries lacking region data.
   - **Quick Column Filtering:** Quickly sort through large columns of data with the Select All/None option in the column filtering options panel.
   - **Platform Completion Status:** See how many games you have/don't have at a glance with colour coded feedback that calculates the percentage of your missing titles.
   - **Real-time Search:** Use the search boxes above the grids to instantly filter the view.
   - **New Right-Click Menu:** Right-click on any missing game and find options to copy the games title/platform data to the clipboard or do an instant search on eBay for that missing game to add to your collection!!

6. **Additional Features from v1.2**
   - Filter games by **Released** status if you only want to check released titles.
   - Sort columns by clicking on the column header.
   - Export your Owned and Missing game lists to CSV.
   - Filter select columns by clicking on the filter icon in the column header.
      - If the filtered column has multiple values (ie. North America, Japan) the row will still show if any of the filters are not applied. All values need to be unchecked in the filter to hide the row.
   - Window resizing (Right edge only)
   - Click on links in the games lists for additional info, such as video URLs, Wikipedia links, and links to the [LaunchBox DB](https://gamesdb.launchbox-app.com/) website.
   - **Leo will give you a CHEERS🥂 with a PERFECT COLLECTION!**

Missing Games Checker v2.0 Screenshot:
![MissingGameChecker](https://github.com/user-attachments/assets/5aa266e1-7776-4a34-886f-f749c7c44efc)


---

## Getting Started: Setting Up a LaunchBox Plugin Project

For those looking to get into LaunchBox plugin development, here is how you can set up a modern plugin project:

1. **Create a Class Library Project**
   - Start by creating a new **Class Library** project in Visual Studio *(Make sure to choose the one with the C# logo, NOT the one labeled ".NET Framework")*.
   - Choose **.NET 8.0** (Long Term Support) or **.NET 9.0** as your target framework.

2. **Add References**
   - Add a reference to the `Unbroken.LaunchBox.Plugins.dll` file, which is located in the **LaunchBox\Core** folder. This is the main assembly that contains the API for LaunchBox plugins.
   - *Note on UI Elements:* If you are building UI elements, it is highly recommended to change your Target Framework Moniker (TFM) in your project file to `net8.0-windows` (or `net9.0-windows`) to natively access Windows Forms or WPF libraries without needing external NuGet packages like `System.Drawing.Common`.

3. **Implement the Interface**
   - Create a new class file and implement the appropriate interface for your project. For example, if you're building a plugin that adds a system menu item, use the `ISystemMenuItemPlugin` interface.
   - You can browse the [LaunchBox Plugin API documentation](https://pluginapi.launchbox-app.com/) to see which interfaces best suit your plugin's needs.

4. **Build and Test**
   - After implementing the interface methods, you can start coding your plugin.
   - To test your plugin, build the project, and place the resulting `.dll` file into the **LaunchBox\Plugins** folder. LaunchBox will automatically load your plugin on the next startup.

For a quick visual overview of plugin development, check out this [video guide by Jason](https://youtu.be/U2bFY_c8iGA).

---

## Special Thanks

A huge thanks to the LaunchBox team and their [API documentation](https://pluginapi.launchbox-app.com/) for making this project possible, as well as Jason's helpful video tutorial.
