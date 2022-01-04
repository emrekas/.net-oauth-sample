#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AuthAPI/AuthAPI.csproj", "AuthAPI/"]
RUN dotnet restore "AuthAPI/AuthAPI.csproj"
COPY . .
WORKDIR "/src/AuthAPI"
RUN dotnet build "AuthAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthAPI.dll"]