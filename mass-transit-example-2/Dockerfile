FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mass-transit-example-2/mass-transit-example-2.csproj", "mass-transit-example-2/"]
RUN dotnet restore "mass-transit-example-2/mass-transit-example-2.csproj"
COPY . .
WORKDIR "/src/mass-transit-example-2"
RUN dotnet build "mass-transit-example-2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mass-transit-example-2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mass-transit-example-2.dll"]
