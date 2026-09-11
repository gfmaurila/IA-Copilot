# CRIAR-PROJETO

## Objetivo

Criar uma solução Full Stack com:

- Backend C# / ASP.NET Core
- Frontend React + TypeScript
- DDD
- CQRS
- Domain Events
- JWT
- Autorização por grupo/permissão
- SQL Server
- Testes unitários
- Testes de integração
- Docker

## Aplicações

### Backend

- MeuProjeto.API.Admin
- MeuProjeto.API.Site
- MeuProjeto.Application
- MeuProjeto.Domain
- MeuProjeto.Infrastructure
- MeuProjeto.CrossCutting

### Frontend

- frontend/admin
- frontend/site

## Funcionalidades iniciais obrigatórias

1. CRUD de usuários
2. CRUD de grupos de usuários
3. Associação de usuários a grupos
4. Permissões por grupo
5. Permissões de leitura e escrita
6. Autenticação JWT
7. Refresh Token
8. Testes unitários
9. Testes de integração
10. SQL Server Development via Docker
11. SQL Server Test via Docker

## Modelo inicial de autorização

Cada usuário poderá pertencer a um ou mais grupos.

Cada grupo poderá possuir permissões.

Exemplo:

```text
Admin
├── Users.Read
├── Users.Write
├── Groups.Read
└── Groups.Write

Reader
├── Users.Read
└── Groups.Read
```

A autorização deverá utilizar Policies do ASP.NET Core.

Exemplo:

```text
[Authorize(Policy = "Users.Read")]
[Authorize(Policy = "Users.Write")]
```

## Entidades iniciais

### User

- Id
- Name
- Email
- PasswordHash
- Active
- CreatedAt
- UpdatedAt

### UserGroup

- Id
- Name
- Description
- Active
- CreatedAt
- UpdatedAt

### Permission

- Id
- Code
- Description

### UserUserGroup

Relacionamento N:N entre User e UserGroup.

### UserGroupPermission

Relacionamento N:N entre UserGroup e Permission.

## Autenticação

Endpoints esperados:

```text
POST /api/auth/login
POST /api/auth/refresh-token
POST /api/auth/forgot-password
POST /api/auth/reset-password
```

JWT deve conter Claims necessárias para identificação do usuário e autorização.

Nunca armazenar senha em texto puro.

## Testes de integração

Os testes de integração devem:

1. Subir ou conectar ao SQL Server de testes.
2. Criar um banco exclusivo de teste.
3. Aplicar migrations.
4. Inserir os dados necessários para o cenário.
5. Executar o teste.
6. Limpar os dados.
7. Excluir o banco de teste ao final da suíte.

O banco de desenvolvimento nunca poderá ser usado por testes automatizados.

## Docker

O arquivo `docker-compose.yml` presente no template deve permanecer vazio.

Ele NÃO deve conter serviços previamente definidos.

O conteúdo do Docker Compose deve ser gerado somente no momento da execução da Spec,
de acordo com os serviços realmente necessários pelo projeto.

Na criação inicial, o Docker Compose deverá gerar o ambiente necessário para:

- API Admin
- API Site
- Frontend Admin
- Frontend Site
- SQL Server

Os vínculos obrigatórios são:

```text
Frontend Admin -> API Admin -> SQL Server
Frontend Site  -> API Site  -> SQL Server
```

Cada frontend deve receber a URL da sua API correspondente através de variável de ambiente.

Exemplo conceitual:

```text
frontend-admin -> VITE_API_URL -> api-admin
frontend-site  -> VITE_API_URL -> api-site
```

Os containers devem se comunicar internamente usando o nome dos serviços Docker.

O SQL Server deverá possuir dois bancos:

```text
MeuProjeto_Dev
MeuProjeto_Test
```

As aplicações normais usam apenas:

```text
MeuProjeto_Dev
```

Os testes de integração usam apenas:

```text
MeuProjeto_Test
```

### Senha do SQL Server

A senha do usuário `sa` deverá ser gerada automaticamente no momento da criação
do Docker Compose.

Formato obrigatório:

```text
Gfm@d{dia}m{mes}a{ano}
```

Onde:

- `{dia}` = dia atual com 2 dígitos
- `{mes}` = mês atual com 2 dígitos
- `{ano}` = ano atual com 4 dígitos

Exemplo para 11/09/2026:

```text
Gfm@d11m09a2026
```

A mesma senha deverá ser utilizada de forma consistente nas variáveis de ambiente
e connection strings geradas para aquele ambiente.

Não salvar senha fixa diretamente no código-fonte.

## Ordem inicial de criação

1. Solution e projetos .NET
2. Domain base
3. User
4. UserGroup
5. Permission
6. Relacionamentos
7. Repositories
8. EF Core / SQL Server
9. Migrations
10. CQRS
11. JWT
12. Authorization Policies
13. API Admin
14. API Site
15. Testes unitários
16. Testes de integração
17. React Admin
18. React Site
19. Gerar docker-compose.yml no momento da execução
20. Gerar senha SQL Server conforme a data atual
21. Build
22. Tests

## Regra para IA

Antes de implementar:

1. Ler CRIAR-PROJETO.md
2. Ler tasks/rules
3. Ler a Spec atual
4. Ler somente as Skills necessárias
5. Implementar
6. Executar build
7. Executar testes
8. Corrigir erros
9. Arquivar a Spec quando finalizada
