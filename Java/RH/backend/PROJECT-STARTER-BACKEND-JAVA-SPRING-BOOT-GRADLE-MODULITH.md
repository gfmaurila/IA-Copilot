# PROJECT STARTER --- BACKEND JAVA / SPRING BOOT / GRADLE

> Documento de bootstrap para criação inicial de um backend em Java
> utilizando Spring Boot e Gradle.
>
> O objetivo deste starter é **somente criar a estrutura técnica inicial
> do projeto**. Nenhuma regra de negócio, integração, persistência,
> autenticação ou feature deve ser implementada nesta etapa.
>
> A arquitetura inicial será um **Monólito Modular**, utilizando **uma
> única aplicação Spring Boot**, com estrutura de packages preparada
> para adoção do **Spring Modulith**.

------------------------------------------------------------------------

# 1. Objetivo

Criar um backend Java/Spring Boot contendo apenas:

-   uma única aplicação Spring Boot;
-   Gradle;
-   estrutura modular orientada aos contextos de negócio;
-   módulos iniciais `Auth`, `Person`, `Admin` e `Site`;
-   camada compartilhada `Shared`;
-   separação arquitetural preparada para DDD e CQRS;
-   endpoints mínimos para validação;
-   build funcionando;
-   aplicação executável;
-   testes de bootstrap mínimos, quando aplicável.

Este starter **não implementa funcionalidades de negócio**.

------------------------------------------------------------------------

# 2. Decisão arquitetural

A aplicação deve iniciar como:

``` text
Monólito Modular
```

Não criar quatro aplicações Spring Boot independentes.

Estrutura conceitual:

``` text
                 Spring Boot
                      │
       ┌──────────────┼──────────────┐
       │              │              │
     Auth           Person         Admin
       │              │              │
       └──────────────┼──────────────┘
                      │
                     Site
                      │
                    Shared
```

Todos os módulos executam dentro:

``` text
1 aplicação Spring Boot
1 build.gradle
1 bootstrap
1 configuração
1 processo de deploy
```

Os módulos devem possuir isolamento lógico através de packages
diretamente abaixo do package raiz, contratos e regras de dependência:

``` text
Packages
Diretórios
Contratos
Camadas
Dependency Injection
Regras de dependência
```

Não utilizar microserviços nesta etapa.

A estrutura deve ser compatível com o modelo de módulos do Spring
Modulith, no qual os packages diretamente abaixo do package principal
representam módulos da aplicação. A dependência do Spring Modulith e
suas validações devem ser adicionadas somente em task específica.

------------------------------------------------------------------------

# 3. Informações do projeto

Preencher antes da criação.

  Campo                  Valor
  ---------------------- -------------
  Nome do projeto        `A DEFINIR`
  Group / package base   `A DEFINIR`
  Versão Java            `A DEFINIR`
  Versão Spring Boot     `A DEFINIR`
  Versão Gradle          `A DEFINIR`
  Repositório            `A DEFINIR`
  Responsável técnico    `A DEFINIR`

Exemplo:

``` text
Nome: meu-projeto
Group: com.meuprojeto
Package base: com.meuprojeto.backend
```

------------------------------------------------------------------------

# 4. Tecnologias base

Utilizar inicialmente:

``` text
Java
Spring Boot
Spring Web
Gradle
JUnit
```

Não adicionar bibliotecas externas sem necessidade explícita.

------------------------------------------------------------------------

# 5. Escopo desta etapa

## Deve ser criado

-   pasta `backend/`;
-   uma única aplicação Spring Boot;
-   Gradle;
-   estrutura modular orientada aos contextos de negócio;
-   módulos de negócio `Auth`, `Person`, `Admin` e `Site`;
-   estrutura `Shared`;
-   estrutura mínima de `application`, `domain`, `infrastructure` e
    `web`;
-   endpoints mínimos de validação;
-   `README.md`;
-   `.gitignore`;
-   `application.yml` ou `application.properties`;
-   `build.gradle`;
-   `settings.gradle`;
-   Gradle Wrapper;
-   build funcionando;
-   aplicação iniciando sem erro.

## Não deve ser criado

Nesta etapa, **não implementar**:

-   frontend;
-   CRUDs;
-   regras de negócio;
-   autenticação;
-   autorização;
-   JWT;
-   OAuth;
-   banco de dados funcional;
-   migrations;
-   seeds;
-   entidades JPA de negócio;
-   repositories concretos;
-   Spring Data JPA;
-   Hibernate customizado;
-   Flyway;
-   Liquibase;
-   MongoDB;
-   Redis;
-   Kafka;
-   RabbitMQ;
-   Docker;
-   Docker Compose;
-   Commands funcionais;
-   Queries funcionais;
-   Handlers;
-   Domain Events;
-   Aggregates;
-   Value Objects de negócio;
-   Jobs;
-   Queues;
-   Workers;
-   Schedulers;
-   integrações externas.

Esses recursos devem ser adicionados posteriormente através de tasks
específicas.

------------------------------------------------------------------------

# 6. Estrutura esperada

Toda a aplicação deve ficar dentro de:

``` text
backend/
```

Estrutura inicial:

``` text
📂 backend
├── 📂 src
│   ├── 📂 main
│   │   ├── 📂 java
│   │   │   └── 📂 com
│   │   │       └── 📂 meuprojeto
│   │   │           └── 📂 backend
│   │   │               ├── 📂 auth
│   │   │               │   ├── 📂 application
│   │   │               │   │   ├── 📂 command
│   │   │               │   │   └── 📂 query
│   │   │               │   ├── 📂 domain
│   │   │               │   │   ├── 📂 model
│   │   │               │   │   ├── 📂 event
│   │   │               │   │   └── 📂 repository
│   │   │               │   ├── 📂 infrastructure
│   │   │               │   │   └── 📂 persistence
│   │   │               │   └── 📂 web
│   │   │               │       ├── 📂 controller
│   │   │               │       ├── 📂 request
│   │   │               │       └── 📂 response
│   │   │               │
│   │   │               ├── 📂 person
│   │   │               │   ├── 📂 application
│   │   │               │   │   ├── 📂 command
│   │   │               │   │   └── 📂 query
│   │   │               │   ├── 📂 domain
│   │   │               │   │   ├── 📂 model
│   │   │               │   │   ├── 📂 event
│   │   │               │   │   └── 📂 repository
│   │   │               │   ├── 📂 infrastructure
│   │   │               │   │   └── 📂 persistence
│   │   │               │   └── 📂 web
│   │   │               │       ├── 📂 controller
│   │   │               │       ├── 📂 request
│   │   │               │       └── 📂 response
│   │   │               │
│   │   │               ├── 📂 admin
│   │   │               │   ├── 📂 application
│   │   │               │   │   ├── 📂 command
│   │   │               │   │   └── 📂 query
│   │   │               │   ├── 📂 domain
│   │   │               │   │   ├── 📂 model
│   │   │               │   │   ├── 📂 event
│   │   │               │   │   └── 📂 repository
│   │   │               │   ├── 📂 infrastructure
│   │   │               │   │   └── 📂 persistence
│   │   │               │   └── 📂 web
│   │   │               │       ├── 📂 controller
│   │   │               │       ├── 📂 request
│   │   │               │       └── 📂 response
│   │   │               │
│   │   │               ├── 📂 site
│   │   │               │   ├── 📂 application
│   │   │               │   │   ├── 📂 command
│   │   │               │   │   └── 📂 query
│   │   │               │   ├── 📂 domain
│   │   │               │   │   ├── 📂 model
│   │   │               │   │   ├── 📂 event
│   │   │               │   │   └── 📂 repository
│   │   │               │   ├── 📂 infrastructure
│   │   │               │   │   └── 📂 persistence
│   │   │               │   └── 📂 web
│   │   │               │       ├── 📂 controller
│   │   │               │       ├── 📂 request
│   │   │               │       └── 📂 response
│   │   │               │
│   │   │               ├── 📂 shared
│   │   │               │   ├── 📂 application
│   │   │               │   ├── 📂 domain
│   │   │               │   ├── 📂 infrastructure
│   │   │               │   └── 📂 crosscutting
│   │   │               │
│   │   │               └── 📄 Application.java
│   │   │
│   │   └── 📂 resources
│   │       └── 📄 application.yml
│   │
│   └── 📂 test
│       └── 📂 java
│
├── 📂 gradle
│   └── 📂 wrapper
│
├── 📄 build.gradle
├── 📄 settings.gradle
├── 📄 gradlew
├── 📄 gradlew.bat
├── 📄 .gitignore
└── 📄 README.md
```

> Ajustar `com/meuprojeto/backend` para o package base definido no
> projeto.

------------------------------------------------------------------------

# 7. Responsabilidade dos módulos

## Auth

Responsável futuramente por:

``` text
Login
Logout
Recuperação de senha
Tokens
Identidade
Autenticação
Autorização
```

Nesta etapa não implementar nenhuma dessas funcionalidades.

Criar apenas estrutura.

------------------------------------------------------------------------

## Person

Responsável futuramente por:

``` text
Pessoa
Usuário
Perfil
Dados pessoais
```

Nesta etapa não implementar regras de negócio.

------------------------------------------------------------------------

## Admin

Responsável futuramente pelas funcionalidades administrativas.

Exemplos futuros:

``` text
Dashboard
Gestão de usuários
Configurações administrativas
Permissões
```

Nesta etapa não implementar essas funcionalidades.

------------------------------------------------------------------------

## Site

Responsável futuramente pelas funcionalidades públicas consumidas pelo
frontend/site.

Nesta etapa criar apenas a estrutura.

------------------------------------------------------------------------

# 8. Estrutura interna de um módulo

Os módulos devem seguir inicialmente:

``` text
module
├── application
│   ├── command
│   └── query
│
├── domain
│   ├── model
│   ├── event
│   └── repository
│
├── infrastructure
│   └── persistence
│
└── web
    ├── controller
    ├── request
    └── response
```

Essa estrutura representa a direção arquitetural futura.

Não criar classes artificiais apenas para preencher pacotes.

------------------------------------------------------------------------

# 9. Application

A camada:

``` text
application
```

será responsável futuramente pelos casos de uso.

Poderá conter:

``` text
Commands
Queries
Handlers
DTOs
Validators
Use Cases
Application Services
```

Nesta etapa criar somente:

``` text
command/
query/
```

Não implementar classes funcionais.

------------------------------------------------------------------------

# 10. Domain

A camada:

``` text
domain
```

representará o núcleo de negócio de cada módulo.

Poderá conter futuramente:

``` text
Entities
Aggregates
Value Objects
Domain Events
Domain Services
Repository Interfaces
Specifications
Business Rules
```

Nesta etapa deve permanecer vazia.

## Regra fundamental

O `domain` não deve depender diretamente de:

``` text
Spring Boot
Spring MVC
Spring Data
JPA
Hibernate
Controllers
Infrastructure
Banco de dados
Redis
Kafka
Frameworks externos
```

O domínio deve permanecer o mais independente possível do framework.

------------------------------------------------------------------------

# 11. Infrastructure

A camada:

``` text
infrastructure
```

poderá conter futuramente implementações técnicas:

``` text
Persistence
Repository Implementations
Spring Data
JPA
Hibernate
Cache
Redis
Kafka
RabbitMQ
MongoDB
HTTP Clients
Filesystem
Outbox
Integrações externas
```

Nesta etapa deve permanecer vazia.

------------------------------------------------------------------------

# 12. Web

A camada:

``` text
web
```

é a porta de entrada da aplicação.

Poderá conter:

``` text
Controllers
Requests
Responses
Exception Handlers
Filtros HTTP específicos do módulo
```

Fluxo futuro:

``` text
HTTP
 ↓
Controller
 ↓
Application
 ↓
Domain
```

Controllers não devem conter regras de negócio.

------------------------------------------------------------------------

# 13. Shared

Criar:

``` text
shared
```

Estrutura:

``` text
shared
├── application
├── domain
├── infrastructure
└── crosscutting
```

O `shared` deve conter apenas componentes realmente compartilhados entre
módulos.

Não utilizar `shared` como pacote genérico para qualquer código.

------------------------------------------------------------------------

# 14. Shared Domain

Poderá conter futuramente abstrações realmente compartilhadas:

``` text
AggregateRoot
DomainEvent
ValueObject base
Identifiers
Clock abstractions
Result
Either
```

Nesta etapa não implementar essas abstrações.

------------------------------------------------------------------------

# 15. Cross-Cutting

Poderá conter futuramente:

``` text
Logging
Exceptions
CorrelationId
Filters
Interceptors
Health Checks
Observabilidade
Helpers técnicos
```

Nesta etapa deve permanecer mínimo.

------------------------------------------------------------------------

# 16. Direção das dependências

Dentro de cada módulo:

``` text
web
 ↓
application
 ↓
domain
```

Infrastructure pode implementar contratos necessários por:

``` text
application
domain
```

Representação:

``` text
      web
           ↓
      application
           ↓
         domain
           ↑
     infrastructure
```

## Permitido

``` text
web -> application
application -> domain
infrastructure -> application
infrastructure -> domain
```

## Não permitido

``` text
domain -> infrastructure
domain -> web
domain -> Spring
application -> web
application -> controllers
```

------------------------------------------------------------------------

# 17. Dependências entre módulos

Evitar dependências diretas entre módulos.

Exemplo a evitar:

``` text
admin.domain
    ↓
person.infrastructure
```

Caso um módulo precise interagir com outro, a estratégia deverá ser
definida em uma task específica.

Possíveis estratégias futuras:

``` text
Application Contracts
Domain Events
Integration Events
Interfaces
Event Bus
Facade
```

Não implementar essas estratégias nesta etapa.

------------------------------------------------------------------------

# 18. Spring Modulith

A estrutura deve ser preparada para futura adoção do Spring Modulith.

Os módulos de negócio devem ficar diretamente abaixo do package raiz:

``` text
com.meuprojeto.backend
├── auth
├── person
├── admin
├── site
└── shared
```

Evitar:

``` text
com.meuprojeto.backend.modules.auth
com.meuprojeto.backend.modules.person
```

O package intermediário `modules` não é necessário.

A intenção é permitir que cada package principal represente um módulo de
aplicação.

Nesta etapa:

-   não adicionar obrigatoriamente a dependência Spring Modulith;
-   não criar eventos apenas para demonstrar Modulith;
-   não criar testes arquiteturais artificiais;
-   não adicionar configuração de persistência de eventos;
-   não adicionar documentação automática de módulos.

Em uma task futura, o Spring Modulith poderá ser utilizado para:

``` text
Validar dependências entre módulos
Detectar violações arquiteturais
Testar módulos isoladamente
Documentar módulos
Gerenciar eventos entre módulos
```

Exemplo conceitual futuro:

``` java
ApplicationModules.of(Application.class).verify();
```

Essa validação não deve ser implementada neste bootstrap.

------------------------------------------------------------------------

# 19. Classe principal

Criar apenas uma classe principal da aplicação.

Exemplo:

``` java
package com.meuprojeto.backend;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class Application {

    public static void main(String[] args) {
        SpringApplication.run(Application.class, args);
    }
}
```

Não adicionar configurações extras sem necessidade.

------------------------------------------------------------------------

# 20. Controllers mínimos

Cada módulo pode possuir um controller mínimo somente para validação.

Exemplo:

``` java
package com.meuprojeto.backend.auth.web.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/auth")
public class AuthController {

    @GetMapping
    public String index() {
        return "Olá Mundo - Auth API";
    }
}
```

Não adicionar regra de negócio ao controller.

------------------------------------------------------------------------

# 21. Endpoints obrigatórios de validação

Criar inicialmente:

``` text
GET /api/auth
GET /api/person
GET /api/admin
GET /api/site
```

Respostas:

``` text
Olá Mundo - Auth API
Olá Mundo - Person API
Olá Mundo - Admin API
Olá Mundo - Site API
```

Não criar endpoints adicionais de negócio.

------------------------------------------------------------------------

# 22. Requests e Responses

Nesta etapa não criar DTOs de negócio.

As pastas:

``` text
web/request
web/response
```

podem permanecer vazias.

Criar DTOs somente quando existirem features reais.

------------------------------------------------------------------------

# 23. Dependency Injection

Utilizar o mecanismo padrão do Spring quando as primeiras features forem
criadas.

Nesta etapa não criar antecipadamente:

``` text
Services
Repositories
Command Bus
Query Bus
Event Dispatcher
Database Client
External API Client
Message Bus
```

Não criar beans artificiais apenas para demonstrar injeção.

------------------------------------------------------------------------

# 24. Banco de dados

Nesta etapa não configurar persistência.

Não adicionar:

``` text
Spring Data JPA
Hibernate adicional
JDBC customizado
MongoDB Driver
```

Não criar:

``` text
@Entity
JpaRepository
Migration
DataSource customizado
Repository concreto
```

Nenhum banco deve ser necessário para executar o starter.

------------------------------------------------------------------------

# 25. CQRS

A aplicação será preparada conceitualmente para CQRS.

Estrutura:

``` text
application
├── command
└── query
```

Nesta etapa não criar:

``` text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
GetUserQuery
ListUserQuery
CommandHandler
QueryHandler
CommandBus
QueryBus
Mediator
```

Não adicionar framework CQRS antecipadamente.

CQRS será implementado através de tasks futuras.

------------------------------------------------------------------------

# 26. Domain Events

A arquitetura poderá utilizar Domain Events futuramente.

Possíveis componentes:

``` text
DomainEvent
DomainEventDispatcher
DomainEventHandler
AggregateRoot
IntegrationEvent
Outbox
```

Nesta etapa não implementar nenhum deles.

------------------------------------------------------------------------

# 27. Spring Events

Não utilizar antecipadamente:

``` text
ApplicationEventPublisher
@EventListener
@TransactionalEventListener
```

para simular Domain Events inexistentes.

Esses recursos poderão ser avaliados em uma task específica.

------------------------------------------------------------------------

# 28. Autenticação

Embora exista um módulo:

``` text
auth
```

não implementar autenticação nesta etapa.

Não adicionar antecipadamente:

``` text
Spring Security
JWT
OAuth2
Keycloak
Auth0
```

O módulo Auth nesta etapa representa somente uma divisão arquitetural
futura.

------------------------------------------------------------------------

# 29. application.yml

Manter configuração mínima.

Exemplo:

``` yaml
spring:
  application:
    name: A-DEFINIR

server:
  port: 8080
```

Não incluir:

``` text
Banco de dados
Redis
Kafka
RabbitMQ
Credenciais
Secrets
```

------------------------------------------------------------------------

# 30. Variáveis de ambiente

Não versionar:

``` text
senhas
tokens
API keys
credenciais reais
secrets
```

Quando necessário futuramente, utilizar variáveis de ambiente.

------------------------------------------------------------------------

# 31. Gradle

Utilizar Gradle como ferramenta de build.

Arquivos principais:

``` text
build.gradle
settings.gradle
gradlew
gradlew.bat
gradle/wrapper/
```

Utilizar o Gradle Wrapper.

Não exigir instalação global do Gradle para executar o projeto.

------------------------------------------------------------------------

# 32. build.gradle

Manter apenas dependências necessárias ao bootstrap.

Exemplo conceitual:

``` groovy
plugins {
    id 'java'
    id 'org.springframework.boot' version 'A DEFINIR'
    id 'io.spring.dependency-management' version 'A DEFINIR'
}

group = 'A DEFINIR'
version = '0.0.1-SNAPSHOT'

java {
    toolchain {
        languageVersion = JavaLanguageVersion.of(A_DEFINIR)
    }
}

repositories {
    mavenCentral()
}

dependencies {
    implementation 'org.springframework.boot:spring-boot-starter-web'

    testImplementation 'org.springframework.boot:spring-boot-starter-test'
}

tasks.named('test') {
    useJUnitPlatform()
}
```

Não inventar versões.

A task de criação deve substituir:

``` text
A DEFINIR
```

pelos valores previamente aprovados.

------------------------------------------------------------------------

# 33. settings.gradle

Exemplo:

``` groovy
rootProject.name = 'A-DEFINIR'
```

Não criar projeto Gradle multi-module nesta etapa. A modularidade será
controlada inicialmente por packages e, futuramente, poderá ser validada
pelo Spring Modulith.

O isolamento será por packages dentro de uma única aplicação.

------------------------------------------------------------------------

# 34. Dependências Gradle

Não adicionar bibliotecas antecipadamente.

O Spring Modulith deve ser adicionado somente quando uma task específica
habilitar a validação modular.

Evitar nesta etapa:

``` text
spring-boot-starter-data-jpa
spring-boot-starter-security
spring-boot-starter-validation
spring-kafka
spring-boot-starter-data-redis
spring-boot-starter-amqp
spring-boot-starter-data-mongodb
Flyway
Liquibase
MapStruct
Lombok
OpenTelemetry
Sentry
Resilience4j
```

Utilizar somente dependências necessárias para:

``` text
Spring Boot
HTTP
Testes básicos
```

------------------------------------------------------------------------

# 35. Lombok

Não instalar Lombok automaticamente.

A adoção de Lombok deve ser uma decisão explícita do projeto.

Nesta etapa preferir Java padrão.

------------------------------------------------------------------------

# 36. Java Records

Records poderão ser utilizados futuramente para DTOs e Value Objects
quando apropriado.

Nesta etapa não criar DTOs apenas para demonstrar Records.

------------------------------------------------------------------------

# 37. Testes

Manter:

``` text
src/test/java
```

Nesta etapa os testes devem se limitar, quando necessários, ao
bootstrap.

Exemplo possível:

``` java
@SpringBootTest
class ApplicationTests {

    @Test
    void contextLoads() {
    }
}
```

Não criar testes para regras de negócio inexistentes.

------------------------------------------------------------------------

# 38. Build

Linux/macOS:

``` bash
./gradlew build
```

Windows:

``` bash
gradlew.bat build
```

Resultado esperado:

``` text
BUILD SUCCESSFUL
```

Nenhum erro de compilação deve existir.

------------------------------------------------------------------------

# 39. Executar testes

Linux/macOS:

``` bash
./gradlew test
```

Windows:

``` bash
gradlew.bat test
```

------------------------------------------------------------------------

# 40. Executar aplicação

Linux/macOS:

``` bash
./gradlew bootRun
```

Windows:

``` bash
gradlew.bat bootRun
```

Exemplo padrão:

``` text
http://localhost:8080
```

------------------------------------------------------------------------

# 41. Validação dos endpoints

Validar:

``` text
GET http://localhost:8080/api/auth
GET http://localhost:8080/api/person
GET http://localhost:8080/api/admin
GET http://localhost:8080/api/site
```

Respostas esperadas:

``` text
Olá Mundo - Auth API
Olá Mundo - Person API
Olá Mundo - Admin API
Olá Mundo - Site API
```

------------------------------------------------------------------------

# 42. Gradle Wrapper

O repositório deve versionar:

``` text
gradlew
gradlew.bat
gradle/wrapper/gradle-wrapper.jar
gradle/wrapper/gradle-wrapper.properties
```

Isso garante execução consistente do build.

------------------------------------------------------------------------

# 43. README inicial

O arquivo:

``` text
backend/README.md
```

deve conter apenas informações essenciais.

Exemplo:

``` markdown
# MeuProjeto Backend

Backend do projeto MeuProjeto.

## Tecnologia

- Java
- Spring Boot
- Gradle

## Arquitetura

Monólito Modular.

## Módulos

- Auth
- Person
- Admin
- Site

## Estrutura

- modules
- shared
- application
- domain
- infrastructure
- web

## Build

```bash
./gradlew build
```

## Executar

``` bash
./gradlew bootRun
```

## Testes

``` bash
./gradlew test
```


    ---

    # 44. `.gitignore`

    Garantir que não sejam versionados:

    ```text
    .gradle/
    build/
    out/
    .idea/
    .vscode/
    *.iml
    .DS_Store
    Thumbs.db
    .env

Não ignorar:

``` text
gradlew
gradlew.bat
gradle/wrapper/
```

------------------------------------------------------------------------

# 45. Convenções

Utilizar:

``` text
Java conventions
PascalCase para classes
camelCase para métodos e variáveis
lowercase para packages
Packages organizados por módulo
Constructor Injection
```

Evitar abstrações prematuras.

------------------------------------------------------------------------

# 46. Injeção de dependência

Quando houver dependências reais, preferir:

``` text
Constructor Injection
```

Evitar:

``` text
@Autowired em campos
```

Exemplo futuro:

``` java
public class ExampleService {

    private final ExampleRepository repository;

    public ExampleService(ExampleRepository repository) {
        this.repository = repository;
    }
}
```

Nesta etapa não criar services artificiais.

------------------------------------------------------------------------

# 47. Package naming

Exemplo:

``` text
com.meuprojeto.backend.auth
com.meuprojeto.backend.person
com.meuprojeto.backend.admin
com.meuprojeto.backend.site
com.meuprojeto.backend.shared
```

Não utilizar packages genéricos como:

``` text
utils
helpers
common
misc
```

sem uma responsabilidade clara.

------------------------------------------------------------------------

# 48. Evolução futura

A arquitetura poderá evoluir para:

``` text
HTTP
 ↓
Controller
 ↓
Command / Query
 ↓
Handler
 ↓
Domain
 ↓
Repository Interface
 ↑
Infrastructure
```

E:

``` text
Domain
 ↓
Domain Event
 ↓
Handler
 ↓
Infrastructure / Integration
```

Nenhum desses fluxos deve ser implementado durante o bootstrap.

------------------------------------------------------------------------

# 49. Monólito Modular x Microserviços

A aplicação deve iniciar como:

``` text
Monólito Modular
```

Não criar:

``` text
Auth Service separado
Person Service separado
Admin Service separado
Site Service separado
```

Caso futuramente exista necessidade comprovada de:

``` text
deploy independente
escala independente
banco independente
times independentes
isolamento operacional
```

um módulo poderá ser avaliado para extração como serviço.

Essa decisão não pertence ao bootstrap inicial.

------------------------------------------------------------------------

# 50. Critérios de aceite

O starter está concluído somente quando:

-   [ ] pasta `backend` criada;
-   [ ] uma única aplicação Spring Boot criada;
-   [ ] Gradle configurado;
-   [ ] Gradle Wrapper criado;
-   [ ] apenas um `build.gradle`;
-   [ ] apenas um `settings.gradle`;
-   [ ] packages `auth`, `person`, `admin` e `site` criados diretamente
    abaixo do package raiz;
-   [ ] nenhum package intermediário `modules` criado;
-   [ ] estrutura Shared criada;
-   [ ] estrutura application criada;
-   [ ] estrutura domain criada;
-   [ ] estrutura infrastructure criada;
-   [ ] estrutura web criada;
-   [ ] estrutura compatível com futura adoção do Spring Modulith;
-   [ ] classe principal Spring Boot criada;
-   [ ] rota `/api/auth` criada;
-   [ ] rota `/api/person` criada;
-   [ ] rota `/api/admin` criada;
-   [ ] rota `/api/site` criada;
-   [ ] todas retornam `Olá Mundo`;
-   [ ] nenhuma regra de negócio criada;
-   [ ] nenhum CRUD criado;
-   [ ] nenhuma Entity de negócio criada;
-   [ ] nenhum Aggregate criado;
-   [ ] nenhum Domain Event criado;
-   [ ] nenhum Command funcional criado;
-   [ ] nenhuma Query funcional criada;
-   [ ] nenhum Handler criado;
-   [ ] nenhuma persistência configurada;
-   [ ] nenhuma autenticação implementada;
-   [ ] nenhuma mensageria configurada;
-   [ ] nenhum frontend criado;
-   [ ] nenhum Docker criado;
-   [ ] `gradlew build` executa sem erro;
-   [ ] `gradlew test` executa sem erro;
-   [ ] `gradlew bootRun` inicia a aplicação;
-   [ ] os quatro endpoints respondem corretamente.

------------------------------------------------------------------------

# 51. Regras para IA / Copilot

Ao utilizar este arquivo como prompt/contexto para IA:

1.  Criar somente o backend.
2.  Utilizar Java.
3.  Utilizar Spring Boot.
4.  Utilizar Gradle.
5.  Utilizar Gradle Wrapper.
6.  Criar **uma única aplicação Spring Boot**.
7.  Utilizar arquitetura de **Monólito Modular**.
8.  Não criar quatro aplicações independentes.
9.  Criar módulos `Auth`, `Person`, `Admin` e `Site`.
10. Criar `Shared`.
11. Não criar frontend.
12. Não implementar features.
13. Não criar CRUDs.
14. Não criar entidades de negócio.
15. Não criar Aggregates.
16. Não implementar Commands.
17. Não implementar Queries.
18. Não implementar Handlers.
19. Não implementar Domain Events.
20. Não configurar banco de dados.
21. Não adicionar Spring Data JPA.
22. Não adicionar Flyway.
23. Não adicionar Liquibase.
24. Não criar migrations.
25. Não configurar MongoDB.
26. Não configurar Redis.
27. Não configurar Kafka.
28. Não configurar RabbitMQ.
29. Não implementar autenticação.
30. Não adicionar Spring Security.
31. Não implementar JWT.
32. Não criar Jobs.
33. Não criar Queues.
34. Não criar Workers.
35. Não criar Scheduler customizado.
36. Não criar Docker.
37. Não criar Docker Compose.
38. Não adicionar dependências Gradle antecipadamente.
39. Utilizar apenas um `build.gradle`.
40. Não criar projeto Gradle multi-module nesta etapa.
41. Manter o Domain independente do Spring.
42. Não utilizar anotações Spring no Domain.
43. Não utilizar entidades JPA como Domain Entities.
44. Não colocar regras de negócio em Controllers.
45. Preferir Constructor Injection quando houver dependências reais.
46. Não utilizar Field Injection.
47. Não criar Services artificiais.
48. Não criar Repositories artificiais.
49. Não criar integrações externas.
50. Não adicionar arquitetura complexa antecipadamente.
51. Criar somente os quatro endpoints de validação definidos.
52. Manter o código mínimo e executável.
53. Respeitar a direção das dependências.
54. Evitar dependência direta entre módulos.
55. Caso alguma informação necessária não esteja definida, utilizar
    `A DEFINIR`.
56. Não inventar versões de Java, Spring Boot ou Gradle.
57. Criar `auth`, `person`, `admin` e `site` diretamente abaixo do
    package raiz.
58. Não criar package intermediário `modules`.
59. Utilizar `web` como adaptador HTTP de entrada.
60. Preparar a estrutura para Spring Modulith.
61. Não adicionar Spring Modulith neste bootstrap sem task específica.
62. Não expandir o escopo sem solicitação explícita.

------------------------------------------------------------------------

# 52. Resultado esperado

Ao final deve existir:

``` text
                 HTTP
                  ↓
             Spring Boot
                  ↓
       Modular Monolith
     (Spring Modulith ready)
       ┌──────────┼──────────┐
       │          │          │
      Auth      Person     Admin
       │          │          │
       └──────────┼──────────┘
                  │
                 Site

Dentro de cada módulo:

Web
     ↓
Application
     ↓
Domain

Infrastructure
     ↑
implementações técnicas futuras

Shared
     ↓
componentes realmente compartilhados
```

Com apenas uma aplicação Spring Boot.

Sem microserviços.

Sem funcionalidades de negócio.

Sem persistência.

Sem autenticação.

Sem mensageria.

Sem frontend.

Sem Docker.

Sem CQRS funcional.

Sem Domain Events.

O desenvolvimento funcional começa somente após a aprovação deste
bootstrap e criação das tasks específicas.
