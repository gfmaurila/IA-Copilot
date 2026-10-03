# SKILLS DO PROJETO

Este documento define as Skills necessárias para que os agentes de IA utilizados no projeto — Claude Code, Codex, OpenCode, GitHub Copilot ou equivalentes — compreendam e respeitem a arquitetura, os padrões, a infraestrutura, os processos de desenvolvimento e os Quality Gates definidos no projeto.

As Skills devem ser reutilizáveis e independentes da ferramenta de IA utilizada.

Antes de criar uma nova Skill, verificar se uma Skill existente pode ser expandida sem perder sua responsabilidade principal.

---

# 1. ARQUITETURA E ENGENHARIA

## `project-architecture`

Responsável pela arquitetura global do projeto.

Deve orientar os agentes sobre:

- arquitetura empresarial;
- Modular Monolith;
- organização da Solution;
- organização dos projetos;
- módulos;
- bounded contexts quando aplicável;
- separação de responsabilidades;
- camadas;
- dependências;
- boundaries;
- padrões arquiteturais;
- comunicação entre módulos;
- regras de dependência;
- decisões estruturais;
- integração entre backend, frontend, mobile e infraestrutura;
- arquitetura LOCAL;
- arquitetura AWS TARGET;
- evolução arquitetural;
- compatibilidade entre arquitetura planejada e implementação real.

Deve impedir alterações estruturais arbitrárias realizadas apenas por conveniência do agente.

---

## `backend-ddd-cqrs`

Responsável pela arquitetura do backend ASP.NET Core.

Deve orientar:

- ASP.NET Core;
- C#;
- DDD;
- CQRS;
- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- Domain Events;
- Entities;
- Aggregates;
- Aggregate Roots;
- Value Objects;
- Domain Services;
- Application Services;
- Repositories;
- interfaces;
- Infrastructure;
- validações;
- regras de domínio;
- invariantes;
- separação entre Domain, Application, Infrastructure e API.

Controllers ou Endpoints não devem conter regras de negócio.

A camada Domain não deve depender de Infrastructure.

---

## `crud-generation`

Responsável pela geração padronizada de funcionalidades CRUD completas.

Um CRUD não deve significar somente criar endpoints.

O fluxo conceitual deverá considerar:

```text
Domain
    ↓
Application
    ↓
Infrastructure
    ↓
API
    ↓
Frontend
    ↓
Tests
```

Quando aplicável, deve gerar:

- Entity;
- Aggregate;
- Value Objects;
- Commands;
- Queries;
- DTOs;
- Validators;
- Handlers;
- Repository;
- Persistence;
- EF Core Configuration;
- Migration;
- Permissions;
- Policies;
- API Endpoints;
- React Admin;
- React Native quando aplicável;
- testes unitários;
- testes de integração;
- documentação.

Deve respeitar IAM, CQRS, DDD e os padrões existentes.

---

## `architecture-as-code`

Responsável pela arquitetura versionável como código.

Ferramentas principais:

- C4 Model;
- Structurizr DSL;
- Structurizr Lite.

Deve representar:

- System Context;
- Containers;
- Components;
- Deployment;
- relações;
- dependências;
- tecnologias;
- sistemas externos;
- arquitetura LOCAL;
- arquitetura AWS TARGET.

Os arquivos `.dsl` devem ser tratados como artefatos oficiais do projeto.

Exemplo:

```text
docs/
└── architecture/
    └── structurizr/
        ├── workspace.dsl
        └── README.md
```

A arquitetura não deve existir somente na documentação textual.

---

## `drawio-architecture`

Responsável pelos diagramas visuais oficiais e editáveis.

Ferramenta principal:

```text
Draw.io / diagrams.net
```

Deve ser utilizada para:

- arquitetura detalhada;
- UML;
- ER;
- Sequence Diagrams;
- CQRS Flow;
- Cache Flow;
- Domain Event Flow;
- Integration Event Flow;
- Transactional Outbox;
- Kafka;
- RabbitMQ;
- IAM;
- AI;
- RAG;
- Agents;
- Docker;
- Kubernetes;
- AWS;
- observabilidade;
- deployment;
- integrações.

Os arquivos `.drawio` são os arquivos-fonte oficiais.

PNG, SVG ou PDF são apenas exportações.

Não considerar um diagrama concluído se existir somente como:

- PNG;
- JPG;
- PDF;
- screenshot;
- ASCII;
- Markdown;
- Mermaid.

---

## `architecture-quality-gate`

Responsável pela validação arquitetural obrigatória.

Deve validar:

- arquitetura planejada;
- arquitetura implementada;
- estrutura física;
- módulos;
- dependências;
- boundaries;
- ADRs;
- Structurizr;
- C4;
- Draw.io;
- infraestrutura;
- persistência;
- mensageria;
- IA;
- segurança;
- observabilidade;
- deployment.

Deve verificar se os diagramas representam a implementação real.

Estados arquiteturais devem ser identificados como:

```text
IMPLEMENTED
PLANNED
OPTIONAL
AWS ONLY
LOCAL ONLY
```

Nenhuma alteração arquitetural relevante deve ser considerada concluída sem passar pelo Architecture Quality Gate.

---

# 2. FRONTEND E MOBILE

## `frontend-react-architecture`

Responsável pela arquitetura React Web.

Deve orientar:

- React;
- TypeScript;
- estrutura de diretórios;
- componentes;
- páginas;
- layouts;
- hooks;
- services;
- API clients;
- state management;
- autenticação;
- autorização;
- permissions;
- tratamento de erros;
- validação;
- componentes reutilizáveis;
- organização do Admin;
- organização do Site.

O frontend não deve implementar autorização apenas visual.

As APIs continuam responsáveis pela autorização real.

---

## `frontend-react-native-architecture`

Responsável pela arquitetura React Native.

Deve orientar:

- React Native;
- TypeScript;
- estrutura mobile;
- telas;
- componentes;
- hooks;
- services;
- API clients;
- autenticação;
- autorização;
- armazenamento seguro;
- navegação;
- tratamento de erros;
- integração com backend;
- compartilhamento adequado de contratos.

Deve preservar os mesmos princípios de segurança utilizados no Web.

---

## `navigation-management`

Responsável pelo gerenciamento de navegação.

Deve orientar:

- menus;
- submenus;
- rotas;
- breadcrumbs;
- navegação administrativa;
- navegação pública;
- navegação mobile;
- visibilidade baseada em permissions;
- ordenação;
- agrupamento;
- configuração dinâmica quando aplicável.

A ocultação de um menu não substitui autorização da API.

---

# 3. IDENTIDADE E SEGURANÇA

## `identity-iam-authorization`

Responsável pelo IAM da aplicação.

Deve orientar:

- Users;
- Groups;
- Roles;
- Permissions;
- Policies;
- Claims;
- autenticação;
- autorização;
- JWT;
- Refresh Token;
- expiração;
- revogação;
- auditoria;
- proteção de endpoints;
- permissões administrativas;
- permissões de domínio.

Modelo conceitual:

```text
User
 ↓
Group
 ↓
Role
 ↓
Permission
 ↓
Policy
```

Deve suportar combinações adequadas conforme a arquitetura real.

---

## `security-secrets`

Responsável pela segurança das configurações e credenciais.

Deve orientar:

- secrets;
- `.env`;
- `.env.example`;
- connection strings;
- JWT secrets;
- API Keys;
- credentials;
- AWS IAM;
- Secrets Manager;
- Parameter Store;
- configuração segura;
- `.gitignore`;
- rotação de secrets;
- separação por ambiente.

Nunca colocar credenciais reais no código-fonte.

O `.env.example` deve utilizar somente valores fictícios.

---

## `multi-tenant`

Responsável pela preparação e implementação de multi-tenancy quando habilitada.

Deve considerar:

```text
Tenant / Organization
    ├── Users
    ├── Groups
    ├── Content
    ├── Documents
    └── AI Knowledge
```

Deve impedir vazamento entre tenants de:

- dados;
- usuários;
- documentos;
- arquivos;
- conteúdo;
- embeddings;
- Vector Store;
- resultados de RAG;
- cache;
- logs sensíveis.

Multi-tenancy deve permanecer configurável quando não for requisito obrigatório.

---

# 4. DADOS E PERSISTÊNCIA

## `mysql-persistence`

Responsável pela persistência transacional principal.

Deve orientar:

- MySQL;
- EF Core;
- DbContext;
- Entities;
- configurations;
- migrations;
- transactions;
- repositories;
- indexes;
- constraints;
- concurrency;
- performance;
- connection management.

MySQL permanece como banco relacional transacional principal, salvo decisão arquitetural documentada.

---

## `mongodb-persistence`

Responsável pelo uso de MongoDB quando existir justificativa arquitetural.

Pode ser utilizado para:

- documentos;
- projections;
- read models;
- histórico;
- estruturas flexíveis;
- dados não relacionais.

MongoDB não deve ser adicionado apenas para aumentar a quantidade de tecnologias do projeto.

Sua responsabilidade deve estar documentada.

---

## `redis-caching`

Responsável pela estratégia de cache utilizando Redis.

Padrão principal:

```text
Cache-Aside
```

Fluxo:

```text
Query
    ↓
Redis
 ┌──┴──┐
HIT   MISS
 ↓      ↓
Return Persistence
        ↓
     Redis SET
        ↓
      Return
```

Deve orientar:

- HIT;
- MISS;
- TTL;
- SET;
- invalidação;
- cache distribuído;
- cache de consultas;
- dados temporários;
- naming de keys;
- fallback;
- indisponibilidade do Redis.

Writes devem invalidar ou atualizar caches relacionados quando necessário.

---

## `database-modeling`

Responsável pela modelagem de dados.

Deve orientar:

- entidades;
- tabelas;
- PK;
- FK;
- relacionamentos;
- cardinalidade;
- índices;
- constraints;
- normalização;
- decisões de desnormalização;
- performance;
- ER Diagram.

O modelo visual deve ser mantido em formato editável.

---

## `seed-fake-data`

Responsável pelos dados iniciais e dados fake.

Deve gerar dados coerentes para:

- usuários;
- grupos;
- roles;
- permissions;
- policies;
- conteúdo;
- relacionamentos;
- módulos;
- dados de demonstração.

Perfis:

```text
Minimal
Demo
Stress
```

`Minimal` deve possuir apenas os dados necessários para funcionamento.

`Demo` deve fornecer dados suficientes para demonstração.

`Stress` deve gerar volume apropriado para testes.

Seeds Demo/Stress não devem ser executados automaticamente em produção.

---

# 5. EVENTOS E MENSAGERIA

## `domain-events`

Responsável por Domain Events.

Deve orientar:

- criação;
- publicação;
- handlers;
- eventos internos;
- desacoplamento;
- regras de domínio;
- transações.

Domain Events não devem depender diretamente de:

- Kafka;
- RabbitMQ;
- SQS;
- SNS.

---

## `integration-events`

Responsável por Integration Events.

Deve orientar:

- comunicação entre módulos;
- comunicação entre sistemas;
- contratos;
- versionamento;
- serialização;
- compatibilidade;
- publicação externa.

Deve existir distinção clara entre:

```text
Domain Event
```

e:

```text
Integration Event
```

---

## `transactional-outbox`

Responsável pelo padrão Transactional Outbox.

Deve garantir consistência entre alterações transacionais e publicação de eventos.

Modelo conceitual:

```text
MessageId
EventType
Payload
OccurredAt
ProcessedAt
CorrelationId
RetryCount
Status
```

Deve orientar:

- gravação;
- processamento;
- retry;
- falhas;
- status;
- idempotência;
- correlation ID;
- observabilidade;
- limpeza/retention.

---

## `event-bus`

Responsável pela abstração do barramento de eventos.

Exemplo conceitual:

```text
IEventBus
```

Adapters possíveis:

```text
KafkaEventBus
RabbitMqEventBus
SqsEventBus
SnsEventPublisher
```

O Domain e a Application não devem ficar diretamente acoplados aos SDKs dos brokers.

Não publicar automaticamente todos os eventos em todos os providers.

Cada provider deve possuir responsabilidade arquitetural clara.

---

## `kafka-messaging`

Responsável pela utilização de Kafka.

Deve orientar:

- Topics;
- Producers;
- Consumers;
- partitions;
- consumer groups;
- Event Streaming;
- serialização;
- retry;
- idempotência;
- correlation ID;
- observabilidade;
- tratamento de falhas.

Kafka deve ser utilizado quando o caso de uso justificar streaming/eventos distribuídos.

---

## `rabbitmq-messaging`

Responsável pela utilização de RabbitMQ.

Deve orientar:

- Exchanges;
- Queues;
- Routing Keys;
- Producers;
- Consumers;
- Workers;
- retry;
- timeout;
- DLQ;
- idempotência;
- correlation ID;
- observabilidade.

RabbitMQ deve ser utilizado quando filas/work processing forem adequados ao caso.

---

## `aws-messaging`

Responsável pela mensageria AWS.

Deve orientar:

- Amazon SQS;
- Amazon SNS;
- publishers;
- consumers;
- subscriptions;
- retry;
- DLQ;
- idempotência;
- integração com Event Bus.

Ambiente local deve funcionar sem depender de uma conta AWS real.

---

## `idempotency-resilience`

Responsável pelos padrões de resiliência.

Deve orientar:

- idempotência;
- retry;
- timeout;
- circuit breaker quando necessário;
- DLQ;
- correlation ID;
- deduplicação;
- recuperação de falhas;
- processamento seguro de mensagens.

---

# 6. INTELIGÊNCIA ARTIFICIAL

## `ai-application`

Responsável pela arquitetura principal da camada de IA.

Fluxo:

```text
React / React Native
        ↓
ASP.NET Core
        ↓
Application / CQRS
        ↓
AI Orchestration
        ↓
LLM / RAG / Tools / Agents
```

Deve manter a IA desacoplada do Domain.

LLMs não podem acessar diretamente os bancos de negócio.

---

## `rag`

Responsável pela arquitetura Retrieval-Augmented Generation.

Fluxo:

```text
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
Context
    ↓
LLM
```

Deve orientar:

- ingestão;
- parsing;
- chunking;
- embeddings;
- metadata;
- indexação;
- retrieval;
- filtros;
- ranking;
- contexto;
- segurança;
- isolamento de tenants;
- avaliação.

Vector Store deve ser desacoplado através de abstrações quando apropriado.

---

## `ai-tools-agents`

Responsável por:

- AI Tools;
- Agents;
- Agentic Workflows;
- Tool Calling;
- Domain Queries;
- Domain Commands;
- APIs externas;
- workflows;
- autorização.

Fluxo obrigatório:

```text
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
```

Tools nunca devem acessar diretamente tabelas de negócio ignorando CQRS/Application/Domain.

---

## `ai-provider-abstraction`

Responsável por desacoplar a aplicação dos providers de IA.

Abstrações conceituais:

```text
ILLMProvider
IEmbeddingProvider
IVectorStore
IAgentOrchestrator
IAITool
IRagService
```

Pode possuir implementações como:

```text
LocalLLMProvider
BedrockLLMProvider
FakeLLMProvider
```

O desenvolvimento e os testes devem funcionar sem exigir serviços pagos de IA.

---

## `amazon-bedrock`

Responsável pela integração AWS com Amazon Bedrock.

Deve orientar:

- Bedrock Models;
- Bedrock Runtime;
- Bedrock Agents quando aplicável;
- Agent Orchestration;
- Tools;
- RAG;
- embeddings;
- integração AWS;
- autenticação;
- observabilidade;
- custos.

Bedrock não deve ser acoplado diretamente ao Domain.

---

## `ai-security`

Responsável pela segurança da camada de IA.

Deve orientar:

- authentication;
- authorization;
- permissions;
- policies;
- proteção de Tools;
- proteção de documentos;
- proteção de RAG;
- isolamento de tenants;
- prompt injection;
- validação de entrada;
- validação de saída;
- ações sensíveis;
- auditoria;
- Human Approval.

A IA nunca deve utilizar seu próprio contexto como autorização para executar operações.

---

## `ai-observability`

Responsável pela observabilidade de IA.

Deve registrar quando apropriado:

- provider;
- model;
- latência;
- tokens de entrada;
- tokens de saída;
- custos estimados;
- Agent Calls;
- Tool Calls;
- retrieval;
- falhas;
- retries;
- traces;
- correlation ID.

Não registrar dados sensíveis indevidamente.

---

## `ai-evaluation`

Responsável pela avaliação da qualidade dos recursos de IA.

Deve orientar:

- avaliação de respostas;
- RAG evaluation;
- retrieval quality;
- relevância;
- groundedness;
- Agent workflows;
- Tool Calls;
- regressão;
- datasets de avaliação;
- métricas;
- comparação de versões.

---

## `human-approval`

Responsável por Human-in-the-loop.

Operações sensíveis devem poder seguir:

```text
AI
 ↓
Proposta de ação
 ↓
Permission Check
 ↓
Human Approval
 ↓
Command
 ↓
Application
 ↓
Domain
```

Deve existir registro auditável quando aprovação humana for exigida.

---

# 7. CONTEÚDO E ARQUIVOS

## `content-platform`

Responsável pelo módulo opcional de Content.

Deve orientar:

- Headless Content;
- Content Types;
- schemas;
- fields;
- versionamento;
- publicação;
- draft;
- permissions;
- Media;
- APIs;
- Admin.

Content deve permanecer opcional.

O projeto não deve ser transformado em clone de WordPress.

---

## `object-storage`

Responsável pela abstração de armazenamento de objetos.

Interface conceitual:

```text
IObjectStorage
```

Implementação local:

```text
MinIO
```

Implementação AWS:

```text
Amazon S3
```

Pode ser utilizado para:

- documentos;
- uploads;
- Media;
- arquivos de RAG;
- artefatos;
- exports.

Acesso deve respeitar IAM e permissions.

---

## `media-management`

Responsável pelo gerenciamento de mídia.

Deve orientar:

- uploads;
- downloads;
- metadata;
- arquivos;
- imagens;
- documentos;
- permissões;
- Object Storage;
- validação de arquivo;
- tamanho;
- tipos permitidos;
- segurança.

---

## `audio-intelligence`

Responsável pelo pipeline de áudio/vídeo, transcrição e enriquecimento por IA.

Deve orientar:

- upload de `mp3`, `wav`, `m4a` e `mp4`;
- validação de mídia;
- Object Storage;
- FFmpeg para normalização e extração de áudio;
- Speech-to-Text;
- timestamps e segmentos;
- diarização quando suportada pelo provider;
- processamento assíncrono;
- status e progresso de jobs;
- retries e idempotência;
- enriquecimento da transcrição por LLM;
- resumo, tópicos, capítulos, decisões, tarefas e entidades;
- ingestão opcional em RAG / Vector Store;
- segurança, IAM e auditoria;
- observabilidade, latência e custo.

Abstrações conceituais:

```text
IMediaProcessor
ISpeechToTextProvider
ITranscriptionService
ITranscriptionEnrichmentService
```

O Domain não deve conhecer FFmpeg ou providers concretos de Speech-to-Text.

---

## `n8n-automation`

Responsável pela integração opcional com n8n para automações externas.

Fluxos permitidos:

```text
Application / Integration Event
        ↓
Webhook / API
        ↓
n8n
        ↓
serviços externos
```

E também:

```text
n8n
 ↓
API autenticada do GFM.Template.CMS
 ↓
Application / CQRS
 ↓
Domain
```

Regras:

- n8n não substitui regras de negócio;
- n8n não acessa diretamente MySQL/MongoDB para contornar a Application;
- autenticação, secrets, retries, idempotência e auditoria são obrigatórios quando aplicáveis;
- desenvolvimento local pode executar n8n em profile Docker opcional;
- a aplicação deve continuar funcional quando n8n estiver desabilitado, exceto fluxos explicitamente dependentes dele.

---

# 8. DOCKER E DESENVOLVIMENTO LOCAL

## `docker-development`

Responsável pelo ambiente containerizado local.

Deve orientar:

- Docker;
- Docker Compose;
- Dockerfiles;
- containers;
- networks;
- volumes;
- environment variables;
- health checks;
- DEV;
- TEST;
- infraestrutura local.

Docker Compose permanece como principal forma de execução local.

---

## `docker-profiles`

Responsável pela organização de serviços através de profiles.

Profiles conceituais:

```text
core
messaging
observability
aws-local
ai
architecture
full
```

Exemplos:

```bash
docker compose --profile core up -d
```

```bash
docker compose --profile observability up -d
```

```bash
docker compose --profile full up -d
```

Somente documentar comandos que realmente existirem no projeto.

---

## `localstack-aws`

Responsável pela simulação local de serviços AWS.

Deve utilizar LocalStack quando tecnicamente adequado para serviços como:

- SQS;
- SNS;
- S3;
- Lambda;
- outros serviços suportados e realmente necessários.

O projeto não deve exigir conta AWS real para desenvolvimento diário.

---

## `local-development-experience`

Responsável pela experiência de desenvolvimento local.

Objetivo:

```text
Clone
 ↓
Configure .env
 ↓
Docker
 ↓
Infrastructure
 ↓
Migrations
 ↓
Seeds
 ↓
Application
 ↓
Tests
 ↓
Observability
 ↓
Architecture
```

Um novo desenvolvedor deve conseguir executar o projeto com mínima configuração manual.

---

# 9. KUBERNETES

## `kubernetes-architecture`

Responsável pela arquitetura Kubernetes.

Deve orientar:

- workloads;
- serviços;
- networking;
- configuration;
- secrets;
- storage;
- scaling;
- health;
- deployment;
- ambientes.

Kubernetes local não significa automaticamente que AWS deverá utilizar EKS.

---

## `kubernetes-deployment`

Responsável pelos manifests Kubernetes.

Deve considerar:

- Deployment;
- Service;
- ConfigMap;
- Secret;
- Ingress;
- PVC;
- HPA;
- readinessProbe;
- livenessProbe;
- resource requests;
- resource limits.

Não armazenar secrets reais no Git.

---

## `kustomize-environments`

Responsável pela configuração de ambientes utilizando Kustomize.

Estrutura conceitual:

```text
deploy/
└── kubernetes/
    ├── base/
    └── overlays/
        ├── dev/
        ├── hml/
        └── prod/
```

A base deve conter configurações comuns.

Os overlays devem conter somente diferenças específicas de cada ambiente.

---

## `kubernetes-local`

Responsável pela execução e validação Kubernetes local.

Ferramentas preferenciais:

```text
kind
```

ou:

```text
k3d
```

Deve permitir validar:

- manifests;
- deployment;
- services;
- probes;
- networking;
- configuração;
- smoke tests.

Docker Compose e Kubernetes local são modos diferentes de execução.

Kubernetes não deve ser colocado "dentro" do Docker Compose.

---

# 10. AWS

## `aws-architecture`

Responsável pela arquitetura AWS TARGET.

Fluxo conceitual:

```text
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
    ├── Lambda
    └── EC2 quando necessário
          ↓
ASP.NET Core
```

Também deve considerar:

- RDS/Aurora;
- ElastiCache;
- S3;
- SQS;
- SNS;
- MSK;
- Amazon MQ;
- Bedrock;
- Secrets Manager;
- Parameter Store;
- IAM;
- observabilidade AWS.

Serviços planejados não devem ser apresentados como implementados.

---

## `aws-edge-networking`

Responsável pela camada externa AWS.

Deve orientar:

- Route 53;
- DNS;
- CloudFront;
- CDN;
- WAF;
- API Gateway;
- TLS;
- certificados;
- edge;
- segurança externa;
- roteamento.

Fluxo:

```text
Internet
    ↓
Route 53
    ↓
CloudFront
    ↓
WAF
    ↓
API Gateway / Frontend
```

---

## `aws-compute`

Responsável pelas opções de compute AWS.

Deve orientar e avaliar:

- ECS;
- EKS;
- Lambda;
- EC2.

Não selecionar um serviço apenas porque ele está disponível.

A escolha deve considerar:

- workload;
- custo;
- complexidade;
- escalabilidade;
- operação;
- manutenção;
- arquitetura.

---

## `aws-databases`

Responsável pelo mapeamento dos serviços de dados para AWS.

Mapeamento conceitual:

```text
MySQL
    ↓
RDS / Aurora MySQL

Redis
    ↓
ElastiCache

Kafka
    ↓
MSK

RabbitMQ
    ↓
Amazon MQ
```

MongoDB deve ter estratégia AWS documentada somente quando realmente utilizado.

---

## `aws-identity`

Responsável pela identidade AWS e integração com IAM da aplicação.

Possível separação:

```text
Cognito
    ↓
Authentication / Federation
```

```text
Application IAM
    ↓
Authorization
Roles
Permissions
Policies
Domain Rules
```

Cognito não deve substituir automaticamente toda a autorização interna da aplicação.

---

## `aws-storage`

Responsável pelo armazenamento AWS.

Serviço principal:

```text
Amazon S3
```

Deve orientar:

- buckets;
- objects;
- permissions;
- lifecycle;
- uploads;
- downloads;
- documentos;
- RAG;
- Media;
- segurança.

---

## `aws-local-to-cloud`

Responsável pelo mapeamento entre ambiente local e AWS TARGET.

Mapa conceitual:

```text
LOCAL                    AWS

MySQL
  ↓
RDS / Aurora MySQL

Redis
  ↓
ElastiCache

Kafka
  ↓
MSK

RabbitMQ
  ↓
Amazon MQ

MinIO
  ↓
S3

LocalStack
  ↓
AWS

kind / k3d
  ↓
EKS

Docker Containers
  ↓
ECS / EKS

LLM Local / Fake
  ↓
Amazon Bedrock
```

O ambiente local não precisa reproduzir artificialmente cada serviço AWS.

---

## `aws-deployment`

Responsável pela estratégia de deployment AWS.

Deve orientar:

- ECS;
- EKS;
- Lambda;
- EC2 quando necessário;
- deploy;
- environments;
- configuration;
- secrets;
- health checks;
- rollback;
- scaling;
- observabilidade;
- CI/CD;
- infraestrutura.

---

# 11. INFRASTRUCTURE AS CODE

## `infrastructure-as-code`

Responsável pelos padrões gerais de Infrastructure as Code.

Deve orientar:

- organização;
- modules;
- variables;
- outputs;
- environments;
- naming;
- state;
- secrets;
- reuso;
- versionamento;
- validação;
- planejamento;
- aplicação controlada.

Infrastructure as Code não substitui documentação arquitetural.

---

## `opentofu-aws`

Responsável pela infraestrutura AWS utilizando preferencialmente:

```text
OpenTofu
```

Terraform poderá ser utilizado quando houver justificativa técnica.

Estrutura conceitual:

```text
infra/
├── local/
├── aws/
├── kubernetes/
└── modules/
```

Deve orientar:

- providers;
- modules;
- variables;
- outputs;
- state;
- environments;
- AWS resources;
- segurança;
- planejamento.

Não executar criação de recursos AWS reais sem credenciais e autorização apropriadas.

---

## `environment-configuration`

Responsável pela configuração dos ambientes:

```text
TEST
DEV
HML
PROD
```

Deve orientar:

- environment variables;
- connection strings;
- secrets;
- providers;
- endpoints;
- feature flags;
- logging;
- observabilidade;
- recursos externos.

Ambientes devem permanecer isolados.

TEST não deve compartilhar banco ou infraestrutura crítica com DEV.

---

# 12. OBSERVABILIDADE

## `observability`

Responsável pela estratégia geral de observabilidade.

Deve considerar:

- logs;
- metrics;
- traces;
- health checks;
- correlation ID;
- dashboards;
- alertas;
- infraestrutura;
- APIs;
- workers;
- messaging;
- database;
- cache;
- IA.

---

## `opentelemetry`

Responsável pela instrumentação OpenTelemetry.

Deve instrumentar quando aplicável:

- ASP.NET Core;
- HTTP;
- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- workers;
- AI;
- external APIs.

OpenTelemetry deve ser a principal estratégia de instrumentação desacoplada de vendor.

---

## `observability-stack`

Responsável pelo stack local de observabilidade.

Arquitetura conceitual:

```text
Application
    ↓
OpenTelemetry
    ↓
OTel Collector
    ├── Prometheus
    ├── Grafana
    ├── Loki
    └── Tempo
```

Responsabilidades:

- metrics;
- dashboards;
- logs;
- traces;
- correlação;
- análise local.

---

## `health-checks`

Responsável pelos health checks.

Endpoints esperados:

```text
/health/live
/health/ready
```

Deve avaliar dependências como:

- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- serviços externos;
- infraestrutura crítica.

`live` e `ready` devem possuir responsabilidades diferentes.

---

## `distributed-tracing`

Responsável por tracing distribuído.

Deve propagar:

- Trace ID;
- Span ID;
- Correlation ID.

Fluxos relevantes:

```text
HTTP
 ↓
API
 ↓
CQRS
 ↓
Database / Cache
 ↓
Outbox
 ↓
Broker
 ↓
Consumer
 ↓
AI / External Service
```

Deve permitir rastrear uma operação entre componentes.

---

# 13. TESTES E QUALIDADE

## `testing`

Responsável pela estratégia global de testes.

Deve orientar:

- Unit Tests;
- Integration Tests;
- Architecture Tests;
- Infrastructure Tests;
- Messaging Tests;
- Cache Tests;
- AI Tests;
- smoke tests;
- regressão;
- cobertura adequada.

---

## `unit-testing`

Responsável por testes unitários.

Deve priorizar:

- Domain;
- Entities;
- Value Objects;
- Domain Services;
- Application;
- Commands;
- Queries;
- Handlers;
- Validators;
- Policies;
- Services.

Testes unitários não devem depender desnecessariamente de infraestrutura externa.

---

## `integration-testing`

Responsável por testes de integração.

Deve validar integrações reais quando apropriado:

- API;
- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- Object Storage;
- Outbox;
- workers;
- autenticação;
- autorização.

Pode utilizar containers para dependências.

---

## `architecture-testing`

Responsável por testes automatizados de arquitetura.

Deve validar:

- boundaries;
- dependências;
- Domain isolation;
- Application isolation;
- módulos;
- referências proibidas;
- padrões arquiteturais.

Deve detectar violações antes do merge/deploy quando possível.

---

## `messaging-testing`

Responsável pelos testes de mensageria.

Deve validar:

- Kafka;
- RabbitMQ;
- SQS;
- SNS;
- Producers;
- Consumers;
- contratos;
- serialização;
- retry;
- DLQ;
- idempotência;
- correlation ID.

---

## `cache-testing`

Responsável pelos testes de cache.

Deve validar:

- Redis HIT;
- Redis MISS;
- SET;
- TTL;
- invalidação;
- atualização;
- fallback;
- indisponibilidade;
- consistência após Commands.

---

## `docker-testing`

Responsável pela execução da suíte de testes através de Docker.

Exemplo conceitual:

```bash
docker compose -f docker-compose.test.yml up --build --abort-on-container-exit
```

O comando deve ser adaptado ao projeto real.

Não documentar comandos inexistentes.

---

## `kubernetes-smoke-testing`

Responsável pelos smoke tests do ambiente Kubernetes local.

Deve validar:

- cluster;
- manifests;
- pods;
- deployments;
- services;
- networking;
- readiness;
- liveness;
- API;
- dependências básicas.

---

## `qa-quality-gates`

Responsável pelos Quality Gates do projeto.

Deve validar, conforme aplicável:

```text
Architecture
Build
Unit Tests
Integration Tests
Architecture Tests
Security
Cache
Messaging
Outbox
Docker
Kubernetes
Observability
AI
Documentation
Code Review
```

Falhas críticas devem impedir a conclusão da implementação.

---

# 14. DOCUMENTAÇÃO E AGENTES

## `technical-documentation`

Responsável pela documentação técnica e operacional.

Deve manter:

- README;
- setup;
- arquitetura;
- execução;
- Docker;
- Kubernetes;
- AWS;
- observabilidade;
- testes;
- troubleshooting;
- decisões;
- comandos reais;
- dependências;
- configuração.

Não documentar funcionalidades ou comandos que não existam.

---

## `adr-management`

Responsável pelos Architecture Decision Records.

Estrutura mínima:

```text
Context
Decision
Alternatives
Consequences
Status
```

Exemplos de decisões que podem exigir ADR:

- Modular Monolith;
- CQRS;
- Redis Cache;
- Domain Events;
- Transactional Outbox;
- Kafka;
- RabbitMQ;
- AWS Target;
- Kubernetes;
- OpenTelemetry;
- Bedrock;
- OpenTofu;
- Vector Store.

ADRs devem registrar decisões relevantes e não apenas repetir documentação.

---

## `agent-workflow`

Responsável pelo pipeline de agentes.

Fluxo conceitual:

```text
prompts.md
    ↓
Requirements Agent
    ↓
Project Bootstrap Agent
    ↓
Architecture Agent
    ↓
Architecture Quality Gate
    ↓
Tech Lead Agent
    ↓
Developer Agent
    ↓
Tester / QA Agent
    ↓
Reviewer Agent
    ↓
Architecture Validation Agent
    ↓
Documentation Agent
```

Os agentes devem compartilhar as mesmas regras arquiteturais.

Claude Code, Codex, OpenCode e GitHub Copilot não devem criar arquiteturas diferentes para o mesmo projeto.

---

## `code-review`

Responsável pela revisão final da implementação.

Deve avaliar:

- arquitetura;
- código;
- DDD;
- CQRS;
- segurança;
- performance;
- testes;
- duplicação;
- padrões;
- tratamento de erros;
- observabilidade;
- documentação;
- secrets;
- dependências;
- maintainability.

Problemas encontrados devem ser classificados e corrigidos antes da conclusão quando críticos.

---

## `feature-flags`

Responsável pelos módulos e funcionalidades configuráveis.

Modelo conceitual:

```text
Identity       ON
Audit          ON
Notifications  configurável
Content        configurável
Media          configurável
AI             configurável
RAG            configurável
MultiTenant    configurável
```

Feature Flags não podem:

- desabilitar controles obrigatórios de segurança;
- permitir bypass de autorização;
- expor funcionalidades sem permission;
- criar comportamento inconsistente entre backend e frontend.

---

# 15. LISTA COMPLETA DAS RESPONSABILIDADES DE SKILLS

```text
01  project-architecture
02  backend-ddd-cqrs
03  crud-generation
04  architecture-as-code
05  drawio-architecture
06  architecture-quality-gate

07  frontend-react-architecture
08  frontend-react-native-architecture
09  navigation-management

10  identity-iam-authorization
11  security-secrets
12  multi-tenant

13  mysql-persistence
14  mongodb-persistence
15  redis-caching
16  database-modeling
17  seed-fake-data

18  domain-events
19  integration-events
20  transactional-outbox
21  event-bus
22  kafka-messaging
23  rabbitmq-messaging
24  aws-messaging
25  idempotency-resilience

26  ai-application
27  rag
28  ai-tools-agents
29  ai-provider-abstraction
30  amazon-bedrock
31  ai-security
32  ai-observability
33  ai-evaluation
34  human-approval

35  content-platform
36  object-storage
37  media-management

38  docker-development
39  docker-profiles
40  localstack-aws
41  local-development-experience

42  kubernetes-architecture
43  kubernetes-deployment
44  kustomize-environments
45  kubernetes-local

46  aws-architecture
47  aws-edge-networking
48  aws-compute
49  aws-databases
50  aws-identity
51  aws-storage
52  aws-local-to-cloud
53  aws-deployment

54  infrastructure-as-code
55  opentofu-aws
56  environment-configuration

57  observability
58  opentelemetry
59  observability-stack
60  health-checks
61  distributed-tracing

62  testing
63  unit-testing
64  integration-testing
65  architecture-testing
66  messaging-testing
67  cache-testing
68  docker-testing
69  kubernetes-smoke-testing
70  qa-quality-gates

71  technical-documentation
72  adr-management
73  agent-workflow
74  code-review
75  feature-flags
```

---

# 16. REGRA PARA CRIAÇÃO DAS SKILLS

As 75 responsabilidades descritas neste documento não significam obrigatoriamente 75 diretórios físicos.

Antes de criar uma nova Skill:

1. verificar se ela já existe;
2. verificar se uma Skill existente cobre a responsabilidade;
3. preferir ampliar uma Skill coerente;
4. evitar Skills pequenas demais;
5. evitar duplicação;
6. evitar responsabilidades conflitantes;
7. manter o `SKILL.md` objetivo;
8. utilizar `references/` para documentação extensa;
9. manter a Skill independente da ferramenta de IA;
10. preservar compatibilidade entre Claude Code, Codex, OpenCode e GitHub Copilot.

---

# 17. ESTRUTURA DAS SKILLS

Estrutura conceitual:

```text
.agents/
└── skills/
    ├── project-architecture/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── backend-ddd-cqrs/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── architecture-as-code/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── drawio-architecture/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── ai-application/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── aws-architecture/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── kubernetes-architecture/
    │   ├── SKILL.md
    │   └── references/
    │
    ├── observability/
    │   ├── SKILL.md
    │   └── references/
    │
    └── testing/
        ├── SKILL.md
        └── references/
```

A estrutura física real deve ser adaptada ao padrão já existente no repositório.

Não mover diretórios existentes apenas para corresponder ao exemplo acima.

---

# 18. REGRA DE REUTILIZAÇÃO

Uma Skill deve representar uma capacidade reutilizável.

Exemplo:

`aws-architecture` pode possuir referências especializadas sobre:

```text
ECS
EKS
Lambda
RDS
ElastiCache
MSK
Amazon MQ
S3
SQS
SNS
Cognito
Bedrock
CloudFront
WAF
Route 53
API Gateway
```

Isso pode ser preferível a criar uma Skill independente para cada serviço.

Da mesma forma:

`testing`

pode possuir referências para:

```text
Unit Testing
Integration Testing
Cache Testing
Messaging Testing
Architecture Testing
Docker Testing
Kubernetes Testing
```

A decisão entre criar uma nova Skill ou uma referência interna deve considerar:

- responsabilidade;
- reutilização;
- tamanho;
- contexto necessário;
- frequência de utilização;
- independência;
- risco de conflito.

---

# 19. REGRA PARA REFERENCES

Utilizar `references/` para conteúdo extenso que não precisa estar integralmente no `SKILL.md`.

Exemplo:

```text
aws-architecture/
├── SKILL.md
└── references/
    ├── ecs.md
    ├── eks.md
    ├── lambda.md
    ├── networking.md
    ├── databases.md
    ├── messaging.md
    ├── bedrock.md
    └── local-to-aws.md
```

Outro exemplo:

```text
backend-ddd-cqrs/
├── SKILL.md
└── references/
    ├── domain.md
    ├── application.md
    ├── cqrs.md
    ├── domain-events.md
    ├── repositories.md
    └── examples.md
```

Não duplicar a mesma documentação em diversas Skills.

---

# 20. REGRA PARA OS AGENTES

Todos os agentes devem trabalhar sobre a mesma base arquitetural.

Aplicável a:

```text
Claude Code
Codex
OpenCode
GitHub Copilot
Outros agentes compatíveis
```

Antes de executar alterações relevantes, o agente deverá analisar quando aplicável:

```text
prompts.md
CLAUDE.md
AGENTS.md
SKILL.md
ADRs
workspace.dsl
Draw.io
código existente
Docker Compose
Kubernetes
Infrastructure as Code
testes
```

Nenhum agente deverá inventar uma arquitetura paralela específica para sua ferramenta.

---

# 21. FLUXO DAS SKILLS

Fluxo conceitual:

```text
Solicitação do usuário
        ↓
Identificar contexto
        ↓
Carregar Skills relevantes
        ↓
Ler references necessárias
        ↓
Analisar arquitetura existente
        ↓
Planejar alteração
        ↓
Architecture Quality Gate
        ↓
Implementar
        ↓
Testar
        ↓
Code Review
        ↓
Atualizar arquitetura/documentação
        ↓
Quality Gates
```

O agente não precisa carregar todas as Skills para toda solicitação.

Deve carregar somente as Skills necessárias para a tarefa atual e suas dependências relevantes.

---

# 22. PRINCÍPIO FINAL

As Skills devem garantir que a IA compreenda que este projeto utiliza, conforme habilitado:

```text
ASP.NET Core
C#
DDD
CQRS
Domain Events
Integration Events
Transactional Outbox
Modular Monolith

React
React Native

IAM
Users
Groups
Roles
Permissions
Policies

MySQL
MongoDB
Redis

Kafka
RabbitMQ
SQS
SNS

Docker
Docker Compose
Kubernetes
Kustomize

AWS
Route 53
CloudFront
WAF
API Gateway
Cognito
ECS
EKS
Lambda
EC2
RDS / Aurora
ElastiCache
S3
MSK
Amazon MQ
Bedrock

OpenTofu
Infrastructure as Code

OpenTelemetry
Prometheus
Grafana
Loki
Tempo

LLM
RAG
Embeddings
Vector Store
Tools
Agents
Agentic Workflows
Human Approval

C4 Model
Structurizr DSL
Draw.io
ADRs

Unit Tests
Integration Tests
Architecture Tests
Quality Gates
```

Princípio arquitetural principal:

```text
LOCAL FIRST
    ↓
CONTAINER FIRST
    ↓
CLOUD READY
    ↓
AWS TARGET
```

E toda alteração relevante deverá manter sincronizados:

```text
Requisitos
    ↓
prompts.md
    ↓
Skills
    ↓
ADRs
    ↓
C4 / Structurizr
    ↓
Draw.io
    ↓
Código
    ↓
Infraestrutura
    ↓
Testes
    ↓
Documentação
```

O código, as Skills, os diagramas, os ADRs, a infraestrutura, os testes e o `prompts.md` devem representar a mesma arquitetura.

---

## `content-intelligence-orchestration`

Responsável pela ingestão e análise multi-tenant de documentos, áudio e vídeo. Deve cumprir `AI_CONTENT_INTELLIGENCE.md`, usar abstrações de Storage Provider, Content Orchestrator, LLM/RAG/Agents e respeitar autorização e isolamento por tenant.

## `multi-tenant-storage-providers`

Providers previstos: Local, MinIO, Amazon S3, Google Drive, OneDrive e SharePoint. Nunca acoplar Domain/Application a SDK concreto. Credenciais são `SecretReference`; adapters externos ficam desabilitados até configuração válida.

## `github-actions-cicd`

GitHub Actions é o CI/CD oficial. Manter workflows de CI/quality/tests, security, Docker build/publish e deploy. Secrets devem usar GitHub Environments/Secrets ou federação/OIDC quando aplicável; nunca commitar credenciais.

## `byoai-multi-tenant`

Implementar Bring Your Own AI por tenant. Modos: `ServerManaged`, `CustomerManaged`, `Hybrid`. Resolver provider por capacidade (LLM, embeddings, STT, TTS, Vision e Reranker quando aplicável), não por um único switch global.

Preparar adapters para OpenAI, Azure OpenAI, Anthropic, Gemini, Bedrock, OpenAI-compatible e Fake/Local. OpenAI-compatible deve aceitar endpoint configurável para Ollama/vLLM/equivalentes.

Credenciais do cliente são referências de secret e nunca devem aparecer em banco como texto puro, commits, logs, traces ou mensagens de erro. Fallback para IA do servidor é opt-in, auditável e bloqueável. Medir uso, latência, tokens/unidades, falhas e custo estimado por tenant/provider/capacidade quando disponível.
