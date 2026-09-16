# 📑 Sistema de Solicitações

## 📌 Visão Geral
Este projeto é composto por dois serviços principais:

- **Backend (Web.Challange)**: API em ASP.NET Core com autenticação JWT e CRUD de solicitações.
- **Frontend (web_react_type)**: Aplicação em Next.js/React para login e gerenciamento de solicitações.

---

## 🚀 Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/)
- Banco de dados configurado (ex.: SQL Server ou PostgreSQL, conforme seu `DbContext`)

---

## ⚙️ Configuração do Backend

### 1. Restaurar pacotes
```bash
cd Web.Challange
dotnet restore

Alterar as configurações da connection string dentro do appsetings adicionando o usuario e a senha do seu SQLSERVER

Apos a alteração rodar na pasta raiz  do projeto os comandos abaixo

dotnet ef migrations add InitialCreate -p Application.Service.Challenge -s Web.Challange

dotnet ef database update -p Application.Service.Challenge -s Web.Challange

dotnet run --project Web.Challange


API disponível em:
👉 http://localhost:7163/api/



React - 
cd web_react_type
npm install


npm run dev

Frontend disponível em:
👉 http://localhost:3000

Rodar os dois projetos e acessar o Projeto Teste_react_typescript para testar as solicitações.


Estrutura dos projetos 

Web.Challange/                # Backend .NET
 ├── Controllers/
 ├── Services/
 ├── Dtos/
 └── Program.cs

web_react_type/               # Frontend Next.js
 ├── src/app/
 │    ├── login/page.tsx
 │    ├── solicitacoes/
 │    │    ├── layout.tsx
 │    │    ├── page.tsx
 │    │    ├── nova/page.tsx
 │    │    └── [id]/...
 ├── src/api/
 │    ├── auth.ts
 │    └── solicitacoes.ts
 └── package.json
