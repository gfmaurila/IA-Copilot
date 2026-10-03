
# 🧩 Template

> Arquitetura completa com **.NET Core**, **DDD**, **CQRS**, **Kafka**, **RabbitMQ**, **Redis**, **MongoDB** e **SQL Server** pronta para escalabilidade, testes e integração com mensageria.

---

## 📐 Arquitetura

```
arq/
│
├── Kafka/
│   ├── Template.Message.Kafka.Consumer
│   └── Template.Message.Kafka.Producer
│
├── RabbitMQ/
│   ├── Template.Message.RabbitMQ.Consumer
│   └── Template.Message.RabbitMQ.Producer
│
├── Redis/
│   ├── Template.Message.Redis.Consumer
│   └── Template.Message.Redis.Producer
│
doc/
│   └── README.md
docker/
src/
├── API/
│   ├── Template.API
│   └── Producer/
│       ├── Template.Message.Kafka.Producer.Api
│       ├── Template.Message.RabbitMQ.Producer.Api
│       └── Template.Message.Redis.Producer.Api
│
├── Batch/
│   └── Template.Batch
│
├── Core/
│   ├── Template.Application
│   ├── Template.Crosscutting
│   ├── Template.Domain
│   └── Template.Infrastructure
│
├── Worker/
│   ├── Template.Message.Kafka.Consumer.Worker
│   ├── Template.Message.RabbitMQ.Consumer.Worker
│   └── Template.Message.Redis.Consumer.Worker
│
test/
```

---

## ⚙️ Tecnologias e Padrões

| Categoria       | Ferramenta / Padrão            |
|----------------|---------------------------------|
| Linguagem      | C# (.NET Core 8+)               |
| Arquitetura    | DDD, CQRS, Vertical Slice       |
| Mensageria     | Kafka, RabbitMQ, Redis Pub/Sub  |
| Bancos         | SQL Server, MongoDB             |
| Testes         | xUnit, Moq, TestContainers      |
| Infraestrutura | Docker, Docker Compose          |
| Serialização   | System.Text.Json / Newtonsoft   |
| Observabilidade| Serilog, HealthChecks           |

---

## 📦 Projetos

### 🔸 Core
- **Template.Application** — Handlers, UseCases e Interfaces (CQRS).
- **Template.Domain** — Entidades, agregados, enums e regras de negócio.
- **Template.Crosscutting** — Helpers, Extensions, Middlewares.
- **Template.Infrastructure** — MongoDB, SQL Server, Redis, Kafka, RabbitMQ.

### 🔸 API
- **Template.API** — API Gateway com rotas genéricas e versionamento.
- **Template.Message.*.Producer.Api** — Endpoints para publicação em tópicos/filas.

### 🔸 Worker
- **Template.Message.*.Consumer.Worker** — Serviços em background escutando tópicos/filas.
- Executam comandos (CommandHandler) via MediatR ou serviço dedicado.

### 🔸 Batch
- **Template.Batch** — Serviços de batch, ETLs ou execuções temporizadas.

### 🔸 arq/*
- Projetos dedicados à mensageria (produtor e consumidor puro).
- Usados para testes unitários, integração e workers manuais.

---

## 🛠️ Funcionalidades

- ✅ Publicação de mensagens em Kafka, RabbitMQ, Redis.
- ✅ Consumidores assíncronos com retry e dead-letter.
- ✅ Integração com bancos relacionais e NoSQL.
- ✅ Pattern MediatR para comandos e queries.
- ✅ HealthCheck para APIs e Workers.
- ✅ Logging estruturado com Serilog.
- ✅ Docker Compose para desenvolvimento local.

---

## 🚀 Execução

### Requisitos

- [.NET SDK 8+](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [MongoDB](https://hub.docker.com/_/mongo)
- [Kafka](https://hub.docker.com/r/bitnami/kafka/)
- [RabbitMQ](https://hub.docker.com/_/rabbitmq/)
- [Redis](https://hub.docker.com/_/redis/)
- [SQL Server](https://hub.docker.com/_/microsoft-mssql-server)

### Subindo os serviços

```bash
cd docker/
docker-compose up -d
```

### Rodando o projeto

```bash
cd src/API/Template.API
dotnet run
```

---

## 🧪 Testes

```bash
cd test/
dotnet test
```

- Testes de unidade com mocks (Moq)
- Testes de integração com testcontainers (Kafka, Mongo, SQL Server)

---

## 📚 Padrões adotados

- `CommandHandler` para escritas
- `QueryHandler` para leituras
- `NotificationHandler` para eventos internos
- `WorkerService` para consumidores e batches
- `Mapster` para mapeamento de DTOs
- `FluentValidation` para validação de dados

---

## 🧩 Extensões futuras

- ✅ Autenticação JWT
- ✅ Swagger + versionamento
- ✅ Retry Policy + Polly
- 🔜 OpenTelemetry / Jaeger
- 🔜 Event Sourcing / Outbox Pattern

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)


