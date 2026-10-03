# EVOLUÇÃO 03 — ARQUITETURA LOCAL FIRST, AWS READY, KUBERNETES, IA E ARCHITECTURE AS CODE

Leia integralmente, nesta ordem:

1. `prompts.md`;
2. toda a documentação existente do projeto;
3. o estado atual do código-fonte;
4. infraestrutura;
5. Docker;
6. diagramas;
7. testes;
8. configurações;
9. ADRs existentes;
10. artefatos gerados pelas execuções anteriores.

Este documento representa a TERCEIRA EVOLUÇÃO do planejamento.

O objetivo NÃO é criar um projeto novo.

O objetivo é RETOMAR o projeto existente e incorporar estes novos requisitos ao `prompts.md`, preservando tudo que já estiver corretamente implementado pelas etapas anteriores.

---

# 1. REGRA PRINCIPAL DE RETOMADA

NÃO recrie o projeto do zero.

NÃO descarte implementações corretas existentes.

NÃO reverta requisitos introduzidos anteriormente.

Antes de alterar qualquer coisa:

1. leia integralmente o `prompts.md`;
2. leia toda a documentação existente;
3. analise a estrutura física atual;
4. analise código existente;
5. analise Docker e Docker Compose;
6. analise diagramas existentes;
7. analise infraestrutura;
8. analise testes;
9. analise configurações TEST/DEV/HML/PROD;
10. identifique o que já foi implementado;
11. compare implementação e documentação;
12. identifique:
    - tarefas concluídas;
    - tarefas parcialmente concluídas;
    - tarefas pendentes;
    - inconsistências;
    - novos requisitos desta evolução;
13. preserve tudo que estiver correto;
14. corrija somente o necessário;
15. continue a partir do estado atual.

---

# 2. PRIMEIRA TAREFA OBRIGATÓRIA — EVOLUIR O `prompts.md`

ANTES de implementar os novos requisitos deste documento:

Atualize o `prompts.md` principal incorporando integralmente esta terceira evolução.

O `prompts.md` continuará sendo a fonte principal de verdade arquitetural do projeto.

Atualize também, quando existirem:

- `README.md`;
- `REQUIREMENTS.md`;
- `ARCHITECTURE_PLAN.md`;
- `EXECUTION_PLAN.md`;
- `CLAUDE.md`;
- `AGENTS.md`;
- documentação Docker;
- documentação Kubernetes;
- documentação AWS;
- documentação de IA;
- documentação de mensageria;
- documentação de observabilidade;
- documentação de cache;
- documentação de testes;
- documentação de segurança;
- documentação de deployment;
- ADRs;
- diagramas.

Não apenas documente.

Depois da atualização documental, implemente efetivamente tudo que puder ser executado localmente.

---

# 3. PRINCÍPIO ARQUITETURAL

A partir desta evolução, o projeto deverá seguir:

LOCAL FIRST
    ↓
CONTAINER FIRST
    ↓
CLOUD READY
    ↓
AWS TARGET

O desenvolvimento diário NÃO deverá depender de uma conta AWS.

A arquitetura deverá permitir equivalência entre componentes locais e serviços AWS.

Objetivo:

LOCAL
→ Docker Compose

LOCAL CLOUD SIMULATION
→ LocalStack

LOCAL ORCHESTRATION
→ Kubernetes

CLOUD
→ AWS

O Domain e Application não devem depender diretamente de AWS, Docker, Kubernetes ou fornecedores específicos.

---

# 4. MODULAR MONOLITH CONTINUA SENDO O PADRÃO

Preservar a decisão existente de Modular Monolith.

Não transformar automaticamente cada módulo em microsserviço.

Manter:

Domain
Application
Infrastructure
API
CrossCutting

e os módulos existentes.

Kafka, RabbitMQ, Kubernetes e AWS NÃO significam que o sistema precisa ser quebrado imediatamente em microsserviços.

A arquitetura deverá permitir evolução futura sem exigir essa evolução agora.

---

# 5. ARCHITECTURE AS CODE

Além dos diagramas existentes, adotar Architecture as Code.

Utilizar como padrão principal:

C4 Model
+
Structurizr DSL

Utilizar preferencialmente:

Structurizr Lite

para visualização local.

Criar estrutura semelhante:

docs/
└── architecture/
    ├── structurizr/
    │   ├── workspace.dsl
    │   └── README.md
    │
    ├── drawio/
    │
    ├── adr/
    │
    ├── exports/
    │
    └── README.md

A localização final deve respeitar a estrutura existente do projeto.

Não reorganizar arquivos apenas para reproduzir este exemplo.

---

# 6. C4 MODEL

Gerar pelo menos:

C4 System Context

C4 Container

C4 Component

Deployment Diagram

Representar:

React Web
React Native
ASP.NET Core
Application
Domain
Infrastructure
IAM
AI
MySQL
MongoDB
Redis
Kafka
RabbitMQ
AWS
Observabilidade
Serviços externos

Os diagramas devem representar a implementação real e também identificar claramente componentes planejados.

Não apresentar componente planejado como se já estivesse implementado.

---

# 7. DRAW.IO

Os diagramas Draw.io existentes NÃO devem ser descartados.

Continuar mantendo diagramas editáveis.

Structurizr/C4 passa a complementar e estruturar Architecture as Code.

Draw.io continuará sendo utilizado para:

- arquitetura detalhada;
- ER;
- UML;
- fluxos;
- sequências;
- IAM;
- AI Flow;
- AWS;
- deployment;
- diagramas especiais.

Quando possível:

Structurizr
→ visão arquitetural versionável

Draw.io
→ diagramas detalhados/editáveis

---

# 8. ARCHITECTURE DECISION RECORDS

Criar ADRs para decisões arquiteturais relevantes.

Exemplos:

ADR-001-modular-monolith.md
ADR-002-cqrs.md
ADR-003-redis-cache.md
ADR-004-domain-events.md
ADR-005-transactional-outbox.md
ADR-006-kafka.md
ADR-007-rabbitmq.md
ADR-008-aws-target.md
ADR-009-local-development.md
ADR-010-kubernetes.md
ADR-011-observability.md
ADR-012-ai-orchestration.md
ADR-013-bedrock.md
ADR-014-iac.md

Cada ADR deverá conter:

Context

Decision

Alternatives Considered

Consequences

Status

Não criar ADR vazio apenas para aumentar quantidade de documentação.

---

# 9. ARQUITETURA AWS DE REFERÊNCIA

Planejar uma arquitetura AWS semelhante conceitualmente a:

Internet
    ↓
Route 53
    ↓
CloudFront
    ↓
WAF
    ↓
API Gateway
    ↓
Authentication / Cognito
    ↓
Compute
    ↓
ASP.NET Core

Compute poderá considerar:

ECS

EKS

Lambda

EC2

A escolha definitiva deverá ser documentada por cenário.

Não obrigar todos simultaneamente em produção.

---

# 10. AWS — SERVIÇOS QUE DEVEM FAZER PARTE DO PLANEJAMENTO

Planejar e documentar:

Route 53

CloudFront

WAF

API Gateway

Cognito

SQS

SNS

Lambda

S3

EC2

ECS

EKS

RDS / Aurora MySQL

ElastiCache

MSK quando Kafka gerenciado fizer sentido

Amazon MQ quando RabbitMQ gerenciado fizer sentido

Amazon Bedrock

Observabilidade AWS quando aplicável

Secrets Manager / Parameter Store quando aplicável

IAM

Não implementar serviço apenas para marcar checkbox.

Cada serviço deverá possuir responsabilidade clara.

---

# 11. EQUIVALÊNCIA LOCAL → AWS

Documentar explicitamente equivalências.

Exemplo conceitual:

MySQL Docker
→ RDS/Aurora MySQL

Redis Docker
→ ElastiCache

Kafka Docker
→ Amazon MSK

RabbitMQ Docker
→ Amazon MQ

MinIO/local storage
→ Amazon S3

LocalStack
→ APIs AWS

Container local
→ ECS/EKS

Kubernetes local
→ EKS quando escolhido

LLM local/provider fake
→ Amazon Bedrock

OpenTelemetry local
→ backend de observabilidade AWS quando escolhido

A aplicação não deverá depender dessas equivalências diretamente.

Utilizar abstrações e configuração.

---

# 12. AWS LOCAL COM LOCALSTACK

Utilizar LocalStack quando apropriado para desenvolvimento e testes locais.

Preparar inicialmente suporte para:

S3

SQS

SNS

Lambda

e outros serviços realmente utilizados pelo projeto.

O código deverá permitir configuração:

Provider = Local

ou:

Provider = AWS

Não espalhar verificações como:

if development use local
else use aws

por regras de negócio.

Centralizar provider/configuração na Infrastructure/Composition Root.

---

# 13. INFRASTRUCTURE AS CODE

Preparar Infrastructure as Code.

Preferir ferramenta open source/gratuita quando possível.

Adotar:

OpenTofu

ou, quando houver justificativa:

Terraform.

Documentar a decisão em ADR.

Criar estrutura semelhante:

infra/
├── local/
├── aws/
├── kubernetes/
└── modules/

A estrutura final deverá respeitar o repositório existente.

Planejar IaC para os principais recursos AWS.

Não executar criação de recursos AWS reais sem autorização e credenciais apropriadas.

---

# 14. DOCKER COMPOSE CONTINUA SENDO O AMBIENTE PRINCIPAL LOCAL

Preservar o Docker Compose existente.

Não substituí-lo por Kubernetes.

Docker Compose deverá continuar sendo a forma mais simples de executar o projeto localmente.

Objetivo:

docker compose up -d

O ambiente deverá suportar, conforme os módulos habilitados:

backend

frontend

MySQL

MongoDB

Redis

Kafka

RabbitMQ

LocalStack

MinIO quando necessário

Vector Database quando RAG estiver habilitado

OpenTelemetry Collector

Prometheus

Grafana

Loki

Tempo

Structurizr Lite

Não subir obrigatoriamente todos os componentes em todas as execuções.

---

# 15. DOCKER COMPOSE PROFILES

Criar profiles quando tecnicamente adequado.

Exemplo:

core

messaging

observability

aws-local

ai

architecture

full

Exemplo de intenção:

docker compose --profile core up -d

docker compose --profile messaging up -d

docker compose --profile observability up -d

docker compose --profile aws-local up -d

docker compose --profile architecture up -d

docker compose --profile full up -d

Evitar consumir memória e CPU com serviços não necessários ao trabalho atual.

---

# 16. KUBERNETES LOCAL

Adicionar Kubernetes ao planejamento e implementação.

Kubernetes NÃO deverá substituir Docker Compose.

Objetivos diferentes:

Docker Compose
→ desenvolvimento diário

Kubernetes Local
→ validação de deployment/orquestração

AWS
→ ambiente cloud alvo

Utilizar preferencialmente uma alternativa gratuita/local:

kind

ou:

k3d

Avaliar e documentar a escolha.

---

# 17. MANIFESTS KUBERNETES

Criar estrutura para manifests.

Exemplo:

deploy/
└── kubernetes/
    ├── base/
    └── overlays/
        ├── dev/
        ├── hml/
        └── prod/

Utilizar Kustomize quando apropriado.

Preparar:

Deployment

Service

ConfigMap

Secret templates

Ingress

PersistentVolumeClaim quando necessário

HorizontalPodAutoscaler quando justificado

Liveness Probe

Readiness Probe

Resource requests

Resource limits

Não versionar secrets reais.

---

# 18. ECS VS EKS

Documentar a diferença entre ECS e EKS para este projeto.

Não assumir automaticamente que Kubernetes local obriga produção em EKS.

Avaliar:

complexidade

custos

portabilidade

operação

necessidade de Kubernetes

equipe

escalabilidade

vendor lock-in

O projeto deverá estar preparado para containers independentemente da decisão final.

---

# 19. CRUD DE REFERÊNCIA END-TO-END

Preservar o requisito do CRUD completo introduzido anteriormente.

Criar ou consolidar um módulo de referência.

Exemplo:

Products

ou entidade equivalente já existente.

Implementar:

Create

Read

Read By Id

Update

Delete

Search

Pagination

Filtering

Sorting

Validation

Authorization

Audit

Logs

Domain Events

Cache

Integration Events quando aplicável

Testes

O CRUD deverá servir como referência arquitetural para futuros módulos.

---

# 20. CQRS

Preservar separação explícita:

Commands
→ escrita

Queries
→ leitura

Fluxo de escrita:

API
→ Command
→ Command Handler
→ Domain
→ Repository
→ MySQL
→ Domain Events

Fluxo de leitura:

API
→ Query
→ Query Handler
→ Cache
→ Read Store

Não introduzir CQRS apenas nominalmente.

Commands e Queries devem possuir responsabilidades realmente separadas.

---

# 21. REDIS — CACHE ASIDE

Utilizar Redis como cache distribuído.

Padrão principal:

Cache Aside.

Fluxo:

Query
    ↓
Redis
    ↓
CACHE HIT
    ↓
Response

ou:

Query
    ↓
Redis
    ↓
CACHE MISS
    ↓
Persistence
    ↓
Redis SET
    ↓
Response

Implementar:

cache key strategy

TTL

invalidation

serialization

cache miss

fallback

observability

A indisponibilidade do Redis não pode provocar perda dos dados persistentes.

---

# 22. INVALIDAÇÃO DE CACHE

Create/Update/Delete devem avaliar invalidação ou atualização do cache correspondente.

Preferir consistência previsível.

Documentar estratégia.

Testar:

MISS

SET

HIT

UPDATE

INVALIDATION

DELETE

REDIS UNAVAILABLE

Não usar Redis como fonte primária de dados transacionais.

---

# 23. MYSQL

MySQL continua sendo o banco transacional principal.

Responsabilidade:

dados transacionais

aggregates

estado consistente de negócio

Outbox quando implementado

Manter isolamento:

TEST

DEV

HML

PROD

---

# 24. MONGODB

MongoDB deverá fazer parte da infraestrutura disponível.

Utilizar somente quando houver justificativa.

Possíveis responsabilidades:

documentos

read models

projeções

histórico

dados semi-estruturados

resultados de IA

Não duplicar indiscriminadamente todos os dados do MySQL.

Documentar a responsabilidade real utilizada.

---

# 25. DOMAIN EVENTS

Preservar Domain Events.

Exemplos:

EntityCreatedDomainEvent

EntityUpdatedDomainEvent

EntityDeletedDomainEvent

Domain Events pertencem ao domínio.

Não devem conhecer:

Kafka

RabbitMQ

SQS

SNS

AWS

---

# 26. DOMAIN EVENT VS INTEGRATION EVENT

Separar explicitamente:

Domain Event

de:

Integration Event

Fluxo conceitual:

Aggregate
    ↓
Domain Event
    ↓
Domain Event Handler
    ↓
Integration Event
    ↓
Outbox
    ↓
Message Broker

Nem todo Domain Event precisa gerar Integration Event.

Documentar essa diferença.

---

# 27. TRANSACTIONAL OUTBOX

Implementar ou consolidar Transactional Outbox Pattern.

Objetivo:

evitar situação:

dados persistidos com sucesso
+
evento externo perdido

Persistir na mesma transação quando aplicável:

Business Data

+

Outbox Message

Depois:

Outbox Processor
    ↓
Event Bus
    ↓
Broker

Implementar:

MessageId

EventType

Payload

OccurredAt

ProcessedAt

CorrelationId

RetryCount quando apropriado

Status quando apropriado

---

# 28. IDEMPOTÊNCIA

Consumers devem ser preparados para mensagens duplicadas.

Implementar estratégia de idempotência.

Utilizar identificador único da mensagem/evento.

Garantir que reprocessamento não provoque:

duplicação de dados

duplicação de operações

efeitos colaterais indevidos

Testar cenários duplicados.

---

# 29. KAFKA

Kafka deverá ser disponibilizado localmente.

Responsabilidade preferencial:

event streaming

eventos distribuídos

integrações orientadas a eventos

Criar exemplos funcionais de:

Producer

Consumer

Implementar quando aplicável:

retry

idempotência

correlation ID

observabilidade

tratamento de falhas

Não acoplar Domain/Application ao SDK Kafka.

---

# 30. RABBITMQ

RabbitMQ deverá ser disponibilizado localmente.

Responsabilidade preferencial:

work queues

processamento assíncrono

jobs distribuídos

mensagens point-to-point quando apropriado

Criar exemplos funcionais de:

Producer

Consumer

Preparar:

retry

DLQ

idempotência

correlation ID

observabilidade

Não acoplar Domain/Application ao SDK RabbitMQ.

---

# 31. EVENT BUS ABSTRACTION

Criar abstração apropriada quando fizer sentido.

Exemplo conceitual:

IEventBus

Adapters:

KafkaEventBus

RabbitMqEventBus

SqsEventBus

SnsEventPublisher

Não publicar automaticamente todo evento em todos os providers.

Provider deverá ser selecionado conforme responsabilidade arquitetural.

---

# 32. IA — ARQUITETURA EVOLUÍDA

Preservar a arquitetura de IA existente:

React / React Native
        ↓
ASP.NET Core
        ↓
Application / CQRS
        ↓
AI Orchestration
        ↓
LLM / RAG / Tools / Agents

Expandir para:

AI Orchestrator
├── LLM Provider
├── Embedding Provider
├── RAG
├── Vector Store
├── Agents
├── Tools
├── Memory/Context quando necessário
└── External APIs

Não permitir acesso direto do LLM aos bancos de negócio.

---

# 33. AMAZON BEDROCK

Adicionar Amazon Bedrock à arquitetura AWS alvo.

Bedrock NÃO deverá ser acoplado diretamente ao Domain ou Application.

Criar abstrações quando apropriado:

ILLMProvider

IEmbeddingProvider

IVectorStore

IAgentOrchestrator

IAITool

IRagService

Provider AWS:

BedrockLLMProvider

Provider local/fake:

LocalLLMProvider

ou equivalente.

O desenvolvimento e testes devem poder funcionar sem Bedrock real.

---

# 34. BEDROCK AGENTS / ORCHESTRATION

Planejar arquitetura semelhante conceitualmente a:

API
    ↓
AI Application Service
    ↓
AI Orchestrator
    ↓
Agent
    ├── Tool
    ├── RAG
    ├── Domain Query
    ├── Domain Command
    └── External API

No ambiente AWS, avaliar Amazon Bedrock Agents quando fizer sentido.

No ambiente local, manter abstração equivalente.

Não permitir que Bedrock Agent ignore:

CQRS

IAM

Permissions

Policies

Domain Rules

Audit

Human Approval

---

# 35. AI TOOLS

Fluxo obrigatório permanece:

LLM / Agent
    ↓
Tool
    ↓
Command / Query
    ↓
Application
    ↓
Domain
    ↓
Repository / Integration

Tools devem respeitar:

authentication

authorization

permissions

validation

domain invariants

audit

idempotency

human approval quando necessário

---

# 36. RAG

Preservar:

Documents
    ↓
Parsing
    ↓
Chunking
    ↓
Embeddings
    ↓
Vector Store
    ↓
Retrieval
    ↓
LLM

Preparar provider de Vector Store desacoplado.

Não obrigar Vector DB quando RAG estiver desabilitado.

---

# 37. S3 / ARMAZENAMENTO

Criar abstração de Object Storage.

Exemplo:

IObjectStorage

Local:

MinIO ou implementação local apropriada

AWS:

S3

Utilizar para:

documentos

media

arquivos de RAG

uploads

artefatos quando apropriado

IAM/permissions devem controlar acesso aos objetos.

---

# 38. COGNITO

Planejar Cognito como alternativa/integração AWS de identidade.

O IAM de domínio existente NÃO deve ser simplesmente removido.

Documentar responsabilidades entre:

IAM da aplicação

e:

Cognito

Possível separação:

Cognito
→ autenticação/federação

Application IAM
→ autorização, roles, permissions, policies e regras internas

A decisão final deverá ser documentada.

---

# 39. API GATEWAY

Planejar API Gateway para ambiente AWS quando fizer sentido.

Avaliar:

HTTP APIs

REST APIs

WebSocket APIs

Não tornar API Gateway obrigatório no desenvolvimento local.

---

# 40. CLOUDFRONT + WAF + ROUTE 53

Planejar:

Route 53
→ DNS

CloudFront
→ CDN/edge

WAF
→ proteção de aplicação

Documentar fluxo externo:

Internet
    ↓
Route 53
    ↓
CloudFront
    ↓
WAF
    ↓
API Gateway / Frontend

A implementação local não precisa reproduzir artificialmente todos esses componentes.

---

# 41. WEBSOCKETS

Se o projeto possuir necessidade de comunicação realtime:

planejar:

API Gateway WebSocket

ou alternativa apropriada em AWS.

Localmente utilizar implementação compatível com ASP.NET Core quando apropriado.

Não adicionar WebSockets sem caso de uso.

---

# 42. OBSERVABILIDADE

Expandir a observabilidade existente.

Utilizar OpenTelemetry como padrão principal de instrumentação.

Instrumentar:

ASP.NET Core

HTTP

MySQL

MongoDB

Redis

Kafka

RabbitMQ

AWS SDK quando aplicável

External APIs

AI/LLM quando possível

Workers

Outbox Processor

Consumers

---

# 43. STACK LOCAL DE OBSERVABILIDADE

Planejar/executar localmente:

OpenTelemetry Collector

Prometheus

Grafana

Loki

Tempo

Responsabilidades:

Prometheus
→ metrics

Grafana
→ dashboards

Loki
→ logs

Tempo
→ distributed traces

OpenTelemetry Collector
→ coleta/roteamento

Utilizar Docker Compose Profile `observability` quando apropriado.

---

# 44. DISTRIBUTED TRACING

Toda operação distribuída deverá manter:

TraceId

CorrelationId

quando aplicável.

Exemplo:

HTTP Request
    ↓
API
    ↓
Command
    ↓
MySQL
    ↓
Domain Event
    ↓
Outbox
    ↓
Kafka
    ↓
Consumer
    ↓
External API

O trace deverá permitir acompanhar o fluxo completo quando tecnicamente possível.

---

# 45. OBSERVABILIDADE DE IA

Continuar registrando quando permitido:

provider

model

latency

input tokens

output tokens

estimated cost

tool calls

agent executions

RAG retrieval

errors

retries

TraceId

CorrelationId

Nunca registrar secrets ou PII indiscriminadamente.

---

# 46. HEALTH CHECKS

Manter:

/health/live

/health/ready

Adicionar verificações apropriadas para:

MySQL

MongoDB

Redis

Kafka

RabbitMQ

Object Storage

dependências externas críticas

Não tornar liveness dependente de todas as integrações externas.

Readiness deve representar capacidade real de atender a aplicação.

---

# 47. AMBIENTE TEST

TEST deve ser completamente isolado.

Utilizar:

mysql-test

mongodb-test

redis-test

tópicos Kafka TEST

queues RabbitMQ TEST

recursos LocalStack TEST quando necessários

Nunca utilizar recursos DEV/HML/PROD.

---

# 48. AMBIENTE DEV

DEV representa desenvolvimento local.

Utilizar:

MySQL DEV

MongoDB DEV

Redis DEV

Kafka DEV

RabbitMQ DEV

LocalStack DEV

observabilidade local quando habilitada

dados fake/seeds

---

# 49. AMBIENTE HML

HML deve possuir configuração própria.

Não reutilizar secrets DEV.

Preparar:

configuration

environment variables

containers/manifests

Kubernetes overlay quando utilizado

recursos externos próprios

---

# 50. AMBIENTE PROD

PROD deve possuir configuração própria.

Nunca:

hardcode credentials

habilitar Demo Seed

habilitar Stress Seed

versionar secrets

Utilizar mecanismos seguros de configuração.

Na AWS avaliar:

IAM Roles

Secrets Manager

Parameter Store

---

# 51. TESTES UNITÁRIOS

Manter testes para:

Domain

Value Objects

Commands

Queries

Handlers

Validators

Domain Events

Policies

Permissions

Cache abstractions

Outbox logic

Idempotency

AI Tools

Structured Outputs

Testes unitários não devem depender da infraestrutura DEV.

---

# 52. TESTES DE INTEGRAÇÃO

Executar integração real quando apropriado com:

API

MySQL

MongoDB

Redis

Kafka

RabbitMQ

Outbox

Cache

Migrations

Seeds

Producer

Consumer

Object Storage

LocalStack quando necessário

Utilizar infraestrutura TEST isolada.

---

# 53. TESTES DO CACHE

Validar explicitamente:

1ª leitura:

API
→ Redis MISS
→ Persistence
→ Redis SET
→ Response

2ª leitura:

API
→ Redis HIT
→ Response

Após UPDATE:

cache invalidado/atualizado

Após DELETE:

cache removido

Redis indisponível:

persistência continua sendo fonte confiável.

---

# 54. TESTES DE MENSAGERIA

Testar:

Producer

Consumer

Retry

DLQ quando aplicável

Duplicate Message

Idempotency

CorrelationId

Serialization

Invalid Message

Consumer Failure

Recovery

---

# 55. TESTES DE OUTBOX

Testar:

Business Data + Outbox persistidos corretamente.

Mensagem pendente.

Processamento da mensagem.

Publicação.

Marcação como processada.

Retry.

Falha do broker.

Reprocessamento.

Idempotência.

---

# 56. TESTES VIA DOCKER

Toda suíte automatizada deverá poder ser executada por um único comando.

Exemplo:

docker compose -f docker-compose.test.yml up --build --abort-on-container-exit

Criar, se útil:

scripts/test.ps1

scripts/test.sh

ou:

Makefile

O processo deverá:

1. criar infraestrutura TEST;
2. criar bancos TEST;
3. subir dependências;
4. executar migrations;
5. executar seeds mínimos quando necessários;
6. executar unit tests;
7. executar integration tests;
8. executar infrastructure tests;
9. coletar resultados;
10. retornar exit code correto;
11. finalizar/destruir recursos temporários.

---

# 57. TESTES KUBERNETES

Criar smoke tests básicos para validar:

Deployment

Service

ConfigMap

Probes

API startup

dependências essenciais

Não transformar testes Kubernetes em requisito para cada pequeno teste unitário.

---

# 58. SEEDS

Preservar estratégia:

Minimal

Demo

Stress

Adicionar dados necessários para testar:

cache

MongoDB

Kafka

RabbitMQ

Outbox

AI

RAG

quando os respectivos módulos estiverem habilitados.

Não executar Demo/Stress automaticamente em PROD.

---

# 59. FEATURE FLAGS

Preservar Feature Flags existentes.

Adicionar flags quando necessário para:

Kafka

RabbitMQ

MongoDB

RAG

AI

AWS Integrations

Observability

Não utilizar Feature Flag para enfraquecer segurança.

---

# 60. SEGURANÇA

Nunca versionar:

AWS Access Key

AWS Secret Key

database passwords reais

JWT production keys

API keys

LLM keys

certificados privados

tokens

secrets

Manter:

.env.example

com valores fictícios.

Adicionar arquivos reais de segredo ao `.gitignore`.

---

# 61. LOCAL DEVELOPMENT EXPERIENCE

Um novo desenvolvedor deverá conseguir:

clonar projeto

configurar `.env`

executar Docker

subir infraestrutura

executar migrations

aplicar seeds DEV

iniciar aplicação

executar testes

visualizar observabilidade

visualizar arquitetura

com documentação clara.

Objetivo:

mínima configuração manual possível.

---

# 62. COMANDOS PADRONIZADOS

Quando possível, fornecer comandos simples para:

DEV:

docker compose --profile core up -d

FULL:

docker compose --profile full up -d

TEST:

script único para testes

OBSERVABILITY:

docker compose --profile observability up -d

ARCHITECTURE:

docker compose --profile architecture up -d

AWS LOCAL:

docker compose --profile aws-local up -d

Documentar os comandos reais implementados.

Não documentar comando inexistente.

---

# 63. ARQUITETURA ALVO

O planejamento arquitetural deverá representar conceitualmente:

Internet
    ↓
Route 53
    ↓
CloudFront
    ↓
WAF
    ↓
API Gateway
    ↓
Authentication / Cognito
    ↓
Compute
    ├── ECS
    ├── EKS
    └── Lambda
          ↓
ASP.NET Core
          ↓
Application / CQRS
    ┌───────────────┴───────────────┐
    ↓                               ↓
Commands                          Queries
    ↓                               ↓
Domain                           Redis
    ↓                          HIT / MISS
MySQL                              ↓
    ↓                         Read Store
Domain Events
    ↓
Integration Events
    ↓
Transactional Outbox
    ↓
Event Bus
    ├── Kafka
    ├── RabbitMQ
    ├── SQS
    └── SNS
          ↓
Consumers / Workers
          ↓
AI Orchestrator
    ├── Bedrock / LLM
    ├── RAG
    ├── Vector Store
    ├── Tools
    ├── Agents
    └── External APIs

Object Storage:

Local
→ MinIO

AWS
→ S3

Observability:

Application
→ OpenTelemetry
→ Collector
→ Metrics / Logs / Traces

Toda a arquitetura deve ser adaptada à estrutura real do projeto.

Não desenhar dependências inexistentes como implementadas.

---

# 64. DIAGRAMAS OBRIGATÓRIOS

Atualizar/criar:

System Architecture

C4 System Context

C4 Container

C4 Component

Modules

Database ER

Identity/IAM

CQRS Flow

Cache Flow

Domain Event Flow

Transactional Outbox

Kafka Flow

RabbitMQ Flow

AI Flow

RAG Flow

AWS Architecture

Local Architecture

Docker Architecture

Kubernetes Deployment

Observability Architecture

Deployment Diagram

Quando apropriado:

Sequence Diagrams

Todos os diagramas oficiais devem possuir fonte editável.

---

# 65. ARCHITECTURE QUALITY GATE — EVOLUÇÃO 03

Antes de considerar esta evolução arquitetural aprovada:

[ ] prompts.md atualizado

[ ] requisitos anteriores preservados

[ ] estado atual analisado

[ ] C4 criado

[ ] Structurizr configurado

[ ] Draw.io atualizado

[ ] ADRs relevantes criados

[ ] arquitetura Local First documentada

[ ] arquitetura AWS Target documentada

[ ] equivalência Local → AWS documentada

[ ] Docker Compose preservado

[ ] Docker Profiles definidos quando necessários

[ ] Kubernetes planejado/configurado

[ ] MySQL definido

[ ] MongoDB definido

[ ] Redis Cache Aside definido

[ ] Domain Events definidos

[ ] Integration Events definidos

[ ] Outbox definido

[ ] Kafka definido

[ ] RabbitMQ definido

[ ] LocalStack definido

[ ] AWS abstractions definidas

[ ] Bedrock planejado

[ ] AI Orchestrator definido

[ ] OpenTelemetry definido

[ ] observabilidade local definida

[ ] TEST/DEV/HML/PROD isolados

[ ] estratégia de testes definida

[ ] nenhuma credencial real versionada

Somente PASS libera conclusão arquitetural.

---

# 66. QUALITY GATES DE IMPLEMENTAÇÃO

Antes de declarar conclusão:

[ ] restore funcionando

[ ] build funcionando

[ ] unit tests passando

[ ] integration tests passando

[ ] infrastructure tests passando

[ ] Docker DEV subindo

[ ] Docker TEST subindo

[ ] migrations funcionando

[ ] seed DEV funcionando

[ ] MySQL funcionando

[ ] MongoDB funcionando quando habilitado

[ ] Redis funcionando

[ ] Kafka funcionando quando habilitado

[ ] RabbitMQ funcionando quando habilitado

[ ] LocalStack funcionando quando habilitado

[ ] Outbox testado

[ ] cache testado

[ ] health checks funcionando

[ ] observabilidade validada

[ ] Kubernetes manifests validados

[ ] diagramas atualizados

[ ] documentação sincronizada com código

Não declare sucesso caso Quality Gate obrigatório esteja falhando.

---

# 67. NÃO IMPLEMENTAR TECNOLOGIA PARA "MARCAR CHECKBOX"

Cada tecnologia deverá possuir responsabilidade.

MySQL
→ dados transacionais

Redis
→ cache distribuído

MongoDB
→ documentos/read models/histórico quando justificado

Kafka
→ event streaming

RabbitMQ
→ work queues/processamento assíncrono

SQS
→ queue AWS

SNS
→ pub/sub AWS

S3
→ object storage

Lambda
→ event-driven/serverless

ECS
→ container orchestration AWS simplificada

EKS
→ Kubernetes AWS quando justificado

Bedrock
→ provider de IA AWS

LocalStack
→ simulação local AWS

OpenTelemetry
→ telemetria padronizada

Prometheus
→ métricas

Grafana
→ visualização

Loki
→ logs

Tempo
→ traces

Structurizr
→ Architecture as Code

OpenTofu/Terraform
→ Infrastructure as Code

Se uma tecnologia não possuir caso de uso real no template, documente como planejada/opcional em vez de criar implementação artificial.

---

# 68. ORDEM DE EXECUÇÃO — EVOLUÇÃO 03

Execute nesta ordem:

1. Ler integralmente `prompts.md`.
2. Ler documentação existente.
3. Analisar código existente.
4. Analisar infraestrutura existente.
5. Analisar Docker existente.
6. Analisar diagramas existentes.
7. Analisar testes existentes.
8. Inventariar tarefas concluídas.
9. Inventariar tarefas parcialmente concluídas.
10. Inventariar tarefas pendentes.
11. Incorporar esta evolução ao `prompts.md`.
12. Atualizar `REQUIREMENTS.md`.
13. Atualizar `ARCHITECTURE_PLAN.md`.
14. Atualizar `EXECUTION_PLAN.md`.
15. Criar/atualizar ADRs.
16. Criar/atualizar C4/Structurizr.
17. Atualizar Draw.io.
18. Planejar arquitetura LOCAL.
19. Planejar arquitetura AWS.
20. Documentar equivalência LOCAL → AWS.
21. Executar Architecture Quality Gate.
22. Ajustar Docker Compose.
23. Criar Docker Profiles.
24. Consolidar MySQL.
25. Incorporar MongoDB.
26. Consolidar Redis/cache.
27. Consolidar CQRS.
28. Consolidar CRUD de referência.
29. Consolidar Domain Events.
30. Implementar Integration Events.
31. Implementar Transactional Outbox.
32. Implementar idempotência.
33. Implementar Kafka.
34. Implementar RabbitMQ.
35. Criar abstrações AWS.
36. Configurar LocalStack.
37. Preparar S3/Object Storage.
38. Preparar SQS.
39. Preparar SNS.
40. Preparar Lambda quando aplicável.
41. Planejar ECS.
42. Planejar EKS.
43. Preparar Kubernetes local.
44. Criar manifests/Kustomize.
45. Consolidar AI Orchestrator.
46. Preparar Bedrock Provider.
47. Consolidar RAG.
48. Consolidar Tools/Agents.
49. Implementar OpenTelemetry.
50. Configurar stack de observabilidade local.
51. Preparar Infrastructure as Code.
52. Consolidar TEST.
53. Consolidar DEV.
54. Preparar HML.
55. Preparar PROD.
56. Implementar/atualizar testes unitários.
57. Implementar/atualizar testes de integração.
58. Implementar testes de infraestrutura.
59. Implementar testes de cache.
60. Implementar testes de Outbox.
61. Implementar testes de mensageria.
62. Implementar execução de testes via Docker.
63. Validar Kubernetes.
64. Executar Quality Gates.
65. Executar Architecture Validation novamente.
66. Atualizar Draw.io.
67. Atualizar Structurizr.
68. Atualizar documentação final.
69. Gerar relatório final.

Não recrie componentes que já estejam corretos.

Não interrompa por problema não bloqueante.

Registre o problema e continue.

Somente solicite intervenção quando:

- faltar informação indispensável;
- houver ação destrutiva;
- forem necessárias credenciais reais;
- houver conflito arquitetural impossível de resolver pela documentação existente.

---

# 69. RELATÓRIO FINAL

Ao terminar apresente:

## Estado encontrado

O que já existia.

## Planejamento incorporado

O que foi incorporado ao `prompts.md`.

## Implementado

Funcionalidades realmente implementadas.

## Arquitetura

C4, Structurizr, Draw.io e ADRs.

## Local

Infraestrutura disponível localmente.

## AWS

Arquitetura planejada e componentes implementados/simulados.

## Docker

Profiles e comandos disponíveis.

## Kubernetes

Manifests, overlays e validações.

## Bancos

MySQL, MongoDB e Redis.

## CQRS

Commands, Queries e handlers.

## Cache

Estratégia Redis implementada.

## Domain Events

Eventos existentes.

## Integration Events

Eventos de integração existentes.

## Outbox

Situação da implementação.

## Mensageria

Kafka/RabbitMQ/SQS/SNS.

## IA

LLM/RAG/Tools/Agents/Bedrock.

## Observabilidade

Logs, metrics, traces e dashboards.

## Testes

Unitários, integração e infraestrutura.

## Quality Gates

Resultado individual de cada gate.

## Arquivos criados

Principais arquivos novos.

## Arquivos alterados

Principais arquivos modificados.

## Pendências

O que ainda não foi concluído.

## Dependências AWS reais

O que necessita conta/credenciais AWS.

## Próxima etapa

Próxima tarefa recomendada.

---

# 70. REGRA FINAL

Este documento NÃO substitui isoladamente o planejamento original.

Ele representa uma EVOLUÇÃO do planejamento.

A tarefa obrigatória desta execução é:

`prompts.md atual`
        +
`requisitos já incorporados anteriormente`
        +
`03 - prompts.md`
        ↓
`prompts.md consolidado`

O resultado deve preservar o projeto existente e evoluí-lo.

Não remova requisitos anteriores sem justificativa explícita.

Não recrie o projeto.

Não implemente arquitetura paralela.

Não crie uma arquitetura para Claude, outra para Codex e outra para OpenCode.

Todos os agentes devem seguir a MESMA arquitetura.

A aplicação deverá continuar podendo ser desenvolvida integralmente em ambiente local.

AWS é a arquitetura cloud alvo.

Docker Compose é o ambiente local principal.

Kubernetes local valida portabilidade e orquestração.

Structurizr/C4 documenta Architecture as Code.

Draw.io permanece para documentação arquitetural detalhada e editável.

OpenTofu/Terraform prepara Infrastructure as Code.

OpenTelemetry fornece observabilidade independente de fornecedor.

O Domain permanece independente de infraestrutura.

CQRS permanece obrigatório.

Domain Events permanecem obrigatórios para mudanças relevantes de domínio.

Integration Events não substituem Domain Events.

Transactional Outbox protege consistência entre persistência e mensageria.

Redis otimiza leitura, mas nunca substitui a fonte transacional.

IA nunca ignora IAM, CQRS, Domain, autorização ou regras de negócio.

Comece analisando o estado atual e incorporando esta evolução ao `prompts.md`.