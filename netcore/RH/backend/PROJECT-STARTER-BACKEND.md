# PROJECT STARTER — BACKEND .NET

> Documento de bootstrap para criação inicial de uma solução backend em ASP.NET Core.
>
> O objetivo deste starter é **somente criar a estrutura técnica inicial do projeto**.
> Nenhuma regra de negócio, integração, persistência, autenticação ou feature deve ser implementada nesta etapa.

---

# 1. Objetivo

Criar uma solution backend em .NET contendo apenas:

- estrutura de pastas;
- projetos base da arquitetura;
- referências entre projetos;
- APIs executáveis;
- endpoint simples de validação (`Olá Mundo`);
- build da solution funcionando.

Este starter **não implementa funcionalidades de negócio**.

---

# 2. Informações do projeto

Preencher antes da criação da solution.

| Campo | Valor |
|---|---|
| Nome do projeto | `A DEFINIR` |
| Prefixo / namespace | `A DEFINIR` |
| Versão .NET | `.NET 10` |
| Repositório | `A DEFINIR` |
| Responsável técnico | `A DEFINIR` |

Exemplo de prefixo:

```text
MeuProjeto
```

Esse prefixo será utilizado nos nomes dos projetos:

```text
MeuProjeto.API.Auth
MeuProjeto.API.Person
MeuProjeto.API.Admin
MeuProjeto.API.Site
MeuProjeto.Application
MeuProjeto.Domain
MeuProjeto.Infrastructure
MeuProjeto.CrossCutting
```

---

# 3. Escopo desta etapa

## Deve ser criado

- Solution `.sln`;
- projetos ASP.NET Core Web API;
- projetos Class Library;
- estrutura de diretórios;
- referências entre projetos;
- Swagger / OpenAPI padrão das APIs, quando disponível no template adotado;
- endpoint inicial para validar cada API;
- `README.md` básico do backend;
- `.gitignore` para .NET;
- build completo da solution.

## Não deve ser criado

Nesta etapa, **não implementar**:

- frontend;
- banco de dados;
- Entity Framework Core;
- SQL Server;
- MongoDB;
- Redis;
- Kafka;
- Docker;
- autenticação;
- autorização;
- JWT;
- CQRS funcional;
- Commands;
- Queries;
- Handlers;
- Domain Events;
- Entities;
- Aggregates;
- Repositories;
- Services;
- Workers;
- Batch;
- CRUDs;
- regras de negócio;
- integrações externas;
- testes funcionais de features.

Esses itens serão adicionados posteriormente por tasks específicas.

---

# 4. Estrutura esperada

Toda a solution deve ficar dentro de `backend/`.

```text
📂 backend
├── 📂 src
│   ├── 📂 API
│   │   ├── 📂 MeuProjeto.API.Auth
│   │   ├── 📂 MeuProjeto.API.Person
│   │   ├── 📂 MeuProjeto.API.Admin
│   │   └── 📂 MeuProjeto.API.Site
│   │
│   ├── 📂 Application
│   │   └── 📂 MeuProjeto.Application
│   │
│   ├── 📂 Domain
│   │   └── 📂 MeuProjeto.Domain
│   │
│   ├── 📂 Infrastructure
│   │   └── 📂 MeuProjeto.Infrastructure
│   │
│   └── 📂 CrossCutting
│       └── 📂 MeuProjeto.CrossCutting
│
├── 📂 test
│   ├── 📂 unitario
│   └── 📂 integrado
│
├── 📄 MeuProjeto.sln
├── 📄 README.md
└── 📄 .gitignore
```

> As pastas de testes podem existir vazias nesta primeira etapa.

---

# 5. Projetos que devem ser criados

## APIs

Criar como ASP.NET Core Web API:

```text
MeuProjeto.API.Auth
MeuProjeto.API.Person
MeuProjeto.API.Admin
MeuProjeto.API.Site
```

## Class Libraries

Criar como Class Library:

```text
MeuProjeto.Application
MeuProjeto.Domain
MeuProjeto.Infrastructure
MeuProjeto.CrossCutting
```

---

# 6. Responsabilidade inicial dos projetos

Nesta etapa, as responsabilidades abaixo servem apenas para definir a futura separação arquitetural.

Nenhuma implementação real deve ser criada agora.

## MeuProjeto.API.Auth

Futura entrada HTTP relacionada a autenticação e identidade.

Nesta etapa:

```text
GET /
```

Resposta:

```text
Olá Mundo - Auth API
```

---

## MeuProjeto.API.Person

Futura entrada HTTP para funcionalidades relacionadas a pessoas e usuários.

Nesta etapa:

```text
GET /
```

Resposta:

```text
Olá Mundo - Person API
```

---

## MeuProjeto.API.Admin

Futura entrada HTTP para funcionalidades administrativas.

Nesta etapa:

```text
GET /
```

Resposta:

```text
Olá Mundo - Admin API
```

---

## MeuProjeto.API.Site

Futura entrada HTTP para funcionalidades públicas ou específicas do site.

Nesta etapa:

```text
GET /
```

Resposta:

```text
Olá Mundo - Site API
```

---

## MeuProjeto.Application

Projeto reservado para futura camada de aplicação.

Nesta etapa, criar somente a estrutura inicial de pastas abaixo, sem implementação de negócio:

```text
📂 MeuProjeto.Application
└── 📂 User
    ├── 📂 Command
    │   └── 📄 Command.cs
    └── 📂 Query
        └── 📄 Query.cs
```

Os arquivos devem existir, porém permanecer vazios:

```csharp
// Command.cs — vazio
```

```csharp
// Query.cs — vazio
```

Essa estrutura será utilizada futuramente para organizar Commands, Queries, Handlers, Validators, DTOs e Application Services relacionados a `User`.

Nesta etapa:

- não implementar Commands;
- não implementar Queries;
- não implementar Handlers;
- não implementar Validators;
- não adicionar regras de negócio;
- não instalar MediatR, FluentValidation ou AutoMapper.

---

## MeuProjeto.Domain

Projeto reservado para o domínio.

Poderá conter futuramente:

```text
Entities
Aggregates
Value Objects
Domain Events
Domain Services
Repository Interfaces
```

Nesta etapa deve permanecer sem implementação de negócio.

---

## MeuProjeto.Infrastructure

Projeto reservado para infraestrutura.

Poderá conter futuramente:

```text
Banco de dados
Repositories
Kafka
Redis
MongoDB
Integrações externas
Outbox
```

Nesta etapa deve permanecer sem implementação técnica dessas dependências.

---

## MeuProjeto.CrossCutting

Projeto reservado para componentes transversais.

Poderá conter futuramente:

```text
Dependency Injection
Logging
Exceptions
Middleware
Health Checks
CorrelationId
Extensions
```

Nesta etapa deve permanecer mínimo.

---

# 7. Referências entre projetos

Criar somente as referências necessárias para estabelecer a direção arquitetural inicial.

```text
API
 ↓
Application
 ↓
Domain

Infrastructure
 ↓
Application / Domain

CrossCutting
 ↓
utilizado pelas APIs quando necessário
```

Sugestão inicial:

```text
MeuProjeto.API.Auth
 ├── MeuProjeto.Application
 └── MeuProjeto.CrossCutting

MeuProjeto.API.Person
 ├── MeuProjeto.Application
 └── MeuProjeto.CrossCutting

MeuProjeto.API.Admin
 ├── MeuProjeto.Application
 └── MeuProjeto.CrossCutting

MeuProjeto.API.Site
 ├── MeuProjeto.Application
 └── MeuProjeto.CrossCutting

MeuProjeto.Application
 └── MeuProjeto.Domain

MeuProjeto.Infrastructure
 ├── MeuProjeto.Application
 └── MeuProjeto.Domain
```

## Regra importante

O projeto `Domain` não deve possuir referência para:

```text
API
Application
Infrastructure
CrossCutting
```

---

# 8. Endpoint obrigatório das APIs

Cada API deve possuir somente um endpoint funcional nesta etapa.

Exemplo com Minimal API:

```csharp
app.MapGet("/", () => "Olá Mundo - Auth API");
```

Ou equivalente com Controller, caso esse padrão tenha sido definido para o projeto.

Não criar endpoints adicionais.

---

# 9. Program.cs

O `Program.cs` deve permanecer o mais simples possível.

Exemplo conceitual:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Olá Mundo - API");

app.Run();
```

Adicionar apenas configurações geradas pelo template ou estritamente necessárias para executar a API.

Não adicionar antecipadamente:

```text
DbContext
Kafka
Redis
MongoDB
JWT
MediatR
FluentValidation
Serilog
AutoMapper
MassTransit
OpenTelemetry
```

Essas dependências devem entrar somente quando uma task exigir.

---

# 10. Pacotes NuGet

Regra para esta etapa:

> Não instalar pacotes NuGet adicionais sem necessidade explícita.

Utilizar apenas o necessário para os templates padrão selecionados.

Evitar instalar antecipadamente bibliotecas para arquitetura futura.

---

# 11. Build obrigatório

Ao finalizar a criação da estrutura, executar:

```bash
dotnet restore
dotnet build
```

O resultado esperado é:

```text
Build succeeded.
0 Error(s)
```

Warnings devem ser analisados, mas não devem ser ocultados apenas para fazer o build parecer limpo.

---

# 12. Validação das APIs

Cada API deve poder ser executada individualmente.

Exemplo:

```bash
dotnet run --project src/API/MeuProjeto.API.Auth
```

Ao acessar a rota raiz:

```text
GET /
```

Deve retornar:

```text
Olá Mundo - Auth API
```

Repetir a validação para:

```text
Auth
Person
Admin
Site
```

---

# 13. README inicial

O arquivo `backend/README.md` deve conter apenas informações básicas.

Exemplo:

```markdown
# MeuProjeto Backend

Backend do projeto MeuProjeto.

## Tecnologia

- C#
- ASP.NET Core
- .NET 10

## Estrutura

- API
- Application
- Domain
- Infrastructure
- CrossCutting

## Build

```bash
dotnet restore
dotnet build
```

## Executar uma API

```bash
dotnet run --project src/API/MeuProjeto.API.Auth
```
```

---

# 14. Critérios de aceite

O starter está concluído somente quando:

- [ ] pasta `backend` criada;
- [ ] solution criada;
- [ ] quatro projetos API criados;
- [ ] Application criado;
- [ ] Domain criado;
- [ ] Infrastructure criado;
- [ ] CrossCutting criado;
- [ ] todos os projetos adicionados à solution;
- [ ] referências entre projetos configuradas;
- [ ] cada API possui somente o endpoint `Olá Mundo`;
- [ ] nenhuma regra de negócio foi criada;
- [ ] nenhuma persistência foi configurada;
- [ ] nenhuma mensageria foi configurada;
- [ ] nenhuma autenticação foi implementada;
- [ ] nenhum frontend foi criado;
- [ ] `dotnet restore` executa com sucesso;
- [ ] `dotnet build` executa com sucesso;
- [ ] todas as APIs iniciam sem erro.

---

# 15. Regras para IA / Copilot

Ao utilizar este arquivo como prompt ou contexto para uma IA:

1. Criar somente o backend.
2. Não criar frontend.
3. Não implementar features.
4. Não criar CRUDs.
5. Não criar entidades de negócio.
6. Não criar Commands ou Queries nesta etapa.
7. Não criar Domain Events nesta etapa.
8. Não configurar banco de dados.
9. Não instalar Entity Framework Core.
10. Não configurar MongoDB.
11. Não configurar Redis.
12. Não configurar Kafka.
13. Não implementar autenticação ou JWT.
14. Não criar Workers ou Batch.
15. Não criar Docker ou Docker Compose.
16. Não instalar pacotes NuGet antecipadamente.
17. Cada API deve possuir somente um endpoint `Olá Mundo`.
18. Manter o código mínimo e compilável.
19. Respeitar a direção das dependências entre projetos.
20. O `Domain` não pode depender das demais camadas.
21. Caso alguma informação necessária não esteja definida, utilizar `A DEFINIR` em vez de inventar.
22. Não expandir o escopo sem solicitação explícita.

---

# 16. Resultado esperado

Ao final desta etapa deve existir somente uma **base backend limpa e compilável**:

```text
HTTP
 ↓
API
 ↓
Application
 ↓
Domain

Infrastructure

CrossCutting
```

Sem funcionalidades de negócio.

Sem integrações externas.

Sem infraestrutura configurada.

Sem frontend.

O desenvolvimento funcional começa somente após a aprovação deste bootstrap e a criação das tasks específicas.
