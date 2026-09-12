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
│   ├── ContactTypeConfiguration.cs
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

### Dados iniciais e dados fake via migrations

A fundação deve gerar dados iniciais utilizando migrations do Entity Framework Core.

Separar em duas categorias:

#### 1. Dados estruturais/catálogos

Podem fazer parte de `InitialCreate` ou de uma migration específica de catálogo, com IDs determinísticos.

Criar, no mínimo:

- tipos de contato (`CONTACT_TYPE`);
- resources principais;
- permissions principais;
- roles padrão;
- vínculos `ROLE_PERMISSION` necessários ao ambiente inicial.

#### 2. Dados fake de desenvolvimento

Criar uma migration separada chamada:

```text
DevelopmentSeed
```

Essa migration deve inserir dados falsos coerentes para demonstrar todos os relacionamentos da fundação.

Gerar no mínimo:

```text
2 ORGANIZATION
4 USER_GROUP
10 PERSON
15+ PERSON_DOCUMENT
6 CONTACT_TYPE
25+ PERSON_CONTACT
12+ ADDRESS
10 USER_ACCOUNT
4 ROLE
8+ RESOURCE
20+ PERMISSION
15+ USER_ROLE
25+ ROLE_PERMISSION
10 USER_PREFERENCE
10+ LOGIN_ATTEMPT
10+ AUDIT_LOG
```

Também pode inserir `REFRESH_TOKEN` e `USER_TOKEN` **somente com hashes fictícios, expirados ou claramente inválidos**, nunca secrets/tokens reais.

Regras obrigatórias do seed:

- usar IDs determinísticos para permitir `Down()` seguro;
- não utilizar dados pessoais reais;
- usar nomes/e-mails/telefones fictícios;
- manter FKs válidas;
- criar pelo menos uma pessoa com múltiplos contatos;
- criar pelo menos uma pessoa com dois contatos do mesmo tipo;
- criar pelo menos uma pessoa com múltiplos documentos;
- criar pelo menos uma pessoa com múltiplos endereços;
- criar usuários distribuídos entre diferentes groups e roles;
- criar exemplo de role `ADMIN` com permissões amplas;
- criar role comum com permissões restritas;
- incluir `Down()` removendo os dados na ordem correta de dependência.

A migration `DevelopmentSeed` é destinada ao ambiente de desenvolvimento/demo. O processo de deploy de produção **não deve aplicar dados fake**.

Comandos esperados:

```bash
dotnet ef migrations add InitialCreate \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext \
  --output-dir Persistence/Migrations

dotnet ef migrations add DevelopmentSeed \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext \
  --output-dir Persistence/Migrations
```

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


## CRUDs obrigatórios da Fundação

A Spec `001-project-foundation.md` deve entregar uma primeira versão **funcional e administrável** do cadastro de pessoas, usuários, organização, segurança e autorização.

Os CRUDs abaixo fazem parte da primeira etapa e **não devem ser postergados para outra Spec**.

### Entidades com CRUD completo

Implementar CRUD completo (Create, GetById, GetPaged/List, Update e Delete/SoftDelete quando aplicável) para:

```text
ORGANIZATION
USER_GROUP
PERSON
PERSON_DOCUMENT
CONTACT_TYPE
PERSON_CONTACT
ADDRESS
USER_ACCOUNT
ROLE
RESOURCE
PERMISSION
USER_PREFERENCE
```

Para todas as listagens administrativas, implementar:

- paginação;
- busca textual quando aplicável;
- ordenação;
- filtro por `STATUS`;
- filtro por entidade pai quando aplicável;
- validação com FluentValidation;
- retorno padronizado;
- tratamento de `NotFound`, `Conflict` e erros de validação;
- soft delete para tabelas que possuem `DELETED_AT`;
- testes unitários e de integração.

### Entidades de associação

As tabelas associativas devem possuir comandos/endpoints próprios de gerenciamento de relacionamento, sem necessidade de um CRUD genérico de tela:

```text
USER_ROLE
ROLE_PERMISSION
```

Operações mínimas:

#### USER_ROLE

- atribuir role ao usuário;
- atualizar expiração da atribuição;
- remover role do usuário;
- listar roles do usuário;
- listar usuários de uma role.

#### ROLE_PERMISSION

- adicionar permission à role;
- permitir/negar via `IS_ALLOWED`;
- remover permission da role;
- listar permissions da role;
- listar roles que possuem determinada permission.

### Entidades de segurança e histórico

As tabelas abaixo não devem expor CRUD administrativo irrestrito. Implementar apenas as operações coerentes com segurança e auditoria:

```text
REFRESH_TOKEN
USER_TOKEN
LOGIN_ATTEMPT
AUDIT_LOG
```

#### REFRESH_TOKEN

- criar via fluxo de autenticação;
- consultar sessões/tokens ativos do próprio usuário ou por administrador autorizado;
- revogar token;
- revogar todos os tokens de um usuário;
- executar rotação de refresh token.

Nunca permitir edição manual de `TOKEN_HASH`.

#### USER_TOKEN

- criar via fluxos de ativação, recuperação e verificação;
- validar token;
- marcar token como utilizado;
- invalidar tokens expirados/anteriores.

Nunca permitir edição manual de `TOKEN_HASH`.

#### LOGIN_ATTEMPT

- inserir automaticamente em toda tentativa de login;
- listar paginado para auditoria administrativa;
- filtrar por usuário, IP, sucesso/falha e período;
- consultar detalhes;
- não permitir update/delete por CRUD comum.

#### AUDIT_LOG

- inserir automaticamente pela aplicação;
- listar paginado;
- consultar detalhes;
- filtrar por usuário, entidade, ação, `CORRELATION_ID` e período;
- não permitir update/delete por CRUD comum.

## CONTACT_TYPE e PERSON_CONTACT

Criar catálogo de tipos de contato separado do contato da pessoa.

Relacionamentos:

```text
PERSON 1 -------- N PERSON_CONTACT
CONTACT_TYPE 1 -- N PERSON_CONTACT
```

### CONTACT_TYPE

Campos mínimos:

```text
ID
CODE
NAME
DESCRIPTION
VALIDATION_PATTERN
MAX_LENGTH
IS_SYSTEM
STATUS
CREATED_AT
UPDATED_AT
DELETED_AT
```

Valores iniciais obrigatórios:

```text
PHONE
MOBILE
EMAIL
WHATSAPP
TELEGRAM
OTHER
```

### PERSON_CONTACT

Campos mínimos:

```text
ID
PERSON_ID
CONTACT_TYPE_ID
CONTACT_VALUE
LABEL
IS_PRIMARY
IS_VERIFIED
VERIFIED_AT
STATUS
CREATED_AT
UPDATED_AT
DELETED_AT
```

Regras:

- uma `PERSON` pode possuir **N contatos**;
- um tipo de contato pode ser usado por N pessoas;
- uma pessoa pode ter mais de um contato do mesmo tipo;
- permitir, por exemplo, dois telefones, dois e-mails e vários números de WhatsApp;
- `CONTACT_VALUE` deve ser validado conforme o `CONTACT_TYPE`;
- deve existir no máximo um contato primário por pessoa/tipo, salvo decisão explícita do domínio;
- excluir contato via soft delete;
- contatos de e-mail/telefone podem possuir fluxo de verificação.

## Cadastro Completo de Usuário em Etapas (Wizard)

Além dos CRUDs individuais, criar um fluxo transacional/orquestrado de **cadastro completo de usuário em etapas**, utilizado pelo Frontend Admin.

O wizard deve permitir salvar progresso e somente concluir o cadastro quando as etapas obrigatórias estiverem válidas.

### Etapa 1 - Person

Cadastrar dados pessoais:

```text
FIRST_NAME
MIDDLE_NAME
LAST_NAME
PREFERRED_NAME
BIRTH_DATE
GENDER
MARITAL_STATUS
NATIONALITY
AVATAR_URL
```

Resultado: criar/atualizar `PERSON`.

### Etapa 2 - Documents

Permitir cadastrar **N documentos**:

```text
DOCUMENT_TYPE
DOCUMENT_NUMBER
ISSUER
ISSUING_STATE
ISSUE_DATE
EXPIRATION_DATE
COUNTRY_CODE
IS_PRIMARY
```

Resultado: criar/atualizar registros em `PERSON_DOCUMENT`.

### Etapa 3 - Contacts

Permitir cadastrar **N formas de contato** usando `CONTACT_TYPE`:

Exemplos:

```text
EMAIL     -> user@example.com
MOBILE    -> +55 51 99999-9999
WHATSAPP  -> +55 51 99999-9999
PHONE     -> +55 51 3333-3333
```

Resultado: criar/atualizar registros em `PERSON_CONTACT`.

### Etapa 4 - Addresses

Permitir cadastrar **N endereços**:

```text
HOME
WORK
BILLING
SHIPPING
OTHER
```

Resultado: criar/atualizar `ADDRESS`.

### Etapa 5 - Account

Criar dados de acesso:

```text
GROUP_ID
USERNAME
EMAIL
PASSWORD
MUST_CHANGE_PASSWORD
TWO_FACTOR_ENABLED
STATUS
```

O comando recebe `PASSWORD`, mas somente `PASSWORD_HASH` pode ser persistido.

Resultado: criar/atualizar `USER_ACCOUNT` ligado à `PERSON` criada na etapa 1.

### Etapa 6 - Roles and Permissions

Permitir selecionar uma ou mais roles.

Resultado:

```text
USER_ROLE
```

As permissões efetivas devem ser derivadas de:

```text
ROLE -> ROLE_PERMISSION -> PERMISSION -> RESOURCE
```

### Etapa 7 - Preferences

Cadastrar preferências:

```text
ALLOW_EMAIL
ALLOW_SMS
ALLOW_WHATSAPP
ALLOW_PUSH
LANGUAGE
TIME_ZONE
THEME
DATE_FORMAT
```

Resultado: criar/atualizar `USER_PREFERENCE`.

### Etapa 8 - Review and Finish

Exibir resumo de:

- pessoa;
- documentos;
- contatos;
- endereços;
- conta;
- roles;
- preferências.

Ao confirmar:

1. validar todas as regras;
2. executar a conclusão de forma transacional;
3. ativar o cadastro conforme regra de negócio;
4. gerar `AUDIT_LOG` da criação;
5. retornar o `USER_ACCOUNT.ID` e `PERSON.ID`.

### Persistência do progresso

O backend pode implementar o wizard de duas formas:

1. salvar cada entidade a cada etapa usando os CRUDs existentes; ou
2. utilizar um draft/orquestrador de cadastro.

Para esta fundação, priorizar reutilizar Commands/Queries dos CRUDs e manter consistência transacional na finalização.

### Endpoints do wizard

Criar, no mínimo:

```text
POST /api/user-registration
GET  /api/user-registration/{personId}
PUT  /api/user-registration/{personId}/person
PUT  /api/user-registration/{personId}/documents
PUT  /api/user-registration/{personId}/contacts
PUT  /api/user-registration/{personId}/addresses
PUT  /api/user-registration/{personId}/account
PUT  /api/user-registration/{personId}/roles
PUT  /api/user-registration/{personId}/preferences
POST /api/user-registration/{personId}/complete
```

A implementação pode adaptar os nomes conforme o padrão de Minimal API/Vertical Slice adotado no projeto, mantendo as mesmas capacidades.

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

A API Admin deve expor todos os recursos da fundação.

### Auth

```text
POST   /api/auth/login
POST   /api/auth/refresh-token
POST   /api/auth/logout
POST   /api/auth/forgot-password
POST   /api/auth/reset-password
POST   /api/auth/verify-email
```

### Organizations

```text
GET    /api/organizations
GET    /api/organizations/{id}
POST   /api/organizations
PUT    /api/organizations/{id}
DELETE /api/organizations/{id}
```

### Groups

```text
GET    /api/groups
GET    /api/groups/{id}
POST   /api/groups
PUT    /api/groups/{id}
DELETE /api/groups/{id}
```

### Persons

```text
GET    /api/persons
GET    /api/persons/{id}
POST   /api/persons
PUT    /api/persons/{id}
DELETE /api/persons/{id}
```

### Person Documents

```text
GET    /api/persons/{personId}/documents
GET    /api/person-documents/{id}
POST   /api/persons/{personId}/documents
PUT    /api/person-documents/{id}
DELETE /api/person-documents/{id}
```

### Contact Types

```text
GET    /api/contact-types
GET    /api/contact-types/{id}
POST   /api/contact-types
PUT    /api/contact-types/{id}
DELETE /api/contact-types/{id}
```

### Person Contacts

```text
GET    /api/persons/{personId}/contacts
GET    /api/person-contacts/{id}
POST   /api/persons/{personId}/contacts
PUT    /api/person-contacts/{id}
DELETE /api/person-contacts/{id}
```

### Addresses

```text
GET    /api/persons/{personId}/addresses
GET    /api/addresses/{id}
POST   /api/persons/{personId}/addresses
PUT    /api/addresses/{id}
DELETE /api/addresses/{id}
```

### User Accounts

```text
GET    /api/users
GET    /api/users/{id}
POST   /api/users
PUT    /api/users/{id}
DELETE /api/users/{id}
PATCH  /api/users/{id}/status
POST   /api/users/{id}/change-password
POST   /api/users/{id}/unlock
```

### Roles

```text
GET    /api/roles
GET    /api/roles/{id}
POST   /api/roles
PUT    /api/roles/{id}
DELETE /api/roles/{id}
```

### Resources

```text
GET    /api/resources
GET    /api/resources/{id}
POST   /api/resources
PUT    /api/resources/{id}
DELETE /api/resources/{id}
```

### Permissions

```text
GET    /api/permissions
GET    /api/permissions/{id}
POST   /api/permissions
PUT    /api/permissions/{id}
DELETE /api/permissions/{id}
```

### User Roles

```text
GET    /api/users/{userId}/roles
POST   /api/users/{userId}/roles/{roleId}
PUT    /api/users/{userId}/roles/{roleId}
DELETE /api/users/{userId}/roles/{roleId}
GET    /api/roles/{roleId}/users
```

### Role Permissions

```text
GET    /api/roles/{roleId}/permissions
POST   /api/roles/{roleId}/permissions/{permissionId}
PUT    /api/roles/{roleId}/permissions/{permissionId}
DELETE /api/roles/{roleId}/permissions/{permissionId}
```

### User Preferences

```text
GET    /api/users/{userId}/preferences
POST   /api/users/{userId}/preferences
PUT    /api/users/{userId}/preferences
```

### Sessions / Refresh Tokens

```text
GET    /api/users/{userId}/sessions
DELETE /api/users/{userId}/sessions/{tokenId}
DELETE /api/users/{userId}/sessions
```

### Login Attempts

```text
GET    /api/login-attempts
GET    /api/login-attempts/{id}
```

### Audit Logs

```text
GET    /api/audit-logs
GET    /api/audit-logs/{id}
```

### Complete User Registration Wizard

```text
POST   /api/user-registration
GET    /api/user-registration/{personId}
PUT    /api/user-registration/{personId}/person
PUT    /api/user-registration/{personId}/documents
PUT    /api/user-registration/{personId}/contacts
PUT    /api/user-registration/{personId}/addresses
PUT    /api/user-registration/{personId}/account
PUT    /api/user-registration/{personId}/roles
PUT    /api/user-registration/{personId}/preferences
POST   /api/user-registration/{personId}/complete
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
- CRUD de todas as entidades administrativas da fundação
- múltiplos documentos por pessoa
- múltiplos contatos por pessoa e por tipo
- múltiplos endereços por pessoa
- associação usuário/role
- associação role/permissão
- fluxo completo do user registration wizard
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

Criar módulos administrativos para todos os CRUDs da fundação:

```text
auth
dashboard
organizations
groups
persons
person-documents
contact-types
person-contacts
addresses
users
roles
resources
permissions
user-preferences
security
login-attempts
audit-logs
user-registration
settings
```

Cada CRUD administrativo deve conter, conforme aplicável:

```text
List
Create
Edit
Details
Delete/Deactivate confirmation
Pagination
Search
Filters
Validation
Loading state
Empty state
Error state
```

### User Registration Wizard

Criar interface em etapas com indicador visual de progresso:

```text
1. Personal Data
2. Documents
3. Contacts
4. Addresses
5. Account
6. Roles
7. Preferences
8. Review & Finish
```

Requisitos do wizard:

- botões `Previous`, `Next`, `Save Draft` e `Finish`;
- não perder os dados ao navegar entre etapas;
- permitir múltiplos documentos;
- permitir múltiplos contatos com botão `Add Contact`;
- permitir múltiplos endereços;
- seleção de `CONTACT_TYPE` carregada da API;
- seleção de roles;
- validação por etapa com Zod;
- resumo final antes da conclusão;
- exibir erros do backend por campo quando disponíveis;
- após sucesso, redirecionar para `User Details`.

### Contacts UI

Na etapa Contacts e no CRUD de contatos, permitir adicionar dinamicamente itens como:

```text
Type: EMAIL      Value: fake.user@example.com
Type: MOBILE     Value: +55 51 99999-1111
Type: WHATSAPP   Value: +55 51 98888-2222
Type: PHONE      Value: +55 51 3333-4444
```

Uma mesma pessoa pode possuir quantos contatos forem necessários.

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
- Migration `DevelopmentSeed` insere dados fake consistentes
- Todos os CRUDs da fundação funcionam
- Cadastro completo em etapas funciona até `complete`
- Uma pessoa aceita N contatos e N contatos do mesmo tipo
- Docker sobe os serviços
- Banco Dev existe
- Banco Test existe
- JWT funciona
- Policies funcionam
- Testes unitários passam
- Testes de integração passam
- Banco usado pela suíte de integração é removido ao final
