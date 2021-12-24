FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutoNews/AutoNews.csproj", "AutoNews/"]
RUN dotnet restore "AutoNews/AutoNews.csproj"
COPY . .
WORKDIR "/src/AutoNews"
RUN dotnet build "AutoNews.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoNews.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoNews.dll"]
