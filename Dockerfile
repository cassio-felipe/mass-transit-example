FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mass-transit-example.csproj", "./"]
RUN dotnet restore "mass-transit-example.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "mass-transit-example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mass-transit-example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mass-transit-example.dll"]
