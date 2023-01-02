# Migration Creation
# Useful EFCore DB Command

Below are a list of of useful commands that can be used to support the extending and management of a DB when using EFCore as a context.

## Create Migration

cmd is `dotnet-ef migrations add <ModelName> --startup-project ..\Bibs.API\Bibs.API.csproj --context AppDbContext`
cmd is `dotnet ef migrations add <ModelName> --startup-project ../Bibs.API/Bibs.API.csproj --context AppDbContext`

## Update to revert Migration

To revert previous migration from db cmd is `dotnet-ef database update <Previous migration name> --startup-project ..\Bibs.API\Bibs.API.csproj --context AppDbContext -v`

## Remove Migration

To remove previous migration cmd is `dotnet-ef migrations remove --startup-project ..\Bibs.API\Bibs.API.csproj --context AppDbContext`