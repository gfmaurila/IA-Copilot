# CRIAR-PROJETO - Laravel

## Objetivo

Criar uma solução Full Stack utilizando:

- PHP
- Laravel
- MySQL
- React + TypeScript
- API REST
- autenticação
- autorização por grupos e permissões
- testes unitários
- testes Feature
- Docker
- Rules + Skills + Specs

## Princípio arquitetural

Seguir o padrão natural do Laravel.

Não criar camadas artificiais apenas para imitar arquiteturas de outras stacks.

Utilizar os recursos nativos do framework sempre que resolverem o problema adequadamente.

Preferir:

- Eloquent Models
- Controllers finos
- Form Requests
- API Resources
- Policies / Gates
- Service Container
- Events / Listeners
- Jobs / Queues
- Actions ou Services somente quando houver regra de aplicação reutilizável
- Migrations
- Seeders
- Factories
- Feature Tests

## Estrutura principal

```text
MeuProjeto
│
├── backend
│   ├── app
│   │   ├── Actions
│   │   ├── Enums
│   │   ├── Events
│   │   ├── Http
│   │   │   ├── Controllers
│   │   │   │   ├── Admin
│   │   │   │   └── Site
│   │   │   ├── Requests
│   │   │   └── Resources
│   │   ├── Jobs
│   │   ├── Listeners
│   │   ├── Models
│   │   ├── Policies
│   │   └── Services
│   │
│   ├── database
│   │   ├── factories
│   │   ├── migrations
│   │   └── seeders
│   │
│   ├── routes
│   │   ├── api.php
│   │   ├── admin.php
│   │   └── site.php
│   │
│   └── tests
│       ├── Unit
│       └── Feature
│           ├── Admin
│           └── Site
│
├── frontend
│   ├── admin
│   └── site
│
├── docs
├── tasks
│   ├── rules
│   ├── skills
│   └── specs
│
├── docker-compose.yml
├── .env.example
├── README.md
├── COPILOT.md
└── CRIAR-PROJETO.md
```

## Funcionalidades iniciais

1. CRUD de usuários
2. CRUD de grupos
3. permissões de leitura e escrita
4. vínculo usuário x grupo
5. autenticação
6. autorização
7. testes Unit
8. testes Feature
9. banco Development
10. banco Test
11. React Admin
12. React Site

## Autenticação

Usar autenticação padrão compatível com API Laravel.

Preferir Laravel Sanctum para autenticação SPA/API quando aplicável.

Usar JWT somente se a Spec exigir explicitamente JWT.

## Autorização

Usar Policies e Gates.

Exemplos de permissões:

```text
users.read
users.write
groups.read
groups.write
```

Não validar autorização manualmente em múltiplos Controllers se Policy/Gate puder resolver.

## Banco de dados

Criar através de migrations.

Nunca editar estrutura de banco manualmente como regra principal.

Toda mudança estrutural deve possuir migration.

## Testes

### Unit

Usar para:

- classes puras
- Actions
- Services
- regras isoladas

### Feature

Usar para:

- endpoints
- autenticação
- autorização
- banco
- CRUD
- Policies
- integração entre componentes Laravel

Os testes devem usar ambiente `testing`.

Nunca utilizar o banco Development nos testes.

## Docker

O arquivo `docker-compose.yml` do template deve permanecer vazio.

Ele deverá ser gerado durante a execução da Spec.

Na primeira implementação, gerar:

- frontend-admin
- frontend-site
- api
- database

Topologia:

```text
frontend-admin -> api
frontend-site  -> api
api            -> database
```

Se a arquitetura exigir APIs separadas para Admin e Site, a Spec poderá criar:

```text
frontend-admin -> api-admin
frontend-site  -> api-site
```

Por padrão, Laravel utiliza uma API única com rotas, middleware e autorização separadas.

## Regra para IA

Antes de implementar:

1. Ler `CRIAR-PROJETO.md`.
2. Ler `AGENTS.md`.
3. Ler `orchestration/workflows/PROJECT_CREATION.md`.
4. Ler `tasks/rules/`.
5. Ler a Spec atual.
6. Gerar `REQUIREMENTS.md`.
7. Gerar `ARCHITECTURE_PLAN.md`.
8. Gerar `EXECUTION_PLAN.md`.
9. Identificar Skills necessárias por tarefa.
10. Ler somente as Skills necessárias.
11. Implementar seguindo Laravel + MySQL.
12. Executar migrations no ambiente adequado.
13. Executar testes.
14. Executar build do frontend.
15. Executar revisão e Quality Gates.
16. Corrigir erros até os gates passarem.
17. Arquivar a Spec somente após validação.
