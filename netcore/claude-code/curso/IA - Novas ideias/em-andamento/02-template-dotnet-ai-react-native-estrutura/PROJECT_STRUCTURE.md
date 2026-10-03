# Estrutura Oficial do Projeto

Este documento define a estrutura oficial de diretórios, projetos, módulos e arquivos do template.

A estrutura deve permanecer compatível com:

- ASP.NET Core;
- C#;
- DDD;
- CQRS;
- Domain Events;
- Integration Events;
- Transactional Outbox;
- Modular Monolith;
- React;
- React Native;
- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- AWS;
- Docker;
- Kubernetes;
- OpenTofu;
- OpenTelemetry;
- Inteligência Artificial;
- RAG;
- Tools;
- Agents;
- Architecture as Code;
- Structurizr;
- Draw.io;
- testes automatizados;
- agentes de desenvolvimento;
- Skills.

Princípio:

```text
LOCAL FIRST
    ↓
CONTAINER FIRST
    ↓
CLOUD READY
    ↓
AWS TARGET
```

---

# 1. Estrutura Raiz

```text
GFM.Template.CMS/
│
├── backend/
├── frontend/
├── mobile/
├── tests/
├── infrastructure/
├── deploy/
├── docs/
├── scripts/
├── tools/
│
├── .agents/
├── .github/
│   └── workflows/
│       ├── ci.yml
│       ├── security.yml
│       ├── docker.yml
│       └── deploy.yml
│
├── docker-compose.yml
├── docker-compose.override.yml
├── docker-compose.test.yml
│
├── .env.example
├── .gitignore
├── .editorconfig
│
├── prompts.md
├── CLAUDE.md
├── AGENTS.md
├── PROJECT_SKILLS.md
├── PROJECT_STRUCTURE.md
│
├── Directory.Build.props
├── Directory.Packages.props
│
├── GFM.Template.CMS.sln
│
└── README.md
```

---

# 2. Backend

```text
backend/
│
├── src/
├── workers/
├── batch/
└── tools/
```

A pasta `backend` concentra exclusivamente os projetos .NET.

---

# 3. Backend — APIs

```text
backend/
└── src/
    └── api/
        │
        ├── GFM.Template.CMS.Admin.API/
        │   ├── Controllers/
        │   ├── Endpoints/
        │   ├── Extensions/
        │   ├── Filters/
        │   ├── Middleware/
        │   ├── Configuration/
        │   ├── Properties/
        │   ├── Program.cs
        │   ├── appsettings.json
        │   ├── appsettings.Development.json
        │   ├── appsettings.HML.json
        │   └── GFM.Template.CMS.Admin.API.csproj
        │
        ├── GFM.Template.CMS.Site.API/
        │   ├── Controllers/
        │   ├── Endpoints/
        │   ├── Extensions/
        │   ├── Filters/
        │   ├── Middleware/
        │   ├── Configuration/
        │   ├── Properties/
        │   ├── Program.cs
        │   ├── appsettings.json
        │   ├── appsettings.Development.json
        │   ├── appsettings.HML.json
        │   └── GFM.Template.CMS.Site.API.csproj
        │
        └── GFM.Template.CMS.Mobile.API/
            ├── Controllers/
            ├── Endpoints/
            ├── Extensions/
            ├── Filters/
            ├── Middleware/
            ├── Configuration/
            ├── Properties/
            ├── Program.cs
            ├── appsettings.json
            ├── appsettings.Development.json
            ├── appsettings.HML.json
            └── GFM.Template.CMS.Mobile.API.csproj
```

## Responsabilidades

```text
Admin.API
    → backend do painel administrativo

Site.API
    → backend público/site

Mobile.API
    → backend específico para React Native
```

As APIs devem ser apenas pontos de entrada.

Não colocar regras de negócio diretamente nos Controllers ou Endpoints.

---

# 4. Core

```text
backend/
└── src/
    └── core/
        │
        ├── GFM.Template.CMS.Domain/
        ├── GFM.Template.CMS.Application/
        ├── GFM.Template.CMS.Infrastructure/
        └── GFM.Template.CMS.CrossCutting/
```

Dependência esperada:

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
Infraestrutura compartilhada
```

O `Domain` deve permanecer independente de Infrastructure, API, AWS, Kafka, RabbitMQ, Redis e providers de IA.

---

# 5. Domain

```text
GFM.Template.CMS.Domain/
│
├── Common/
│   ├── Abstractions/
│   ├── Events/
│   ├── Exceptions/
│   ├── Specifications/
│   └── ValueObjects/
│
├── Identity/
│   ├── Entities/
│   │   ├── User.cs
│   │   ├── Group.cs
│   │   ├── Role.cs
│   │   ├── Permission.cs
│   │   └── RefreshToken.cs
│   │
│   ├── ValueObjects/
│   ├── Events/
│   ├── Specifications/
│   ├── Services/
│   └── Repositories/
│
├── Content/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   ├── Specifications/
│   ├── Services/
│   └── Repositories/
│
├── Media/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   └── Repositories/
│
├── Navigation/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   └── Repositories/
│
├── Notifications/
│   ├── Entities/
│   ├── Events/
│   └── Repositories/
│
├── Audit/
│   ├── Entities/
│   └── Events/
│
├── AI/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   └── Services/
│
├── Shared/
│   ├── Enums/
│   └── Constants/
│
└── GFM.Template.CMS.Domain.csproj
```

---

# 6. Application

Organização por Feature / Vertical Slice:

```text
GFM.Template.CMS.Application/
│
├── Common/
│   ├── Abstractions/
│   ├── Behaviors/
│   ├── Exceptions/
│   ├── Interfaces/
│   ├── Mappings/
│   ├── Models/
│   └── Validation/
│
├── Features/
│   │
│   ├── Authentication/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── Handlers/
│   │   ├── Validators/
│   │   ├── DTOs/
│   │   ├── Mappings/
│   │   └── Services/
│   │
│   ├── Users/
│   │   ├── Commands/
│   │   │   ├── CreateUser/
│   │   │   ├── UpdateUser/
│   │   │   ├── DeleteUser/
│   │   │   └── ChangeUserStatus/
│   │   │
│   │   ├── Queries/
│   │   │   ├── GetUser/
│   │   │   ├── GetUsers/
│   │   │   └── SearchUsers/
│   │   │
│   │   ├── Handlers/
│   │   ├── Validators/
│   │   ├── DTOs/
│   │   └── Mappings/
│   │
│   ├── Groups/
│   ├── Roles/
│   ├── Permissions/
│   ├── Content/
│   ├── Media/
│   ├── ContentIntelligence/
│   │   ├── Ingestion/
│   │   ├── Orchestration/
│   │   ├── Documents/
│   │   ├── AudioIntelligence/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── Handlers/
│   │   ├── DTOs/
│   │   ├── Validators/
│   │   └── Services/
│   ├── Navigation/
│   ├── Notifications/
│   ├── Audit/
│   │
│   └── AI/
│       ├── Chat/
│       ├── RAG/
│       ├── Tools/
│       ├── Agents/
│       └── Knowledge/
│
└── GFM.Template.CMS.Application.csproj
```

---

# 7. Infrastructure

```text
GFM.Template.CMS.Infrastructure/
│
├── Persistence/
│   │
│   ├── MySql/
│   │   ├── Context/
│   │   ├── Configurations/
│   │   ├── Repositories/
│   │   ├── Migrations/
│   │   ├── Interceptors/
│   │   ├── Seed/
│   │   └── UnitOfWork/
│   │
│   └── MongoDB/
│       ├── Context/
│       ├── Collections/
│       ├── Documents/
│       ├── Repositories/
│       ├── Mappings/
│       └── Indexes/
│
├── Cache/
│   └── Redis/
│       ├── RedisCacheService.cs
│       ├── RedisConnectionFactory.cs
│       ├── RedisKeyFactory.cs
│       └── RedisCacheOptions.cs
│
├── Messaging/
│   │
│   ├── Abstractions/
│   │   └── IEventBus.cs
│   │
│   ├── Kafka/
│   │   ├── Producers/
│   │   ├── Consumers/
│   │   ├── Events/
│   │   ├── Serialization/
│   │   └── Configuration/
│   │
│   ├── RabbitMQ/
│   │   ├── Publishers/
│   │   ├── Consumers/
│   │   ├── Events/
│   │   ├── Configuration/
│   │   └── DeadLetter/
│   │
│   └── AWS/
│       ├── SQS/
│       └── SNS/
│
├── Outbox/
│   ├── Entities/
│   ├── Persistence/
│   ├── Processing/
│   └── Configuration/
│
├── Storage/
│   ├── Abstractions/
│   ├── Local/
│   ├── MinIO/
│   ├── S3/
│   ├── GoogleDrive/
│   ├── OneDrive/
│   └── SharePoint/
│
├── Identity/
│   ├── Jwt/
│   ├── Passwords/
│   ├── Cognito/
│   └── Authorization/
│
├── AI/
│   │
│   ├── Providers/
│   │   ├── Fake/
│   │   ├── Local/
│   │   └── Bedrock/
│   │
│   ├── Embeddings/
│   ├── SpeechToText/
│   │   ├── Abstractions/
│   │   ├── Fake/
│   │   ├── Local/
│   │   └── Cloud/
│   ├── MediaProcessing/
│   │   └── FFmpeg/
│   ├── Automation/
│   │   └── N8n/
│   ├── VectorStore/
│   ├── RAG/
│   ├── Tools/
│   ├── Agents/
│   └── Observability/
│
├── ExternalServices/
│   ├── Clients/
│   └── Resilience/
│
├── DependencyInjection/
│
└── GFM.Template.CMS.Infrastructure.csproj
```

## Ajuste importante

Redis não deve ficar em:

```text
Persistence/redis/UnitOfWorkRedis.cs
```

Redis passa para:

```text
Infrastructure/Cache/Redis/
```

MongoDB também não deve utilizar:

```text
SqlConnectionFactory
```

A infraestrutura MongoDB deve possuir abstrações e nomes próprios do MongoDB.

---

# 8. CrossCutting

```text
GFM.Template.CMS.CrossCutting/
│
├── Correlation/
│   ├── CorrelationIdMiddleware.cs
│   ├── CorrelationIdGenerator.cs
│   └── ICorrelationIdGenerator.cs
│
├── Logging/
│   ├── Extensions/
│   └── Middleware/
│
├── Health/
│   ├── MySqlHealthCheck.cs
│   ├── MongoDbHealthCheck.cs
│   ├── RedisHealthCheck.cs
│   ├── KafkaHealthCheck.cs
│   ├── RabbitMqHealthCheck.cs
│   └── ObjectStorageHealthCheck.cs
│
├── Observability/
│   ├── OpenTelemetry/
│   ├── Metrics/
│   ├── Tracing/
│   └── Logging/
│
├── Swagger/
│   └── SwaggerConfig.cs
│
├── Extensions/
│
└── GFM.Template.CMS.CrossCutting.csproj
```

Não manter Health Checks de bancos que não façam parte da configuração atual do template.

---

# 9. Workers

A estrutura antiga `arq/Consumer`, `arq/Producer` e Workers duplicados deve ser consolidada.

```text
backend/
└── workers/
    │
    ├── GFM.Template.CMS.Worker.Kafka/
    │   ├── Consumers/
    │   ├── Handlers/
    │   ├── Extensions/
    │   ├── Configuration/
    │   ├── Worker.cs
    │   ├── Program.cs
    │   ├── appsettings.json
    │   ├── appsettings.Development.json
    │   ├── appsettings.HML.json
    │   └── GFM.Template.CMS.Worker.Kafka.csproj
    │
    ├── GFM.Template.CMS.Worker.RabbitMQ/
    │   ├── Consumers/
    │   ├── Handlers/
    │   ├── Extensions/
    │   ├── Configuration/
    │   ├── Worker.cs
    │   ├── Program.cs
    │   └── GFM.Template.CMS.Worker.RabbitMQ.csproj
    │
    ├── GFM.Template.CMS.Worker.Outbox/
    │   ├── Processing/
    │   ├── Extensions/
    │   ├── Worker.cs
    │   ├── Program.cs
    │   └── GFM.Template.CMS.Worker.Outbox.csproj
    │
    ├── GFM.Template.CMS.Worker.AI/
    │   ├── Processing/
    │   ├── Agents/
    │   ├── RAG/
    │   ├── Extensions/
    │   ├── Worker.cs
    │   ├── Program.cs
    │   └── GFM.Template.CMS.Worker.AI.csproj
    │
    └── GFM.Template.CMS.Worker.Media/
        ├── Processing/
        ├── Transcription/
        ├── FFmpeg/
        ├── Handlers/
        ├── Extensions/
        ├── Worker.cs
        ├── Program.cs
        └── GFM.Template.CMS.Worker.Media.csproj
```

Redis não deve possuir um Worker genérico apenas para justificar sua presença.

Redis é prioritariamente:

```text
Cache
Distributed Cache
Temporary Data
```

Caso exista Redis Pub/Sub real, deverá ser documentado separadamente.

---

# 10. Batch

```text
backend/
└── batch/
    └── GFM.Template.CMS.Batch/
        ├── Commands/
        ├── Jobs/
        ├── Processing/
        ├── Services/
        ├── Extensions/
        ├── Configuration/
        ├── Scripts/
        ├── Program.cs
        ├── appsettings.json
        ├── appsettings.Development.json
        ├── appsettings.HML.json
        └── GFM.Template.CMS.Batch.csproj
```

---

# 11. React Admin

```text
frontend/
└── admin/
    ├── public/
    ├── src/
    │   ├── app/
    │   ├── assets/
    │   ├── components/
    │   ├── features/
    │   │   ├── authentication/
    │   │   ├── users/
    │   │   ├── groups/
    │   │   ├── roles/
    │   │   ├── permissions/
    │   │   ├── content/
    │   │   ├── media/
    │   │   ├── navigation/
    │   │   └── ai/
    │   ├── hooks/
    │   ├── layouts/
    │   ├── pages/
    │   ├── routes/
    │   ├── services/
    │   ├── stores/
    │   ├── types/
    │   └── utils/
    │
    ├── .env.example
    ├── package.json
    ├── tsconfig.json
    └── vite.config.ts
```

---

# 12. React Site

```text
frontend/
└── site/
    ├── public/
    ├── src/
    │   ├── app/
    │   ├── assets/
    │   ├── components/
    │   ├── features/
    │   ├── hooks/
    │   ├── layouts/
    │   ├── pages/
    │   ├── routes/
    │   ├── services/
    │   ├── stores/
    │   ├── types/
    │   └── utils/
    │
    ├── .env.example
    ├── package.json
    ├── tsconfig.json
    └── vite.config.ts
```

---

# 13. React Native

```text
mobile/
└── app/
    ├── src/
    │   ├── app/
    │   ├── assets/
    │   ├── components/
    │   ├── features/
    │   │   ├── authentication/
    │   │   ├── profile/
    │   │   ├── content/
    │   │   └── ai/
    │   ├── hooks/
    │   ├── navigation/
    │   ├── screens/
    │   ├── services/
    │   ├── stores/
    │   ├── types/
    │   └── utils/
    │
    ├── android/
    ├── ios/
    ├── .env.example
    ├── package.json
    └── tsconfig.json
```

---

# 14. Testes

Os testes devem acompanhar a arquitetura real.

```text
tests/
│
├── unit/
│   ├── GFM.Template.CMS.Domain.UnitTests/
│   └── GFM.Template.CMS.Application.UnitTests/
│
├── integration/
│   ├── GFM.Template.CMS.API.IntegrationTests/
│   ├── GFM.Template.CMS.Persistence.IntegrationTests/
│   ├── GFM.Template.CMS.Redis.IntegrationTests/
│   ├── GFM.Template.CMS.Kafka.IntegrationTests/
│   ├── GFM.Template.CMS.RabbitMQ.IntegrationTests/
│   └── GFM.Template.CMS.Outbox.IntegrationTests/
│
├── architecture/
│   └── GFM.Template.CMS.ArchitectureTests/
│
├── functional/
│   └── GFM.Template.CMS.FunctionalTests/
│
├── ai/
│   ├── GFM.Template.CMS.AI.Tests/
│   └── evaluation/
│
└── smoke/
    ├── docker/
    └── kubernetes/
```

---

# 15. Infrastructure

```text
infrastructure/
│
├── docker/
│   ├── backend/
│   ├── frontend/
│   ├── mobile/
│   └── services/
│
├── localstack/
│   ├── init/
│   └── scripts/
│
├── mysql/
│   └── init/
│
├── mongodb/
│   └── init/
│
├── redis/
│
├── kafka/
│
├── rabbitmq/
│
├── minio/
│
├── vector-store/
│
├── observability/
│   ├── otel/
│   ├── prometheus/
│   ├── grafana/
│   ├── loki/
│   └── tempo/
│
└── architecture/
    └── structurizr/
```

---

# 16. Deploy

```text
deploy/
│
├── kubernetes/
│   │
│   ├── base/
│   │   ├── api/
│   │   ├── workers/
│   │   ├── frontend/
│   │   ├── config/
│   │   └── kustomization.yaml
│   │
│   └── overlays/
│       ├── dev/
│       ├── hml/
│       └── prod/
│
├── opentofu/
│   │
│   ├── modules/
│   │   ├── networking/
│   │   ├── compute/
│   │   ├── database/
│   │   ├── cache/
│   │   ├── messaging/
│   │   ├── storage/
│   │   ├── security/
│   │   ├── observability/
│   │   └── ai/
│   │
│   └── environments/
│       ├── dev/
│       ├── hml/
│       └── prod/
│
└── aws/
    ├── scripts/
    └── configuration/
```

---

# 17. Arquitetura e Documentação

```text
docs/
│
├── architecture/
│   │
│   ├── structurizr/
│   │   ├── workspace.dsl
│   │   └── README.md
│   │
│   ├── drawio/
│   │   ├── system-context.drawio
│   │   ├── container.drawio
│   │   ├── component.drawio
│   │   ├── database-er.drawio
│   │   ├── cqrs-flow.drawio
│   │   ├── cache-flow.drawio
│   │   ├── domain-events.drawio
│   │   ├── integration-events.drawio
│   │   ├── outbox.drawio
│   │   ├── kafka-flow.drawio
│   │   ├── rabbitmq-flow.drawio
│   │   ├── iam-flow.drawio
│   │   ├── ai-flow.drawio
│   │   ├── rag-flow.drawio
│   │   ├── docker-architecture.drawio
│   │   ├── kubernetes-deployment.drawio
│   │   ├── local-architecture.drawio
│   │   ├── aws-architecture.drawio
│   │   └── observability.drawio
│   │
│   ├── adr/
│   │   ├── ADR-001-modular-monolith.md
│   │   ├── ADR-002-cqrs.md
│   │   ├── ADR-003-domain-events.md
│   │   ├── ADR-004-outbox.md
│   │   ├── ADR-005-redis.md
│   │   ├── ADR-006-messaging.md
│   │   ├── ADR-007-ai.md
│   │   ├── ADR-008-kubernetes.md
│   │   └── ADR-009-aws.md
│   │
│   └── exports/
│       ├── svg/
│       ├── png/
│       └── pdf/
│
├── api/
├── database/
├── deployment/
├── development/
├── testing/
├── security/
├── ai/
└── operations/
```

Os arquivos `.drawio` e `.dsl` são os artefatos editáveis oficiais.

Os arquivos em `exports/` são derivados.

---

# 18. Agentes e Skills

```text
.agents/
│
├── skills/
│   │
│   ├── project-architecture/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── backend-ddd-cqrs/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── frontend-react-architecture/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── frontend-react-native-architecture/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── crud-generation/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── identity-iam-authorization/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── content-platform/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── navigation-management/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── ai-application/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── rag/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── ai-tools-agents/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── testing/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   ├── docker-development/
│   │   ├── SKILL.md
│   │   └── references/
│   │
│   └── drawio-architecture/
│       ├── SKILL.md
│       └── references/
│
└── README.md
```

O `PROJECT_SKILLS.md` funciona como catálogo.

Cada:

```text
SKILL.md
```

contém as instruções executáveis daquela capacidade.

---

# 19. Scripts

```text
scripts/
│
├── setup/
│   ├── bootstrap.ps1
│   └── bootstrap.sh
│
├── database/
│   ├── migrate.ps1
│   ├── seed.ps1
│   └── reset.ps1
│
├── docker/
│   ├── up.ps1
│   ├── down.ps1
│   └── reset.ps1
│
├── kubernetes/
│   ├── create-cluster.ps1
│   ├── deploy.ps1
│   └── destroy-cluster.ps1
│
├── tests/
│   ├── unit.ps1
│   ├── integration.ps1
│   ├── architecture.ps1
│   └── all.ps1
│
└── architecture/
    ├── validate.ps1
    └── export.ps1
```

Sempre que possível, fornecer equivalentes `.sh` para ambientes Linux/macOS.

---

# 20. Tools

```text
tools/
├── architecture/
├── development/
├── testing/
└── generators/
```

Ferramentas auxiliares não pertencentes ao código de produção devem permanecer separadas da aplicação.

---

# 21. Estrutura Consolidada

```text
GFM.Template.CMS/
│
├── backend/
│   ├── src/
│   │   ├── api/
│   │   │   ├── GFM.Template.CMS.Admin.API/
│   │   │   ├── GFM.Template.CMS.Site.API/
│   │   │   └── GFM.Template.CMS.Mobile.API/
│   │   │
│   │   └── core/
│   │       ├── GFM.Template.CMS.Domain/
│   │       ├── GFM.Template.CMS.Application/
│   │       ├── GFM.Template.CMS.Infrastructure/
│   │       └── GFM.Template.CMS.CrossCutting/
│   │
│   ├── workers/
│   │   ├── GFM.Template.CMS.Worker.Kafka/
│   │   ├── GFM.Template.CMS.Worker.RabbitMQ/
│   │   ├── GFM.Template.CMS.Worker.Outbox/
│   │   └── GFM.Template.CMS.Worker.AI/
│   │
│   └── batch/
│       └── GFM.Template.CMS.Batch/
│
├── frontend/
│   ├── admin/
│   └── site/
│
├── mobile/
│   └── app/
│
├── tests/
│   ├── unit/
│   ├── integration/
│   ├── architecture/
│   ├── functional/
│   ├── ai/
│   └── smoke/
│
├── infrastructure/
│   ├── docker/
│   ├── localstack/
│   ├── mysql/
│   ├── mongodb/
│   ├── redis/
│   ├── kafka/
│   ├── rabbitmq/
│   ├── minio/
│   ├── vector-store/
│   ├── observability/
│   └── architecture/
│
├── deploy/
│   ├── kubernetes/
│   ├── opentofu/
│   └── aws/
│
├── docs/
│   ├── architecture/
│   │   ├── structurizr/
│   │   ├── drawio/
│   │   ├── adr/
│   │   └── exports/
│   ├── api/
│   ├── database/
│   ├── deployment/
│   ├── development/
│   ├── testing/
│   ├── security/
│   ├── ai/
│   └── operations/
│
├── scripts/
├── tools/
│
├── .agents/
│   └── skills/
│
├── .github/
│   └── workflows/
│       ├── ci.yml
│       ├── security.yml
│       ├── docker.yml
│       └── deploy.yml
│
├── docker-compose.yml
├── docker-compose.override.yml
├── docker-compose.test.yml
│
├── .env.example
├── .gitignore
├── .editorconfig
│
├── Directory.Build.props
├── Directory.Packages.props
│
├── prompts.md
├── CLAUDE.md
├── AGENTS.md
├── PROJECT_SKILLS.md
├── PROJECT_STRUCTURE.md
│
├── GFM.Template.CMS.sln
└── README.md
```

---

# 22. Regras Arquiteturais da Estrutura

A estrutura física deve seguir as seguintes regras:

1. `Domain` não depende de Infrastructure.
2. `Domain` não conhece MySQL, MongoDB, Redis, Kafka, RabbitMQ ou AWS.
3. `Application` coordena os casos de uso através de CQRS.
4. `Infrastructure` implementa persistência e integrações.
5. APIs são pontos de entrada e não concentram regras de negócio.
6. Redis é Cache/Distributed Cache, não banco transacional principal.
7. MySQL é a persistência relacional principal.
8. MongoDB somente deve existir quando houver caso de uso documentado.
9. Domain Events são diferentes de Integration Events.
10. Publicação externa deve suportar Transactional Outbox quando necessário.
11. Kafka e RabbitMQ possuem responsabilidades específicas e não devem ser usados simultaneamente sem justificativa.
12. AWS deve ser tratada como TARGET, sem impedir execução local.
13. Docker Compose permanece como principal ambiente de desenvolvimento local.
14. Kubernetes local é utilizado para validação de deployment.
15. OpenTofu representa Infrastructure as Code.
16. Structurizr representa Architecture as Code.
17. Draw.io representa diagramas detalhados editáveis.
18. OpenTelemetry é o padrão de instrumentação.
19. AI Tools devem utilizar Application/CQRS.
20. Agentes de IA não acessam diretamente bancos de negócio.
21. Skills devem representar as mesmas regras do `prompts.md`.
22. Diagramas devem representar a estrutura real.
23. Testes devem acompanhar a arquitetura real.
24. Documentação deve ser atualizada quando a arquitetura mudar.

---

# 23. Fluxo Arquitetural Principal

```text
React Admin
React Site
React Native
     │
     ▼
Admin API / Site API / Mobile API
     │
     ▼
Application
     │
     ├────────────── Queries
     │                   │
     │                   ▼
     │                 Redis
     │               HIT │ MISS
     │                   │
     │                   ▼
     │                 MySQL
     │
     └────────────── Commands
                         │
                         ▼
                       Domain
                         │
                         ▼
                       MySQL
                         │
                         ▼
                   Domain Events
                         │
                         ▼
                 Integration Events
                         │
                         ▼
                  Transactional Outbox
                         │
                         ▼
                     Event Bus
                    /         \
                 Kafka      RabbitMQ
                    \         /
                     \       /
                      Workers
                         │
                         ▼
                  External Systems
```

---

# 24. Fluxo de Inteligência Artificial

```text
React / React Native
        │
        ▼
ASP.NET Core
        │
        ▼
Application / CQRS
        │
        ▼
AI Orchestrator
        │
        ├── LLM
        │
        ├── RAG
        │    ├── Documents
        │    ├── Embeddings
        │    └── Vector Store
        │
        ├── Tools
        │      │
        │      ▼
        │   Commands / Queries
        │      │
        │      ▼
        │   Application
        │      │
        │      ▼
        │    Domain
        │
        ├── Agents
        │
        └── External APIs
```

## 24.1 Fluxo de Audio Intelligence

```text
React / React Native / API
        │
        ▼
Upload de áudio/vídeo
        │
        ▼
Object Storage (MinIO local / S3 target)
        │
        ▼
Fila / Worker.Media
        │
        ▼
FFmpeg
(normalização / extração de áudio)
        │
        ▼
ISpeechToTextProvider
        │
        ├── Fake / Local
        └── Cloud Provider
        │
        ▼
Transcrição + timestamps + metadados
        │
        ▼
AI Orchestrator
        ├── resumo / tópicos / capítulos
        ├── decisões / tarefas / entidades
        └── RAG / Embeddings / Vector Store
        │
        ├──────────────► Chat / Search / Agents
        │
        └──────────────► n8n / Webhooks / APIs externas
```

Regras:

1. O arquivo original permanece no Object Storage.
2. MySQL mantém estado do job, metadados e referências persistentes.
3. Arquivos grandes não devem bloquear request HTTP; utilizar processamento assíncrono.
4. n8n nunca acessa diretamente tabelas de negócio; integra-se por APIs, eventos ou Webhooks autorizados.
5. O provider de Speech-to-Text deve ser substituível sem alterar Domain/Application.
6. Transcrições só entram no RAG quando a política de segurança e autorização permitir.
7. OpenTelemetry deve rastrear o pipeline de upload, processamento, transcrição e enriquecimento por IA.

---

# 25. Fluxo LOCAL → AWS

```text
LOCAL                           AWS TARGET

React
  │
  └──────────────────────────→ CloudFront

ASP.NET Core
  │
  └──────────────────────────→ ECS / EKS

MySQL
  │
  └──────────────────────────→ RDS / Aurora MySQL

Redis
  │
  └──────────────────────────→ ElastiCache

Kafka
  │
  └──────────────────────────→ MSK

RabbitMQ
  │
  └──────────────────────────→ Amazon MQ

MinIO
  │
  └──────────────────────────→ S3

LocalStack
  │
  └──────────────────────────→ AWS Services

kind / k3d
  │
  └──────────────────────────→ EKS

Local/Fake LLM
  │
  └──────────────────────────→ Amazon Bedrock

OpenTelemetry
  │
  └──────────────────────────→ AWS Observability / compatible backend
```

---

# 26. Regra Final

A estrutura física do repositório deve representar a arquitetura definida pelo projeto.

A seguinte cadeia deve permanecer sincronizada:

```text
prompts.md
    ↓
PROJECT_STRUCTURE.md
    ↓
PROJECT_SKILLS.md
    ↓
ADRs
    ↓
Structurizr / C4
    ↓
Draw.io
    ↓
Código
    ↓
Infrastructure
    ↓
Docker
    ↓
Kubernetes
    ↓
AWS TARGET
    ↓
Testes
    ↓
Documentação
```

Nenhum agente deve criar diretórios, projetos ou camadas arquiteturais arbitrárias sem verificar primeiro:

```text
prompts.md
PROJECT_STRUCTURE.md
PROJECT_SKILLS.md
ADRs
arquitetura existente
código existente
```

Ao adicionar uma nova tecnologia ou responsabilidade, primeiro determinar onde ela pertence arquiteturalmente.

A estrutura do projeto não deve crescer por tecnologia sem necessidade.

A organização deve refletir responsabilidades reais.

# 25. AI Content Intelligence & Storage Orchestration

A arquitetura deve implementar a especificação `AI_CONTENT_INTELLIGENCE.md`. Storage é resolvido por tenant/perfil através de abstrações. Providers previstos: Local, MinIO, Amazon S3, Google Drive, OneDrive e SharePoint. Documentos, áudio e vídeo convergem para um Content Orchestrator e podem seguir para LLM, RAG, Agents/Tools e automações n8n. Credenciais são referenciadas por secrets e nunca persistidas em texto puro.

# 26. CI/CD oficial — GitHub Actions

O repositório oficial usa GitHub e GitHub Actions. Workflows mínimos: CI/build/test/quality, security scanning, Docker build/publish e deploy por ambiente com approvals/secrets. Não criar GitLab CI como pipeline principal.

# 27. BYOAI — AI Providers por tenant

O projeto deve suportar `ServerManaged`, `CustomerManaged` e `Hybrid`. Criar `AIProfile` por tenant e resolver providers em runtime por capacidade: LLM, Embeddings, Speech-to-Text, Text-to-Speech, Vision e Reranker quando necessário.

Estrutura sugerida:

```text
Application/AI/
├── Abstractions/
│   ├── IAIProfileResolver
│   ├── IAIProviderResolver
│   ├── ILLMProvider
│   ├── IEmbeddingProvider
│   ├── ISpeechToTextProvider
│   ├── ITextToSpeechProvider
│   └── IVisionProvider
Infrastructure/AI/Providers/
├── ServerManaged/
├── OpenAI/
├── AzureOpenAI/
├── Anthropic/
├── Gemini/
├── Bedrock/
├── OpenAICompatible/
└── FakeLocal/
```

`OpenAICompatible` deve permitir endpoint configurável para Ollama, vLLM ou servidores equivalentes. O provider concreto nunca deve vazar para Domain. Configuração persistida referencia secrets; secrets são resolvidos em runtime. Fallback para ServerManaged somente com consentimento/configuração explícita do tenant.
