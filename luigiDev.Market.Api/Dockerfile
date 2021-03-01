#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["luigiDev.Market.Api/luigiDev.Market.Api.csproj", "luigiDev.Market.Api/"]
COPY ["luiguiDev.Market.Business/luiguiDev.Market.Business.csproj", "luiguiDev.Market.Business/"]
COPY ["luigiDev.Market.Entities/luigiDev.Market.Entities.csproj", "luigiDev.Market.Entities/"]
COPY ["luigiDev.Market.DataAccess/luigiDev.Market.DataAccess.csproj", "luigiDev.Market.DataAccess/"]
RUN dotnet restore "luigiDev.Market.Api/luigiDev.Market.Api.csproj"
COPY . .
WORKDIR "/src/luigiDev.Market.Api"
RUN dotnet build "luigiDev.Market.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "luigiDev.Market.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "luigiDev.Market.Api.dll"]
