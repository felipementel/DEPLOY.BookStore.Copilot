#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DEPLOY.BookStore.Api/DEPLOY.BookStore.Api.csproj", "DEPLOY.BookStore.Api/"]
COPY ["DEPLOY.BookStore.Application/DEPLOY.BookStore.Application.csproj", "DEPLOY.BookStore.Application/"]
COPY ["DEPLOY.BookStore.Domain/DEPLOY.BookStore.Domain.csproj", "DEPLOY.BookStore.Domain/"]
COPY ["DEPLOY.BookStore.Infra.CrossCutting/DEPLOY.BookStore.Infra.CrossCutting.csproj", "DEPLOY.BookStore.Infra.CrossCutting/"]
COPY ["DEPLOY.BookStore.Infra.Database/DEPLOY.BookStore.Infra.Database.csproj", "DEPLOY.BookStore.Infra.Database/"]
RUN dotnet restore "./DEPLOY.BookStore.Api/DEPLOY.BookStore.Api.csproj"
COPY . .
WORKDIR "/src/DEPLOY.BookStore.Api"
RUN dotnet build "./DEPLOY.BookStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DEPLOY.BookStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DEPLOY.BookStore.Api.dll"]