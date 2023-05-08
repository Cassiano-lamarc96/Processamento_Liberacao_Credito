FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Processamento_Liberacao_Credito/Processamento_Liberacao_Credito.csproj", "Processamento_Liberacao_Credito/"]
COPY ["Processamento_Liberacao_Credito.Application/Processamento_Liberacao_Credito.Application.csproj", "Processamento_Liberacao_Credito.Application/"]
RUN dotnet restore "Processamento_Liberacao_Credito/Processamento_Liberacao_Credito.csproj"
COPY . .
WORKDIR "/src/Processamento_Liberacao_Credito"
RUN dotnet build "Processamento_Liberacao_Credito.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Processamento_Liberacao_Credito.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Processamento_Liberacao_Credito.dll"]