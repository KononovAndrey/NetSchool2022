#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/DSRNetSchool.Api/DSRNetSchool.Api.csproj", "Systems/Api/DSRNetSchool.Api/"]
COPY ["Services/DSRNetSchool.Services.Settings/DSRNetSchool.Services.Settings.csproj", "Services/DSRNetSchool.Services.Settings/"]
COPY ["Shared/DSRNetSchool.Settings/DSRNetSchool.Settings.csproj", "Shared/DSRNetSchool.Settings/"]
COPY ["Shared/DSRNetSchool.Common/DSRNetSchool.Common.csproj", "Shared/DSRNetSchool.Common/"]
COPY ["Systems/Api/DSRNetSchool.Api.Settings/DSRNetSchool.Api.Settings.csproj", "Systems/Api/DSRNetSchool.Api.Settings/"]
RUN dotnet restore "Systems/Api/DSRNetSchool.Api/DSRNetSchool.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/DSRNetSchool.Api"
RUN dotnet build "DSRNetSchool.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRNetSchool.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRNetSchool.Api.dll"]