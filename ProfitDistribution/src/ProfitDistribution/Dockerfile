# generate base image to mount container on top
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

# build image to container structure using sdk ASP.NET Core 3.1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ProfitDistribution/ProfitDistribution.csproj ProfitDistribution/
RUN dotnet restore "ProfitDistribution/ProfitDistribution.csproj"
COPY . .
WORKDIR "/src/ProfitDistribution"
RUN dotnet build "ProfitDistribution.csproj" -c Release -o /app/build

# publish app to /app/publish in order to segregate runtime env
FROM build AS publish
RUN dotnet publish "ProfitDistribution.csproj" -c Release -o /app/publish

# setup application startup
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ProfitDistribution.dll"]