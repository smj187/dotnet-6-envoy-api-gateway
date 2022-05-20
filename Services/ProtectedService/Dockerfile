FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ProtectedService/ProtectedService.csproj", "Services/ProtectedService/"]
RUN dotnet restore "Services/ProtectedService/ProtectedService.csproj"
COPY . .
WORKDIR "/src/Services/ProtectedService"
RUN dotnet build "ProtectedService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProtectedService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProtectedService.dll"]