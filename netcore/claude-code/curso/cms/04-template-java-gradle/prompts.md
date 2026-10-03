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
Gradle
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

Este projeto é um template empresarial para criação de aplicações **CRUD/CMS com Java + Gradle**.

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

Preserve a estrutura Gradle existente.

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
├── gradle/
│   └── wrapper/
├── .claude/
│   └── skills/
├── docker/
├── docker-compose.yml
├── build.gradle
│   ou build.gradle.kts
├── settings.gradle
│   ou settings.gradle.kts
├── gradlew
├── gradlew.bat
└── ...
```

Se o projeto utilizar Gradle multi-project, preserve os módulos existentes.

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
- módulos Gradle;
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
        │
        ├── query/
        │   ├── get/
        │   └── list/
        │
        └── dto/
```

Commands representam intenção de alteração.

Queries representam leitura.

Não utilize CQRS apenas como nomenclatura.

Handlers não devem concentrar invariantes pertencentes ao Aggregate.

---

# 11. CQRS

O fluxo conceitual de escrita deve ser:

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

O fluxo conceitual de leitura:

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

Exemplo de publicação:

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

Não faça:

```java
page.setStatus("PUBLISHED");
repository.save(page);
```

quando publicação possuir regras de domínio.

Prefira comportamento explícito:

```java
page.publish();
```

com invariantes protegidas pelo Aggregate.

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
- adapters técnicos;
- implementação de contratos definidos pelas camadas internas.

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

Não escolha automaticamente uma tecnologia de persistência.

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

Não assuma que:

```text
JPA Entity = Domain Entity
```

Quando Domain e Persistence estiverem separados:

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

O contrato do Repository pertence à camada interna apropriada.

---

# 14. MIGRATIONS

Antes de criar migrations, identifique a tecnologia existente.

Pode ser:

- Flyway;
- Liquibase;
- mecanismo do framework;
- outra ferramenta.

Não instale Flyway ou Liquibase automaticamente.

Preserve a decisão existente.

Migrations já aplicadas em ambientes compartilhados não devem ser alteradas para representar novas mudanças quando uma nova migration for apropriada.

---

# 15. API / HTTP

A camada API é responsável pela fronteira HTTP.

Pode conter:

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

# 16. FRAMEWORK

O framework deve ser detectado no projeto.

Se for Spring Boot, utilize seus recursos sem permitir que eles substituam as fronteiras arquiteturais.

Por exemplo:

```text
@RestController
@Service
@Repository
@Configuration
@Component
```

são mecanismos técnicos do framework.

Eles não definem, sozinhos, a arquitetura da aplicação.

Não transforme automaticamente a arquitetura em:

```text
Controller
→ Service
→ Spring Data Repository
→ JPA Entity
```

apenas porque essa estrutura é comum em projetos Spring.

A arquitetura deste prompt possui precedência.

---

# 17. DEPENDENCY INJECTION

Utilize Dependency Injection conforme o framework adotado.

As dependências devem apontar para abstrações adequadas.

Exemplo conceitual:

```text
Application
    ↓
PageRepository interface

Infrastructure
    ↓
JpaPageRepository implementation
```

A implementação técnica deve ser injetada na composição da aplicação.

Não utilize Service Locator para substituir DI sem justificativa.

---

# 18. IDENTITY

Relacionamento conceitual:

```text
User
  → Roles
      → Permissions
```

`User`, `Role` e `Permission` são conceitos distintos.

Permissions representam operações autorizadas pelo sistema.

A API é sempre a autoridade final para autorização.

Frontend pode ocultar funcionalidades conforme permissões, mas isso não substitui validação no backend.

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

Não implemente autenticação customizada quando o projeto já utilizar um mecanismo consolidado.

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

Quando Spring Security estiver presente, podem ser utilizados recursos como:

```text
SecurityFilterChain
Method Security
AuthorizationManager
```

ou mecanismos equivalentes da versão existente.

Entretanto, não acople o Domain diretamente ao Spring Security sem necessidade.

Autorização de fronteira e invariantes de domínio são responsabilidades diferentes.

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

Quando explicitamente implementado pelo domínio:

```text
Published → Draft/Unpublished
Published → Archived
```

Não introduza novos estados automaticamente.

As transições devem possuir regras explícitas.

`Version` pode participar de controle de concorrência quando necessário.

Não adote estratégia específica de optimistic locking sem analisar o mecanismo de persistência.

## Content

Conteúdos devem ser modelados conforme a feature e suas invariantes.

Evite uma entidade universal `Content` para qualquer informação.

Prefira modelos semanticamente relevantes.

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
- resolução no Site público.

Hierarquia e ordenação devem ser regras do Domain quando possuírem invariantes.

---

# 23. ADMIN E SITE

O sistema possui conceitualmente:

```text
Admin
Site
```

## Admin

Responsável por:

- autenticação;
- dashboard;
- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação.

## Site

Responsável por apresentar:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação pública.

Páginas básicas devem poder mudar sem alteração manual de código.

Não escolha automaticamente tecnologia frontend.

Se existir frontend, preserve a tecnologia adotada.

Se ainda não existir, apresente opções antes de escolher.

---

# 24. DOMAIN EVENTS

Domain Events representam acontecimentos relevantes do domínio.

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
Message Broker Event
```

Um Domain Event pode originar um Integration Event, mas são conceitos distintos.

---

# 25. EVENT SOURCING

Event Sourcing deve ser utilizado somente quando aplicável.

Não implemente Event Sourcing em CRUDs simples automaticamente.

Quando utilizado, defina claramente:

- Aggregate;
- Event Stream;
- versão;
- Event Store;
- reconstrução;
- concorrência;
- snapshots quando necessários.

---

# 26. MENSAGERIA

Quando houver processamento assíncrono, preserve separação entre:

```text
Domain Event
Integration Event
Message
```

A infraestrutura pode utilizar:

- Kafka;
- RabbitMQ;
- AWS SQS;
- Google Pub/Sub;
- outro mecanismo existente.

Não instale broker automaticamente.

Analise os requisitos e a infraestrutura existente.

---

# 27. RESULT PATTERN

Casos de uso devem utilizar Result Pattern conforme a convenção do projeto.

Exemplo conceitual:

```text
Result<T>
├── success
├── value
└── errors
```

Não utilize exceptions como controle comum de fluxo de negócio quando Result Pattern for mais apropriado.

Exceptions continuam válidas para condições realmente excepcionais.

---

# 28. DOMAIN NOTIFICATIONS

Domain Notifications podem representar violações ou informações relevantes de domínio.

Mantenha separação entre:

```text
Domain Notification
Validation Error
Application Error
HTTP Error
Exception
```

A API deve converter resultados da Application/Domain em respostas HTTP apropriadas.

---

# 29. VALIDATIONS

Existem níveis diferentes de validação.

## API Validation

Responsável por:

- formato;
- campos obrigatórios;
- tipos;
- estrutura da entrada.

Pode utilizar Bean Validation/Jakarta Validation quando a stack existente oferecer suporte.

## Domain Validation

Responsável por:

- invariantes;
- regras de negócio;
- transições;
- consistência do Aggregate.

API Validation nunca substitui Domain Validation.

---

# 30. GRADLE

Gradle é obrigatório como sistema de build deste cenário.

Preserve o formato existente:

```text
build.gradle
```

ou:

```text
build.gradle.kts
```

Não converta Groovy DSL para Kotlin DSL ou Kotlin DSL para Groovy DSL sem instrução explícita.

Utilize Gradle Wrapper:

```text
gradlew
gradlew.bat
gradle/wrapper/
```

Não dependa exclusivamente de uma instalação global do Gradle.

Antes de adicionar dependências:

1. analise dependências existentes;
2. verifique se a funcionalidade já existe;
3. confirme compatibilidade;
4. adicione somente quando necessária.

Não atualize plugins ou dependências indiscriminadamente.

---

# 31. MULTI-PROJECT GRADLE

Se o projeto utilizar multi-project build, preserve-o.

Exemplo conceitual:

```text
/
├── domain/
├── application/
├── infrastructure/
├── api/
├── build.gradle
└── settings.gradle
```

Pode existir uma relação conceitual:

```text
domain
   ↑
application
   ↑
infrastructure
   ↑
api
```

A relação real deve ser desenhada para impedir dependências indevidas.

Não force essa estrutura caso o projeto utilize packages em um único módulo.

Primeiro analise o projeto.

---

# 32. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

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
- [ ] Gradle atualizado quando necessário
- [ ] Docker atualizado quando necessário

Não considere o CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 33. TESTES

Devem existir testes de:

```text
Unit
Integration
E2E/API
```

conforme aplicável.

## Unit Tests

Devem validar:

- Aggregates;
- Entities;
- Value Objects;
- invariantes;
- Domain Services;
- Domain Validations;
- transições de estado;
- Commands/Handlers quando apropriado.

Unit Tests de Domain não devem iniciar framework ou banco quando não necessário.

## Integration Tests

Devem validar integrações reais:

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
5. chamar API;
6. validar autenticação;
7. validar autorização;
8. validar persistência;
9. limpar o ambiente.

Testes não devem utilizar banco DEV.

---

# 34. FRAMEWORK DE TESTES

Antes de alterar testes, identifique o projeto.

Pode utilizar:

- JUnit;
- TestNG;
- AssertJ;
- Mockito;
- Testcontainers;
- framework específico da stack.

Não instale bibliotecas automaticamente apenas porque são populares.

Preserve ferramentas existentes.

Quando integração real com banco for necessária, avalie o mecanismo já adotado pelo projeto.

---

# 35. TESTCONTAINERS

Se Testcontainers já estiver presente, preserve seu uso.

Se não estiver presente, não o instale automaticamente.

Pode ser considerado quando testes de integração necessitarem infraestrutura real e descartável.

A decisão deve considerar:

- banco;
- broker;
- cache;
- serviços externos simuláveis;
- ambiente CI.

Testcontainers não substitui Unit Tests.

---

# 36. BANCO DEV E TEST

Devem existir ambientes isolados:

```text
database-dev
database-test
```

Regras obrigatórias:

- testes nunca usam DEV;
- migrations devem executar em TEST;
- credenciais devem ser separadas quando apropriado;
- limpeza de TEST não pode afetar DEV;
- configuração deve tornar o isolamento explícito.

---

# 37. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz.

Deve contemplar pelo menos:

- aplicação Java;
- banco DEV;
- banco TEST.

Quando aplicável:

- frontend;
- Redis;
- Kafka;
- RabbitMQ;
- mail testing;
- outras dependências realmente utilizadas.

Não adicione infraestrutura sem necessidade.

DEV e TEST devem permanecer isolados.

---

# 38. CONFIGURAÇÃO

Preserve o mecanismo de configuração existente.

Pode incluir:

```text
application.properties
application.yml
environment variables
profiles
```

ou mecanismo equivalente do framework adotado.

Nunca armazene secrets reais em:

```text
Git
CLAUDE.md
AGENTS.md
SKILL.md
application.properties versionado
application.yml versionado
```

quando o arquivo fizer parte do repositório.

---

# 39. OBSERVABILIDADE

Preserve a estratégia existente de:

- logging;
- metrics;
- tracing;
- health checks.

Não adicione stack de observabilidade sem necessidade.

Logs não devem expor:

- passwords;
- tokens;
- secrets;
- dados sensíveis desnecessários.

---

# 40. FRONTEND

Se existir frontend no mesmo repositório, mantenha separação clara.

Exemplo:

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

A API Java continua sendo a autoridade final para autorização.

Não introduza React, Angular, Vue ou outro framework sem analisar o projeto.

---

# 41. INSTALAÇÃO DO TEMPLATE DO KIT

Minha stack não deve ser tratada automaticamente como um template Java simples.

Este projeto possui arquitetura combinada:

```text
Java
+ Gradle
+ DDD
+ CQRS
+ CMS/CRUD
+ Admin/Site
+ User/Role/Permission
```

Portanto:

1. Analise os templates disponíveis.
2. Identifique templates Java.
3. Identifique templates específicos do framework encontrado.
4. Não force Node.js, Next.js, PHP/Laravel, Python ou outra stack incompatível.
5. Analise se o template Java preserva a arquitetura deste prompt.
6. Não utilize template Java simplificado se eliminar Domain/Application/Infrastructure/API.
7. Se nenhum template preservar integralmente esta arquitetura, utilize:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

8. Adapte o template genérico às regras deste prompt.
9. Não deixe instruções genéricas contradizerem esta arquitetura.

---

# 42. CONFIGURAÇÃO DO CLAUDE.md

Leia o `SETUP NOTE` do `CLAUDE.md`.

Execute a entrevista necessária para substituir `[FILL]`.

Registre:

- Java;
- Gradle;
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

Não altere versões existentes apenas porque existem versões mais recentes.

Se Java, Gradle ou framework ainda não possuírem versões definidas, identifique opções e peça confirmação antes de adotá-las.

Depois de resolver todos os `[FILL]`, remova `SETUP NOTE` conforme orientação do Kit.

---

# 43. MULTI-TOOL

Se não utilizar somente Claude Code, configure também:

```text
AGENTS.md
```

ou equivalentes quando necessário.

Existe uma única arquitetura.

Não crie regras divergentes entre:

- `CLAUDE.md`;
- `AGENTS.md`;
- Agent Skills;
- documentação de agentes.

---

# 44. INSTALAÇÃO DAS SKILLS DO KIT

Instale as 10 skills existentes em:

```text
Kit-IA-Dev/3-Skills/
```

Para cada skill:

1. identifique a pasta completa;
2. copie a pasta inteira;
3. preserve `SKILL.md`;
4. preserve `references/`;
5. preserve arquivos auxiliares.

Para Claude Code:

```text
.claude/skills/
```

quando aplicável.

---

# 45. SKILLS AVANÇADAS

Depois das skills básicas:

1. localize as 8 skills novas;
2. instale suas pastas completas;
3. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

4. aplique os 8 patches correspondentes.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não remova essas skills por ausência de patch.

---

# 46. SKILLS ESPECÍFICAS DO PROJETO

Configure pelo menos:

```text
project-architecture
java-gradle-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
content-management
navigation-management
persistence
testing
docker-development
```

Quando o framework for identificado, avalie também uma skill específica.

Exemplo:

```text
spring-boot-architecture
```

somente se Spring Boot realmente fizer parte do projeto.

Evite duplicação desnecessária.

Não deixe regras críticas implícitas.

---

# 47. GERAÇÃO DE CRUD

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
Gradle, quando necessário
        ↓
Docker, quando necessário
```

---

# 48. VALIDAÇÃO DA INSTALAÇÃO

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

Confirme que a skill apropriada é utilizada.

## Validação 2 — Arquitetura

Execute:

```text
"crie um CRUD de categorias"
```

Confirme que a IA considera:

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

Confirme que considera:

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

# 49. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso ao pacote Templates.
3. Confirmar acesso ao pacote Skills Avançadas.
4. Confirmar a raiz do projeto.
5. Inspecionar estrutura atual.
6. Identificar ferramenta de IA.
7. Identificar diretório de Agent Skills.
8. Identificar versão Java.
9. Identificar versão Gradle.
10. Identificar Groovy DSL ou Kotlin DSL.
11. Identificar single-project ou multi-project.
12. Identificar framework Java.
13. Identificar persistência/ORM.
14. Identificar banco.
15. Identificar ferramenta de migrations.
16. Identificar framework de testes.
17. Identificar frontend quando aplicável.
18. Analisar templates.
19. Avaliar template Java/framework quando existir.
20. Utilizar template genérico quando necessário.
21. Configurar `CLAUDE.md`.
22. Configurar multi-tool quando necessário.
23. Instalar as 10 skills básicas.
24. Instalar as 8 skills avançadas.
25. Aplicar os 8 patches.
26. Criar/adaptar skills específicas.
27. Validar conflitos/duplicações.
28. Validar arquitetura.
29. Validar ativação das skills.
30. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 50. PROIBIÇÕES

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
- instalar dependências Gradle sem necessidade;
- atualizar Java indiscriminadamente;
- atualizar Gradle indiscriminadamente;
- atualizar framework indiscriminadamente;
- atualizar plugins indiscriminadamente;
- converter Gradle para Maven;
- converter Groovy DSL para Kotlin DSL sem autorização;
- converter Kotlin DSL para Groovy DSL sem autorização;
- escolher Spring Boot automaticamente;
- escolher JPA/Hibernate automaticamente;
- escolher banco automaticamente;
- escolher Flyway/Liquibase automaticamente;
- adicionar Lombok automaticamente;
- adicionar MapStruct automaticamente;
- adicionar Testcontainers automaticamente;
- adicionar Kafka/RabbitMQ automaticamente;
- substituir framework de testes sem analisar o projeto;
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

Isso não significa ignorar o framework.

Significa utilizar Java, Gradle e o framework escolhido sem permitir que convenções simplificadas eliminem as fronteiras arquiteturais.

---

# 51. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial Java + Gradle para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS, separação entre Domain/Application/Infrastructure/API, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, persistência isolada das regras de domínio, testes reais e ambientes Docker DEV/TEST.

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
Value Objects
        ↓
Invariants
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
Gradle
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