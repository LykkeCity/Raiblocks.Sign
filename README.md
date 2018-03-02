# Raiblocks.Sign


This is a Sign Service for Raiblocks (NANO).

# Prerequisites

- [ASP.NET Core 2](https://docs.microsoft.com/en-us/aspnet/core/getting-started)

# Running
 
Getting the repository:
```
git clone -b dev https://github.com/LykkeCity/Raiblocks.Sign.git 
cd ./Raiblocks.Sign
git submodule init
git submodule update
```

Running:
```
cd ./Lykke.Service.Raiblocks.Sign/src/Lykke.Service.RaiblocksSign
dotnet restore
dotnet run
```
Go to [http://localhost:5000/swagger/ui/#/](http://localhost:5000/swagger/ui/#/)


# Implementation of methods of work with signature and key pairs

To create SignService the original source code of RaiBlocks node is used which is compliled into libsign_service.dll. A SignService source code contains this compiled library as well as the facade that implemented required public methods.
The facade contains two functions block_create_c and key_create that described in sign_service.cpp file. It is a lightweight implementation of RPC-methods block_create and key_create respectively. The method block_create_c don’t perform calculation of parameter “work” and expected the parameter “work” already contains in transaction parameters.

[libsign_service.dll source code](https://github.com/artem-kruglov/raiblocks/tree/sign_service)  


# Updating the code base of libsign_service.dll

To update a base code is needed merge changes to sign_service branch and build. If you are maintaining compatibility in the interface with working with blocks, no additional changes in the code are required. Then you should replace the resulting dynamic library libsign_service in a SignService instance.
Note: a library, building for Linux, have a .SO extension, but the libsign_service is imported with .dll extension for universality:
[DllImport("libsign_service.dll")]

To build libsign_service.dll follow [Build Instructions](https://github.com/nanocurrency/raiblocks/wiki/Build-Instructions). Note, you should 
```
make sign_service 
```
instead of 
```
make rai_node
```