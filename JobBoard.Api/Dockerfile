FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8000
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["JobBoard.Api.csproj", "./"]
RUN dotnet restore "JobBoard.Api.csproj"
COPY . .
RUN dotnet build "JobBoard.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "JobBoard.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "JobBoard.Api.dll" ]