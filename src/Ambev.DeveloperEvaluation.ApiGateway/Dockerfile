# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia arquivos de projeto primeiro (para melhor uso do cache)
COPY ["src/Ambev.DeveloperEvaluation.ApiGateway/Ambev.DeveloperEvaluation.ApiGateway.csproj", "src/Ambev.DeveloperEvaluation.ApiGateway/"]

# Restaura dependências
RUN dotnet restore "src/Ambev.DeveloperEvaluation.ApiGateway/Ambev.DeveloperEvaluation.ApiGateway.csproj"

# Copia o restante do código
COPY . .

# Compila e publica o projeto
WORKDIR /src/src/Ambev.DeveloperEvaluation.ApiGateway
RUN dotnet publish "Ambev.DeveloperEvaluation.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Expõe a porta usada pelo app
EXPOSE 80

# Copia os arquivos publicados da etapa de build
COPY --from=build /app/publish .

# Define o ambiente para desenvolvimento (ajuste conforme necessário)
ENV ASPNETCORE_ENVIRONMENT=Development

# Inicia a aplicação
ENTRYPOINT ["dotnet", "Ambev.DeveloperEvaluation.ApiGateway.dll"]
