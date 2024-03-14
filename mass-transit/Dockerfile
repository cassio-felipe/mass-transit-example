FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mass-transit/mass-transit.csproj", "mass-transit/"]
RUN dotnet restore "mass-transit/mass-transit.csproj"
COPY . .
WORKDIR "/src/mass-transit"
RUN dotnet build "mass-transit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mass-transit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mass-transit.dll"]
