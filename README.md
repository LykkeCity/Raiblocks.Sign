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
export SettingsUrl=appsettings.json
cd ./Lykke.Service.Raiblocks.Sign/src/Lykke.Service.RaiblocksSign
dotnet restore
dotnet run
```
Go to [http://localhost:5000/swagger/ui/#/](http://localhost:5000/swagger/ui/#/)

# Implementation

The SignService is the REST API for [libsign_service library](https://github.com/LykkeCity/Raiblocks.SignFacade). The libsign_service.so is an implementation of methods of work with signature and key pairs, which contains the full source code of RaiBlocks node as well as the facade that implements required for SignService methods. The facade contains two functions: block_create_c and key_create which are described in [sign_service.cpp](https://github.com/LykkeCity/Raiblocks.SignFacade) file. This functions are lightweight implementation of RPC-methods block_create and key_create respectively. The method block_create_c doesn’t perform calculation of a “work” argument and expects it to be among unsigned transaction fields.


# Updating the code base of libsign_service

To update a base code you should rebuild library after pulling latest raiblock changes. If there are no breaking changes in work with blocks in upstream, no additional changes of the the source code are required. Otherwise you'll have to change facade methods. After that you should replace the resulting dynamic library libsign_service in a SignService instance.
```
[DllImport("libsign_service")]
```
have automatically loads libsign_service with extension according to current runtime enviroment, but it's stil need to provide valid image format (compile libsign_service with Windows toolchain for Windows runtime, or compile libsign_service with Linux toolchain for Linux runtime).

To build libsign_service:
Update all submodules:
```
git submodule update --init --recursive
```

Patch raiblocks cmake file:
```
chmod a+x cmake_patch.sh && ./cmake_patch.sh
```

Then follow [Build Instructions](https://github.com/nanocurrency/raiblocks/wiki/Build-Instructions), to build raiblocks submodule, but you should call
```
make sign_service 
```
instead of 
```
make rai_node
```

Compiled libsign_service.so must be placed to output directory of Lykke.Service.RaiblocksSign.

# See also
 - [RaiBlocks Integration API Service](https://github.com/LykkeCity/Raiblocks.Api)

 - [Test private RaiBlocks node with a custom generis block](https://github.com/artem-kruglov/raiblocks/tree/testnet)
