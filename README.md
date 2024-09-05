# Missing Games Checker (MGC) Plugin for LaunchBox

## Overview

Missing Games Checker (MGC) is a LaunchBox plugin designed to help users identify missing games in their collection based on platform metadata. It provides an easy-to-use interface that lets you view owned and missing games, and export the results.

---

## Instructions for Using the Missing Games Checker (MGC)

1. **Install the Plugin**
   - Download the latest release of the MGC plugin from this repository.
   - Place the `LBMissingGamesCheckerPlugin.dll` file into the **LaunchBox\Plugins** folder.

2. **Access the Plugin**
   - Launch LaunchBox, then access the **Tools** menu and find **Missing Games Checker**.

3. **Using the Plugin**
   - Select a platform from the dropdown menu and click the **Confirm Selection** button.
   - MGC will display a list of games owned and a list of games missing from your collection based on the LaunchBox metadata.
   - You can export the list of missing games to a CSV file for easy reference.

4. **Options**
   - Filter games by **Released** status if you only want to check released titles.
   - Click on game titles for additional info, such as video URLs, Wikipedia links, and links to the [LaunchBox DB](https://gamesdb.launchbox-app.com/) website.

---

## Getting Started: Setting Up a LaunchBox Plugin Project

For those looking to get into LaunchBox plugin development, this is how I got started.
Follow these steps to set up a LaunchBox plugin project:

1. **Create a Class Library Project**
   - Start by creating a new **Class Library (.NET Framework)** project in Visual Studio.
   - Choose **.NET Framework 4.8** and create the project.

2. **Add References**
   - Add a reference to the `Unbroken.LaunchBox.Plugins.dll` file, which is located in the **LaunchBox\Core** folder. This is the main assembly that contains the API for LaunchBox plugins.
   - You'll also need to install **System.Drawing.Common** via NuGet. Make sure to use **version 7.0.0**, as later versions might cause compatibility issues with .NET Framework projects.

3. **Implement the Interface**
   - Create a new class file and implement the appropriate interface for your project. For example, if you're building a plugin that adds a system menu item, use the `ISystemMenuItemPlugin` interface.
   - `System.Drawing.Image IconImage` will also need a Reference to **System.Drawing v4.0.0** which you can add from the Interface fix suggestion.
   - You can browse the [LaunchBox Plugin API documentation](https://pluginapi.launchbox-app.com/) to see which interfaces best suit your plugin's needs.

4. **Build and Test**
   - After implementing the interface methods, you can start coding your plugin.
   - To test your plugin, build the project, and place the resulting `.dll` file into the **LaunchBox\Plugins** folder. LaunchBox will automatically load your plugin on the next startup.

For a quick tutorial on getting started with plugin development, check out this [video guide by Jason](https://youtu.be/U2bFY_c8iGA).

---

## Special Thanks

A huge thanks to the LaunchBox team and their [API documentation](https://pluginapi.launchbox-app.com/) for making this project possible, as well as Jason's helpful video tutorial.

***

![License](https://img.shields.io/github/license/jprinz-cc/LBMissingGamesCheckerPlugin)
![Version](https://img.shields.io/github/v/release/jprinz-cc/LBMissingGamesCheckerPlugin?include_prereleases)
![Commit-Activity](https://img.shields.io/github/commit-activity/t/jprinz-cc/LBMissingGamesCheckerPlugin)
