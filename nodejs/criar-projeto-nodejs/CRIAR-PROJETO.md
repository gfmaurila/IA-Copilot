# CRIAR-PROJETO - Node.js

## Objetivo

Criar uma solução Full Stack utilizando:

- Node.js
- TypeScript
- Fastify
- MySQL
- Prisma ORM
- React + TypeScript
- API REST
- autenticação
- autorização por grupos e permissões
- testes unitários
- testes de integração
- Docker
- Rules + Skills + Specs

## Princípio arquitetural

Seguir padrões naturais do ecossistema Node.js.

Não copiar mecanicamente estruturas de C# ou Java.

Preferir:

- Fastify
- TypeScript
- módulos por domínio/feature
- controllers/routes finos
- services para regras de aplicação
- repositories quando houver acesso a banco
- Prisma para persistência
- Zod para validação
- middlewares/hooks para autenticação e autorização
- testes com Vitest
- Supertest ou inject do Fastify para integração

## Estrutura principal

```text
MeuProjeto
│
├── backend
│   ├── src
│   │   ├── config
│   │   ├── controllers
│   │   │   ├── admin
│   │   │   └── site
│   │   ├── database
│   │   │   ├── migrations
│   │   │   ├── seeders
│   │   │   └── factories
│   │   ├── middlewares
│   │   ├── modules
│   │   │   ├── auth
│   │   │   ├── users
│   │   │   ├── groups
│   │   │   └── permissions
│   │   ├── repositories
│   │   ├── routes
│   │   ├── schemas
│   │   ├── services
│   │   ├── types
│   │   └── utils
│   │
│   └── tests
│       ├── unit
│       └── integration
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
5. vínculo grupo x permissão
6. autenticação JWT
7. autorização
8. testes Unit
9. testes Integration
10. MySQL Development
11. MySQL Test
12. React Admin
13. React Site

## Autenticação

Usar JWT.

Criar:

```text
POST /api/auth/login
POST /api/auth/refresh
GET  /api/auth/me
POST /api/auth/logout
```

Senhas devem usar hash seguro, preferencialmente Argon2 ou bcrypt.

Nunca armazenar senha em texto puro.

## Autorização

Usar permissões por código.

Exemplos:

```text
users.read
users.write
groups.read
groups.write
```

Usuários herdam permissões através dos grupos.

A autorização deve ser centralizada em middleware/hook.

## Banco de dados

Usar MySQL.

Usar Prisma ORM como padrão.

Toda mudança estrutural deve estar refletida em migration.

## Testes

### Unit

Usar para:

- services
- regras
- utils
- validações
- autorização isolada

### Integration

Usar para:

- endpoints
- autenticação
- autorização
- banco
- CRUD
- relacionamentos

Nunca utilizar o banco Development nos testes.

## Docker

O arquivo `docker-compose.yml` do template deve permanecer vazio.

Gerar durante a execução da Spec.

Serviços iniciais:

```text
frontend-admin
frontend-site
api
mysql
```

Topologia:

```text
frontend-admin -> api
frontend-site  -> api
api            -> mysql
```

Bancos:

```text
meuprojeto_dev
meuprojeto_test
```

## Regra para IA

Antes de implementar:

1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules/`.
3. Ler a Spec atual.
4. Identificar Skills necessárias.
5. Ler somente as Skills necessárias.
6. Implementar seguindo Node.js/TypeScript.
7. Executar migrations.
8. Executar testes.
9. Executar build backend.
10. Executar build frontend.
11. Corrigir erros.
12. Arquivar a Spec somente após validação.
