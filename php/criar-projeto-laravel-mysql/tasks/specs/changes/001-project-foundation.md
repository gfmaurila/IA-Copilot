# Spec 001 - Fundação Laravel

## Objetivo

Criar a fundação funcional do projeto utilizando padrões Laravel.

## Usuários

Criar CRUD com:

- id
- name
- email
- password
- active
- timestamps

Criar:

- Model
- Migration
- Factory
- Seeder
- Form Requests
- Resource
- Controller
- Policy
- Feature Tests

## Grupos

Criar CRUD com:

- id
- name
- description
- active
- timestamps

Criar:

- Model
- Migration
- Factory
- Seeder
- Form Requests
- Resource
- Controller
- Policy
- Feature Tests

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

## Autenticação

Preferir Laravel Sanctum.

Criar:

```text
POST /api/login
POST /api/logout
GET  /api/me
```

Caso a implementação use token de API, manter padrão Laravel.

Não implementar JWT customizado se não houver necessidade.

## Autorização

Usar Policies/Gates.

Exemplos:

```text
users.read
users.write
groups.read
groups.write
```

## Rotas Admin

Separar rotas administrativas em arquivo próprio ou grupo de rotas.

Exemplo:

```text
/api/admin/users
/api/admin/groups
```

## Rotas Site

Separar rotas de site.

Exemplo:

```text
/api/site/profile
```

## Testes Feature

Cobrir:

- login válido
- login inválido
- logout
- usuário não autenticado
- CRUD usuários
- CRUD grupos
- autorização leitura
- autorização escrita
- acesso negado
- vínculo usuário x grupo
- vínculo grupo x permissão

## Banco de teste

O ambiente de testes deve utilizar banco separado.

Durante a execução:

- usar `.env.testing`
- aplicar migrations
- usar RefreshDatabase quando adequado
- popular dados com Factories
- nunca usar Development

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

- Laravel sobe sem erros
- migrations funcionam
- seeders funcionam
- autenticação funciona
- Policies funcionam
- testes passam
- frontend admin compila
- frontend site compila
- Docker gerado e validado
