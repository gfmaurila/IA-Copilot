# Spec 001 - Fundação Node.js

## Objetivo

Criar a fundação funcional do projeto utilizando Node.js, TypeScript, Fastify, Prisma e MySQL.

## Usuários

Criar CRUD com:

- id
- name
- email
- passwordHash
- active
- createdAt
- updatedAt

Criar:

- schema Prisma
- repository
- service
- controller
- routes
- schemas Zod
- testes unitários
- testes de integração

## Grupos

Criar CRUD com:

- id
- name
- description
- active
- createdAt
- updatedAt

## Permissões

Criar permissões iniciais:

```text
users.read
users.write
groups.read
groups.write
```

Criar relacionamentos:

```text
users <-> groups
groups <-> permissions
```

## Autenticação JWT

Criar:

```text
POST /api/auth/login
POST /api/auth/refresh
GET  /api/auth/me
POST /api/auth/logout
```

## Autorização

Criar middleware/hook centralizado para permissões.

Exemplos:

```text
users.read
users.write
groups.read
groups.write
```

## Rotas Admin

Exemplo:

```text
/api/admin/users
/api/admin/groups
```

## Rotas Site

Exemplo:

```text
/api/site/profile
```

## Testes Integration

Cobrir:

- login válido
- login inválido
- refresh
- usuário não autenticado
- CRUD usuários
- CRUD grupos
- autorização leitura
- autorização escrita
- acesso negado
- vínculo usuário x grupo
- vínculo grupo x permissão

## Banco de teste

Criar banco separado:

```text
meuprojeto_test
```

Durante os testes:

1. usar `DATABASE_URL_TEST`
2. aplicar migrations
3. popular cenário necessário
4. executar testes
5. limpar dados
6. nunca usar `meuprojeto_dev`

## Frontend Admin

Criar módulos:

```text
auth
dashboard
users
groups
settings
```

## Frontend Site

Criar:

```text
home
auth
profile
```

## Critérios de aceite

- backend compila
- migrations funcionam
- seed funciona
- autenticação funciona
- permissões funcionam
- testes unitários passam
- testes de integração passam
- frontend admin compila
- frontend site compila
- Docker gerado e validado
