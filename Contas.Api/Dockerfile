FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Contas.Api/Contas.Api.csproj", "Contas.Api/"]
RUN dotnet restore "Contas.Api/Contas.Api.csproj"
COPY . .
WORKDIR "/src/Contas.Api"
RUN dotnet build "Contas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contas.Api.dll"]
