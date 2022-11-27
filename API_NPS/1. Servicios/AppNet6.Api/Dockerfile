#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["1. Servicios/AppNet6.Api/AppNet6.Api.csproj", "1. Servicios/AppNet6.Api/"]
RUN dotnet restore "1. Servicios/AppNet6.Api/AppNet6.Api.csproj"
COPY . .
WORKDIR "/src/1. Servicios/AppNet6.Api"
RUN dotnet build "AppNet6.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppNet6.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppNet6.Api.dll"]