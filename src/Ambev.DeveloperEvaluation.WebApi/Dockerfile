# Imagem base para tempo de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas os arquivos de projeto primeiro para aproveitar cache
COPY ["src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj", "src/Ambev.DeveloperEvaluation.WebApi/"]
COPY ["src/Ambev.DeveloperEvaluation.IoC/Ambev.DeveloperEvaluation.IoC.csproj", "src/Ambev.DeveloperEvaluation.IoC/"]
COPY ["src/Ambev.DeveloperEvaluation.Domain/Ambev.DeveloperEvaluation.Domain.csproj", "src/Ambev.DeveloperEvaluation.Domain/"]
COPY ["src/Ambev.DeveloperEvaluation.Common/Ambev.DeveloperEvaluation.Common.csproj", "src/Ambev.DeveloperEvaluation.Common/"]
COPY ["src/Ambev.DeveloperEvaluation.Application/Ambev.DeveloperEvaluation.Application.csproj", "src/Ambev.DeveloperEvaluation.Application/"]
COPY ["src/Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation.ORM.csproj", "src/Ambev.DeveloperEvaluation.ORM/"]

# Restaura as dependências
RUN dotnet restore "src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj"

# Copia o restante da aplicação
COPY . .

# Compila o projeto
WORKDIR "/src/src/Ambev.DeveloperEvaluation.WebApi"
RUN dotnet build "Ambev.DeveloperEvaluation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica o projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ambev.DeveloperEvaluation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final para execução
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Ambev.DeveloperEvaluation.WebApi.dll"]
