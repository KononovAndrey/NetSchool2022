#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Web/DSRNetSchool.Web/DSRNetSchool.Web.csproj", "Systems/Web/DSRNetSchool.Web/DSRNetSchool.Web.csproj"]
RUN dotnet restore "Systems/Web/DSRNetSchool.Web/DSRNetSchool.Web.csproj"
COPY . .
WORKDIR "/src/Systems/Web/DSRNetSchool.Web"
RUN dotnet build "DSRNetSchool.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRNetSchool.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine
WORKDIR /var/www/web

COPY --from=publish /app/publish/wwwroot .
COPY Systems/Web/DSRNetSchool.Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
