FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OtoServisSatis.WebUI/OtoServisSatis.WebUI.csproj", "OtoServisSatis.WebUI/"]
RUN dotnet restore "OtoServisSatis.WebUI/OtoServisSatis.WebUI.csproj"
COPY . .
WORKDIR "/src/OtoServisSatis.WebUI"
RUN dotnet build "OtoServisSatis.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OtoServisSatis.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OtoServisSatis.WebUI.dll"]
