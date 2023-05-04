# Processamento_Liberacao_Credito

Este projeto é um projeto simples e configurado para ser uma api para processamento de liberação de créditos, baseado em algumas regras e métricas definida préviamente.

Para realizar a análise do crédito basta acesar o endpoint /api/Processing/calculate da seguinte forma:

curl -X 'POST' \
  '{{urlbase}}/api/Processing/calculate' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "creditType": 3,
  "amount": 50000,
  "installmentQuantity": 72,
  "firstDueDate": "2023-05-24T20:55:30.955Z"
}'.


obtendo o seguinte objeto de respota:

{
  "error": false,
  "errorMessage": "",
  "dataResult": {
    "approved": true,
    "TEC": 158000,
    "interestAmount": 108000
  }
}
