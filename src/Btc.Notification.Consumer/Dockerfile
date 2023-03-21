#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Btc.Notification.Consumer/Btc.Notification.Consumer.csproj", "src/Btc.Notification.Consumer/"]
RUN dotnet restore "src/Btc.Notification.Consumer/Btc.Notification.Consumer.csproj"
COPY . .
WORKDIR "/src/src/Btc.Notification.Consumer"
RUN dotnet build "Btc.Notification.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Btc.Notification.Consumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Btc.Notification.Consumer.dll"]