# MonolithDKPBidHistory
A searchable web interface for bid history from MonolithDKP.

## Description

This application is a companion to the MonolithDKP mod for World of Warcraft Classic.  It reads MonolithDKP.lua from your WoW Classic data directory to create a web interface similar to the Loot History tab within MonolithDKP.

![Screenshot](https://i.imgur.com/Qdi0cMD.png)

Additional features include automated backups of the MonolithDKP.lua file and the ability to mirror your DKP data to a cloud server (which you must run yourself).

## Installation

Get a release from [the project's releases tab](https://github.com/bp2008/MonolithDKPBidHistory/releases).

### On Windows

This will require some computer literacy.  To install, simply extract the application to a directory of your choosing (using 7zip), and run `MonolithDKPBidHistory.exe`.

This Service Manager will open:

![Service Manager](https://i.imgur.com/7Jbxrs5.png)

Here, you can install, uninstall, start, and stop the service.  A configuration GUI is also provided.

![Configuration GUI](https://i.imgur.com/pGzqpgv.png)

For basic functionality, enable the web server, choose a port (80 is default for HTTP), and enter the path to your `MonolithDKP.lua` file.

To find `MonolithDKP.lua`, look here: `World of Warcraft\_classic_\WTF\Account\YOUR_ACCOUNT\SavedVariables\MonolithDKP.lua`

If you intend for others to access your web server, you will need to open its port in Windows Firewall.  You will also need to set up the internet routing via a port forwarding rule in your router, or by a private VPN service such as Hamachi.

### On Linux

Advanced users may wish to run the web server in the cloud.  A minimal linux virtual machine is all that is required.  This is a .NET Framework application, so to run it you should install `mono-complete`.  Then you can run the application via `mono /path/to/MonolithDKPBidHistory.exe`.  This will give you a little bit of console output which further instructs on where the data directory is and how to run the application as a command-line app.  It is up to you to deal with automatic start/stop; I can only point you at [supervisor](http://supervisord.org/running.html).

This app's built-in Service Manager and configuration GUI are unavailable on linux, but you can do most of the configuration on a Windows machine and copy the configuration file out of the service's data directory.

You will of course need to transfer MonolithDKP.lua from your WoW machine to the linux box.  This app can handle that for you via its built-in uploading functionality (see screenshot above for a bit of guidance on how to configure it).

* Note: The app currently does not support multiple instances on one machine due to the data directory being at a shared path.

## Building from Source

This solution was built with Visual Studio 2019 Community Edition. To build, you will also need my general-purpose utility project, [BPUtil](https://github.com/bp2008/BPUtil). Due to path issues, you may need to remove and re-add the BPUtil project from the solution. BPUtil is updated separately from this project, and may not be compatible at all times.
