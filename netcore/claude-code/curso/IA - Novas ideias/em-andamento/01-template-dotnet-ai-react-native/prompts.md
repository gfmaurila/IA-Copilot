# INSTALAÇÃO, CONFIGURAÇÃO E EVOLUÇÃO DO TEMPLATE .NET AI APPLICATION PLATFORM

Você vai me ajudar a instalar, configurar, adaptar e evoluir o **Kit IA
Dev** neste projeto.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar arquivos do Kit. A ferramenta de IA deve
compreender e preservar a arquitetura, as regras de negócio, os padrões
de desenvolvimento, o pipeline de agentes e a documentação arquitetural
definidos neste prompt.

------------------------------------------------------------------------

# 1. VISÃO DO TEMPLATE

Este projeto é um template empresarial reutilizável para aplicações:

-   ASP.NET Core;
-   React Web;
-   React Native;
-   DDD;
-   CQRS;
-   Domain Events;
-   Modular Monolith;
-   IAM (Identity and Access Management);
-   MySQL;
-   Redis quando necessário;
-   IA com LLM, RAG, Tools e Agents;
-   Docker;
-   testes unitários e de integração;
-   desenvolvimento assistido por Claude Code, Codex, Copilot ou
    ferramentas equivalentes.

O template **não é um clone do WordPress** e não deve ser tratado como
CMS WordPress.

O módulo de conteúdo é opcional e deve funcionar como **Headless Content
/ Content Platform**, sem transformar conteúdo no centro de toda
aplicação.

Conceito:

``` text
.NET Full Stack
      ↓
AI Full Stack
      ↓
AI Engineering
```

A IA deve ampliar a engenharia tradicional, e não substituir DDD, CQRS,
segurança, testes, observabilidade ou regras de domínio.

------------------------------------------------------------------------

# 2. PACOTES E CONTEXTOS DISPONÍVEIS

Podem ser fornecidos:

-   `Kit-IA-Dev/` ou `Kit-IA-Dev.zip`;
-   raiz do projeto;
-   Templates por Stack;
-   Skills Avançadas;
-   arquivos e projetos de referência.

Se algum pacote necessário não estiver disponível, solicite o caminho
absoluto ou ZIP correspondente.

Não invente conteúdo que deveria ser obtido desses pacotes.

Não copie arquivos antes de confirmar que está trabalhando na raiz
correta.

------------------------------------------------------------------------

# 3. FORMA DE CONDUÇÃO

Regras obrigatórias:

-   execute o processo em etapas;
-   execute um passo por vez;
-   ao final de cada etapa, informe resumidamente o que foi realizado;
-   espere minha confirmação antes da próxima etapa;
-   não altere silenciosamente decisões arquiteturais;
-   não simplifique a arquitetura para reduzir projetos, camadas ou
    arquivos;
-   se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas
    objetivas;
-   converse comigo em PT-BR;
-   documentação técnica destinada à IA (`CLAUDE.md`, `AGENTS.md`,
    `agent_docs`, `SKILL.md` etc.) deve permanecer em inglês, salvo
    padrão contrário do arquivo original;
-   antes de sobrescrever arquivos importantes, identifique o arquivo e
    explique a alteração.

------------------------------------------------------------------------

# 4. REGRA DE EXECUÇÃO MAIS IMPORTANTE

A primeira ação do agente deve ser **ler e executar este `prompts.md`**.

Depois disso, a ordem obrigatória é:

``` text
01. Executar prompts.md
        ↓
02. Inspecionar e construir/adaptar a estrutura inicial do projeto
        ↓
03. Gerar arquitetura editável no Draw.io
        ↓
04. Gerar ER/UML/diagramas complementares no Draw.io
        ↓
05. Architecture Quality Gate
        ↓
06. Planejar implementação
        ↓
07. Implementar
        ↓
08. Gerar/aplicar Seeds e dados fake
        ↓
09. Executar testes e QA
        ↓
10. Code Review
        ↓
11. Revalidar e atualizar Draw.io
        ↓
12. Documentação final
```

**Não iniciar implementação funcional antes do Architecture Quality
Gate.**

Os diagramas devem representar a estrutura real criada/inspecionada, e
não uma arquitetura imaginada apenas a partir deste documento.

------------------------------------------------------------------------

# 5. ESTRUTURA FÍSICA DO REPOSITÓRIO

A estrutura física principal existente deve ser preservada.

Conceitualmente:

``` text
/
├── backend/
├── frontend/
├── mobile/
├── .claude/
│   └── skills/
├── docs/
│   └── architecture/
├── docker-compose.yml
└── ...
```

Não reorganize o repositório apenas para introduzir IA, IAM ou módulos.

Responsabilidades:

-   `backend/`: ASP.NET Core e projetos/camadas existentes;
-   `frontend/`: React Web com Admin, Site e Shared;
-   `mobile/`: React Native;
-   `.claude/skills/`: skills específicas quando Claude Code for
    utilizado;
-   `docs/architecture/`: fontes Draw.io e exportações dos diagramas;
-   `docker-compose.yml`: mantém o padrão de orquestração existente.

------------------------------------------------------------------------

# 6. ARQUITETURA PRINCIPAL

Preserve as fronteiras:

-   Domain;
-   Application;
-   Infrastructure;
-   API;
-   CrossCutting;
-   Frontend React;
-   Mobile React Native.

Adote **Modular Monolith** inicialmente, sem transformar cada módulo em
microsserviço/container.

Módulos iniciais:

``` text
Identity / IAM
Content
Media
Navigation
Notifications
Audit
AI
```

Módulos podem ser opcionais conforme o projeto.

Não concentrar regras de negócio em controllers, endpoints,
repositories, componentes React, componentes React Native ou prompts de
IA.

Não substituir a arquitetura por `Controller + Service + Repository`.

------------------------------------------------------------------------

# 7. BACKEND

Preserve os projetos existentes e suas responsabilidades:

``` text
backend/
├── Template.Api/
├── Template.Application/
├── Template.Domain/
├── Template.Infrastructure/
├── Template.CrossCutting/
├── Template.Consumer/
├── Template.Producer/
├── Template.Btc/
├── Template.Csm/
└── tests/
    ├── Template.UnitTests/
    └── Template.IntegrationTests/
```

`Template` deve ser substituído pelo nome real quando definido.

Use conforme aplicável:

-   DDD;
-   CQRS;
-   Domain Events;
-   Unit of Work;
-   Repository Pattern;
-   Result Pattern;
-   Domain Notifications;
-   Domain Validations;
-   Event Sourcing somente quando houver justificativa real de domínio.

`Template.Api`: HTTP, middleware, autenticação/autorização na fronteira
e composição.

`Template.Application`: Commands, Queries, Handlers, DTOs e Use Cases.

`Template.Domain`: Aggregates, Entities, Value Objects, invariantes,
Domain Events e contratos de repositories.

`Template.Infrastructure`: persistência, repositories, Unit of Work,
migrations, MySQL e integrações técnicas.

`Template.CrossCutting`: DI e preocupações transversais.

`Template.Consumer` / `Template.Producer`: mensageria.

`Template.Btc` / `Template.Csm`: preservar responsabilidades dos
projetos de referência. Não inventar novas responsabilidades.

------------------------------------------------------------------------

# 8. IDENTITY / IAM

Substituir o modelo simples de usuários por um IAM reutilizável.

Conceitos:

``` text
User
Organization
Team
Group
Role
Permission
Policy
Session
RefreshToken
ApiKey
Audit
```

Relacionamento conceitual:

``` text
User
 ├── Organization
 ├── Teams
 ├── Groups
 └── Roles
       ↓
 Permissions
       ↓
 Policies
```

A API é sempre a autoridade final de autorização.

O frontend pode ocultar/desabilitar ações, mas nunca substituir a
autorização da API.

Permissões devem ser granulares, por exemplo:

``` text
users.read
users.create
users.update
users.delete
users.block

roles.read
roles.create
roles.update
roles.delete

permissions.read
permissions.assign

content.read
content.create
content.update
content.delete
content.publish

media.read
media.upload
media.delete

ai.chat.use
ai.agents.read
ai.agents.execute
ai.agents.manage
ai.tools.execute
ai.tools.manage
ai.knowledge.read
ai.knowledge.manage

audit.read
settings.read
settings.manage
```

Roles iniciais de demonstração:

``` text
SuperAdmin
Administrator
UserManager
ContentManager
Editor
Viewer
AIManager
AIOperator
User
```

Groups de demonstração:

``` text
Administrators
Developers
Marketing
Content Team
Support
Finance
Guests
```

------------------------------------------------------------------------

# 9. CONTENT PLATFORM --- SEM WORDPRESS

Eliminar o conceito de CMS inspirado em WordPress como núcleo do
template.

Quando o módulo Content estiver habilitado, utilizar uma abordagem
**Headless Content / Content Platform**:

``` text
Content
├── ContentTypes
├── ContentSchemas
├── ContentItems
├── Fields
├── Collections
├── Taxonomies
├── Versions
├── Drafts
├── Publishing
└── Workflows
```

O módulo deve permitir tipos de conteúdo configuráveis sem criar uma
entidade universal sem semântica de domínio.

Quando houver regras específicas de negócio, prefira entidades
explícitas.

Estados mínimos de publicação:

``` text
Draft -> Published
```

Estados adicionais só devem existir quando explicitamente modelados.

O módulo Content é opcional. Aplicações bancárias, administrativas ou
APIs internas não devem ser obrigadas a carregá-lo.

------------------------------------------------------------------------

# 10. MEDIA E NAVIGATION

`Media` deve cuidar de metadados, armazenamento e autorização de
arquivos, sem misturar regras de conteúdo.

`Navigation` deve permitir:

``` text
Menu
- Id
- Name
- Location
- Items

MenuItem
- Id
- MenuId
- Label
- Content/PageId ou Url
- ParentId
- Order
- IsVisible
```

Deve suportar hierarquia, ordenação, URLs internas/externas,
visibilidade e resolução pública.

------------------------------------------------------------------------

# 11. FRONTEND REACT

Preservar:

``` text
frontend/
└── src/
    ├── admin/
    ├── site/
    └── shared/
```

Organizar por feature.

Admin conceitual:

``` text
Dashboard

Identity
 ├── Users
 ├── Groups
 ├── Roles
 ├── Permissions
 ├── Organizations
 └── Sessions

Content (quando habilitado)
 ├── Content Types
 ├── Content
 ├── Media
 ├── Navigation
 └── Publishing

AI
 ├── Copilot
 ├── Agents
 ├── Knowledge
 ├── Documents
 ├── Prompts
 ├── Tools
 └── Executions

System
 ├── Settings
 ├── Feature Flags
 ├── Audit
 ├── Logs
 ├── Jobs
 └── Health
```

Admin e Site não devem importar implementações internas um do outro.
Código compartilhado deve estar em `shared`.

------------------------------------------------------------------------

# 12. REACT NATIVE

Preservar a estrutura e padrões React Native existentes.

Não adotar Expo automaticamente.

O Mobile deve consumir os mesmos contratos/autorização da API e
respeitar permissions/policies.

Features não devem conter regras de domínio que pertencem ao backend.

------------------------------------------------------------------------

# 13. BANCO DE DADOS

Banco padrão inicial:

``` text
MySQL 8.x
```

Persistência via EF Core com provider compatível.

Domain e Application não devem depender de detalhes do MySQL.

A infraestrutura deve permitir futura substituição por SQL Server ou
PostgreSQL sem reescrever o domínio/CQRS.

Conceitualmente:

``` text
Domain
   ↑
Application
   ↑
Infrastructure
   └── MySQL
```

Não introduzir abstrações artificiais sem necessidade, mas evitar
SQL/provider específico fora de Infrastructure.

------------------------------------------------------------------------

# 14. SEEDS E BASE FAKE --- OBRIGATÓRIO

O template deve iniciar em desenvolvimento com dados demonstrativos
coerentes e relacionados.

Não entregar dashboards e CRUDs vazios.

Criar seeds para:

``` text
IdentitySeed
├── Organizations
├── Users
├── Groups
├── Roles
├── Permissions
├── UserRoles
├── GroupRoles
└── Sessions

ContentSeed
├── ContentTypes
├── ContentItems
├── Categories/Taxonomies
├── Pages quando aplicável
├── Navigation
└── Versions

MediaSeed
NotificationSeed
AuditSeed

AISeed
├── Agents
├── Prompts
├── Tools
├── KnowledgeBases
├── Documents
└── Executions
```

Gerar aproximadamente 30--50 usuários no modo Demo, além de contas
determinísticas.

Exemplos:

``` text
admin@demo.local
manager@demo.local
editor@demo.local
developer@demo.local
viewer@demo.local
ai.admin@demo.local
user@demo.local
```

Senhas de desenvolvimento devem vir de `.env`/secrets e nunca ser
hardcoded para produção.

Os dados fake devem ser reproduzíveis, preferencialmente usando seed
aleatória fixa quando Bogus ou biblioteca equivalente for utilizada.

Modos:

``` text
Minimal
Demo
Stress
```

-   `Minimal`: contas essenciais, roles e permissions;
-   `Demo`: base funcional completa;
-   `Stress`: grande volume para paginação e performance.

Criar também cenários coerentes:

-   usuário bloqueado;
-   sessão expirada;
-   permissão negada;
-   conteúdo Draft/Published/Archived quando suportado;
-   aprovação pendente;
-   auditoria;
-   execução de agente concluída;
-   execução de agente com falha;
-   ação de IA aguardando aprovação humana.

Seeds de desenvolvimento não devem executar automaticamente em produção.

------------------------------------------------------------------------

# 15. INTELIGÊNCIA ARTIFICIAL

O módulo AI deve ser desacoplado do fornecedor de LLM.

Capacidades:

``` text
LLM
Structured Output
Prompt Management
RAG
Embeddings
Vector Search
Tools
Agents
Agent Workflows
Human Approval
AI Security
AI Observability
AI Evaluation
```

Arquitetura conceitual:

``` text
React / React Native
        ↓
ASP.NET Core
        ↓
Application / CQRS
        ↓
AI Orchestration
   ├── LLM
   ├── RAG
   ├── Tools
   └── Agents
        ↓
Domain/Application
        ↓
MySQL / Redis / Vector DB / APIs
```

Não espalhar SDK de fornecedor de LLM por controllers ou handlers de
domínio.

Definir abstrações apropriadas para Chat Model, Embeddings, Vector
Store, Tools e Agents.

Provedores concretos pertencem à Infrastructure.

------------------------------------------------------------------------

# 16. AI TOOLS + CQRS

Agents/LLMs não devem acessar diretamente tabelas de negócio.

Fluxo obrigatório:

``` text
LLM/Agent
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

Tools devem respeitar:

-   autorização;
-   permissions;
-   validações;
-   invariantes;
-   auditoria;
-   idempotência quando necessária.

Ações sensíveis devem suportar **Human-in-the-loop**.

Exemplo:

``` text
Agent cria plano
      ↓
usuário visualiza
      ↓
usuário aprova
      ↓
Commands são executados
```

------------------------------------------------------------------------

# 17. RAG

Quando habilitado:

``` text
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
```

Documentos devem possuir autorização e escopo.

Em cenário multi-tenant, conhecimento de tenants diferentes nunca pode
ser misturado.

Vector DB é opcional e só deve ser adicionado ao Docker quando RAG
estiver habilitado ou necessário.

------------------------------------------------------------------------

# 18. SEGURANÇA DE IA

Tratar IA como componente não confiável.

Considerar obrigatoriamente:

-   autenticação;
-   autorização;
-   permissions para Tools;
-   prompt injection;
-   indirect prompt injection;
-   proteção de dados;
-   PII;
-   secrets;
-   limites de contexto;
-   validação de structured output;
-   allowlist de Tools;
-   rate limits;
-   auditoria;
-   aprovação humana para ações sensíveis.

Nunca permitir que texto produzido pelo modelo ignore regras de domínio
ou autorização.

------------------------------------------------------------------------

# 19. OBSERVABILIDADE E AVALIAÇÃO DE IA

Registrar quando aplicável:

-   modelo/provedor;
-   latência;
-   tokens de entrada;
-   tokens de saída;
-   custo estimado;
-   falhas;
-   Tool Calls;
-   Agent executions;
-   retries;
-   avaliações;
-   taxa de erro;
-   resultados de RAG;
-   correlation/trace id.

Não registrar secrets, PII ou conteúdo sensível sem necessidade e
política explícita.

------------------------------------------------------------------------

# 20. DOCKER COMPOSE

**Preservar a estrutura e estratégia do Docker Compose existente.**

Não redesenhar o Docker Compose apenas porque o projeto se tornou
modular.

Modular Monolith não significa um container por módulo.

Manter `/docker-compose.yml` na raiz e os arquivos de ambiente
existentes do template, inclusive variações DEV/HML/PROD quando já
existirem.

Serviços conceituais:

``` text
mysql-dev
mysql-test
redis          # quando necessário
backend
frontend
vector-db      # opcional, somente quando RAG exigir
```

DEV e TEST devem permanecer isolados.

O banco padrão passa a ser MySQL.

Não criar containers separados para Identity, Content, Audit ou AI
enquanto continuarem módulos do mesmo backend.

------------------------------------------------------------------------

# 21. TESTES

Unit Tests devem cobrir principalmente:

-   invariantes;
-   Value Objects;
-   Domain Validations;
-   Commands/Handlers apropriados;
-   transições;
-   autorização;
-   Policies;
-   Tools;
-   parsing/validação de respostas estruturadas.

Integration Tests devem usar infraestrutura real de teste e banco TEST
isolado.

Cobrir:

-   API;
-   persistência;
-   IAM;
-   permissions;
-   seeds;
-   migrations;
-   fluxos CQRS;
-   Tools;
-   Human Approval;
-   integrações de IA através de doubles/fakes quando chamada externa
    real não for necessária.

Nunca usar banco DEV nos testes.

------------------------------------------------------------------------

# 22. DRAW.IO --- OBRIGATÓRIO E SEGUNDA ETAPA APÓS A ESTRUTURA

Depois de executar este prompt e construir/inspecionar a estrutura
inicial, gerar documentação arquitetural em **Draw.io**.

Os arquivos `.drawio` são a fonte oficial e devem permanecer editáveis.

Criar no mínimo:

``` text
docs/architecture/
├── system-architecture.drawio
├── system-architecture.png
├── modules.drawio
├── modules.png
├── database-er.drawio
├── database-er.png
├── identity-iam.drawio
├── identity-iam.png
├── ai-flow.drawio
└── ai-flow.png
```

Quando UML adicional for necessária, também gerar `.drawio` + exportação
PNG.

Os diagramas devem ser gerados a partir da estrutura real.

Processo:

``` text
1. construir/inspecionar estrutura
2. identificar projetos
3. identificar módulos
4. identificar dependências
5. identificar entidades/relacionamentos
6. gerar Draw.io
7. exportar PNG
8. validar contra código
```

Não utilizar Mermaid como substituto do Draw.io para os diagramas
oficiais.

Mermaid pode ser usado apenas como documentação auxiliar quando
explicitamente solicitado.

------------------------------------------------------------------------

# 23. ARCHITECTURE QUALITY GATE

Antes da implementação funcional, validar:

``` text
[ ] prompts.md executado
[ ] estrutura física preservada
[ ] projetos/camadas identificados
[ ] dependências analisadas
[ ] MySQL configurado como padrão
[ ] IAM definido
[ ] módulos definidos
[ ] estratégia de Seeds definida
[ ] AI boundaries definidas

[ ] system-architecture.drawio criado
[ ] modules.drawio criado
[ ] database-er.drawio criado
[ ] identity-iam.drawio criado
[ ] ai-flow.drawio criado
[ ] PNGs exportados

[ ] diagramas correspondem à estrutura real
[ ] nenhuma dependência inexistente foi desenhada
[ ] nenhuma dependência crítica foi omitida
```

Somente `PASS` libera a implementação.

Ao final da implementação, executar o Architecture Agent novamente em
modo de validação e atualizar os Draw.io quando necessário.

------------------------------------------------------------------------

# 24. AGENTES DE DESENVOLVIMENTO

Pipeline conceitual:

``` text
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

Artefatos esperados, quando aplicáveis:

``` text
REQUIREMENTS.md
ARCHITECTURE_PLAN.md
EXECUTION_PLAN.md
TEST_REPORT.md
REVIEW_REPORT.md
```

Claude Code, Codex e Copilot devem receber regras arquiteturais
equivalentes. Não criar arquiteturas diferentes por ferramenta.

------------------------------------------------------------------------

# 25. CLAUDE.md, AGENTS.md E SKILLS

Leia o `SETUP NOTE` do `CLAUDE.md` e resolva os `[FILL]`.

Registre:

-   ASP.NET Core;
-   React;
-   React Native;
-   DDD/CQRS;
-   Modular Monolith;
-   IAM;
-   MySQL;
-   Seeds;
-   AI/RAG/Tools/Agents;
-   Human Approval;
-   Draw.io;
-   Docker DEV/TEST e ambientes existentes;
-   checklist de CRUD/features.

Instale as skills do Kit preservando pastas completas, inclusive
`references/`.

Skills específicas do projeto devem cobrir pelo menos:

``` text
project-architecture
backend-ddd-cqrs
frontend-react-architecture
frontend-react-native-architecture
crud-generation
identity-iam-authorization
content-platform
navigation-management
ai-application
rag
ai-tools-agents
testing
docker-development
drawio-architecture
```

Antes de criar uma nova skill, verifique se uma existente pode ser
estendida sem perder sua finalidade.

------------------------------------------------------------------------

# 26. FEATURE FLAGS

Preparar o template para habilitar/desabilitar módulos quando fizer
sentido:

``` text
Identity       ON
Audit          ON
Notifications  configurável
Content        configurável
Media          configurável
AI             configurável
RAG            configurável
MultiTenant    configurável
```

Feature Flag não deve enfraquecer segurança nem permitir bypass de
autorização.

------------------------------------------------------------------------

# 27. MULTI-TENANT READY

O template pode nascer preparado para futura multi-tenancy, sem obrigar
todo projeto a usá-la.

Quando habilitada:

``` text
Tenant/Organization
 ├── Users
 ├── Groups
 ├── Content
 └── AI Knowledge
```

Nunca permitir vazamento de dados, documentos, embeddings ou resultados
de RAG entre tenants.

------------------------------------------------------------------------

# 28. VALIDAÇÃO DA INSTALAÇÃO

Validar pelo menos:

## Kit

Confirmar ativação correta das skills.

## Arquitetura

Solicitação exemplo:

``` text
"crie um CRUD de produtos"
```

A IA deve considerar Domain, Application, Infrastructure, API,
permissions, Admin, testes e demais superfícies aplicáveis.

## IAM

Solicitação exemplo:

``` text
"adicione gerenciamento de usuários"
```

Deve considerar Users, Groups, Roles, Permissions, Policies, API
authorization, audit e testes.

## Content

Quando habilitado:

``` text
"crie um tipo de conteúdo Produto"
```

Deve considerar schema, fields, permissions, versionamento/publicação
quando aplicável e APIs.

## AI

``` text
"crie um agente que possa consultar clientes"
```

Deve produzir:

``` text
Agent -> Tool -> Query -> Application -> Domain/Repository
```

e nunca acesso direto do LLM ao banco.

## Draw.io

Confirmar que os diagramas oficiais existem, são editáveis e
correspondem ao código.

------------------------------------------------------------------------

# 29. PROIBIÇÕES

Não:

-   substituir DDD por arquitetura simplificada;
-   remover CQRS;
-   eliminar projetos existentes porque parecem desnecessários;
-   transformar módulos em microsserviços sem necessidade;
-   criar container por módulo;
-   colocar regra de negócio em Controller/Endpoint;
-   colocar autorização somente no frontend;
-   compartilhar DEV com TEST;
-   transformar o sistema em clone do WordPress;
-   adicionar plugins, marketplace ou themes do WordPress;
-   tornar Content obrigatório para todos os projetos;
-   permitir LLM acessar diretamente tabelas de negócio;
-   permitir Tool ignorar CQRS/Domain;
-   permitir IA executar ações sensíveis sem autorização/aprovação
    quando exigida;
-   misturar dados de tenants;
-   hardcodar secrets;
-   habilitar seeds Demo/Stress automaticamente em produção;
-   usar Mermaid como substituto dos Draw.io oficiais;
-   gerar diagramas antes de inspecionar/construir a estrutura;
-   alterar a estrutura-base de pastas sem necessidade;
-   redesenhar o Docker Compose sem necessidade;
-   alterar Btc/Csm sem analisar referência;
-   atualizar versões indiscriminadamente.

As regras específicas deste projeto têm precedência sobre sugestões
genéricas do Kit.

------------------------------------------------------------------------

# 30. RESULTADO ESPERADO

Ao terminar, quero um template onde a IA compreenda:

> Este é um template empresarial ASP.NET Core + React + React Native,
> com DDD, CQRS, Domain Events, Modular Monolith, IAM completo, MySQL,
> dados fake/seeds, módulos opcionais de Content/Media/Navigation, IA
> com LLM/RAG/Tools/Agents, Human-in-the-loop, testes reais, Docker e
> documentação arquitetural oficial em Draw.io. A estrutura física
> principal e a estratégia de Docker Compose existentes devem ser
> preservadas.

O template deve servir como base para:

-   sistemas administrativos;
-   APIs corporativas;
-   portais;
-   aplicações internas;
-   SaaS;
-   aplicações com IA;
-   aplicações sem Content;
-   aplicações com Headless Content.

A IA deve receber futuras solicitações e respeitar automaticamente esta
arquitetura.

------------------------------------------------------------------------

# 31. INÍCIO

Comece somente pela **Etapa 1**.

Confirme se consegue acessar:

1.  Kit IA Dev;
2.  pacote Templates por Stack;
3.  pacote Skills Avançadas;
4.  raiz do projeto.

Depois:

-   leia este `prompts.md` integralmente;
-   inspecione a estrutura atual;
-   não implemente features ainda;
-   não gere Draw.io antes de construir/validar a estrutura inicial;
-   não altere a estrutura-base ou Docker Compose sem necessidade.

Se algum pacote não estiver disponível, solicite apenas o caminho
absoluto ou ZIP correspondente.

**Espere minha confirmação antes de continuar para a próxima etapa.**
