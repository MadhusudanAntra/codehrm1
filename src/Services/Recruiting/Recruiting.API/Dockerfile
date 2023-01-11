#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Services/Recruiting/Recruiting.API/Recruiting.API.csproj", "Services/Recruiting/Recruiting.API/"]
#COPY ["Services/Recruiting/Recruiting.Infrastructure/Recruiting.Infrastructure.csproj", "Services/Recruiting/Recruiting.Infrastructure/"]
#COPY ["Services/Recruiting/Recruiting.ApplicationCore/Recruiting.ApplicationCore.csproj", "Services/Recruiting/Recruiting.ApplicationCore/"]
#RUN dotnet restore "Services/Recruiting/Recruiting.API/Recruiting.API.csproj"
#COPY . .
#WORKDIR "/src/Services/Recruiting/Recruiting.API"
#RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build
#
#
#
#FROM build AS publish
#RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Recruiting.API.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/Services/Recruiting/Recruiting.API
RUN dotnet dev-certs https
COPY bin/Release/net6.0/publish/ app/
ENV ASPNETCORE_URLS https://+:99
EXPOSE 99
ENV MSSQLConnectionString="Server=tcp:hrm.database.windows.net,1433;Initial Catalog=Recruiting;Persist Security Info=False;User ID=AntraFS;Password=Antra20155;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENTRYPOINT ["dotnet", "app/Recruiting.API.dll"]