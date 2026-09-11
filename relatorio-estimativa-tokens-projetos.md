# Relatório estimado de consumo de tokens --- Templates de projetos

**Data:** 11/09/2026\
**Objetivo:** estimar o consumo de tokens para um agente de IA/Copilot
gerar os projetos completos descritos nesta sequência de templates.

> **Importante:** estes números são estimativas de planejamento, não uma
> medição exata. O consumo real depende do modelo, quantidade de
> arquivos lidos a cada interação, tamanho das respostas, erros de
> build, número de ciclos de correção, logs enviados ao modelo e se o
> agente reutiliza contexto/cache.

------------------------------------------------------------------------

## 1. Projetos considerados

Este relatório considera os seguintes projetos criados/discutidos:

1.  **.NET Core --- DDD + CQRS + Domain Events**
2.  **PHP Laravel --- CQRS + MySQL**
3.  **Python FastAPI --- CQRS + Domain Events + MySQL**
4.  **Java Gradle / Spring Boot --- CQRS + MySQL**
5.  **Java Gradle / Spring Boot --- Arquitetura Hexagonal + CQRS +
    MySQL**
6.  **.NET Core --- Vertical Slice Architecture + Minimal APIs +
    Domain + CQRS**

Todos incluem, em maior ou menor grau:

-   Backend
-   autenticação
-   usuários
-   grupos
-   permissões Read/Write
-   banco de desenvolvimento
-   banco de testes
-   migrations
-   testes unitários
-   testes de integração
-   React Admin
-   React Site
-   Docker
-   Rules
-   Skills
-   Specs
-   documentação/instruções para Copilot/IA

------------------------------------------------------------------------

## 2. Como interpretar a estimativa

Foram criadas três faixas.

### Econômica

O agente lê apenas os arquivos necessários, implementa por etapas e
quase não encontra erros.

### Provável

Representa um desenvolvimento normal, com leitura das Rules/Skills,
geração de código, builds, testes e alguns ciclos de correção.

### Alta

Representa geração muito ampla em uma única execução, repetição de
contexto, logs grandes, erros de compilação/testes e várias correções.

Os valores abaixo representam aproximadamente **tokens totais
processados durante o trabalho**, somando contexto de entrada e conteúdo
gerado pelo agente. Não representam necessariamente tokens faturáveis de
uma API específica.

------------------------------------------------------------------------

## 3. Resumo geral

  -----------------------------------------------------------------------
  Projeto                 Econômica           Provável               Alta
  -------------- ------------------ ------------------ ------------------
  .NET DDD +                180 mil            320 mil            550 mil
  CQRS                                                 

  Laravel + CQRS            150 mil            270 mil            470 mil

  Python                    145 mil            260 mil            450 mil
  FastAPI + CQRS                                       

  Java Spring +             180 mil            325 mil            560 mil
  CQRS                                                 

  Java                      210 mil            380 mil            650 mil
  Hexagonal +                                          
  CQRS                                                 

  .NET Vertical             155 mil            280 mil            480 mil
  Slice +                                              
  Minimal API                                          

  **Total dos 6    **1,020 milhão**   **1,835 milhão**  **3,160 milhões**
  projetos**                                           
  -----------------------------------------------------------------------

### Média por projeto

-   Econômica: **\~170 mil tokens**
-   Provável: **\~306 mil tokens**
-   Alta: **\~527 mil tokens**

------------------------------------------------------------------------

# 4. .NET Core --- DDD + CQRS + Domain Events

## Arquitetura

``` text
API
Application
Domain
Infrastructure
CrossCutting
Tests
React Admin
React Site
```

Inclui:

-   DDD
-   CQRS
-   Commands
-   Queries
-   Handlers
-   Domain Events
-   MediatR
-   AutoMapper
-   FluentValidation
-   EF Core
-   autenticação JWT
-   Refresh Token
-   Users
-   Groups
-   Permissions
-   testes
-   Docker

## Estimativa

  Parte                  Tokens prováveis
  -------------------- ------------------
  Fundação/Solution                15.000
  Domain                           30.000
  Application/CQRS                 55.000
  Infrastructure/EF                35.000
  APIs/Auth                        35.000
  Testes                           45.000
  React Admin                      45.000
  React Site                       20.000
  Docker/Config                    15.000
  Correções/build                  25.000
  **Total provável**        **\~320.000**

**Faixa:** 180.000 a 550.000 tokens.

A estrutura em camadas tende a produzir mais arquivos e abstrações,
aumentando a quantidade de código e contexto.

------------------------------------------------------------------------

# 5. PHP Laravel --- CQRS + MySQL

## Arquitetura

``` text
Application
├── Commands
├── Queries
└── Handlers

Domain
Http
Infrastructure
Models
Policies
Events
```

Inclui:

-   Laravel
-   Eloquent
-   MySQL
-   CQRS
-   Commands/Queries/Handlers
-   Domain Events
-   Form Requests
-   API Resources
-   Policies/Gates
-   Sanctum/JWT conforme necessidade
-   React Admin/Site

## Estimativa

  Parte                  Tokens prováveis
  -------------------- ------------------
  Fundação Laravel                 10.000
  Models/Migrations                20.000
  CQRS                             45.000
  Auth/Policies                    30.000
  APIs                             25.000
  Testes                           35.000
  React Admin                      45.000
  React Site                       20.000
  Docker                           15.000
  Correções                        25.000
  **Total provável**        **\~270.000**

**Faixa:** 150.000 a 470.000 tokens.

Laravel reduz parte do boilerplate graças aos recursos nativos do
framework.

------------------------------------------------------------------------

# 6. Python FastAPI --- CQRS + Domain Events + MySQL

## Arquitetura

``` text
api
application
├── commands
├── queries
├── handlers
└── dtos
domain
infrastructure
core
```

Inclui:

-   FastAPI
-   SQLAlchemy 2
-   Alembic
-   Pydantic
-   MySQL
-   CQRS
-   Domain Events
-   JWT
-   pytest
-   React Admin/Site

## Estimativa

  Parte                   Tokens prováveis
  --------------------- ------------------
  Fundação FastAPI                  12.000
  Domain                            20.000
  CQRS                              40.000
  SQLAlchemy/Alembic                25.000
  Auth                              25.000
  APIs                              20.000
  Testes                            35.000
  React Admin                       45.000
  React Site                        20.000
  Docker/Correções                  18.000
  Leitura Rules/Specs               20.000
  **Total provável**         **\~260.000**

**Faixa:** 145.000 a 450.000 tokens.

Python normalmente exige menos boilerplate que Java ou uma implementação
DDD/CQRS mais formal em .NET.

------------------------------------------------------------------------

# 7. Java Gradle + Spring Boot --- CQRS + MySQL

## Arquitetura

``` text
api
application
├── command
├── query
└── handler
domain
infrastructure
config
```

Inclui:

-   Java LTS
-   Spring Boot
-   Gradle Kotlin DSL
-   Spring Security
-   Spring Data JPA
-   Hibernate
-   Flyway
-   MySQL
-   CQRS
-   Domain Events
-   JWT
-   Testcontainers
-   React

## Estimativa

  Parte                        Tokens prováveis
  -------------------------- ------------------
  Gradle/Spring Foundation               20.000
  Domain                                 25.000
  CQRS                                   50.000
  JPA/Flyway                             30.000
  Spring Security/JWT                    35.000
  APIs                                   25.000
  Testes/Testcontainers                  45.000
  React Admin                            45.000
  React Site                             20.000
  Docker/Correções                       30.000
  **Total provável**              **\~325.000**

**Faixa:** 180.000 a 560.000 tokens.

Java tende a consumir mais tokens devido à quantidade de classes, tipos,
configurações, testes e código de infraestrutura.

------------------------------------------------------------------------

# 8. Java Gradle + Arquitetura Hexagonal + CQRS + MySQL

## Arquitetura

``` text
Domain
    ↑
Application
├── Port In
├── Port Out
└── Use Cases
    ↑
Adapters
├── In/Web
└── Out/Persistence/Security
```

Inclui:

-   Arquitetura Hexagonal
-   Ports & Adapters
-   CQRS
-   Domain Events
-   separação Domain Entity / JPA Entity
-   mappers
-   Input Ports
-   Output Ports
-   Persistence Adapters
-   Spring Boot
-   MySQL
-   Flyway
-   JWT
-   Testcontainers
-   React

## Estimativa

  Parte                          Tokens prováveis
  ---------------------------- ------------------
  Fundação                                 20.000
  Domain                                   35.000
  Input/Output Ports                       35.000
  Commands/Queries/Use Cases               55.000
  Persistence Adapters                     40.000
  Security Adapter                         30.000
  Web Adapters                             25.000
  Testes                                   55.000
  React Admin/Site                         65.000
  Docker/Config                            15.000
  Correções                                35.000
  Leitura Rules/Specs                      10.000
  **Total provável**                **\~380.000**

**Faixa:** 210.000 a 650.000 tokens.

Este é o projeto com maior consumo estimado porque há mais fronteiras
arquiteturais e arquivos: Ports, Adapters, Use Cases, Domain Models, JPA
Entities e Mappers.

------------------------------------------------------------------------

# 9. .NET Core --- Vertical Slice + Minimal APIs + Domain + CQRS

## Arquitetura

``` text
API
└── Features
    ├── Users
    │   ├── Create
    │   ├── Update
    │   ├── Delete
    │   ├── GetById
    │   └── GetPaged
    ├── Groups
    └── Auth

Domain
Infrastructure
```

Cada Slice concentra:

``` text
Command/Query
Validator
Handler
Endpoint
Response
```

Inclui:

-   ASP.NET Core
-   Minimal APIs
-   Vertical Slice Architecture
-   CQRS
-   Domain
-   Domain Events
-   EF Core
-   FluentValidation
-   MediatR
-   JWT
-   Policies
-   React
-   testes
-   Docker

## Estimativa

  Parte                  Tokens prováveis
  -------------------- ------------------
  Fundação                         15.000
  Domain                           25.000
  Users Slices                     35.000
  Groups Slices                    35.000
  Auth Slices                      20.000
  Infrastructure                   25.000
  Testes                           40.000
  React Admin                      45.000
  React Site                       20.000
  Docker/Config                    10.000
  Correções                        10.000
  **Total provável**        **\~280.000**

**Faixa:** 155.000 a 480.000 tokens.

Vertical Slice tende a reduzir contexto cruzado porque uma
funcionalidade pode ser implementada lendo apenas o Slice e os contratos
compartilhados relevantes.

------------------------------------------------------------------------

# 10. Comparação de consumo

Do menor para o maior consumo provável:

``` text
Python FastAPI + CQRS              ~260k
Laravel + CQRS                     ~270k
.NET Vertical Slice + Minimal API  ~280k
.NET DDD + CQRS                    ~320k
Java Spring + CQRS                 ~325k
Java Hexagonal + CQRS              ~380k
```

A diferença não significa que uma arquitetura seja melhor que outra. Ela
representa principalmente o volume de abstrações e arquivos que o agente
precisa gerar e reler.

------------------------------------------------------------------------

# 11. Onde os tokens são gastos

O maior custo não costuma estar apenas na geração inicial do código.

Em uma execução com agente/Copilot, o consumo pode ser aproximadamente:

  Atividade                           Participação aproximada
  --------------------------------- -------------------------
  Leitura de Markdown/Rules/Specs                     10--15%
  Geração inicial                                     30--40%
  Testes                                              10--15%
  Logs de build/erros                                 10--15%
  Correções                                           15--25%
  Releitura de arquivos/contexto                      10--20%

As porcentagens se sobrepõem conforme a ferramenta e o fluxo de
execução; servem apenas como referência operacional.

------------------------------------------------------------------------

# 12. Por que Rules + Skills + Specs ajudam

A estrutura criada para estes projetos pode reduzir desperdício porque
evita repetir no prompt coisas como:

``` text
Use CQRS
Use FluentValidation
Use Minimal API
Crie testes
Use JWT
Use MySQL
Use React
Use paginação
```

A informação fica persistida no repositório:

``` text
CRIAR-PROJETO.md
tasks/
├── rules/
├── skills/
└── specs/
```

Assim, uma nova tarefa pode ser curta:

``` text
Execute a Spec 002 seguindo CRIAR-PROJETO.md,
Rules e Skills necessárias.
Faça build e testes antes de concluir.
```

------------------------------------------------------------------------

# 13. Estratégia recomendada para economizar tokens

Não pedir ao agente para criar o projeto inteiro em uma única interação.

Uma sequência melhor é:

``` text
Spec 001 - Foundation
Spec 002 - Domain Users
Spec 003 - Auth
Spec 004 - Users CRUD
Spec 005 - Groups/Permissions
Spec 006 - Admin Frontend
Spec 007 - Site Frontend
Spec 008 - Integration Tests
Spec 009 - Docker
Spec 010 - CI/CD
```

Cada execução deve ler:

``` text
CRIAR-PROJETO.md
        ↓
Rules relevantes
        ↓
Spec atual
        ↓
Skills necessárias
```

e **não todas as Skills existentes**.

------------------------------------------------------------------------

# 14. Potencial de economia com execução segmentada

Uma estrutura mal utilizada pode chegar à faixa alta:

``` text
Java Hexagonal
~650.000 tokens
```

Com Specs pequenas, contexto seletivo e builds frequentes, a mesma
implementação pode ficar mais próxima de:

``` text
~250.000–380.000 tokens
```

A economia potencial em projetos grandes pode ficar aproximadamente
entre **25% e 45%**, dependendo principalmente de quanto contexto é
repetido e quantos ciclos de correção são necessários.

------------------------------------------------------------------------

# 15. Estimativa consolidada

Para gerar **todos os seis projetos completos**:

### Cenário econômico

``` text
~1.020.000 tokens
```

### Cenário provável

``` text
~1.835.000 tokens
```

### Cenário de alto consumo

``` text
~3.160.000 tokens
```

Portanto, para planejamento, eu reservaria aproximadamente:

> **1,8 a 2,0 milhões de tokens processados para gerar os seis projetos
> completos**, considerando geração, leitura do repositório, testes e
> algumas correções.

------------------------------------------------------------------------

# 16. Projeto mais eficiente para IA

Considerando somente organização do código + facilidade de geração
incremental, a estrutura:

``` text
.NET
+ Vertical Slice Architecture
+ Minimal APIs
+ CQRS
+ Domain
```

é particularmente interessante.

Uma Spec pode apontar diretamente para:

``` text
Features/Users/Create
```

e o agente precisa trabalhar principalmente com:

``` text
Command
Validator
Handler
Endpoint
Response
Domain
Infrastructure necessária
```

Isso reduz a necessidade de navegar repetidamente por muitas camadas
horizontais.

------------------------------------------------------------------------

# 17. Observação final

Token não equivale diretamente a custo financeiro.

Para calcular custo em dinheiro é necessário saber:

-   modelo utilizado;
-   preço de input;
-   preço de output;
-   eventual preço de cached input;
-   ferramenta utilizada;
-   política de cobrança vigente.

A fórmula geral, para uso via API, seria:

``` text
Custo =
(tokens_input / 1.000.000 × preço_input)
+
(tokens_output / 1.000.000 × preço_output)
+
(tokens_cached / 1.000.000 × preço_cached)
```

Por isso este relatório trata **consumo estimado de tokens**, sem
transformar os valores em reais ou dólares.
