#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Identity/DSRNetSchool.Identity/DSRNetSchool.Identity.csproj", "Systems/Identity/DSRNetSchool.Identity/"]
COPY ["Data/DSRNetSchool.Context.Entities/DSRNetSchool.Context.Entities.csproj", "Data/DSRNetSchool.Context.Entities/"]
COPY ["Data/DSRNetSchool.Context/DSRNetSchool.Context.csproj", "Data/DSRNetSchool.Context/"]
COPY ["Shared/DSRNetSchool.Settings/DSRNetSchool.Settings.csproj", "Shared/DSRNetSchool.Settings/"]
COPY ["Shared/DSRNetSchool.Common/DSRNetSchool.Common.csproj", "Shared/DSRNetSchool.Common/"]
RUN dotnet restore "Systems/Identity/DSRNetSchool.Identity/DSRNetSchool.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/DSRNetSchool.Identity"
RUN dotnet build "DSRNetSchool.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRNetSchool.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRNetSchool.Identity.dll"]