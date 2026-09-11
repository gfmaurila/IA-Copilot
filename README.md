# IA-Copilot

**IA Copilot** é um conjunto de templates e estruturas de projetos preparados para desenvolvimento assistido por Inteligência Artificial, utilizando arquivos de **Rules, Skills e Specs** para orientar ferramentas como GitHub Copilot e outros agentes de IA.

O objetivo é padronizar a criação de projetos, reduzir repetição de prompts, diminuir o consumo desnecessário de tokens e garantir que a IA respeite a arquitetura definida para cada tecnologia.

---

## 📦 Projetos

### 1. Python FastAPI + CQRS + MySQL

**Stack:**

* Python
* FastAPI
* CQRS
* Domain Events
* SQLAlchemy
* Alembic
* Pydantic
* MySQL
* JWT
* Pytest
* React + TypeScript
* Docker

**Consumo estimado:**

```text
Tokens: ~260.000
Custo:  ~US$ 2,29
Custo:  ~R$ 11,62
```

---

### 2. PHP Laravel + CQRS + MySQL

**Stack:**

* PHP
* Laravel
* CQRS
* Commands
* Queries
* Handlers
* Domain Events
* Eloquent
* MySQL
* Policies / Gates
* Sanctum / JWT
* React + TypeScript
* Docker

**Consumo estimado:**

```text
Tokens: ~270.000
Custo:  ~US$ 2,38
Custo:  ~R$ 12,07
```

---

### 3. .NET Core + Vertical Slice + Minimal APIs + CQRS

**Stack:**

* .NET
* ASP.NET Core
* Vertical Slice Architecture
* Minimal APIs
* CQRS
* Domain
* Domain Events
* MediatR
* FluentValidation
* EF Core
* JWT
* React + TypeScript
* Docker

**Consumo estimado:**

```text
Tokens: ~280.000
Custo:  ~US$ 2,46
Custo:  ~R$ 12,52
```

---

### 4. .NET Core + DDD + CQRS + Domain Events

**Stack:**

* .NET
* ASP.NET Core
* DDD
* CQRS
* Domain Events
* Clean Architecture
* MediatR
* AutoMapper
* FluentValidation
* EF Core
* JWT
* React + TypeScript
* Docker

**Consumo estimado:**

```text
Tokens: ~320.000
Custo:  ~US$ 2,82
Custo:  ~R$ 14,31
```

---

### 5. Java + Spring Boot + Gradle + CQRS + MySQL

**Stack:**

* Java
* Spring Boot
* Gradle
* Gradle Kotlin DSL
* CQRS
* Domain Events
* Spring Security
* Spring Data JPA
* Hibernate
* Flyway
* MySQL
* JWT
* JUnit
* Testcontainers
* React + TypeScript
* Docker

**Consumo estimado:**

```text
Tokens: ~325.000
Custo:  ~US$ 2,86
Custo:  ~R$ 14,53
```

---

### 6. Java + Spring Boot + Gradle + Hexagonal + CQRS

**Stack:**

* Java
* Spring Boot
* Gradle
* Arquitetura Hexagonal
* Ports & Adapters
* CQRS
* Domain Events
* Spring Security
* Spring Data JPA
* Hibernate
* Flyway
* MySQL
* JWT
* JUnit
* Testcontainers
* React + TypeScript
* Docker

**Consumo estimado:**

```text
Tokens: ~380.000
Custo:  ~US$ 3,34
Custo:  ~R$ 16,99
```

---

## 📊 Resumo de consumo

| Projeto                           | Tokens estimados |           US$ |           R$ |
| --------------------------------- | ---------------: | ------------: | -----------: |
| Python FastAPI + CQRS             |         ~260.000 |      US$ 2,29 |     R$ 11,62 |
| Laravel + CQRS                    |         ~270.000 |      US$ 2,38 |     R$ 12,07 |
| .NET Vertical Slice + Minimal API |         ~280.000 |      US$ 2,46 |     R$ 12,52 |
| .NET DDD + CQRS                   |         ~320.000 |      US$ 2,82 |     R$ 14,31 |
| Java Spring + CQRS                |         ~325.000 |      US$ 2,86 |     R$ 14,53 |
| Java Hexagonal + CQRS             |         ~380.000 |      US$ 3,34 |     R$ 16,99 |
| **TOTAL**                         |   **~1.835.000** | **US$ 16,15** | **R$ 82,04** |

> Os valores são estimativas e podem variar conforme modelo de IA utilizado, quantidade de contexto, cache, quantidade de correções, builds, testes e número de interações necessárias.

---

## 🧠 Estrutura para IA

Os templates utilizam uma estrutura padronizada para orientar o agente de IA:

```text
Projeto
│
├── CRIAR-PROJETO.md
│
├── tasks
│   ├── rules
│   ├── skills
│   └── specs
│       ├── changes
│       └── archive
│
├── COPILOT.md
│
├── backend
│
├── frontend
│   ├── admin
│   └── site
│
└── docker-compose.yml
```

---

## 📋 CRIAR-PROJETO.md

Define a visão geral do projeto:

* arquitetura;
* tecnologias;
* estrutura de diretórios;
* banco de dados;
* autenticação;
* autorização;
* frontend;
* testes;
* Docker;
* padrões obrigatórios.

É o primeiro arquivo que a IA deve consultar.

---

## 📏 Rules

Diretório:

```text
tasks/rules/
```

Contém as regras obrigatórias do projeto.

Exemplos:

```text
architecture.md
domain.md
cqrs.md
backend.md
frontend.md
database.md
security.md
testing.md
docker.md
```

As Rules determinam **como o código deve ser desenvolvido**.

---

## 🛠️ Skills

Diretório:

```text
tasks/skills/
```

As Skills funcionam como receitas reutilizáveis.

Exemplos:

```text
create-entity
create-command
create-query
create-handler
create-validator
create-domain-event
create-endpoint
create-repository
create-unit-test
create-integration-test
create-crud
create-form
create-service
```

A IA deve carregar apenas as Skills necessárias para executar a Spec atual.

---

## 📝 Specs

Diretório:

```text
tasks/specs/
```

Organização:

```text
specs
├── changes
└── archive
```

### Changes

Contém tarefas que ainda precisam ser executadas:

```text
tasks/specs/changes/
```

Exemplo:

```text
001-project-foundation.md
002-user-crud.md
003-authentication.md
004-groups-permissions.md
```

### Archive

Após a implementação, build e testes serem concluídos com sucesso, a Spec pode ser movida para:

```text
tasks/specs/archive/
```

---

## 🔄 Fluxo de execução

O fluxo esperado para um agente de IA é:

```text
CRIAR-PROJETO.md
        ↓
      Rules
        ↓
       Spec
        ↓
Skills necessárias
        ↓
 Implementação
        ↓
    Migrations
        ↓
      Build
        ↓
      Tests
        ↓
   Correções
        ↓
     Validação
        ↓
  Archive Spec
```

---

## 💡 Estratégia para redução de tokens

Evitar solicitar a criação de todo o sistema em uma única execução.

Preferir Specs menores:

```text
001 - Project Foundation
002 - Domain
003 - Authentication
004 - Users CRUD
005 - Groups
006 - Permissions
007 - Admin Frontend
008 - Site Frontend
009 - Integration Tests
010 - Docker
011 - CI/CD
```

Dessa forma, o agente precisa carregar somente:

```text
CRIAR-PROJETO.md
+
Rules relevantes
+
Spec atual
+
Skills necessárias
```

em vez de analisar novamente todo o projeto a cada alteração.

---

## 🤖 Exemplo de comando para IA

```text
Execute a Spec atual deste projeto.

Antes de implementar:

1. Leia CRIAR-PROJETO.md.
2. Leia as Rules do projeto.
3. Leia a Spec solicitada.
4. Identifique as Skills necessárias.
5. Leia somente as Skills necessárias.

Implemente completamente a Spec.

Depois:

- execute migrations;
- execute build;
- execute testes unitários;
- execute testes de integração;
- execute o build dos frontends;
- corrija os erros encontrados.

Não considere a tarefa concluída enquanto houver
erro de compilação ou teste relacionado à implementação.

Somente após tudo estar validado, mova a Spec de
tasks/specs/changes para tasks/specs/archive.
```

---

## 🎯 Objetivo

O objetivo do **IA-Copilot** é permitir que diferentes stacks utilizem o mesmo conceito de desenvolvimento assistido por IA:

```text
Especificação
      +
Regras
      +
Skills
      ↓
     IA
      ↓
Implementação
      ↓
Build + Tests
      ↓
Projeto validado
```

Cada tecnologia mantém seus próprios padrões e arquitetura, enquanto o processo de desenvolvimento assistido por IA permanece padronizado.
