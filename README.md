# CommunityDKPBidHistory
A searchable web interface for bid history with data sourced from CommunityDKP.

## Description

This application is a companion to the CommunityDKP mod for World of Warcraft Classic.  It reads CommunityDKP.lua from your WoW Classic data directory to create a web interface similar to the Loot History tab within CommunityDKP.

![Screenshot](https://i.imgur.com/Qdi0cMD.png)

An additional feature provided by this app is automated backups of the CommunityDKP.lua file (which contains all your dkp history and configuration).

## Installation

Get a release from [the project's releases tab](https://github.com/bp2008/CommunityDKPBidHistory/releases).

This will require some computer literacy.  To install, simply extract the application to a directory of your choosing (using 7zip), and run `CommunityDKPBidHistory.exe`.

This Service Manager will open:

![Service Manager](https://i.imgur.com/7Jbxrs5.png)

Here, you can install, uninstall, start, and stop the service.  A configuration GUI is also provided.

Since version 2.0, this app is designed to be run either as a web server **or** as a client service which uploads data to a web server and/or makes automated backups of the dkp data file.  At this time, it is not a supported configuration to run the web server and the client service on the same machine.

### Client Configuration

To configure the app as a client, just disable the web server option.

You will need to tell the app where to find `CommunityDKP.lua`.  Typically this is in `World of Warcraft\_classic_\WTF\Account\YOUR_ACCOUNT\SavedVariables\CommunityDKP.lua`

For the app to be useful, you need to enable uploading or local backups (or both).  The following screenshot is an example configuration:

![Client Configuration GUI](https://i.imgur.com/49lB2EU.png)

Don't worry about a 1 minute interval being too fast; the upload and backup tasks only occur once upon service startup and then whenever the file changes, so it doesn't waste too much space or bandwidth.

### Server Configuration

To configure as a web server, enable the web server option and choose a port (80 is default for HTTP). You can leave the path path to your `CommunityDKP.lua` file blank.  Set a server password, and enable the option to accept uploads from remote clients.

![Server Configuration GUI](https://i.imgur.com/Mbl29hz.png)

If you intend for others to access your web server, you will need to open its port in Windows Firewall.  You will also need to set up the internet routing via a port forwarding rule in your router, or by a private VPN service such as Hamachi.

Set the same server password in your configuration for the web server and for the client app -- this password is used only to authenticate clients attempting to use the DKP uploading interface.

Loot history and player names/classes are remembered in a file `History.json` which will be located in the same folder as the program executable.

### Serving On Linux

Advanced users may wish to run the web server in the cloud.  A minimal linux virtual machine is all that is required.  This is a .NET Framework application, so to run it you should install `mono-complete`.  Then you can run the application via

```
mono /path/to/CommunityDKPBidHistory.exe
```

This will give you a little bit of console output which further instructs on where the data directory is and how to run the application as a command-line app.  It is up to you to deal with automatic start/stop; I can only point you at [supervisor](http://supervisord.org/running.html).

This app's built-in Service Manager and configuration GUI are unavailable on linux, but you can do most of the configuration on a Windows machine and copy the configuration file out of the service's data directory.

If you want HTTPS, I recommend using nginx and certbot.

## Building from Source

This solution was built with Visual Studio 2019 Community Edition. To build, you will also need my general-purpose utility project, [BPUtil](https://github.com/bp2008/BPUtil). Due to path issues, you may need to remove and re-add the BPUtil project from the solution. BPUtil is updated separately from this project, and may not be compatible at all times.
