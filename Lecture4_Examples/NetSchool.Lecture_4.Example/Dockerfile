FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetSchool.Lecture_4.Example.csproj", "NetSchool.Lecture_4.Example/"]
RUN dotnet restore "NetSchool.Lecture_4.Example/NetSchool.Lecture_4.Example.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "NetSchool.Lecture_4.Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetSchool.Lecture_4.Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetSchool.Lecture_4.Example.dll"]