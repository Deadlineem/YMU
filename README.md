# YimMenu Updater

YimMenu Updater is an All-in-One Updater/Downloader for YimMenu, designed to simplify various tasks in one easy-to-use application. With YimMenu Updater (YMU), you can effortlessly download YimMenu, Lua Scripts, and Addons, as well as manage them efficiently.

## Screenshots
You can view screenshots for YMU on this topic, since there are so many screenshots, its neatly contained here rather than mucking up the readme :)

https://github.com/Deadlineem/YMU/discussions/6

# Download

To download YimMenu Updater, visit https://github.com/Deadlineem/YMU/releases and download both YMU.exe and dllinject.exe, put them in a folder together on your desktop and run YMU.exe
(YMU.exe ONLY depends on dllinject for injecting into game processes, it does not need it for anything else.)

NOTE: YMU.exe wont detect djjinject.exe if they are not moved to your desktop and they are left in the downloads folder, no idea why and do not intend to add extra permissions to get it to work.

## Features

### YimMenu
- Download YimMenu
- Uninstall YimMenu
- Delete YimMenu Cache
- How to Use Guide

### Lua Scripts
- Automatically Generated buttons from the YimMenu-Lua Repository
- 1-Click installer for your favorite Lua Scripts

### Addons
- Install Animations
- Install XML Maps & Vehicles
- Install YimASI
- Install Json Vehicles
- Install Outfits

### HorseMenu
- Download HorseMenu

### Tools
- Process Name (GTA5, RDR2, Minecraft.Windows, etc.)
- Launch Game -> Launches the chosen process
- Select/Inject DLL


# How To Compile
This program was built using the latest .NET Runtime (8.0) in Visual Studio.  To compile, follow the below instructions:

Download the Source, open the .sln with Visual Studio
Open the YimMenu Updater solution in the Solution Explorer on the right and right click it
Click 'Publish' and hit the Publish Button then click Open Folder when its finished

You should have 2 .exe's -- YimMenu Updater & dllinject.exe

# FAQ

- Q:  I am having trouble installing addons through YimMenu Updater.
- A:  Make sure you have Administrator privileges on your account that is logged into windows.  It requires this to place files in %APPDATA%\YimMenu\scripts, IF you do not have admin, use the [Update.bat](https://github.com/Deadlineem/Extras-Addon-for-YimMenu/blob/main/update.bat)

- Q: Do i have to download dllinject?
- A: ONLY if you plan to use the injector in Tools, if not, no.

- Q: Can I install all of this stuff manually?
- A: YES!  Everything can be downloaded from YimMenu's official repositories and installed manually if you choose to.  You can view a detailed guide at [YimMenu Updater Guide - Discussions](https://github.com/Deadlineem/YMU/discussions/9)



IF you do not have the dllinject.exe, visit https://github.com/nefarius/Injector and download the release,
then rename it to dllinject.exe and put it in the same location as YMU.exe
