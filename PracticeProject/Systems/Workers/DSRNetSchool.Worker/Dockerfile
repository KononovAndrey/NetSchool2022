#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Workers/DSRNetSchool.Worker/DSRNetSchool.Worker.csproj", "Systems/Workers/DSRNetSchool.Worker/"]
COPY ["Data/DSRNetSchool.Context/DSRNetSchool.Context.csproj", "Data/DSRNetSchool.Context/"]
COPY ["Shared/DSRNetSchool.Settings/DSRNetSchool.Settings.csproj", "Shared/DSRNetSchool.Settings/"]
COPY ["Data/DSRNetSchool.Context.Entities/DSRNetSchool.Context.Entities.csproj", "Data/DSRNetSchool.Context.Entities/"]
COPY ["Services/DSRNetSchool.Services.Actions/DSRNetSchool.Services.Actions.csproj", "Services/DSRNetSchool.Services.Actions/"]
COPY ["Shared/DSRNetSchool.Consts/DSRNetSchool.Consts.csproj", "Shared/DSRNetSchool.Consts/"]
COPY ["Services/DSRNetSchool.Services.EmailSender/DSRNetSchool.Services.EmailSender.csproj", "Services/DSRNetSchool.Services.EmailSender/"]
COPY ["Services/DSRNetSchool.Services.RabbitMq/DSRNetSchool.Services.RabbitMq.csproj", "Services/DSRNetSchool.Services.RabbitMq/"]
COPY ["Shared/DSRNetSchool.Common/DSRNetSchool.Common.csproj", "Shared/DSRNetSchool.Common/"]
RUN dotnet restore "Systems/Workers/DSRNetSchool.Worker/DSRNetSchool.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Workers/DSRNetSchool.Worker"
RUN dotnet build "DSRNetSchool.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRNetSchool.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRNetSchool.Worker.dll"]