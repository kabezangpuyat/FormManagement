#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["QMS.Web/QMS.Web.csproj", "QMS.Web/"]
RUN dotnet restore "QMS.Web/QMS.Web.csproj"
COPY . .
WORKDIR "/src/QMS.Web"
RUN dotnet build "QMS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QMS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QMS.Web.dll"]