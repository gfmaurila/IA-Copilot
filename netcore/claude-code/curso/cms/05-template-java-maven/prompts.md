# INSTALAÇÃO E CONFIGURAÇÃO DO KIT IA DEV

Você vai me ajudar a instalar, configurar e adaptar o **Kit IA Dev** ao meu projeto.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar os arquivos do Kit. Você deve configurar o Kit para que a ferramenta de IA de código compreenda e preserve a arquitetura, as regras de negócio e os padrões de desenvolvimento definidos neste prompt.

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
Java
Maven
```

O framework Java não deve ser escolhido automaticamente.

Antes de configurar o projeto, identifique se ele utiliza:

- Spring Boot;
- Quarkus;
- Micronaut;
- Jakarta EE;
- outro framework;
- Java sem framework de aplicação.

Preserve a decisão existente.

Se nenhum framework estiver definido, apresente as opções identificadas e peça confirmação antes de adotar uma.

Para instalar skills:

1. Primeiro identifique onde a ferramenta utilizada espera encontrar Agent Skills.
2. Caso isso não esteja claro, consulte `Kit-IA-Dev/3-Skills/COMO-INSTALAR.md`.
3. Nunca copie apenas o `SKILL.md` quando a skill possuir arquivos auxiliares.
4. Copie a pasta inteira da skill, incluindo `references/` e demais arquivos.

---

# 2. ARQUIVOS E PASTAS QUE POSSO FORNECER

Os seguintes contextos podem ser fornecidos como pasta ou ZIP.

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

Se algum arquivo necessário não estiver disponível no contexto, solicite:

- o caminho absoluto da pasta; ou
- o ZIP correspondente.

Não invente conteúdo que deveria ser obtido desses pacotes.

Não copie arquivos antes de confirmar que está trabalhando na raiz correta do projeto.

---

# 3. FORMA DE CONDUÇÃO

Execute o processo em etapas.

Regras obrigatórias:

- Execute um passo por vez.
- Ao final de cada etapa, informe resumidamente o que foi realizado.
- Espere minha confirmação antes de iniciar a próxima etapa.
- Não altere silenciosamente decisões arquiteturais.
- Não substitua a arquitetura definida neste prompt por uma arquitetura Java genérica.
- Não simplifique a estrutura para reduzir quantidade de módulos, camadas ou arquivos.
- Se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas objetivas.
- Converse comigo em PT-BR.
- Conteúdo técnico destinado à IA, como `CLAUDE.md`, `AGENTS.md`, `agent_docs`, `SKILL.md` e documentação equivalente, deve permanecer em inglês, salvo quando o arquivo original estabelecer outro padrão.

Antes de sobrescrever arquivos existentes importantes, identifique o arquivo e explique brevemente a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para criação de aplicações **CRUD/CMS com Java + Maven**.

A experiência administrativa é inspirada no gerenciamento de conteúdo do WordPress.

Administradores devem conseguir gerenciar:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação de conteúdo.

O site público deve refletir páginas, menus e conteúdos publicados sem exigir alteração manual de código para páginas básicas.

A inspiração no WordPress é exclusivamente relacionada à experiência de administração de conteúdo.

Não fazem parte do escopo:

- plugins;
- marketplace;
- sistema de temas instaláveis;
- widgets;
- page builder complexo;
- extensões instaláveis.

Não transforme o projeto em um clone arquitetural do WordPress.

---

# 5. ESTRUTURA OBRIGATÓRIA DO REPOSITÓRIO

Preserve a estrutura Maven existente.

Conceitualmente:

```text
/
├── src/
│   ├── main/
│   │   ├── java/
│   │   └── resources/
│   └── test/
│       ├── java/
│       └── resources/
│
├── .mvn/
│   └── wrapper/
├── .claude/
│   └── skills/
├── docker/
├── docker-compose.yml
├── pom.xml
├── mvnw
├── mvnw.cmd
└── ...
```

Se o projeto utilizar Maven multi-module, preserve os módulos existentes.

Não converta automaticamente um projeto multi-module para single-module.

Não converta automaticamente um projeto single-module para multi-module.

A arquitetura lógica deve preservar:

```text
Domain
Application
Infrastructure
API
```

Ela pode ser representada por:

- packages;
- módulos Maven;
- combinação de módulos e packages;

conforme a estrutura existente ou decisão arquitetural aprovada.

---

# 6. REGRA ARQUITETURAL PRINCIPAL

Esta regra possui prioridade sobre sugestões genéricas existentes nos templates:

**NÃO simplifique, substitua ou descaracterize a arquitetura definida neste prompt.**

Todo novo CRUD deve respeitar conceitualmente:

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

As dependências devem respeitar as fronteiras arquiteturais.

O Domain não deve depender diretamente de:

- Controllers;
- REST;
- HTTP;
- ORM;
- banco de dados;
- framework web;
- interface administrativa.

Não concentre regras de negócio em:

- Controllers;
- Services genéricos;
- ORM Entities;
- Repositories concretos;
- DTOs;
- Validators HTTP;
- frontend.

Não substitua a arquitetura por:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
ORM Entity
    ↓
Database
```

As regras de negócio devem permanecer no Domain.

---

# 7. ARQUITETURA

A arquitetura deve utilizar, conforme a responsabilidade de cada caso:

- Domain Driven Design (DDD);
- CQRS;
- Event Sourcing quando aplicável;
- Unit of Work quando necessário;
- Repository Pattern;
- Result Pattern;
- Domain Events;
- Domain Notifications;
- Domain Validations;
- Dependency Injection.

Não utilize padrões apenas porque estão listados.

Cada padrão deve possuir responsabilidade arquitetural real.

---

# 8. ORGANIZAÇÃO POR DOMÍNIO

Os domínios iniciais são:

```text
Identity
Content
Navigation
```

Uma organização conceitual pode seguir:

```text
com.company.project
├── domain
│   ├── identity
│   ├── content
│   └── navigation
│
├── application
│   ├── identity
│   ├── content
│   └── navigation
│
├── infrastructure
│   ├── persistence
│   ├── messaging
│   └── services
│
└── api
```

O package base definitivo deve ser obtido do projeto existente.

Não invente `com.company.project` como package real.

---

# 9. DOMAIN

O Domain é responsável por:

- Aggregates;
- Entities;
- Value Objects;
- Domain Events;
- Domain Validations;
- invariantes;
- regras de negócio;
- contratos de repositories;
- Domain Services quando necessários.

Estrutura conceitual:

```text
domain/
└── content/
    ├── aggregate/
    ├── entity/
    ├── valueobject/
    ├── event/
    ├── repository/
    ├── service/
    ├── validation/
    └── exception/
```

O Domain deve permanecer independente do framework sempre que possível.

Não adicione anotações de persistência às Domain Entities apenas por conveniência quando isso acoplar indevidamente o domínio ao ORM.

Não transforme automaticamente uma JPA Entity em Domain Entity.

---

# 10. APPLICATION

Application é responsável por:

- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- Use Cases;
- DTOs internos;
- Result Pattern;
- orquestração dos casos de uso.

Exemplo:

```text
application/
└── content/
    └── page/
        ├── command/
        │   ├── create/
        │   ├── update/
        │   ├── delete/
        │   └── publish/
        ├── query/
        │   ├── get/
        │   └── list/
        └── dto/
```

Commands representam intenção de alteração.

Queries representam leitura.

Não utilize CQRS apenas como nomenclatura.

Handlers não devem concentrar invariantes pertencentes ao Aggregate.

---

# 11. CQRS

Fluxo conceitual de escrita:

```text
HTTP Request
    ↓
Command
    ↓
Command Handler
    ↓
Aggregate / Domain
    ↓
Repository
    ↓
Persistence
```

Fluxo conceitual de leitura:

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

```java
page.setStatus("PUBLISHED");
repository.save(page);
```

quando publicação possuir invariantes.

Prefira comportamento explícito:

```java
page.publish();
```

---

# 12. INFRASTRUCTURE

Infrastructure é responsável por:

- persistência;
- implementação de repositories;
- ORM;
- migrations;
- banco;
- mensageria;
- cache;
- filesystem;
- e-mail;
- integrações externas;
- adapters técnicos.

Estrutura conceitual:

```text
infrastructure/
├── persistence/
├── repository/
├── messaging/
├── cache/
├── mail/
├── filesystem/
└── integration/
```

Detalhes técnicos não devem vazar desnecessariamente para o Domain.

---

# 13. PERSISTÊNCIA / ORM

Não escolha automaticamente uma tecnologia.

Antes de configurar, verifique se o projeto utiliza:

- JPA;
- Hibernate;
- Spring Data JPA;
- JDBC;
- jOOQ;
- MyBatis;
- MongoDB;
- outro mecanismo.

Preserve a tecnologia existente.

Se nenhuma estiver definida, apresente opções antes de adotar uma.

Não assuma:

```text
JPA Entity = Domain Entity
```

Quando separados:

```text
Domain Entity
      ↕
Persistence Mapper
      ↕
Persistence Entity
```

Exemplo:

```text
Page
PagePersistenceEntity
PagePersistenceMapper
```

O Repository concreto pertence à Infrastructure.

---

# 14. MIGRATIONS

Identifique primeiro a tecnologia existente.

Pode ser:

- Flyway;
- Liquibase;
- mecanismo do framework;
- outra ferramenta.

Não instale Flyway ou Liquibase automaticamente.

Migrations já aplicadas em ambientes compartilhados não devem ser alteradas para representar novas mudanças quando uma nova migration for apropriada.

---

# 15. API / HTTP

A camada API pode conter:

```text
api/
├── controller/
├── request/
├── response/
├── mapper/
├── security/
├── filter/
└── exception/
```

Controllers devem:

1. receber requisição;
2. validar aspectos HTTP;
3. converter entrada;
4. executar Command/Query/Use Case;
5. converter resultado;
6. retornar resposta HTTP.

Controllers não devem conter regras de domínio.

Request DTOs não substituem Value Objects.

Validação HTTP não substitui Domain Validation.

---

# 16. FRAMEWORK JAVA

O framework deve ser detectado no projeto.

Se for Spring Boot, utilize seus recursos sem permitir que substituam as fronteiras arquiteturais.

Anotações como:

```text
@RestController
@Service
@Repository
@Configuration
@Component
```

são mecanismos técnicos.

Elas não definem sozinhas a arquitetura.

Não transforme automaticamente o sistema em:

```text
Controller
→ Service
→ Spring Data Repository
→ JPA Entity
```

apenas porque esse padrão é comum.

---

# 17. DEPENDENCY INJECTION

Utilize Dependency Injection conforme o framework adotado.

Conceitualmente:

```text
Application
    ↓
PageRepository interface

Infrastructure
    ↓
JpaPageRepository implementation
```

A implementação técnica deve ser conectada na composição da aplicação.

---

# 18. IDENTITY

Relacionamento conceitual:

```text
User
  → Roles
      → Permissions
```

`User`, `Role` e `Permission` são conceitos distintos.

Permissions representam operações autorizadas.

A API é a autoridade final para autorização.

---

# 19. AUTENTICAÇÃO

Antes de implementar autenticação, analise o projeto.

Pode utilizar:

- JWT;
- Session;
- OAuth 2;
- OpenID Connect;
- Identity Provider;
- outro mecanismo.

Não escolha automaticamente JWT.

Passwords nunca devem ser armazenadas em texto puro.

Secrets não devem ser versionados.

---

# 20. AUTORIZAÇÃO

Cada CRUD deve possuir permissões por operação.

Exemplo:

```text
Page.Read
Page.Create
Page.Update
Page.Delete
Page.Publish
```

O backend deve validar essas permissões.

Quando Spring Security estiver presente, utilize os mecanismos compatíveis com a versão existente.

Não acople Domain diretamente ao Spring Security sem necessidade.

---

# 21. CONTENT

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

Transições devem possuir regras explícitas.

## Content

Não crie automaticamente uma entidade universal `Content`.

Modele conteúdos conforme suas features e invariantes.

---

# 22. NAVIGATION

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

---

# 23. ADMIN E SITE

Existem conceitualmente:

```text
Admin
Site
```

Admin gerencia:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação.

Site apresenta:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação.

Não escolha automaticamente framework frontend.

Preserve a tecnologia existente.

---

# 24. DOMAIN EVENTS

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
Framework Event
ORM Listener
Integration Event
Message Broker Event
```

Mantenha responsabilidades explícitas.

---

# 25. EVENT SOURCING

Event Sourcing deve ser utilizado somente quando aplicável.

Não implemente Event Sourcing indiscriminadamente.

Quando utilizado, defina:

- Aggregate;
- Event Stream;
- versão;
- Event Store;
- reconstrução;
- concorrência;
- snapshots quando necessários.

---

# 26. MENSAGERIA

Quando houver processamento assíncrono, preserve:

```text
Domain Event
Integration Event
Message
```

A infraestrutura pode utilizar tecnologia já definida, como:

- Kafka;
- RabbitMQ;
- AWS SQS;
- Google Pub/Sub;
- outra.

Não instale broker automaticamente.

---

# 27. RESULT PATTERN

Utilize Result Pattern conforme a convenção do projeto.

Exemplo:

```text
Result<T>
├── success
├── value
└── errors
```

Não utilize exceptions como controle comum de fluxo quando Result Pattern for mais apropriado.

---

# 28. DOMAIN NOTIFICATIONS

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

# 29. VALIDATIONS

## API Validation

Responsável por:

- formato;
- campos obrigatórios;
- tipos;
- estrutura da entrada.

Pode utilizar Bean Validation/Jakarta Validation quando disponível.

## Domain Validation

Responsável por:

- invariantes;
- regras de negócio;
- transições;
- consistência.

API Validation nunca substitui Domain Validation.

---

# 30. MAVEN

**Maven é obrigatório como sistema de build deste cenário.**

O arquivo principal é:

```text
pom.xml
```

Preserve a configuração existente.

Antes de adicionar uma dependência:

1. analise o `pom.xml`;
2. analise parent/BOM existente;
3. verifique se a funcionalidade já está disponível;
4. verifique compatibilidade com Java e framework;
5. adicione somente quando necessária.

Não altere versões indiscriminadamente.

Não converta o projeto para Gradle.

---

# 31. MAVEN WRAPPER

Quando o projeto possuir Maven Wrapper, preserve:

```text
mvnw
mvnw.cmd
.mvn/wrapper/
```

Prefira os comandos do wrapper:

```text
./mvnw
```

ou, no Windows:

```text
mvnw.cmd
```

Não dependa exclusivamente de uma instalação global do Maven quando o Wrapper estiver disponível.

Se o projeto não possuir Maven Wrapper, não o adicione automaticamente sem analisar a convenção existente.

---

# 32. DEPENDENCY MANAGEMENT

Analise:

```xml
<parent>
```

e:

```xml
<dependencyManagement>
```

antes de declarar versões diretamente nas dependencies.

Quando o projeto utilizar BOM ou parent para gerenciamento de versões, respeite essa estratégia.

Não declare versões redundantes.

Não sobrescreva versões gerenciadas sem justificativa.

Analise também:

```xml
<properties>
```

para identificar versões centralizadas.

---

# 33. MAVEN PLUGINS

Antes de adicionar ou alterar plugins em:

```xml
<build>
    <plugins>
```

analise os plugins existentes.

Preserve configurações importantes de:

- compilação;
- testes;
- integration tests;
- packaging;
- code quality;
- coverage;
- geração de código;
- framework.

Não atualize plugins indiscriminadamente.

---

# 34. MULTI-MODULE MAVEN

Se o projeto utilizar Maven multi-module, preserve essa estrutura.

Exemplo conceitual:

```text
/
├── pom.xml
├── domain/
│   └── pom.xml
├── application/
│   └── pom.xml
├── infrastructure/
│   └── pom.xml
└── api/
    └── pom.xml
```

O `pom.xml` raiz pode atuar como aggregator/parent conforme a arquitetura existente.

Uma relação conceitual pode ser:

```text
domain
   ↑
application
   ↑
infrastructure
   ↑
api
```

Mas não crie dependências circulares.

O Domain deve permanecer o mais independente possível.

Não force multi-module se o projeto existente utiliza um único módulo com packages.

Não force single-module se o projeto já utiliza multi-module.

---

# 35. MAVEN LIFECYCLE

Respeite o lifecycle Maven.

Utilize fases apropriadas:

```text
validate
compile
test
package
verify
install
```

Não crie scripts paralelos desnecessários para substituir funcionalidades naturais do Maven.

Testes unitários e testes de integração devem possuir separação clara quando o projeto exigir.

---

# 36. UNIT E INTEGRATION TESTS NO MAVEN

Identifique a configuração existente.

Conceitualmente:

```text
Unit Tests
→ test

Integration Tests
→ integration-test / verify
```

Quando aplicável, Maven Surefire pode executar Unit Tests e Maven Failsafe pode executar Integration Tests.

Entretanto:

- não instale/configure Surefire ou Failsafe automaticamente sem analisar o projeto;
- preserve configurações existentes;
- não confunda Unit Tests com Integration Tests;
- integração não deve utilizar banco DEV.

---

# 37. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

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
- [ ] Persistence Entity criada quando necessária
- [ ] Mapper criado quando Domain/Persistence estiverem separados
- [ ] Repository concreto implementado
- [ ] Unit of Work respeitado quando aplicável
- [ ] Migration criada quando necessária
- [ ] Dependency Injection configurada
- [ ] Controller implementado
- [ ] Request/Response DTOs implementados
- [ ] Validation implementada
- [ ] Permissions definidas
- [ ] Autorização validada no backend
- [ ] Admin implementado
- [ ] Site implementado quando aplicável
- [ ] Unit Tests criados
- [ ] Integration Tests criados
- [ ] E2E/API Tests criados quando apropriado
- [ ] `pom.xml` atualizado quando necessário
- [ ] Docker atualizado quando necessário

Não considere o CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 38. TESTES

Devem existir testes:

```text
Unit
Integration
E2E/API
```

## Unit Tests

Devem validar:

- Aggregates;
- Entities;
- Value Objects;
- invariantes;
- Domain Services;
- Domain Validations;
- transições;
- Commands/Handlers quando apropriado.

Unit Tests de Domain não devem iniciar framework ou banco desnecessariamente.

## Integration Tests

Devem validar:

- banco;
- repositories;
- ORM;
- migrations;
- infraestrutura;
- mensageria quando aplicável.

Devem utilizar banco TEST.

## E2E/API Tests

Devem poder:

1. iniciar dependências;
2. utilizar banco TEST;
3. aplicar migrations/schema;
4. iniciar aplicação;
5. executar chamadas HTTP;
6. validar autenticação;
7. validar autorização;
8. validar persistência;
9. limpar o ambiente.

Nunca utilize DEV.

---

# 39. FRAMEWORK DE TESTES

Identifique ferramentas existentes.

Podem incluir:

- JUnit;
- TestNG;
- AssertJ;
- Mockito;
- Testcontainers;
- ferramentas específicas do framework.

Não adicione bibliotecas automaticamente porque são populares.

Preserve ferramentas existentes.

---

# 40. TESTCONTAINERS

Se Testcontainers estiver presente, preserve seu uso.

Se não estiver, não instale automaticamente.

Pode ser considerado para infraestrutura descartável de integração, incluindo:

- bancos;
- brokers;
- cache.

A decisão deve considerar também CI/CD.

---

# 41. BANCO DEV E TEST

Devem existir ambientes isolados:

```text
database-dev
database-test
```

Regras:

- testes nunca usam DEV;
- migrations devem executar em TEST;
- limpeza de TEST não afeta DEV;
- configurações devem tornar o isolamento explícito.

---

# 42. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz.

Deve contemplar pelo menos:

- aplicação Java;
- banco DEV;
- banco TEST.

Quando necessário:

- frontend;
- Redis;
- Kafka;
- RabbitMQ;
- mail testing;
- outras dependências reais.

Não adicione infraestrutura sem necessidade.

---

# 43. CONFIGURAÇÃO

Preserve o mecanismo do framework existente.

Pode incluir:

```text
application.properties
application.yml
environment variables
profiles
```

Nunca armazene secrets reais em arquivos versionados.

---

# 44. FRONTEND

Se existir frontend:

```text
/
├── backend/
├── frontend/
├── .claude/
│   └── skills/
└── docker-compose.yml
```

Se React for utilizado:

```text
frontend/src/
├── admin/
├── site/
└── shared/
```

Admin e Site não devem importar internals um do outro.

A API Java é a autoridade final de autorização.

---

# 45. INSTALAÇÃO DO TEMPLATE DO KIT

Minha stack não deve ser tratada automaticamente como template Java simples.

Arquitetura:

```text
Java
+ Maven
+ DDD
+ CQRS
+ CMS/CRUD
+ Admin/Site
+ User/Role/Permission
```

Portanto:

1. Analise os templates.
2. Identifique templates Java/Maven.
3. Identifique template do framework encontrado.
4. Não force Gradle, Node.js, PHP/Laravel, Python ou stack incompatível.
5. Analise se o template preserva esta arquitetura.
6. Não utilize template simplificado que elimine Domain/Application/Infrastructure/API.
7. Se nenhum template preservar integralmente a arquitetura, utilize:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

8. Adapte o template genérico.
9. As regras deste prompt têm precedência.

---

# 46. CONFIGURAÇÃO DO CLAUDE.md

Leia `SETUP NOTE`.

Resolva `[FILL]`.

Registre:

- Java;
- Maven;
- framework detectado;
- DDD/CQRS;
- Domain/Application/Infrastructure/API;
- Identity/Content/Navigation;
- User/Role/Permission;
- persistência;
- migrations;
- segurança;
- DEV/TEST;
- testes;
- Docker;
- checklist de CRUDs;
- Admin/Site quando aplicável.

Não altere versões existentes simplesmente porque existem versões mais recentes.

Depois de resolver `[FILL]`, remova `SETUP NOTE` conforme orientação do Kit.

---

# 47. MULTI-TOOL

Se necessário, configure:

```text
AGENTS.md
```

ou equivalente.

Existe uma única arquitetura.

Não crie divergências entre:

- `CLAUDE.md`;
- `AGENTS.md`;
- Agent Skills;
- documentação de agentes.

---

# 48. INSTALAÇÃO DAS SKILLS DO KIT

Instale as 10 skills de:

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

Para Claude Code:

```text
.claude/skills/
```

quando aplicável.

---

# 49. SKILLS AVANÇADAS

Depois:

1. instale as 8 skills novas;
2. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

3. aplique os 8 patches correspondentes.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não remova essas skills.

---

# 50. SKILLS ESPECÍFICAS DO PROJETO

Configure pelo menos:

```text
project-architecture
java-maven-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
content-management
navigation-management
persistence
testing
docker-development
```

Quando o framework for identificado, avalie skill específica.

Exemplo:

```text
spring-boot-architecture
```

somente quando Spring Boot realmente fizer parte da stack.

---

# 51. GERAÇÃO DE CRUD

Uma solicitação:

```text
"crie um CRUD de produtos"
```

não deve resultar apenas em:

```text
ProductController
ProductService
ProductRepository
ProductEntity
```

Deve considerar:

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
Persistence Entity
        ↓
Mapper
        ↓
Repository Implementation
        ↓
Migration
        ↓
Dependency Injection
        ↓
API Controller
        ↓
Request / Response DTO
        ↓
Validation
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
pom.xml, quando necessário
        ↓
Docker, quando necessário
```

---

# 52. VALIDAÇÃO DA INSTALAÇÃO

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

Confirme a skill utilizada.

## Validação 2 — Arquitetura

Execute:

```text
"crie um CRUD de categorias"
```

Confirme:

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

# 53. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso ao pacote Templates.
3. Confirmar acesso ao pacote Skills Avançadas.
4. Confirmar raiz do projeto.
5. Inspecionar estrutura atual.
6. Identificar ferramenta de IA.
7. Identificar diretório de Agent Skills.
8. Identificar versão Java.
9. Identificar versão Maven.
10. Analisar `pom.xml`.
11. Identificar Maven Wrapper.
12. Identificar single-module ou multi-module.
13. Identificar parent/BOM/dependencyManagement.
14. Identificar framework Java.
15. Identificar persistência/ORM.
16. Identificar banco.
17. Identificar migrations.
18. Identificar framework de testes.
19. Identificar frontend.
20. Analisar templates.
21. Avaliar template Java/Maven/framework.
22. Utilizar template genérico quando necessário.
23. Configurar `CLAUDE.md`.
24. Configurar multi-tool.
25. Instalar as 10 skills básicas.
26. Instalar as 8 skills avançadas.
27. Aplicar os 8 patches.
28. Criar/adaptar skills específicas.
29. Validar conflitos/duplicações.
30. Validar arquitetura.
31. Validar ativação das skills.
32. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 54. PROIBIÇÕES

Não faça sem instrução explícita:

- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar camadas;
- transformar tudo em Controller + Service + Repository;
- colocar regras de negócio em Controllers;
- colocar invariantes exclusivamente em DTO validation;
- transformar Persistence Entity automaticamente em Domain Entity;
- colocar autorização somente no frontend;
- utilizar banco DEV nos testes;
- compartilhar DEV e TEST;
- criar `Content` universal sem analisar invariantes;
- transformar o projeto em arquitetura de plugins WordPress;
- adicionar marketplace;
- adicionar sistema de temas;
- adicionar page builder;
- instalar dependências Maven sem necessidade;
- atualizar Java indiscriminadamente;
- atualizar Maven indiscriminadamente;
- atualizar framework indiscriminadamente;
- atualizar plugins indiscriminadamente;
- converter Maven para Gradle;
- escolher Spring Boot automaticamente;
- escolher JPA/Hibernate automaticamente;
- escolher banco automaticamente;
- escolher Flyway/Liquibase automaticamente;
- adicionar Lombok automaticamente;
- adicionar MapStruct automaticamente;
- adicionar Testcontainers automaticamente;
- adicionar Kafka/RabbitMQ automaticamente;
- substituir framework de testes sem analisar;
- alterar migrations históricas indevidamente;
- implementar Event Sourcing indiscriminadamente;
- utilizar framework events como substitutos automáticos de Domain Events;
- armazenar secrets no repositório;
- sobrescrever código existente sem análise prévia.

Quando houver conflito entre:

```text
sugestão genérica do Kit
        vs
convenção simplificada do framework
        vs
regras específicas deste projeto
```

**AS REGRAS ESPECÍFICAS DESTE PROJETO TÊM PRECEDÊNCIA.**

---

# 55. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial Java + Maven para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS, separação entre Domain/Application/Infrastructure/API, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, persistência isolada das regras de domínio, testes reais e ambientes Docker DEV/TEST.

A IA deve conseguir receber solicitações futuras de CRUDs e features e automaticamente respeitar essa arquitetura.

Ao receber:

```text
"crie um CRUD de produtos"
```

ela não deve presumir:

```text
Controller
Service
Repository
JPA Entity
```

como solução completa.

Ela deve analisar e implementar os itens aplicáveis:

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
Persistence Model / Mapper
        ↓
Repository Implementation
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
pom.xml, quando necessário
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