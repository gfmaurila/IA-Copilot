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
- Entity Framework Core
- Migrations EF Core desde a fundação do backend
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
- Entity Framework Core
- Migrations EF Core desde a fundação do backend

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

## Persistência e migrations obrigatórias

A persistência deve ser criada na fundação do backend usando **Entity Framework Core + SQL Server**.

Regras obrigatórias:

1. Adicionar os pacotes EF Core necessários ao projeto `MeuProjeto.Infrastructure`:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Design`
2. Criar o `ApplicationDbContext` na camada `Infrastructure`.
3. Criar uma classe `IEntityTypeConfiguration<T>` para cada entidade persistida.
4. Não usar Data Annotations para substituir o mapeamento principal; priorizar Fluent API.
5. Aplicar nomes de tabelas e colunas em inglês conforme a Spec de modelagem.
6. Criar índices, constraints, chaves primárias, chaves estrangeiras e unicidade pela Fluent API.
7. Registrar o `DbContext` no Dependency Injection das APIs.
8. Configurar a connection string por variável de ambiente/configuração.
9. Criar a migration inicial assim que o modelo persistente e os mappings estiverem definidos.
10. A migration inicial deve se chamar:

```text
InitialCreate
```

Comando de referência:

```bash
dotnet ef migrations add InitialCreate \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext \
  --output-dir Persistence/Migrations
```

Ajustar os caminhos ao layout efetivamente criado pela solução.

Após criar a migration, validar o SQL/modelo com:

```bash
dotnet ef migrations script \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext
```

Não continuar para CQRS/JWT enquanto a migration inicial não puder ser criada com sucesso.

## Ordem inicial de criação

1. Solution e projetos .NET
2. Domain base
3. Entidades do modelo inicial
4. Relacionamentos e invariantes do Domain
5. Infrastructure base
6. Pacotes Entity Framework Core / SQL Server
7. `ApplicationDbContext`
8. `IEntityTypeConfiguration<T>` de todas as entidades
9. Repositories e implementações necessárias
10. Registrar EF Core no Dependency Injection
11. Criar migration `InitialCreate`
12. Validar migration com `dotnet ef migrations script`
13. CQRS
14. JWT / Refresh Token
15. Authorization Policies
16. API Admin
17. API Site
18. Testes unitários
19. Testes de integração aplicando migrations
20. React Admin
21. React Site
22. Gerar `docker-compose.yml` no momento da execução
23. Gerar senha SQL Server conforme a data atual
24. Aplicar migrations no banco de desenvolvimento
25. Build
26. Tests

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
