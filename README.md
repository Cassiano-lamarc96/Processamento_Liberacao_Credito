# Processamento_Liberacao_Credito

Este projeto é um projeto simples e configurado para ser uma api para processamento de liberação de créditos, baseado em algumas regras e métricas definida préviamente.

Para realizar a análise do crédito basta acesar o endpoint /api/Processing/calculate da seguinte forma:

curl -X 'POST' \
  '{{urlbase}}/api/Processing/calculate' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "creditType": 0,
  "amount": 0,
  "installmentQuantity": 0,
  "firstDueDate": "2023-05-04T19:50:01.445Z"
}'.
