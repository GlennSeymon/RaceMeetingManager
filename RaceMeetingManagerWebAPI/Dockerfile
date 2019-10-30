FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["RaceMeetingManagerWebAPI/RaceMeetingManagerWebAPI.csproj", "RaceMeetingManagerWebAPI/"]
RUN dotnet restore "RaceMeetingManagerWebAPI/RaceMeetingManagerWebAPI.csproj"
COPY . .
WORKDIR "/src/RaceMeetingManagerWebAPI"
RUN dotnet build "RaceMeetingManagerWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RaceMeetingManagerWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RaceMeetingManagerWebAPI.dll"]