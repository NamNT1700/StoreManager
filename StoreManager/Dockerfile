#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StoreManager/StoreManager.csproj", "StoreManager/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Store/Store.csproj", "Store/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "StoreManager/StoreManager.csproj"
COPY . .
WORKDIR "/src/StoreManager"
RUN dotnet build "StoreManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreManager.dll"]
