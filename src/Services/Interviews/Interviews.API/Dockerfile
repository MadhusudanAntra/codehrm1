FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN dotnet dev-certs https
COPY bin/Release/net6.0/publish/ app/
ENV ASPNETCORE_URLS https://+:85
EXPOSE 85
ENV MSSQLConnectionString='Server=tcp:hrm.database.windows.net,1433;Initial Catalog=Interview;Persist Security Info=False;User ID=AntraFS;Password=Antra20155;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENTRYPOINT ["dotnet", "app/Interviews.API.dll"]