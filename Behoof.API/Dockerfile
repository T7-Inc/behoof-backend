FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Behoof.API/Behoof.API.csproj", "Behoof.API/"]
COPY ["ProductsManagement.DAL/ProductsManagement.DAL.csproj", "ProductsManagement.DAL/"]
COPY ["ProductsManagement.BLL/ProductsManagement.BLL.csproj", "ProductsManagement.BLL/"]
COPY ["UserAccess.API/UserAccess.API.csproj", "UserAccess.API/"]
COPY ["UserAccess.BLL/UserAccess.BLL.csproj", "UserAccess.BLL/"]
COPY ["UserAccess.DAL/UserAccess.DAL.csproj", "UserAccess.DAL/"]
COPY ["ProductsManagement.API/ProductsManagement.API.csproj", "ProductsManagement.API/"]
RUN dotnet restore "Behoof.API/Behoof.API.csproj"
COPY . .
WORKDIR "/src/Behoof.API"
RUN dotnet build "Behoof.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Behoof.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Behoof.API.dll"]
