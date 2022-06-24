#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CompanyEmployees.WebApi/CompanyEmployees.WebApi.csproj", "src/CompanyEmployees.WebApi/"]
COPY ["src/CompanyEmployees.Application/CompanyEmployees.Application.csproj", "src/CompanyEmployees.Application/"]
COPY ["src/CompanyEmployees.Infrastructure/CompanyEmployees.Infrastructure.csproj", "src/CompanyEmployees.Infrastructure/"]
COPY ["src/CompanyEmployees.Domain/CompanyEmployees.Domain.csproj", "src/CompanyEmployees.Domain/"]
RUN dotnet restore "src/CompanyEmployees.WebApi/CompanyEmployees.WebApi.csproj"
COPY . .
WORKDIR "/src/src/CompanyEmployees.WebApi"
RUN dotnet build "CompanyEmployees.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyEmployees.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyEmployees.WebApi.dll"]