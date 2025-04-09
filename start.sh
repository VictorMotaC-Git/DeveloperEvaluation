#!/bin/bash

NETWORK_NAME=ambev-network  # Correção aqui

echo "🔍 Verificando se a rede '$NETWORK_NAME' existe..."

if ! docker network ls | grep -q "$NETWORK_NAME"; then
  echo "🔧 Rede não encontrada. Criando '$NETWORK_NAME'..."
  docker network create "$NETWORK_NAME"
else
  echo "✅ Rede '$NETWORK_NAME' já existe."
fi

echo "🚀 Iniciando containers com Docker Compose..."
docker-compose -f docker-compose.yml up -d --build

echo "🎉 Containers iniciados. Use 'docker ps' para verificar o status."
