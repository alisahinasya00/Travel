#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Travel/TravelApi.csproj", "Travel/"]
COPY ["Travel.Business/Travel.Business.csproj", "Travel.Business/"]
COPY ["Travel.DataAccess/Travel.DataAccess.csproj", "Travel.DataAccess/"]
COPY ["Travel.Entities/Travel.Entities.csproj", "Travel.Entities/"]
RUN dotnet restore "Travel/TravelApi.csproj"
COPY . .
WORKDIR "/src/Travel"
RUN dotnet build "TravelApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelApi.dll"]