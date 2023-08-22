FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
EXPOSE 80
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CustomerBase.API/CustomerBase.API.csproj", "CustomerBase.API/"]
RUN dotnet restore "CustomerBase.API/CustomerBase.API.csproj"
COPY . .
WORKDIR "/src/CustomerBase.API"
RUN dotnet build "CustomerBase.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerBase.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerBase.API.dll"]