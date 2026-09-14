# Batch Base — .NET 10

Template base para desenvolvimento de aplicações **Batch/Console em C# e .NET 10**, orientado a processamento de dados entre tabelas de origem e destino utilizando **CQRS, Mediator, Entity Framework Core e SQL Server**.

O projeto foi pensado para rotinas batch simples, organizadas, testáveis e de fácil manutenção, sem adicionar componentes de infraestrutura desnecessários.

---

# 🚀 Stack

| Tecnologia            | Utilização                         |
| --------------------- | ---------------------------------- |
| C#                    | Linguagem principal                |
| .NET                  | .NET 10                            |
| Console Application   | Execução do Batch                  |
| CQRS                  | Separação das operações            |
| Mediator              | Orquestração de Commands e Queries |
| Entity Framework Core | Persistência                       |
| SQL Server            | Banco de dados                     |
| Dependency Injection  | Injeção de dependências            |
| Configuration         | Configuração da aplicação          |
| Logging               | Logs de execução                   |
| xUnit                 | Testes automatizados               |
| Moq                   | Mocks para testes                  |

> As versões das bibliotecas devem ser revalidadas antes da implementação para utilização de releases estáveis e compatíveis com o .NET 10.

---

# 🎯 Objetivo

O objetivo deste template é fornecer uma estrutura padronizada para criação de aplicações Batch responsáveis por:

```text
Tabela Origem
      ↓
Consulta
      ↓
CQRS Query
      ↓
Processamento
      ↓
CQRS Command
      ↓
Persistência
      ↓
Tabela Destino
```

O Batch pode ser utilizado para cenários como:

* carga de dados;
* transformação;
* consolidação;
* sincronização;
* migração;
* processamento periódico;
* atualização de tabelas;
* integração entre estruturas SQL Server.

---

# 🔄 Fluxo principal

O fluxo padrão da aplicação é:

```text
START
  │
  ▼
Carregar configurações
  │
  ▼
Inicializar dependências
  │
  ▼
Executar Batch
  │
  ▼
Query
  │
  ▼
Consultar tabela origem
  │
  ▼
Carregar registros
  │
  ▼
Processar dados
  │
  ▼
Command
  │
  ▼
Persistir tabela destino
  │
  ▼
Registrar resultado
  │
  ▼
END
```

De forma resumida:

```text
SOURCE
   ↓
 QUERY
   ↓
HANDLER
   ↓
PROCESS
   ↓
COMMAND
   ↓
HANDLER
   ↓
DESTINATION
```

---

# ⚡ CQRS

O projeto utiliza **CQRS — Command Query Responsibility Segregation** para separar operações de consulta das operações que modificam dados.

## Queries

Responsáveis pela leitura.

Exemplo:

```text
GetSourceRecordsQuery
        ↓
GetSourceRecordsQueryHandler
        ↓
SourceRepository
        ↓
SQL Server
        ↓
Tabela Origem
```

## Commands

Responsáveis pelas operações de escrita.

Exemplo:

```text
SaveDestinationRecordsCommand
        ↓
SaveDestinationRecordsCommandHandler
        ↓
DestinationRepository
        ↓
SQL Server
        ↓
Tabela Destino
```

---

# 🧩 Mediator

O Mediator é utilizado para desacoplar o fluxo principal dos handlers responsáveis pelas operações.

Exemplo:

```csharp
await mediator.Send(
    new GetSourceRecordsQuery(),
    cancellationToken);
```

Para persistência:

```csharp
await mediator.Send(
    new SaveDestinationRecordsCommand(records),
    cancellationToken);
```

O fluxo fica:

```text
Batch
  │
  ▼
Mediator
  │
  ├───────────────┐
  ▼               ▼
Query           Command
  │               │
  ▼               ▼
Handler         Handler
```

---

# 🏗️ Estrutura sugerida

```text
BatchBase/
│
├── src/
│   │
│   ├── BatchBase.Console/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── DependencyInjection.cs
│   │
│   ├── BatchBase.Application/
│   │   │
│   │   ├── Commands/
│   │   │   └── SaveDestination/
│   │   │       ├── SaveDestinationCommand.cs
│   │   │       └── SaveDestinationCommandHandler.cs
│   │   │
│   │   ├── Queries/
│   │   │   └── GetSource/
│   │   │       ├── GetSourceQuery.cs
│   │   │       └── GetSourceQueryHandler.cs
│   │   │
│   │   ├── DTOs/
│   │   │
│   │   ├── Interfaces/
│   │   │
│   │   └── Services/
│   │
│   ├── BatchBase.Domain/
│   │   ├── Entities/
│   │   ├── Models/
│   │   └── Interfaces/
│   │
│   └── BatchBase.Infrastructure/
│       │
│       ├── Persistence/
│       │   ├── SourceDbContext.cs
│       │   └── DestinationDbContext.cs
│       │
│       ├── Repositories/
│       │   ├── SourceRepository.cs
│       │   └── DestinationRepository.cs
│       │
│       └── Configuration/
│
├── tests/
│   ├── BatchBase.UnitTests/
│   └── BatchBase.IntegrationTests/
│
├── BatchBase.sln
└── README.md
```

---

# 🗄️ SQL Server

O banco utilizado pelo template é:

```text
SQL Server
```

O projeto pode trabalhar com:

```text
SQL Server
     │
     ├── Database Origem
     │       │
     │       └── Tabela Origem
     │
     └── Database Destino
             │
             └── Tabela Destino
```

Ou dentro do mesmo banco:

```text
Database
   │
   ├── Tabela Origem
   │
   └── Tabela Destino
```

---

# 🗃️ Entity Framework Core

O **Entity Framework Core** é responsável pelo acesso e persistência dos dados.

Uma separação recomendada é:

```text
SourceDbContext
      │
      └── leitura

DestinationDbContext
      │
      └── escrita
```

Isso deixa explícita a responsabilidade de cada contexto dentro do fluxo Batch.

---

# ⚙️ Configuração

Exemplo básico de `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SourceDatabase": "Server=localhost;Database=SourceDb;Trusted_Connection=True;TrustServerCertificate=True;",
    "DestinationDatabase": "Server=localhost;Database=DestinationDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Credenciais reais não devem ser armazenadas diretamente no repositório.

Para ambientes corporativos, utilize variáveis de ambiente, Secret Manager ou o mecanismo de secrets adotado pela infraestrutura.

---

# 🏃 Batch Runner

O ponto de entrada deve permanecer simples.

Exemplo conceitual:

```csharp
var host = Host.CreateApplicationBuilder(args);

host.Services.AddApplication();
host.Services.AddInfrastructure(host.Configuration);
host.Services.AddBatch();

using var app = host.Build();

var batch = app.Services.GetRequiredService<IBatchJob>();

await batch.ExecuteAsync();
```

A regra de processamento não deve ficar diretamente no `Program.cs`.

---

# 📦 Batch Job

A execução principal pode ser encapsulada através de uma interface:

```csharp
public interface IBatchJob
{
    Task ExecuteAsync(
        CancellationToken cancellationToken = default);
}
```

Implementação:

```text
BatchJob
   │
   ├── Consulta origem
   │
   ├── Processa registros
   │
   ├── Persiste destino
   │
   └── Registra resultado
```

---

# 🔄 Processamento

O processamento deve ficar isolado da infraestrutura.

Exemplo:

```text
Source Records
      ↓
Mapper
      ↓
Business Processing
      ↓
Validation
      ↓
Destination Model
      ↓
Persistence
```

Isso permite testar a transformação sem necessidade de banco de dados.

---

# 📊 Processamento em lote

Para volumes maiores, os registros podem ser processados em blocos.

Exemplo:

```text
10.000 registros
       │
       ▼
Batch Size = 1.000
       │
       ├── Lote 01
       ├── Lote 02
       ├── Lote 03
       ├── ...
       └── Lote 10
```

O tamanho do lote deve ser configurável conforme volume de dados, memória disponível e estratégia de persistência.

---

# 📝 Logging

A aplicação deve registrar pelo menos:

```text
Batch iniciado
Data/hora inicial

Quantidade encontrada

Quantidade processada

Quantidade inserida/atualizada

Quantidade rejeitada

Erros encontrados

Tempo total

Batch finalizado
```

Exemplo:

```text
[INFO] Batch iniciado
[INFO] Registros encontrados: 15000
[INFO] Registros processados: 15000
[INFO] Registros persistidos: 14998
[WARN] Registros rejeitados: 2
[INFO] Tempo total: 00:01:42
[INFO] Batch finalizado
```

---

# ⚠️ Tratamento de erros

Falhas devem ser tratadas de forma controlada.

Fluxo recomendado:

```text
Processamento
     │
     ▼
Erro?
 │
 ├── NÃO ─────► Continua
 │
 └── SIM
      │
      ▼
Registrar erro
      │
      ▼
Aplicar estratégia
      │
      ├── continuar
      └── abortar
```

Erros não devem ser simplesmente ignorados.

---

# 🧪 Testes

O projeto deve possuir testes para as principais responsabilidades.

## Unit Tests

Testam:

```text
Handlers
Services
Processors
Validators
Mappers
Regras de processamento
```

Sem necessidade de SQL Server real.

---

## Integration Tests

Validam:

```text
EF Core
Repositories
Queries
Commands
Persistência
Fluxo origem → destino
```

Quando possível, o ambiente de integração deve ser isolado do ambiente de desenvolvimento.

---

# 🖥️ Execução

Para restaurar dependências:

```powershell
dotnet restore
```

Compilar:

```powershell
dotnet build
```

Executar testes:

```powershell
dotnet test
```

Executar o Batch:

```powershell
dotnet run --project src/BatchBase.Console
```

Publicar para Windows:

```powershell
dotnet publish src/BatchBase.Console -c Release -r win-x64
```

---

# 🪟 Windows

O projeto é orientado à execução em ambiente Windows.

A aplicação publicada pode ser executada por:

```text
Windows Task Scheduler
PowerShell
CMD
Job corporativo
Orquestrador externo
```

Exemplo:

```powershell
BatchBase.Console.exe
```

---

# 🚫 Fora do escopo

Este template foi propositalmente criado como um **Batch simples e desacoplado de componentes distribuídos**.

Não fazem parte deste projeto:

```text
❌ Kafka
❌ RabbitMQ
❌ Redis
❌ MassTransit
❌ Domain Events
❌ REST API
❌ Minimal API
❌ Controllers
❌ Swagger
❌ Frontend
❌ React
❌ Angular
❌ WebSocket
```

A ausência desses componentes é intencional.

O fluxo esperado é:

```text
DATABASE
    ↓
BATCH
    ↓
DATABASE
```

e não:

```text
API
 ↓
MESSAGE BROKER
 ↓
EVENT
 ↓
MICROSERVICE
 ↓
CACHE
 ↓
DATABASE
```

---

# 🧭 Princípios

O template segue alguns princípios básicos:

```text
Simplicidade
     +
Separação de responsabilidades
     +
CQRS
     +
Código testável
     +
Baixo acoplamento
     +
Observabilidade
     +
Processamento previsível
```

Não devem ser adicionadas tecnologias sem necessidade real para o processamento Batch.

---

# ✅ Definition of Done

Uma rotina somente deve ser considerada concluída quando:

```text
[✓] Consulta de origem implementada

[✓] Query e QueryHandler implementados

[✓] Processamento implementado

[✓] Command e CommandHandler implementados

[✓] Persistência de destino implementada

[✓] Tratamento de erros implementado

[✓] Logging implementado

[✓] Build aprovado

[✓] Testes unitários aprovados

[✓] Testes de integração aprovados

[✓] Execução origem → destino validada

[✓] Documentação atualizada
```

---

# 📌 Resumo

## Plataforma

```text
C#
.NET 10
Console / Batch
Windows
```

## Arquitetura

```text
CQRS
Mediator
Dependency Injection
Separation of Concerns
```

## Dados

```text
Entity Framework Core
SQL Server
```

## Testes

```text
xUnit
Moq
Integration Tests
```

## Fluxo

```text
Tabela Origem
      ↓
CQRS Query
      ↓
Processamento
      ↓
CQRS Command
      ↓
Tabela Destino
```

---

# 🎯 Filosofia do template

Este projeto não pretende transformar uma rotina Batch em um microsserviço complexo.

A proposta é:

```text
LER
 ↓
PROCESSAR
 ↓
GRAVAR
 ↓
FINALIZAR
```

com uma arquitetura suficientemente organizada para permitir **manutenção, testes, evolução e reutilização**, sem adicionar complexidade que o problema não exige.

---

# 📄 Licença

Defina a licença conforme as necessidades do projeto ou da organização.
