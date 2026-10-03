# INSTALAÇÃO E CONFIGURAÇÃO DO KIT IA DEV

Você vai me ajudar a instalar, configurar e adaptar o **Kit IA Dev** ao meu projeto.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar arquivos do Kit. Você deve configurar o Kit para que a ferramenta de IA de código compreenda e preserve a arquitetura, as regras de negócio e os padrões definidos neste prompt.

---

# 1. CONTEXTO

Pacotes disponíveis:

- Kit IA Dev
- Templates por Stack
- Skills Avançadas

Ferramenta de IA utilizada:

- Claude Code; ou
- outra ferramenta de IA de código compatível com instruções de projeto e/ou Agent Skills no padrão `SKILL.md`.

Stack principal:

```text
Python
```

Python é a linguagem principal.

Não escolha automaticamente framework, ORM, banco de dados, gerenciador de dependências ou servidor de aplicação.

Antes de configurar o projeto, identifique se ele utiliza:

### Framework

- Django;
- FastAPI;
- Flask;
- Litestar;
- outro framework;
- Python sem framework web.

### Persistência

- Django ORM;
- SQLAlchemy;
- SQLModel;
- Tortoise ORM;
- outro ORM;
- SQL direto;
- mecanismo NoSQL;
- outro mecanismo.

### Gerenciamento de dependências

- Poetry;
- uv;
- pip;
- pip-tools;
- PDM;
- Pipenv;
- outro mecanismo.

Preserve as decisões existentes.

Se alguma decisão ainda não estiver definida, apresente as opções relevantes e solicite confirmação antes de adotar uma.

---

# 2. ARQUIVOS E PASTAS QUE POSSO FORNECER

Os contextos podem ser fornecidos como pasta ou ZIP.

## Kit principal

```text
Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev.zip
```

## Projeto

A raiz do repositório onde o Kit será instalado.

## Templates por Stack

```text
Order-Bump-Templates-por-Stack/
```

ou:

```text
Kit-IA-Dev-Templates-por-Stack.zip
```

## Skills Avançadas

```text
Upsell1-Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev-Skills-Avancadas.zip
```

Se algum arquivo necessário não estiver disponível, solicite:

- caminho absoluto; ou
- ZIP correspondente.

Não invente conteúdo que deveria ser obtido desses pacotes.

Não copie arquivos antes de confirmar a raiz correta do projeto.

---

# 3. FORMA DE CONDUÇÃO

Execute o processo em etapas.

Regras obrigatórias:

- execute um passo por vez;
- ao final de cada etapa, informe resumidamente o que foi realizado;
- espere minha confirmação antes da próxima etapa;
- não altere silenciosamente decisões arquiteturais;
- não substitua esta arquitetura por uma arquitetura Python genérica;
- não simplifique a estrutura apenas para reduzir arquivos;
- não introduza frameworks ou bibliotecas por preferência;
- se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas objetivas;
- converse comigo em PT-BR.

Conteúdo técnico destinado à IA, como:

```text
CLAUDE.md
AGENTS.md
agent_docs/
SKILL.md
```

deve permanecer em inglês, salvo quando o arquivo original estabelecer outro padrão.

Antes de sobrescrever arquivos existentes importantes, identifique-os e explique brevemente a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para aplicações **CRUD/CMS com Python**.

A experiência administrativa é inspirada no gerenciamento de conteúdo do WordPress.

Administradores devem conseguir gerenciar:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação.

O site público deve refletir páginas, menus e conteúdos publicados sem exigir alteração manual de código para páginas básicas.

A inspiração no WordPress é exclusivamente relacionada à experiência administrativa de conteúdo.

Não fazem parte do escopo:

- plugins;
- marketplace;
- sistema de temas instaláveis;
- widgets;
- page builder complexo;
- extensões instaláveis.

Não transforme o projeto em um clone arquitetural do WordPress.

---

# 5. ESTRUTURA DO REPOSITÓRIO

A estrutura deve respeitar o projeto existente.

Conceitualmente:

```text
/
├── src/
├── tests/
├── .claude/
│   └── skills/
├── docker/
├── docker-compose.yml
├── pyproject.toml
│   ou requirements*.txt
│   ou equivalente
├── .env.example
└── ...
```

Não reorganize automaticamente um projeto existente apenas para fazê-lo coincidir literalmente com esta estrutura.

A arquitetura lógica obrigatória é:

```text
Domain
Application
Infrastructure
API
Presentation
```

Uma estrutura conceitual possível:

```text
src/
├── domain/
│   ├── identity/
│   ├── content/
│   └── navigation/
│
├── application/
│   ├── identity/
│   ├── content/
│   └── navigation/
│
├── infrastructure/
│   ├── persistence/
│   ├── messaging/
│   └── services/
│
├── api/
└── shared/
```

A representação física pode variar conforme o framework existente.

As fronteiras arquiteturais, porém, devem ser preservadas.

---

# 6. REGRA ARQUITETURAL PRINCIPAL

**NÃO simplifique, substitua ou descaracterize a arquitetura definida neste prompt.**

Todo CRUD deve respeitar conceitualmente:

```text
Domain
    ↓
Application
    ↓
Infrastructure
    ↓
API
    ↓
Presentation
```

O Domain não deve depender diretamente de:

- Django;
- FastAPI;
- Flask;
- SQLAlchemy;
- Django ORM;
- HTTP;
- banco de dados;
- framework frontend;
- detalhes de infraestrutura.

Não concentre regras de negócio em:

- views;
- routes;
- routers;
- controllers;
- API endpoints;
- serializers;
- schemas;
- ORM models;
- repositories concretos;
- frontend.

Não substitua a arquitetura por:

```text
Route
  ↓
Service
  ↓
ORM Model
  ↓
Database
```

ou:

```text
View
  ↓
Model
  ↓
Database
```

apenas porque isso é comum em determinados frameworks Python.

As regras de negócio permanecem no Domain.

---

# 7. ARQUITETURA

Utilize, conforme a responsabilidade:

- Domain Driven Design;
- CQRS;
- Event Sourcing quando aplicável;
- Unit of Work quando necessário;
- Repository Pattern;
- Result Pattern;
- Domain Events;
- Domain Notifications;
- Domain Validations;
- Dependency Injection quando apropriada.

Não utilize um padrão apenas porque ele está listado.

Cada padrão deve possuir responsabilidade real.

---

# 8. DOMÍNIOS INICIAIS

Os domínios iniciais são:

```text
Identity
Content
Navigation
```

Cada domínio deve possuir organização coerente com suas responsabilidades.

---

# 9. DOMAIN

O Domain é responsável por:

- Aggregates;
- Entities;
- Value Objects;
- Domain Events;
- Domain Services;
- Domain Validations;
- invariantes;
- regras de negócio;
- contratos de repositories.

Estrutura conceitual:

```text
domain/
└── content/
    ├── aggregates/
    ├── entities/
    ├── value_objects/
    ├── events/
    ├── repositories/
    ├── services/
    ├── validations/
    └── exceptions/
```

Domain deve utilizar Python puro sempre que possível.

Evite imports de:

```python
django
fastapi
flask
sqlalchemy
pydantic
```

dentro do Domain quando esses imports representarem acoplamento técnico desnecessário.

Domain Entities não devem automaticamente ser ORM Models.

---

# 10. ENTITIES E VALUE OBJECTS

Entities possuem identidade.

Value Objects representam conceitos definidos por seus valores.

Exemplos possíveis:

```text
PageId
UserId
Slug
Email
MenuLocation
```

Não transforme toda string em Value Object sem necessidade.

Crie Value Objects quando eles encapsularem:

- validação;
- normalização;
- comportamento;
- invariantes;
- semântica relevante.

---

# 11. APPLICATION

Application é responsável por:

- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- Use Cases;
- DTOs internos;
- Result Pattern;
- orquestração.

Exemplo:

```text
application/
└── content/
    └── pages/
        ├── commands/
        │   ├── create_page/
        │   ├── update_page/
        │   ├── delete_page/
        │   └── publish_page/
        │
        ├── queries/
        │   ├── get_page/
        │   └── list_pages/
        │
        └── dto/
```

Commands representam intenção de alteração.

Queries representam leitura.

Não utilize CQRS apenas como nomenclatura.

---

# 12. CQRS

Fluxo de escrita:

```text
HTTP Request
      ↓
Command
      ↓
Command Handler
      ↓
Domain Aggregate
      ↓
Repository
      ↓
Persistence
```

Fluxo de leitura:

```text
HTTP Request
      ↓
Query
      ↓
Query Handler
      ↓
Read Model / Repository
      ↓
Response
```

Exemplo:

```text
PublishPageCommand
        ↓
PublishPageHandler
        ↓
Page Aggregate
        ↓
page.publish()
        ↓
PagePublished
        ↓
Repository
```

Não faça simplesmente:

```python
page.status = "published"
repository.save(page)
```

quando publicação possuir invariantes.

Prefira:

```python
page.publish()
```

onde o Aggregate protege suas regras.

---

# 13. INFRASTRUCTURE

Infrastructure é responsável por:

- persistência;
- implementação de repositories;
- ORM;
- migrations;
- banco;
- cache;
- mensageria;
- filesystem;
- e-mail;
- serviços externos;
- adapters técnicos.

Estrutura conceitual:

```text
infrastructure/
├── persistence/
├── repositories/
├── messaging/
├── cache/
├── mail/
├── filesystem/
└── integrations/
```

Detalhes técnicos não devem vazar para o Domain sem necessidade.

---

# 14. ORM / PERSISTÊNCIA

Não escolha ORM automaticamente.

Verifique primeiro:

- Django ORM;
- SQLAlchemy;
- SQLModel;
- Tortoise ORM;
- outro ORM;
- SQL direto;
- NoSQL.

Preserve a decisão existente.

Não assuma:

```text
ORM Model = Domain Entity
```

Quando separados:

```text
Domain Entity
      ↕
Persistence Mapper
      ↕
Persistence Model
```

Exemplo:

```text
Page
PageModel
PageMapper
```

O contrato do Repository pertence à camada interna apropriada.

A implementação concreta pertence à Infrastructure.

---

# 15. UNIT OF WORK

Quando múltiplas alterações precisarem compartilhar uma transação, utilize Unit of Work quando apropriado.

Conceitualmente:

```python
with unit_of_work:
    repository.save(entity)
    unit_of_work.commit()
```

A interface concreta deve seguir o mecanismo adotado pelo projeto.

Não crie Unit of Work artificial se a stack já possuir uma abstração transacional adequada.

Não espalhe `commit()` arbitrariamente pelas regras de negócio.

---

# 16. MIGRATIONS

Identifique o mecanismo existente.

Pode ser:

- Django Migrations;
- Alembic;
- outro mecanismo.

Não escolha Alembic automaticamente.

Não escolha Django Migrations se Django não fizer parte do projeto.

Preserve migrations históricas.

Novas alterações estruturais devem gerar novas migrations quando apropriado.

---

# 17. API

A camada API pode possuir:

```text
api/
├── routes/
├── controllers/
├── schemas/
├── requests/
├── responses/
├── dependencies/
├── security/
├── middleware/
└── exception_handlers/
```

A estrutura concreta depende do framework.

A API deve:

1. receber requisição;
2. validar aspectos de transporte;
3. converter entrada;
4. executar Command/Query/Use Case;
5. converter resultado;
6. produzir resposta HTTP.

Não coloque regras de negócio em endpoints.

---

# 18. PYDANTIC / SERIALIZERS / SCHEMAS

Quando FastAPI/Pydantic estiver presente:

```text
Pydantic Model
≠
Domain Entity
```

Quando Django/DRF estiver presente:

```text
Serializer
≠
Domain Entity
```

Schemas e serializers são mecanismos de transporte/validação.

Eles não substituem:

- Value Objects;
- Aggregates;
- Domain Validation;
- invariantes.

---

# 19. DJANGO

Se Django estiver presente, utilize seus recursos sem eliminar as fronteiras arquiteturais.

Django pode fornecer:

- routing;
- ORM;
- migrations;
- middleware;
- authentication;
- admin;
- forms;
- management commands.

Mas não transforme automaticamente:

```text
Django Model
=
Domain Entity
```

nem:

```text
View
→ Model
→ Database
```

em toda a arquitetura.

Se Django Admin for utilizado, trate-o como mecanismo de Presentation/Admin.

Ele não substitui Application nem Domain.

---

# 20. FASTAPI

Se FastAPI estiver presente, utilize seus recursos técnicos.

Pode fornecer:

- routing;
- dependency injection;
- OpenAPI;
- request validation;
- response models;
- middleware.

Não coloque regras de negócio diretamente em:

```python
@router.post(...)
async def create_page(...):
    ...
```

Endpoints devem delegar para Application.

Pydantic validation não substitui Domain Validation.

---

# 21. FLASK

Se Flask estiver presente, preserve sua configuração existente.

Blueprints, extensions e handlers são recursos técnicos.

Não transforme o projeto automaticamente em:

```text
Route
→ Service
→ SQLAlchemy Model
```

quando isso violar as fronteiras deste prompt.

---

# 22. ASYNC / SYNC

Não converta automaticamente código síncrono para assíncrono.

Não converta automaticamente código assíncrono para síncrono.

Identifique:

- framework;
- driver do banco;
- ORM;
- mensageria;
- integrações.

Use `async/await` quando fizer sentido para a stack.

Não misture APIs sync e async de forma insegura.

---

# 23. IDENTITY

Relacionamento:

```text
User
  → Roles
      → Permissions
```

User, Role e Permission são conceitos distintos.

Permissions representam operações autorizadas.

A API é a autoridade final para autorização.

Frontend não é fronteira de segurança.

---

# 24. AUTENTICAÇÃO

Antes de implementar autenticação, analise a stack.

Pode existir:

- sessão;
- JWT;
- OAuth 2;
- OpenID Connect;
- Django Authentication;
- Identity Provider;
- outro mecanismo.

Não escolha JWT automaticamente.

Não implemente autenticação própria quando o projeto já utilizar mecanismo adequado.

Passwords nunca devem ser armazenadas em texto puro.

Secrets não devem ser versionados.

---

# 25. AUTORIZAÇÃO

Cada CRUD deve definir permissions.

Exemplo:

```text
Page.Read
Page.Create
Page.Update
Page.Delete
Page.Publish
```

A API deve validar essas permissions.

A UI pode ocultar ações, mas isso não substitui autorização do backend.

Não coloque regras críticas apenas em decorators ou middleware se o caso de uso também precisar protegê-las.

---

# 26. CONTENT

## Page

Modelo inicial:

```text
Page
- Id
- Title
- Slug
- Body/Content
- Status
- PublishedAt
- CreatedAt
- UpdatedAt
- Version
```

Estados iniciais:

```text
Draft → Published
```

Opcionalmente, quando explicitamente definidos:

```text
Published → Draft/Unpublished
Published → Archived
```

Não introduza estados automaticamente.

As transições devem possuir regras explícitas.

Prefira:

```python
page.publish()
```

em vez de alterar diretamente o estado quando houver invariantes.

---

# 27. NAVIGATION

## Menu

```text
Menu
- Id
- Name
- Location
- Items
```

## MenuItem

```text
MenuItem
- Id
- MenuId
- Label
- PageId ou Url
- ParentId
- Order
- IsVisible
```

Menus devem permitir:

- hierarquia;
- ordenação;
- páginas internas;
- URLs externas;
- visibilidade;
- resolução pública.

As invariantes devem permanecer no Domain.

---

# 28. ADMIN E SITE

O sistema possui:

```text
Admin
Site
```

Admin deve permitir gerenciar:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação.

Site deve resolver:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação pública.

Não escolha automaticamente frontend.

Se Django Templates fizer parte da solução, preserve essa decisão.

Se existir frontend separado, preserve a tecnologia utilizada.

---

# 29. DOMAIN EVENTS

Exemplos:

```text
PagePublished
UserRoleChanged
MenuUpdated
```

Não confunda:

```text
Domain Event
```

com:

```text
Framework Signal
ORM Hook
Integration Event
Message Broker Message
```

Em Django, por exemplo:

```text
Django Signal
≠
Domain Event automaticamente
```

Um Domain Event pode originar Integration Event.

São responsabilidades diferentes.

---

# 30. EVENT SOURCING

Utilize somente quando aplicável.

Não transforme CRUDs simples em Event Sourcing.

Quando utilizado, defina:

- Aggregate;
- Event Stream;
- Event Store;
- versão;
- reconstrução;
- concorrência;
- snapshots quando necessários.

---

# 31. MENSAGERIA

Quando necessária, mantenha:

```text
Domain Event
Integration Event
Message
```

Tecnologias podem incluir, se já definidas ou aprovadas:

- RabbitMQ;
- Kafka;
- SQS;
- Redis Streams;
- Celery broker;
- outras.

Não instale broker automaticamente.

---

# 32. BACKGROUND JOBS

Antes de criar processamento em background, verifique se existe:

- Celery;
- RQ;
- Dramatiq;
- framework-specific background tasks;
- outro mecanismo.

Não instale Celery automaticamente.

Jobs devem chamar Application/Use Cases quando apropriado.

Não duplique regras de negócio dentro de workers.

---

# 33. CACHE

Cache não é fonte primária da verdade.

Se conteúdo publicado ou menus forem armazenados em cache, defina estratégia de invalidação.

Pode existir:

- Redis;
- Memcached;
- cache local;
- outro mecanismo.

Não instale Redis automaticamente.

---

# 34. RESULT PATTERN

Utilize Result Pattern conforme a convenção do projeto.

Exemplo conceitual:

```text
Result[T]
├── success
├── value
└── errors
```

Não utilize exceptions como mecanismo comum de fluxo de negócio quando Result Pattern for mais apropriado.

Exceptions permanecem válidas para condições excepcionais.

---

# 35. DOMAIN NOTIFICATIONS

Mantenha separação entre:

```text
Domain Notification
Validation Error
Application Error
HTTP Error
Exception
```

A API deve converter resultados internos em respostas HTTP adequadas.

---

# 36. DEPENDENCY INJECTION

Não introduza container de DI automaticamente.

Primeiro analise a arquitetura.

Pode existir:

- DI nativa do framework;
- factory/composition root;
- biblioteca específica;
- wiring explícito.

O importante é preservar Dependency Inversion.

Exemplo:

```text
Application
    ↓
PageRepository Protocol/ABC

Infrastructure
    ↓
SqlAlchemyPageRepository
```

Não faça Domain depender da implementação concreta.

---

# 37. INTERFACES / PROTOCOLS / ABC

Quando necessário, contratos podem utilizar:

```python
typing.Protocol
```

ou:

```python
abc.ABC
```

ou outra convenção existente.

Não force Protocol ou ABC indiscriminadamente.

Preserve o estilo arquitetural do projeto.

---

# 38. TYPE HINTS

O projeto deve utilizar type hints de maneira consistente quando essa for a convenção adotada.

Não utilize:

```python
Any
```

como fuga sistemática de modelagem.

Não desabilite type checking apenas para eliminar erros.

Se houver:

- mypy;
- pyright;
- basedpyright;
- outro checker;

preserve sua configuração.

---

# 39. PYTHON VERSION

Identifique a versão antes de alterar código.

Pode estar definida em:

```text
pyproject.toml
.python-version
Dockerfile
runtime config
CI
```

Não utilize recursos de uma versão mais nova sem verificar compatibilidade.

Não atualize Python automaticamente.

---

# 40. DEPENDENCY MANAGEMENT

Identifique primeiro a ferramenta.

Pode existir:

```text
pyproject.toml
requirements.txt
requirements-dev.txt
poetry.lock
uv.lock
Pipfile
Pipfile.lock
pdm.lock
```

Preserve o mecanismo existente.

Não crie múltiplos mecanismos concorrentes.

Por exemplo, não introduza Poetry em projeto gerenciado por uv sem autorização.

Não gere lockfiles conflitantes.

---

# 41. PYPROJECT.TOML

Quando existir:

```text
pyproject.toml
```

analise:

- metadata;
- dependencies;
- optional dependencies;
- build system;
- test configuration;
- lint;
- formatting;
- type checking;
- package configuration.

Não sobrescreva configurações existentes indiscriminadamente.

---

# 42. QUALIDADE DE CÓDIGO

Identifique ferramentas existentes.

Podem existir:

- Ruff;
- Black;
- isort;
- Flake8;
- pylint;
- mypy;
- pyright;
- pre-commit.

Preserve a configuração existente.

Não instale todas essas ferramentas automaticamente.

Não configure ferramentas concorrentes para a mesma responsabilidade sem necessidade.

---

# 43. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

Sempre que for solicitado um novo CRUD, verifique:

- [ ] Aggregate/Entity criado no Domain quando aplicável
- [ ] Invariantes definidas
- [ ] Value Objects criados quando necessários
- [ ] Domain Events definidos quando necessários
- [ ] Domain Validations implementadas
- [ ] Repository contract definido
- [ ] Commands criados
- [ ] Queries criadas
- [ ] Command Handlers implementados
- [ ] Query Handlers implementados
- [ ] Use Cases implementados quando apropriado
- [ ] Result Pattern aplicado
- [ ] Domain Notifications aplicadas quando necessárias
- [ ] Persistence Model criado quando necessário
- [ ] Mapper criado quando Domain/Persistence estiverem separados
- [ ] Repository concreto implementado
- [ ] Unit of Work respeitado quando aplicável
- [ ] Migration criada quando necessária
- [ ] Dependency Injection/composition configurada
- [ ] API endpoint/controller/router implementado
- [ ] Request/Response schemas implementados
- [ ] Validation implementada
- [ ] Permissions definidas
- [ ] Autorização validada no backend
- [ ] Admin implementado
- [ ] Site implementado quando aplicável
- [ ] Unit Tests criados
- [ ] Integration Tests criados
- [ ] E2E/API Tests criados quando apropriado
- [ ] Dependências atualizadas quando necessárias
- [ ] Docker atualizado quando necessário

Não considere o CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 44. TESTES

Devem existir:

```text
tests/
├── unit/
├── integration/
└── e2e/
```

ou estrutura equivalente já adotada.

## Unit Tests

Validam principalmente:

- Aggregates;
- Entities;
- Value Objects;
- invariantes;
- Domain Services;
- Domain Validations;
- Commands/Handlers quando apropriado;
- transições;
- autorização isolável.

Unit Tests de Domain não devem iniciar banco ou framework sem necessidade.

## Integration Tests

Validam:

- repositories;
- ORM;
- banco;
- migrations;
- cache;
- mensageria;
- integrações técnicas.

Devem utilizar TEST.

## E2E/API Tests

Devem poder:

1. iniciar dependências;
2. utilizar banco TEST;
3. executar migrations/schema;
4. iniciar aplicação;
5. executar chamadas HTTP;
6. validar autenticação;
7. validar autorização;
8. validar persistência;
9. limpar ambiente.

Nunca utilize DEV.

---

# 45. PYTEST

Se pytest estiver presente, preserve sua configuração.

Pode utilizar:

```text
pytest
pytest-asyncio
pytest-django
pytest-cov
```

quando já existentes ou realmente necessários.

Não instale plugins automaticamente.

Se o projeto utilizar `unittest` ou outro framework, não migre para pytest sem autorização.

---

# 46. FIXTURES

Fixtures de testes devem ser:

- pequenas;
- previsíveis;
- reutilizáveis quando apropriado;
- independentes entre testes quando necessário.

Não transforme `conftest.py` em um arquivo gigantesco contendo toda a infraestrutura de testes.

Evite estado compartilhado imprevisível.

---

# 47. BANCO DEV E TEST

Devem existir ambientes isolados:

```text
database-dev
database-test
```

Regras:

- testes nunca utilizam DEV;
- migrations executam em TEST;
- limpeza de TEST não afeta DEV;
- configurações devem deixar a separação explícita.

---

# 48. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz.

Deve contemplar pelo menos:

- aplicação Python;
- banco DEV;
- banco TEST.

Quando necessário:

- frontend;
- Redis;
- RabbitMQ;
- Kafka;
- worker;
- scheduler;
- mail testing;
- outras dependências reais.

Não adicione infraestrutura sem necessidade.

---

# 49. DOCKERFILE

Antes de alterar Dockerfile:

- identifique a versão Python;
- identifique gerenciador de dependências;
- identifique servidor;
- identifique necessidades de build;
- preserve multi-stage build quando existente.

Não utilize automaticamente `latest`.

Não execute aplicação de produção com servidor de desenvolvimento quando a stack exigir servidor apropriado.

A estratégia concreta depende do framework.

---

# 50. CONFIGURAÇÃO

Configuração deve utilizar environment variables ou mecanismo apropriado.

Podem existir:

```text
.env
.env.example
settings/
config/
```

Não versione secrets reais.

`.env.example` deve conter apenas exemplos seguros.

Configuração não deve ser acessada arbitrariamente em todo Domain.

---

# 51. FRONTEND

Se existir frontend separado:

```text
/
├── backend/
├── frontend/
├── .claude/
│   └── skills/
└── docker-compose.yml
```

Se React estiver presente:

```text
frontend/src/
├── admin/
├── site/
└── shared/
```

Admin e Site não devem importar internals um do outro.

O backend Python permanece a autoridade final para autorização.

---

# 52. TEMPLATE DO KIT

Não trate esta stack simplesmente como:

```text
Python
```

A arquitetura real é:

```text
Python
+ DDD
+ CQRS
+ CMS/CRUD
+ Admin/Site
+ User/Role/Permission
```

Portanto:

1. analise os templates;
2. identifique templates Python;
3. identifique templates do framework encontrado;
4. não force Django, FastAPI ou Flask;
5. não force Node.js, Java, PHP/Laravel ou stack incompatível;
6. verifique se o template preserva Domain/Application/Infrastructure/API;
7. rejeite template simplificado incompatível;
8. se nenhum preservar a arquitetura, utilize:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

9. adapte o template genérico;
10. as regras deste prompt têm precedência.

---

# 53. CONFIGURAÇÃO DO CLAUDE.md

Leia `SETUP NOTE`.

Resolva todos os `[FILL]`.

Registre:

- Python;
- versão Python;
- framework;
- dependency manager;
- DDD/CQRS;
- Domain/Application/Infrastructure/API;
- Identity/Content/Navigation;
- User/Role/Permission;
- ORM/persistência;
- migrations;
- sync/async;
- segurança;
- DEV/TEST;
- testes;
- Docker;
- Admin/Site;
- checklist obrigatório de CRUD.

Não atualize versões simplesmente porque existem versões mais recentes.

Depois de resolver os `[FILL]`, remova `SETUP NOTE` conforme orientação do Kit.

---

# 54. MULTI-TOOL

Se necessário, configure também:

```text
AGENTS.md
```

ou equivalente.

Existe uma única arquitetura.

Não crie regras divergentes entre:

- CLAUDE.md;
- AGENTS.md;
- Agent Skills;
- documentação dos agentes.

---

# 55. SKILLS DO KIT

Instale as 10 skills existentes em:

```text
Kit-IA-Dev/3-Skills/
```

Copie pastas completas.

Preserve:

```text
SKILL.md
references/
arquivos auxiliares
```

Para Claude Code, utilize:

```text
.claude/skills/
```

quando aplicável.

---

# 56. SKILLS AVANÇADAS

Depois:

1. localize as 8 skills novas;
2. instale as pastas completas;
3. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

4. aplique os 8 patches correspondentes.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não remova essas skills.

---

# 57. SKILLS ESPECÍFICAS DO PROJETO

Configure pelo menos:

```text
project-architecture
python-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
content-management
navigation-management
persistence
testing
docker-development
```

Depois de identificar o framework, avalie skill específica.

Exemplos:

```text
django-architecture
fastapi-architecture
flask-architecture
```

Crie apenas a correspondente à stack real.

Não crie todas automaticamente.

---

# 58. GERAÇÃO DE CRUD

Quando receber:

```text
"crie um CRUD de produtos"
```

não gere apenas:

```text
ProductModel
ProductSchema
ProductService
ProductRouter
```

A IA deve considerar:

```text
Product Domain
        ↓
Aggregate / Entity
        ↓
Value Objects
        ↓
Invariants
        ↓
Domain Events
        ↓
Repository Contract
        ↓
Commands
        ↓
Queries
        ↓
Handlers / Use Cases
        ↓
Result Pattern
        ↓
Infrastructure
        ↓
Persistence Model
        ↓
Mapper
        ↓
Repository Implementation
        ↓
Unit of Work
        ↓
Migration
        ↓
API
        ↓
Request / Response Schemas
        ↓
Permissions
        ↓
Authorization
        ↓
Admin
        ↓
Site, quando aplicável
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E/API Tests
        ↓
Dependencies, quando necessário
        ↓
Docker, quando necessário
```

---

# 59. VALIDAÇÃO DA INSTALAÇÃO

## Validação 1 — Kit

Execute:

```text
"revise este código"
```

ou:

```text
"escreva o commit"
```

ou:

```text
"isso está lento"
```

Confirme que a skill apropriada foi utilizada.

## Validação 2 — Arquitetura

Execute:

```text
"crie um CRUD de categorias"
```

Confirme que considera:

- Domain;
- Application;
- Commands;
- Queries;
- Infrastructure;
- Persistence;
- API;
- Permissions;
- Admin;
- testes;
- Site quando aplicável.

## Validação 3 — CMS

Execute:

```text
"adicione gerenciamento de páginas"
```

Confirme:

- Page;
- Draft/Published;
- invariantes;
- Commands;
- Queries;
- permissions;
- Admin;
- API;
- persistência;
- migrations;
- publicação;
- Site;
- testes.

---

# 60. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso aos Templates.
3. Confirmar acesso às Skills Avançadas.
4. Confirmar raiz do projeto.
5. Inspecionar estrutura existente.
6. Identificar ferramenta de IA.
7. Identificar diretório de Agent Skills.
8. Identificar versão Python.
9. Identificar framework.
10. Identificar gerenciador de dependências.
11. Identificar arquivos de lock.
12. Identificar estrutura de packages.
13. Identificar sync/async.
14. Identificar ORM/persistência.
15. Identificar banco.
16. Identificar migrations.
17. Identificar autenticação.
18. Identificar autorização.
19. Identificar framework de testes.
20. Identificar lint/format/type checking.
21. Identificar frontend.
22. Analisar Docker.
23. Analisar templates.
24. Avaliar template Python/framework.
25. Utilizar template genérico quando necessário.
26. Configurar `CLAUDE.md`.
27. Configurar multi-tool.
28. Instalar as 10 skills básicas.
29. Instalar as 8 skills avançadas.
30. Aplicar os 8 patches.
31. Criar/adaptar skills específicas.
32. Validar conflitos/duplicações.
33. Validar arquitetura.
34. Validar ativação das skills.
35. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 61. PROIBIÇÕES

Não faça sem instrução explícita:

- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar camadas;
- transformar tudo em Route + Service + ORM;
- colocar regras de negócio em endpoints;
- colocar regras de negócio em serializers;
- colocar invariantes exclusivamente em Pydantic;
- transformar ORM Model automaticamente em Domain Entity;
- colocar autorização somente no frontend;
- utilizar banco DEV nos testes;
- compartilhar DEV e TEST;
- criar entidade `Content` universal sem analisar invariantes;
- criar arquitetura de plugins WordPress;
- adicionar marketplace;
- adicionar sistema de temas;
- adicionar page builder;
- escolher Django automaticamente;
- escolher FastAPI automaticamente;
- escolher Flask automaticamente;
- escolher SQLAlchemy automaticamente;
- escolher Django ORM automaticamente;
- escolher PostgreSQL automaticamente;
- escolher Redis automaticamente;
- escolher Celery automaticamente;
- escolher RabbitMQ/Kafka automaticamente;
- escolher pytest automaticamente;
- escolher Poetry automaticamente;
- escolher uv automaticamente;
- migrar pip para Poetry/uv automaticamente;
- criar múltiplos lockfiles conflitantes;
- converter sync para async indiscriminadamente;
- converter async para sync indiscriminadamente;
- atualizar Python indiscriminadamente;
- atualizar dependências indiscriminadamente;
- implementar Event Sourcing indiscriminadamente;
- confundir framework signals com Domain Events;
- armazenar secrets no repositório;
- sobrescrever código existente sem análise prévia.

Quando houver conflito entre:

```text
sugestão genérica do Kit
        vs
convenção simplificada do framework Python
        vs
regras específicas deste projeto
```

**AS REGRAS ESPECÍFICAS DESTE PROJETO TÊM PRECEDÊNCIA.**

---

# 62. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial Python para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS, separação entre Domain/Application/Infrastructure/API, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, persistência isolada das regras de domínio, testes reais e ambientes Docker DEV/TEST.

A IA não deve confundir framework com arquitetura.

Django, FastAPI, Flask, SQLAlchemy, Pydantic ou qualquer outra biblioteca devem funcionar como mecanismos técnicos dentro das fronteiras definidas.

Ao receber:

```text
"crie um CRUD de produtos"
```

ela não deve considerar suficiente criar:

```text
ProductModel
ProductSchema
ProductService
ProductRouter
```

Ela deve analisar os itens aplicáveis:

```text
Product Domain
        ↓
Aggregate / Entity
        ↓
Value Objects / Invariants
        ↓
Domain Events
        ↓
Repository Contract
        ↓
Commands / Queries
        ↓
Handlers / Use Cases
        ↓
Result Pattern
        ↓
Infrastructure
        ↓
Persistence Model
        ↓
Mapper
        ↓
Repository Implementation
        ↓
Unit of Work
        ↓
Migration
        ↓
API
        ↓
Permissions / Authorization
        ↓
Admin
        ↓
Site, quando aplicável
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E/API Tests
        ↓
Dependencies
        ↓
Docker, quando necessário
```

---

# INÍCIO

Comece somente pela **Etapa 1**.

Confirme se você consegue acessar:

1. Kit IA Dev;
2. pacote Templates por Stack;
3. pacote Skills Avançadas;
4. raiz do meu projeto.

Se algum deles não estiver disponível no contexto, solicite apenas o caminho absoluto ou o ZIP correspondente.

**Não copie, altere ou crie arquivos ainda.**

Espere minha confirmação antes de continuar para a próxima etapa.