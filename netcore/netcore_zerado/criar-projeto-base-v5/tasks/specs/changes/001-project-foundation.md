# Spec 001 - Fundação do Projeto

## Objetivo

Criar a primeira versão funcional do projeto contendo autenticação, usuários,
grupos, permissões, banco de desenvolvimento, banco de testes e testes automatizados.

## Backend

## Entity Framework Core e Migration Inicial

A fundação do backend deve configurar a persistência **antes da implementação de CQRS, JWT e endpoints**.

Criar no projeto `MeuProjeto.Infrastructure`:

```text
Persistence/
├── ApplicationDbContext.cs
├── Configurations/
│   ├── OrganizationConfiguration.cs
│   ├── UserGroupConfiguration.cs
│   ├── PersonConfiguration.cs
│   ├── UserAccountConfiguration.cs
│   ├── PersonDocumentConfiguration.cs
│   ├── PersonContactConfiguration.cs
│   ├── AddressConfiguration.cs
│   ├── RoleConfiguration.cs
│   ├── ResourceConfiguration.cs
│   ├── PermissionConfiguration.cs
│   ├── UserRoleConfiguration.cs
│   ├── RolePermissionConfiguration.cs
│   ├── RefreshTokenConfiguration.cs
│   ├── UserTokenConfiguration.cs
│   ├── UserPreferenceConfiguration.cs
│   ├── LoginAttemptConfiguration.cs
│   └── AuditLogConfiguration.cs
└── Migrations/
```

Usar os campos, relacionamentos, índices e constraints definidos em:

```text
tasks/specs/changes/TASK_USER_PERSON_DATA_MODEL.md
```

A modelagem desse documento substitui o modelo simplificado de `User`, `UserGroup` e `Permission` quando houver conflito de nomes ou estrutura.

### Pacotes mínimos

```text
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
```

### Migration inicial obrigatória

Após criar as entidades persistentes, `ApplicationDbContext` e configurations, criar:

```text
InitialCreate
```

Exemplo:

```bash
dotnet ef migrations add InitialCreate \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext \
  --output-dir Persistence/Migrations
```

Os caminhos devem ser adaptados aos nomes reais da solution.

Antes de continuar a implementação, executar:

```bash
dotnet ef migrations script \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext
```

A criação da migration deve ocorrer sem erro.

### Aplicação das migrations

Development:

```bash
dotnet ef database update \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext
```

Testes de integração devem criar o banco de teste e chamar `Database.MigrateAsync()` ou executar o equivalente via EF Core antes da suíte.

Não usar `Database.EnsureCreated()` para substituir migrations.


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

## Docker

Durante a execução desta Spec:

1. Preencher o `docker-compose.yml`, que inicialmente estará vazio.
2. Criar os serviços:
   - `frontend-admin`
   - `frontend-site`
   - `api-admin`
   - `api-site`
   - `sqlserver`
3. Configurar os vínculos:
   - `frontend-admin` -> `api-admin`
   - `frontend-site` -> `api-site`
   - `api-admin` -> `sqlserver`
   - `api-site` -> `sqlserver`
4. Configurar as URLs das APIs nos frontends através de variáveis de ambiente.
5. Configurar connection strings das APIs através de variáveis de ambiente.
6. Garantir que todos os containers usem a mesma rede Docker do projeto.
7. Criar os bancos `MeuProjeto_Dev` e `MeuProjeto_Test`.
8. Gerar a senha do usuário `sa` usando a data atual no padrão:

```text
Gfm@d{dia}m{mes}a{ano}
```

Exemplo:

```text
11/09/2026 -> Gfm@d11m09a2026
```

9. Aplicar a mesma senha às configurações e connection strings geradas.
10. Não deixar senha fixa previamente cadastrada no template.
11. Garantir que comunicação entre containers utilize o nome dos serviços Docker, e não `localhost`.
12. Validar que:
    - Admin chama apenas a API Admin;
    - Site chama apenas a API Site;
    - ambas as APIs acessam o SQL Server.

## Critérios de aceite

- Backend compila
- Frontend compila
- Migration `InitialCreate` é criada no início da fundação e compila
- `dotnet ef migrations script` funciona
- Migrations funcionam
- Docker sobe os serviços
- Banco Dev existe
- Banco Test existe
- JWT funciona
- Policies funcionam
- Testes unitários passam
- Testes de integração passam
- Banco usado pela suíte de integração é removido ao final
