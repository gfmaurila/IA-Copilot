# PROJECT STARTER — BACKEND .NET — MINIMAL API + VERTICAL SLICE

> Documento de bootstrap para criação inicial de uma solução backend em ASP.NET Core utilizando **Minimal API** e **Vertical Slice Architecture**.
>
> A arquitetura deve combinar **Vertical Slices nas APIs** com projetos compartilhados de **Domain**, **Infrastructure**, **Extensions** e **Shared**, evitando replicação de código entre as APIs.
>
> O objetivo deste starter é criar somente a estrutura técnica inicial do projeto.
> Nenhuma regra de negócio, persistência, autenticação, mensageria ou integração externa deve ser implementada nesta etapa.

---

# 1. Objetivo

Criar uma solution backend em .NET contendo apenas:

- estrutura de pastas;
- projetos base da arquitetura;
- quatro APIs em ASP.NET Core Minimal API;
- organização futura por Vertical Slice dentro de cada API;
- projetos compartilhados para evitar duplicação de código;
- endpoint simples de validação (`Olá Mundo`);
- referências entre projetos;
- build da solution funcionando.

Este starter **não implementa funcionalidades reais de negócio**.

---

# 2. Arquitetura adotada

A aplicação deve utilizar:

```text
ASP.NET Core
Minimal API
Vertical Slice Architecture
Shared Domain
Shared Infrastructure
Shared Extensions
Shared Components
```

A arquitetura é híbrida:

```text
Vertical Slice Architecture
+
Shared Domain
+
Shared Infrastructure
+
Shared Extensions
+
Shared Components
```

As funcionalidades devem ficar organizadas verticalmente dentro de cada API.

Código reutilizável entre APIs não deve ser replicado dentro delas.

Fluxo conceitual futuro:

```text
HTTP Request
    ↓
Minimal API Endpoint
    ↓
Feature / Slice
    ↓
Domain
    ↓
Infrastructure, quando necessário
```

Os projetos compartilhados atendem todas as APIs:

```text
API.Auth ───────┐
API.Person ─────┤
API.Admin ──────┼──> Domain
API.Site ───────┤
                ├──> Infrastructure
                ├──> Extensions
                └──> Shared
```

---

# 3. Princípio de organização

## Código específico de uma API

Deve ficar dentro da própria API, preferencialmente organizado por feature e caso de uso.

Exemplo futuro:

```text
MeuProjeto.API.Person
└── Features
    └── Users
        ├── Create
        │   ├── CreateUserEndpoint.cs
        │   ├── CreateUserCommand.cs
        │   ├── CreateUserHandler.cs
        │   ├── CreateUserValidator.cs
        │   └── CreateUserResponse.cs
        │
        ├── GetById
        │   ├── GetUserByIdEndpoint.cs
        │   ├── GetUserByIdQuery.cs
        │   ├── GetUserByIdHandler.cs
        │   └── GetUserByIdResponse.cs
        │
        └── GetPaged
```

## Código compartilhado entre APIs

Não deve ser replicado.

Deve ser colocado no projeto correspondente:

```text
Domain
Infrastructure
Extensions
Shared
```

---

# 4. Informações do projeto

Preencher antes da criação da solution.

| Campo | Valor |
|---|---|
| Nome do projeto | `A DEFINIR` |
| Prefixo / namespace | `A DEFINIR` |
| Versão .NET | `.NET 10` |
| Arquitetura | `Vertical Slice Architecture` |
| API | `ASP.NET Core Minimal API` |
| Repositório | `A DEFINIR` |
| Responsável técnico | `A DEFINIR` |

Exemplo de prefixo:

```text
MeuProjeto
```

Projetos iniciais:

```text
MeuProjeto.API.Auth
MeuProjeto.API.Person
MeuProjeto.API.Admin
MeuProjeto.API.Site
MeuProjeto.Domain
MeuProjeto.Infrastructure
MeuProjeto.Extensions
MeuProjeto.Shared
```

---

# 5. Escopo desta etapa

## Deve ser criado

- pasta `backend`;
- solution `.sln`;
- quatro projetos ASP.NET Core Minimal API;
- projeto `Domain`;
- projeto `Infrastructure`;
- projeto `Extensions`;
- projeto `Shared`;
- estrutura inicial de `Features` em cada API;
- endpoint inicial para validar cada API;
- referências entre projetos;
- OpenAPI/Swagger somente se já vier do template ou configuração mínima adotada;
- `README.md` básico;
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
- RabbitMQ;
- Docker;
- Docker Compose;
- autenticação;
- autorização;
- JWT;
- CQRS funcional;
- Commands;
- Queries;
- Handlers;
- Validators;
- Domain Events;
- Entities de negócio;
- Aggregates;
- Repositories;
- Services;
- Workers;
- Batch;
- CRUDs;
- regras de negócio;
- integrações externas;
- migrations;
- testes funcionais de features.

Esses itens devem ser adicionados posteriormente por tasks específicas.

---

# 6. Estrutura esperada

Toda a solution deve ficar dentro de `backend/`.

```text
📂 backend
├── 📂 src
│   │
│   ├── 📂 APIs
│   │   │
│   │   ├── 📂 MeuProjeto.API.Auth
│   │   │   ├── 📂 Features
│   │   │   ├── 📂 Endpoints
│   │   │   ├── 📄 Program.cs
│   │   │   └── 📄 MeuProjeto.API.Auth.csproj
│   │   │
│   │   ├── 📂 MeuProjeto.API.Person
│   │   │   ├── 📂 Features
│   │   │   ├── 📂 Endpoints
│   │   │   ├── 📄 Program.cs
│   │   │   └── 📄 MeuProjeto.API.Person.csproj
│   │   │
│   │   ├── 📂 MeuProjeto.API.Admin
│   │   │   ├── 📂 Features
│   │   │   ├── 📂 Endpoints
│   │   │   ├── 📄 Program.cs
│   │   │   └── 📄 MeuProjeto.API.Admin.csproj
│   │   │
│   │   └── 📂 MeuProjeto.API.Site
│   │       ├── 📂 Features
│   │       ├── 📂 Endpoints
│   │       ├── 📄 Program.cs
│   │       └── 📄 MeuProjeto.API.Site.csproj
│   │
│   ├── 📂 Domain
│   │   └── 📂 MeuProjeto.Domain
│   │       └── 📄 MeuProjeto.Domain.csproj
│   │
│   ├── 📂 Infrastructure
│   │   └── 📂 MeuProjeto.Infrastructure
│   │       └── 📄 MeuProjeto.Infrastructure.csproj
│   │
│   ├── 📂 Extensions
│   │   └── 📂 MeuProjeto.Extensions
│   │       └── 📄 MeuProjeto.Extensions.csproj
│   │
│   └── 📂 Shared
│       └── 📂 MeuProjeto.Shared
│           └── 📄 MeuProjeto.Shared.csproj
│
├── 📂 tests
│   ├── 📂 Unit
│   └── 📂 Integration
│
├── 📄 MeuProjeto.sln
├── 📄 README.md
└── 📄 .gitignore
```

> As pastas podem conter somente `.gitkeep` quando necessário.
>
> As pastas de testes podem existir vazias nesta primeira etapa.

---

# 7. Projetos que devem ser criados

## APIs

Criar como ASP.NET Core Web API utilizando Minimal API:

```text
MeuProjeto.API.Auth
MeuProjeto.API.Person
MeuProjeto.API.Admin
MeuProjeto.API.Site
```

Não criar Controllers.

## Class Libraries

Criar como Class Library:

```text
MeuProjeto.Domain
MeuProjeto.Infrastructure
MeuProjeto.Extensions
MeuProjeto.Shared
```

Não criar projeto `Application`.

Não criar projeto `CrossCutting`.

As responsabilidades que normalmente ficariam nesses projetos serão distribuídas entre as Features, Domain, Infrastructure, Extensions e Shared.

---

# 8. Responsabilidade das APIs

As APIs representam os pontos de entrada HTTP da aplicação.

Cada API deve conter apenas:

```text
Features
Endpoints
Program.cs
```

Além dos arquivos mínimos gerados pelo template.

As APIs não devem conter implementações duplicadas de:

```text
Entities
Value Objects
Repositories compartilhados
DbContext
Cache
Mensageria
Integrações externas
ServiceCollection Extensions comuns
WebApplication Extensions comuns
Result Pattern
Paginação compartilhada
Contratos comuns
```

Esses elementos pertencem aos projetos compartilhados apropriados.

---

# 9. Organização por Vertical Slice

A unidade principal de organização funcional deve ser uma **Feature / Use Case**.

Não criar uma camada global contendo todos os Commands, outra contendo todas as Queries e outra contendo todos os Handlers.

Evitar:

```text
Application
├── Commands
├── Queries
├── Handlers
├── Validators
└── DTOs
```

Preferir:

```text
Features
└── Users
    ├── Create
    ├── Update
    ├── Delete
    ├── GetById
    └── GetPaged
```

Exemplo futuro:

```text
Features
└── Users
    └── Create
        ├── CreateUserEndpoint.cs
        ├── CreateUserCommand.cs
        ├── CreateUserHandler.cs
        ├── CreateUserValidator.cs
        └── CreateUserResponse.cs
```

Nesta etapa criar apenas:

```text
Features/
```

sem implementar slices reais.

---

# 10. MeuProjeto.Domain

Projeto compartilhado responsável pelo domínio da aplicação.

Deve concentrar elementos de domínio utilizados por uma ou mais APIs.

Poderá conter futuramente:

```text
Entities
Aggregates
ValueObjects
Enums
DomainEvents
DomainServices
Specifications
Repository Interfaces
Business Rules
```

Exemplo futuro:

```text
MeuProjeto.Domain
└── Users
    ├── User.cs
    ├── UserId.cs
    ├── UserStatus.cs
    ├── UserCreatedDomainEvent.cs
    └── IUserRepository.cs
```

## Regra importante

O projeto `Domain` deve permanecer independente de detalhes técnicos.

Não deve depender de:

```text
APIs
Infrastructure
Extensions
```

Idealmente, deve possuir somente dependências estritamente necessárias ao domínio.

Nesta etapa deve permanecer sem implementação de negócio.

---

# 11. MeuProjeto.Infrastructure

Projeto compartilhado responsável pelas implementações técnicas utilizadas pelas APIs e Features.

Poderá conter futuramente:

```text
Persistence
Database
DbContext
Repositories
Cache
Redis
MongoDB
Messaging
Kafka
RabbitMQ
ExternalServices
Outbox
Observability
FileStorage
Email
```

Exemplo futuro:

```text
MeuProjeto.Infrastructure
├── Persistence
│   ├── AppDbContext.cs
│   └── Configurations
│
├── Repositories
│   └── UserRepository.cs
│
├── Cache
├── Messaging
└── ExternalServices
```

## Regra importante

Implementações técnicas compartilhadas devem existir aqui e não serem duplicadas nas APIs.

`Infrastructure` pode depender de:

```text
Domain
Shared
```

Nesta etapa não configurar nenhuma infraestrutura externa.

---

# 12. MeuProjeto.Extensions

Projeto compartilhado responsável por métodos de extensão e composição reutilizável entre APIs.

Poderá conter futuramente:

```text
DependencyInjectionExtensions.cs
InfrastructureExtensions.cs
OpenApiExtensions.cs
AuthenticationExtensions.cs
AuthorizationExtensions.cs
LoggingExtensions.cs
HealthCheckExtensions.cs
WebApplicationExtensions.cs
EndpointExtensions.cs
```

Exemplo futuro:

```csharp
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddAuthenticationServices(builder.Configuration)
    .AddOpenApiServices();
```

E:

```csharp
app
    .UseApplicationMiddlewares()
    .MapApplicationEndpoints();
```

## Regra importante

Não transformar `Extensions` em uma camada genérica para qualquer código.

Somente composição, bootstrap e extensões reutilizáveis devem existir aqui.

Nesta etapa manter o projeto mínimo e sem dependências técnicas antecipadas.

---

# 13. MeuProjeto.Shared

Projeto compartilhado para componentes genéricos reutilizados entre APIs e que não pertencem especificamente ao domínio ou à infraestrutura.

Poderá conter futuramente:

```text
Result
Errors
Pagination
Common Responses
Common Contracts
Shared Primitives
Base Abstractions
Constants
Common Exceptions
```

Exemplo futuro:

```text
MeuProjeto.Shared
├── Results
│   ├── Result.cs
│   └── Error.cs
│
├── Pagination
│   └── PagedResult.cs
│
└── Contracts
```

## Regra importante

Não transformar `Shared` em uma pasta para código sem responsabilidade definida.

Somente componentes realmente reutilizados por mais de uma API devem existir aqui.

Nesta etapa não implementar componentes compartilhados reais.

---

# 14. Endpoints

Cada API pode possuir uma pasta:

```text
Endpoints
```

Ela deve servir somente para composição ou agrupamento de endpoints quando necessário.

Poderá conter futuramente:

```text
EndpointRegistration.cs
EndpointGroups.cs
RouteConstants.cs
```

Os endpoints específicos de uma Feature devem permanecer próximos ao slice correspondente.

Exemplo:

```text
Features
└── Users
    └── Create
        └── CreateUserEndpoint.cs
```

Nesta etapa a pasta `Endpoints` pode permanecer vazia.

---

# 15. Endpoint obrigatório

Cada API deve possuir somente um endpoint funcional nesta etapa.

## Auth

```http
GET /
```

Resposta:

```text
Olá Mundo - Auth API
```

## Person

```http
GET /
```

Resposta:

```text
Olá Mundo - Person API
```

## Admin

```http
GET /
```

Resposta:

```text
Olá Mundo - Admin API
```

## Site

```http
GET /
```

Resposta:

```text
Olá Mundo - Site API
```

Exemplo:

```csharp
app.MapGet("/", () => "Olá Mundo - Auth API");
```

Não criar endpoints adicionais.

---

# 16. Program.cs

O `Program.cs` deve permanecer extremamente simples.

Exemplo inicial:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Olá Mundo - API");

app.Run();
```

Quando os projetos compartilhados passarem a possuir implementações reais, o objetivo será manter o `Program.cs` semelhante a:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSharedServices()
    .AddInfrastructure(builder.Configuration)
    .AddApplicationExtensions();

var app = builder.Build();

app.MapApplicationEndpoints();

app.Run();
```

O segundo exemplo representa apenas a direção futura.

Nesta etapa não criar implementações inexistentes somente para reproduzir esse exemplo.

Não adicionar antecipadamente:

```text
DbContext
Entity Framework Core
MediatR
Carter
FluentValidation
Mapster
AutoMapper
Kafka
RabbitMQ
Redis
MongoDB
JWT
Serilog
MassTransit
OpenTelemetry
```

---

# 17. Referências entre projetos

A direção arquitetural deve evitar dependências circulares.

Estrutura conceitual:

```text
API.Auth ───────┐
API.Person ─────┤
API.Admin ──────┼──> Domain
API.Site ───────┤
                ├──> Infrastructure
                ├──> Extensions
                └──> Shared

Infrastructure ─────> Domain
Infrastructure ─────> Shared

Extensions ─────────> Infrastructure
Extensions ─────────> Shared

Domain ─────────────> Shared somente se estritamente necessário
```

Sugestão inicial de referências:

```text
MeuProjeto.API.Auth
 ├── MeuProjeto.Domain
 ├── MeuProjeto.Infrastructure
 ├── MeuProjeto.Extensions
 └── MeuProjeto.Shared

MeuProjeto.API.Person
 ├── MeuProjeto.Domain
 ├── MeuProjeto.Infrastructure
 ├── MeuProjeto.Extensions
 └── MeuProjeto.Shared

MeuProjeto.API.Admin
 ├── MeuProjeto.Domain
 ├── MeuProjeto.Infrastructure
 ├── MeuProjeto.Extensions
 └── MeuProjeto.Shared

MeuProjeto.API.Site
 ├── MeuProjeto.Domain
 ├── MeuProjeto.Infrastructure
 ├── MeuProjeto.Extensions
 └── MeuProjeto.Shared

MeuProjeto.Infrastructure
 ├── MeuProjeto.Domain
 └── MeuProjeto.Shared

MeuProjeto.Extensions
 ├── MeuProjeto.Infrastructure
 └── MeuProjeto.Shared
```

## Regras obrigatórias

As APIs não devem possuir referência direta umas às outras.

Proibido:

```text
MeuProjeto.API.Admin
   ↓
MeuProjeto.API.Auth
```

O projeto `Domain` não deve possuir referência para:

```text
APIs
Infrastructure
Extensions
```

Evitar dependências circulares entre qualquer projeto.

---

# 18. CQRS dentro de Vertical Slice

Vertical Slice Architecture pode utilizar CQRS.

CQRS não deve gerar uma estrutura horizontal global.

Quando implementado futuramente:

```text
Features
└── Users
    ├── Create
    │   ├── CreateUserCommand.cs
    │   └── CreateUserHandler.cs
    │
    └── GetById
        ├── GetUserByIdQuery.cs
        └── GetUserByIdHandler.cs
```

Evitar:

```text
Commands
└── Users

Queries
└── Users

Handlers
└── Users
```

Nesta etapa não criar Commands, Queries ou Handlers.

---

# 19. Domain Events

Domain Events pertencentes ao domínio devem ficar no projeto compartilhado `Domain`.

Exemplo futuro:

```text
MeuProjeto.Domain
└── Users
    └── Events
        └── UserCreatedDomainEvent.cs
```

O código responsável por reagir ao evento pode ficar próximo ao slice ou em infraestrutura, dependendo da responsabilidade real.

Nesta etapa não criar Domain Events.

---

# 20. Pacotes NuGet

Regra desta etapa:

> Não instalar pacotes NuGet adicionais sem necessidade explícita.

Não instalar antecipadamente bibliotecas somente porque poderão ser utilizadas futuramente.

Especialmente não instalar nesta etapa:

```text
MediatR
Carter
FluentValidation
Mapster
AutoMapper
EntityFrameworkCore
Serilog
MassTransit
```

O objetivo é manter o bootstrap pequeno e compilável.

---

# 21. Convenção futura de Slice

Quando uma task solicitar uma funcionalidade, utilizar preferencialmente:

```text
Features
└── <Feature>
    └── <UseCase>
        ├── <UseCase>Endpoint.cs
        ├── <UseCase>Command.cs ou <UseCase>Query.cs
        ├── <UseCase>Handler.cs
        ├── <UseCase>Validator.cs
        ├── <UseCase>Request.cs
        └── <UseCase>Response.cs
```

Nem todo slice precisa possuir todos esses arquivos.

Exemplo:

```text
Features
└── Users
    └── GetById
        ├── GetUserByIdEndpoint.cs
        ├── GetUserByIdQuery.cs
        ├── GetUserByIdHandler.cs
        └── GetUserByIdResponse.cs
```

Criar somente os arquivos necessários para o caso de uso.

Evitar abstrações genéricas antecipadas.

---

# 22. Reutilização e duplicação de código

Antes de criar código dentro de uma API, verificar se a responsabilidade é compartilhada.

## Deve permanecer na API

```text
Endpoint específico
Request específico
Response específico
Command específico
Query específica
Handler específico
Validator específico
Orquestração do caso de uso
```

## Deve ir para Domain

```text
Entity
Aggregate
Value Object
Enum de domínio
Domain Event
Regra de domínio
Contrato de Repository ligado ao domínio
```

## Deve ir para Infrastructure

```text
DbContext
Repository implementation
Redis
MongoDB
Kafka
RabbitMQ
Integrações externas
Cache
Storage
Email provider
```

## Deve ir para Extensions

```text
AddInfrastructure()
AddAuthentication()
AddOpenApi()
AddHealthChecks()
MapApplicationEndpoints()
Middlewares compartilhados registrados via extension
```

## Deve ir para Shared

```text
Result<T>
Error
PagedResult<T>
Contratos comuns
Constantes compartilhadas
Abstrações técnicas realmente comuns
```

Regra principal:

> Código reutilizável não deve ser copiado entre APIs.

---

# 23. Build obrigatório

Ao finalizar a criação da estrutura, executar:

```bash
dotnet restore
dotnet build
```

Resultado esperado:

```text
Build succeeded.
0 Error(s)
```

Warnings devem ser analisados e não escondidos artificialmente.

---

# 24. Validação das APIs

Cada API deve poder ser executada individualmente.

Exemplo:

```bash
dotnet run --project src/APIs/MeuProjeto.API.Auth
```

Ao acessar:

```http
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

# 25. README inicial

O arquivo `backend/README.md` deve conter apenas informações básicas.

Exemplo:

```markdown
# MeuProjeto Backend

Backend do projeto MeuProjeto utilizando ASP.NET Core Minimal API e Vertical Slice Architecture.

## Tecnologia

- C#
- ASP.NET Core
- .NET 10
- Minimal API
- Vertical Slice Architecture

## Projetos

### APIs

- MeuProjeto.API.Auth
- MeuProjeto.API.Person
- MeuProjeto.API.Admin
- MeuProjeto.API.Site

### Shared Projects

- MeuProjeto.Domain
- MeuProjeto.Infrastructure
- MeuProjeto.Extensions
- MeuProjeto.Shared

## Build

```bash
dotnet restore
dotnet build
```

## Executar uma API

```bash
dotnet run --project src/APIs/MeuProjeto.API.Auth
```
```

---

# 26. Critérios de aceite

O starter está concluído somente quando:

- [ ] pasta `backend` criada;
- [ ] solution criada;
- [ ] quatro projetos Minimal API criados;
- [ ] projeto `Domain` criado;
- [ ] projeto `Infrastructure` criado;
- [ ] projeto `Extensions` criado;
- [ ] projeto `Shared` criado;
- [ ] projeto `Application` não existe;
- [ ] projeto `CrossCutting` não existe;
- [ ] todos os projetos adicionados à solution;
- [ ] estrutura `Features` criada em cada API;
- [ ] estrutura `Endpoints` criada em cada API;
- [ ] referências entre projetos configuradas;
- [ ] nenhuma API referencia outra API;
- [ ] `Domain` não referencia `Infrastructure`, `Extensions` ou APIs;
- [ ] cada API possui somente o endpoint `Olá Mundo`;
- [ ] nenhum Controller foi criado;
- [ ] nenhuma feature real foi implementada;
- [ ] nenhuma regra de negócio foi criada;
- [ ] nenhuma persistência foi configurada;
- [ ] nenhuma mensageria foi configurada;
- [ ] nenhuma autenticação foi implementada;
- [ ] nenhum frontend foi criado;
- [ ] nenhuma dependência arquitetural antecipada foi instalada;
- [ ] não existe duplicação desnecessária de código compartilhável entre APIs;
- [ ] `dotnet restore` executa com sucesso;
- [ ] `dotnet build` executa com sucesso;
- [ ] todas as APIs iniciam sem erro.

---

# 27. Regras para IA / Copilot

Ao utilizar este documento como contexto ou prompt para IA:

1. Criar somente o backend.
2. Utilizar ASP.NET Core Minimal API.
3. Utilizar Vertical Slice Architecture dentro das APIs.
4. Criar os projetos compartilhados `Domain`, `Infrastructure`, `Extensions` e `Shared`.
5. Não criar projeto `Application`.
6. Não criar projeto `CrossCutting`.
7. Não criar Controllers.
8. Não criar frontend.
9. Não implementar features reais nesta etapa.
10. Não criar CRUDs.
11. Não criar entidades de negócio nesta etapa.
12. Não criar Commands ou Queries nesta etapa.
13. Não criar Handlers nesta etapa.
14. Não criar Validators nesta etapa.
15. Não criar Domain Events nesta etapa.
16. Não configurar banco de dados.
17. Não instalar Entity Framework Core.
18. Não configurar MongoDB.
19. Não configurar Redis.
20. Não configurar Kafka.
21. Não configurar RabbitMQ.
22. Não implementar autenticação ou JWT.
23. Não criar Workers ou Batch.
24. Não criar Docker ou Docker Compose.
25. Não instalar pacotes NuGet antecipadamente.
26. Não criar abstrações genéricas sem uso concreto.
27. Não separar Commands, Queries e Handlers em camadas horizontais globais.
28. Features futuras devem ser organizadas por caso de uso.
29. Não duplicar código compartilhável entre APIs.
30. Código de domínio compartilhado deve ficar em `Domain`.
31. Implementações técnicas compartilhadas devem ficar em `Infrastructure`.
32. Extensões e bootstrap compartilhados devem ficar em `Extensions`.
33. Componentes genéricos reutilizáveis devem ficar em `Shared`.
34. Cada API deve possuir somente um endpoint `Olá Mundo` nesta etapa.
35. APIs não devem referenciar outras APIs diretamente.
36. `Domain` não deve depender de `Infrastructure`, `Extensions` ou APIs.
37. Evitar dependências circulares.
38. Manter `Program.cs` pequeno.
39. Manter o código mínimo e compilável.
40. Caso alguma informação necessária não esteja definida, utilizar `A DEFINIR` em vez de inventar.
41. Não expandir o escopo sem solicitação explícita.

---

# 28. Resultado esperado

Ao final desta etapa deve existir somente uma base backend limpa e compilável baseada em Minimal API e preparada para Vertical Slices.

```text
HTTP
 ↓
Minimal API
 ↓
Feature / Slice
 ↓
Domain
 ↓
Infrastructure
```

Com projetos compartilhados:

```text
backend
└── src
    ├── APIs
    │   ├── MeuProjeto.API.Auth
    │   ├── MeuProjeto.API.Person
    │   ├── MeuProjeto.API.Admin
    │   └── MeuProjeto.API.Site
    │
    ├── Domain
    │   └── MeuProjeto.Domain
    │
    ├── Infrastructure
    │   └── MeuProjeto.Infrastructure
    │
    ├── Extensions
    │   └── MeuProjeto.Extensions
    │
    └── Shared
        └── MeuProjeto.Shared
```

As APIs devem concentrar os slices.

Os projetos compartilhados devem evitar replicação de código.

Sem funcionalidades de negócio.

Sem integrações externas.

Sem infraestrutura configurada.

Sem frontend.

O desenvolvimento funcional começa somente após a aprovação deste bootstrap e criação de tasks específicas para cada Vertical Slice.

---

# 29. Referência arquitetural

Usar como referência conceitual o projeto:

```text
https://github.com/gfmaurila/poc.vertical.slices.net8
```

O projeto de referência demonstra conceitos relacionados a:

```text
Minimal API
Vertical Slice Architecture
Domain
Endpoints
Extensions
Features
Infrastructure
```

A arquitetura deste starter, porém, deve evitar replicar `Domain`, `Infrastructure` e `Extensions` dentro de cada API.

Essas responsabilidades devem existir como projetos compartilhados:

```text
MeuProjeto.Domain
MeuProjeto.Infrastructure
MeuProjeto.Extensions
MeuProjeto.Shared
```

Componentes adicionais como:

```text
MediatR
Carter
FluentValidation
Mapster
Domain Events
Repository Pattern
Result Pattern
Entity Framework
JWT
Serilog
Docker
```

servem somente como referência futura.

Eles não devem ser instalados ou configurados no bootstrap inicial sem uma task específica.
