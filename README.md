# Desafio Back-end - Plataforma de Pagamentos Simplificada

Este projeto é uma solução para o desafio de desenvolvedor back-end, cujo objetivo é criar uma plataforma de pagamentos simplificada onde usuários podem realizar transferências e depósitos. 

## 📋 Descrição do Desafio

A aplicação simula uma plataforma de pagamentos com funcionalidades básicas de transferência de dinheiro entre usuários. Há dois tipos de usuários:

- **Usuários Comuns**: Podem enviar e receber dinheiro.
- **Lojistas**: Apenas recebem dinheiro.

A aplicação garante que os dados de CPF/CNPJ e e-mails são únicos e conta com um sistema de notificação para transferências bem-sucedidas.

## 🔧 Tecnologias Utilizadas

- **Framework**: [ASP.NET Core]
- **Banco de Dados**: SQL Server
- **Autorizador**: Mock API para simular serviços de terceiros
- **Postman**: Para teste dos enpoints da aplicação

## 🚀 Funcionalidades

### 1. Cadastro de Usuários
- **Campos**: Primeiro Nome, Último Nome, CPF/CNPJ, e-mail, senha, tipo de usuário
- **Regras**: CPF/CNPJ e e-mail são únicos.

### 2. Transferências entre Usuários
- **Regras de Negócio**:
  - Usuários comuns podem transferir e receber.
  - Lojistas apenas recebem transferências.
  - O saldo do usuário é validado antes da transferência.
  - Transferências entre usuários comuns e lojistas são permitidas.
  - **Transação Reversível**: Em caso de falha, o saldo retorna à carteira do remetente.

### 3. Consulta de Serviço Autorizador
- **Serviço Externo**: `GET https://util.devi.tools/api/v2/authorize`
- **Objetivo**: Verificar se a transferência pode ser autorizada antes de concluir.



## 📥 Endpoint's

### Endpoint para Registro de novos usuários

```
POST /user
Content-Type: application/json
```

#### Request Body
```json
{
  "firstName": "Example",
  "lastName": "Example",
  "document": "799.612.345-05",
  "email": "Example@gmail.com",
  "password": 10800,
  "userType": 1
}
```

| Parâmetro | Tipo   | Descrição                   |
|-----------|--------|-----------------------------|
| firstName     | string  | Primeiro nome do usuário   |
| lastName    | string    | ltimo nome do usuário      |
| document  | string    | CPF ou CNPJ do usuário     |
| email  | string    | Email do usuário     |
| password  | int    | Senha do usuário      |
| userType  | enum    | tipo de do usuário (0=Comum ou 1=logista)      |

### Endpoint para listar todos os usuários
Retorna uma lista com todos os usuários cadastrados na plataforma.
```
POST /user
Content-Type: application/json
```
### Endpoint para Transferências

```
POST /transaction
Content-Type: application/json
```

#### Request Body
```json
{
    "value": "10",
    "sender": "2",
    "receiver": "4"
}
```

| Parâmetro | Tipo   | Descrição                   |
|-----------|--------|-----------------------------|
| value     | decimal  | Valor a ser transferido     |
| sender     | int    | ID do usuário pagador       |
| receiver     | int    | ID do usuário receptor      |

### Endpoint para Depósitos

```
PUT /user
Content-Type: application/json
```

#### Request Body
```json
{
    "Id": "10",
    "value": "2""
}
```

| Parâmetro | Tipo   | Descrição                   |
|-----------|--------|-----------------------------|
| sender     | int    | ID do usuário recebedor      |
| value     | decimal  | Valor a ser depósitado     |



---

Caso precise de mais informações ou ajustes, posso ajudar com o conteúdo específico.
