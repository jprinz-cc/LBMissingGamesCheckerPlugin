![mgc-header](https://github.com/user-attachments/assets/35368a7d-52d0-4ac3-bb6f-22a21294a6a5)

## Overview

Missing Games Checker (MGC) is a powerful LaunchBox plugin designed to help collectors instantly identify missing games from their platform libraries based on official LaunchBox metadata. Compare your local collection against the LaunchBox database, track completion percentages, filter regional variants, and export missing titles directly into LaunchBox Wishlists!

![Version](https://img.shields.io/github/v/release/jprinz-cc/LBMissingGamesCheckerPlugin?include_prereleases)
![Commit-Activity](https://img.shields.io/github/commit-activity/t/jprinz-cc/LBMissingGamesCheckerPlugin)
![License](https://img.shields.io/github/license/jprinz-cc/LBMissingGamesCheckerPlugin)

---
![announcing](https://github.com/user-attachments/assets/244300db-4430-4333-866d-3fd4568a0c40)
### NEW in v2.1!
* **Dedicated "Wishlists" Category Nesting: When exporting missing games to LaunchBox, MGC can now seamlessly create a custom Wishlists root category in your sidebar—complete with an auto-installed Wishlists.png Clear Logo icon.
* **Dynamic Hardware vs. Wishlist Categorization: Toggle between nesting wishlist platforms under the new Wishlists category or keeping them inside their default hardware categories (Consoles, Handhelds, etc.). Moving * **platforms back and forth carries all scraped metadata and box art automatically without duplicates!
* **Enhanced Right-Click Context Menu: Added "📋 Copy Title to Clipboard" alongside existing title/platform export tools for ultra-quick search workflows.
* **One-Click Search Clear: A sleek, interactive 'X' button now appears beside search boxes whenever text is typed, allowing you to reset your search filter instantly.
* **Title Columns Locked: The 'Title' columns are now locked in place while scrolling across the table details.
* **Improved UI & Stats Layout: Moved Platform Completion Statistics directly above the Owned Games grid for immediate visual feedback.

---
### CORE FEATURES AT A GLANCE
* **Powered by LaunchBox SQLite: Built on LaunchBox’s modern SQLite database for sub-second load times, instant processing, and a ultra-lightweight ~1.3MB footprint.
* **Platform Completion Statistics: Color-coded completion metrics give you immediate percentage feedback ($80\%+$ Green, $30\%-79\%$ Yellow, $<30\%$ Red) on your library progress.
* **Export Wishlist Platforms Directly to LaunchBox: Generate shadow platforms filled with placeholder games for missing titles. Download box art, banners, and media in LaunchBox for games you don't even own yet!
* **Regional & Released Filters: Strict-filter missing games by region (North America, Europe, Japan) or toggle the safety-net checkbox to capture titles with missing region data.
* **Interactive Grid Search & Column Filters: Real-time global search, column header sorting, multi-value field filtering (Genres, Region, Developers), and frozen title columns for easy horizontal scrolling.
* **Collector Clipboard & eBay Search Integration: Right-click any missing game to quickly copy formatting, spreadsheet-ready tabbed data, or launch an instant eBay search query in your browser.
* **Clickable Media Links: Direct links to YouTube gameplay videos, Wikipedia articles, and LaunchBox Games Database entries right inside grid cells.
* **CSV Exporting: Export owned or missing game tables to standard CSV format for offline library management.

---
## Instructions for Using the Missing Games Checker (MGC) v2.1
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
   - Launch LaunchBox, then access the **Tools** menu and find **Missing Games Checker(v2.1)**.

3. **Using the Plugin**
   - Select a platform from the dropdown menu and click **Check It!**.
   - MGC will instantly display a list of games you own and a list of games missing from your collection based on the LaunchBox metadata.
   - You can export the lists to a CSV file, or use the Missing Games export button to generate a LaunchBox Wishlist Platform!

Missing Games Checker v2.1 Screenshot:
![MissingGameChecker](https://github.com/user-attachments/assets/359c284d-a358-48d7-bdb2-13f8107adabf)


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
