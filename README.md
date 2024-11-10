

## Install Dotnet
### Alpine 
Find the latest supported sdk version and add it.  
```
doas apk add dotnet8-sdk
```

If it does not install, you may need to search the [Alpine releases](https://pkgs.alpinelinux.org/packages?name=dotnet*&branch=v3.17&repo=&arch=x86_64&origin=&flagged=&maintainer=) for the available dotnet versions of the etc/apk/repositories main and community repos.   For example, this WSL Alpine is 3.17, which means:  
```
doas apk add dotnet7-sdk
```

### Python


## Console
### Dotnet
Create the app.  
```
mkdir apricot
cd apricot
dotnet new console --framework net7.0
```

