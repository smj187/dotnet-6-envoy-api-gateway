FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/PublicService/PublicService.csproj", "Services/PublicService/"]
RUN dotnet restore "Services/PublicService/PublicService.csproj"
COPY . .
WORKDIR "/src/Services/PublicService"
RUN dotnet build "PublicService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PublicService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PublicService.dll"]