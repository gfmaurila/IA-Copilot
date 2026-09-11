# Spec 001 - Fundação do Projeto

## Objetivo

Criar a primeira versão funcional do projeto contendo autenticação, usuários,
grupos, permissões, banco de desenvolvimento, banco de testes e testes automatizados.

## Backend

### User

Criar CRUD completo de usuários.

Campos:

- Id
- Name
- Email
- PasswordHash
- Active
- CreatedAt
- UpdatedAt

Operações:

- Criar
- Consultar por Id
- Listar paginado
- Atualizar
- Ativar/Desativar
- Excluir

### UserGroup

Criar CRUD completo de grupos.

Campos:

- Id
- Name
- Description
- Active
- CreatedAt
- UpdatedAt

Operações:

- Criar
- Consultar
- Listar
- Atualizar
- Excluir

### Permission

Criar permissões iniciais:

```text
Users.Read
Users.Write
Groups.Read
Groups.Write
```

### Associação User x Group

Permitir:

- adicionar usuário ao grupo
- remover usuário do grupo
- consultar grupos do usuário
- consultar usuários do grupo

### Associação Group x Permission

Permitir:

- adicionar permissão ao grupo
- remover permissão do grupo
- consultar permissões do grupo

## Autenticação JWT

Criar:

- Login
- Geração de Access Token
- Refresh Token
- Validação do usuário ativo
- Claims de usuário
- Claims de grupos/permissões

## Autorização

Endpoints devem aplicar Policies.

Exemplos:

```text
Users.Read
Users.Write
Groups.Read
Groups.Write
```

## API Admin

Responsável inicialmente por:

- Auth
- Users
- Groups
- Permissions

Endpoints principais:

```text
POST   /api/auth/login
POST   /api/auth/refresh-token

GET    /api/users
GET    /api/users/{id}
POST   /api/users
PUT    /api/users/{id}
DELETE /api/users/{id}

GET    /api/groups
GET    /api/groups/{id}
POST   /api/groups
PUT    /api/groups/{id}
DELETE /api/groups/{id}

POST   /api/groups/{groupId}/users/{userId}
DELETE /api/groups/{groupId}/users/{userId}

POST   /api/groups/{groupId}/permissions/{permissionId}
DELETE /api/groups/{groupId}/permissions/{permissionId}
```

## Testes unitários

Criar testes para:

- User
- UserGroup
- Commands
- Queries
- Validators
- Permission rules
- Auth services

## Testes de integração

Cobrir:

- login válido
- login inválido
- CRUD de usuários
- CRUD de grupos
- associação usuário/grupo
- associação grupo/permissão
- autorização de leitura
- autorização de escrita
- acesso negado sem permissão

### Banco dos testes

Cada execução deve:

1. criar banco
2. aplicar migrations
3. inserir dados do cenário
4. executar testes
5. limpar recursos
6. dropar o banco ao final

Nunca apontar testes para o banco de desenvolvimento.

## Frontend Admin

Criar módulos:

```text
auth
dashboard
users
groups
settings
```

### Users

- List
- Create
- Edit
- Details
- Paginação
- Busca
- Validação

### Groups

- List
- Create
- Edit
- Details
- Aba de usuários
- Aba de permissões
- Controle Read/Write

## Frontend Site

Criar inicialmente:

- Home
- Login
- Recuperar senha
- Perfil

## Critérios de aceite

- Backend compila
- Frontend compila
- Migrations funcionam
- Docker sobe os serviços
- Banco Dev existe
- Banco Test existe
- JWT funciona
- Policies funcionam
- Testes unitários passam
- Testes de integração passam
- Banco usado pela suíte de integração é removido ao final
