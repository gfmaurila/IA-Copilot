# EXECUÇÃO AUTOMÁTICA DO SEED APÓS MIGRATION

Os dados fake NÃO devem depender de execução manual separada.

A carga de dados deve fazer parte do processo de inicialização do banco de dados da aplicação.

O fluxo obrigatório será:

```text
Application Startup
        ↓
Database Connection
        ↓
Database Available
        ↓
EF Core Migration
        ↓
Migration Successful
        ↓
Seed Environment Validation
        ↓
DEV / TEST?
   ┌────┴────┐
  SIM       NÃO
   ↓          ↓
Seed Data    Skip Seed
   ↓
IAM Base Data
   ↓
Roles
   ↓
Permissions
   ↓
Groups
   ↓
Test Users
   ↓
Fake Users
   ↓
Related Data
   ↓
Seed Validation
   ↓
Application Ready
```

---

## Regra de Migration + Seed

Sempre que o projeto executar:

```csharp
database.Migrate();
```

ou mecanismo equivalente utilizado pelo projeto, após a conclusão bem-sucedida das migrations deverá ser executada a rotina de Seed.

Conceitualmente:

```csharp
await database.MigrateAsync();

await databaseSeeder.SeedAsync();
```

A implementação final deve respeitar a arquitetura existente.

Não inserir os 1.000 registros diretamente dentro de uma classe `Migration`.

As migrations são responsáveis por:

```text
Schema
Tables
Columns
Indexes
Constraints
Foreign Keys
```

O Seeder é responsável por:

```text
IAM
Roles
Permissions
Groups
Users
Fake Data
Related Data
```

Portanto:

```text
Migration
    ↓
Seeder
```

e não:

```text
Migration contendo 1000 INSERTs
```

---

# EXECUÇÃO AUTOMÁTICA

O processo deverá funcionar sem intervenção manual.

Ao iniciar o ambiente local:

```bash
docker compose up
```

o fluxo esperado será:

```text
Containers
    ↓
MySQL
    ↓
Health Check
    ↓
Backend
    ↓
EF Core Migration
    ↓
Seed
    ↓
1000 Users
    ↓
Related Data
    ↓
Application Ready
```

O desenvolvedor não deverá precisar executar posteriormente:

```text
seed.ps1
```

para obter a base Demo padrão.

O script manual poderá continuar existindo para:

```text
reset
reseed
stress seed
maintenance
development
```

mas não será necessário para a inicialização normal.

---

# AMBIENTES

A execução automática deve respeitar o ambiente.

## Development

```text
Migration = YES
Seed Minimal/Demo = YES
Fake Data = YES
```

## Test

```text
Migration = YES
Seed = YES
Fake Data = YES
```

## HML

```text
Migration = conforme estratégia de deployment
Fake Data = NO
```

## Production

```text
Migration = conforme estratégia de deployment
Fake Data = NEVER
```

Dados fake devem possuir proteção explícita contra execução em:

```text
HML
Production
```

---

# PERFIL PADRÃO LOCAL

O ambiente de desenvolvimento deverá utilizar:

```text
Seed:
  Enabled: true
  Profile: Demo
  Users: 1000
```

O perfil `Demo` será responsável por deixar o banco pronto para desenvolvimento.

---

# TOTAL DE USUÁRIOS

Após Migration + Seed:

```text
TOTAL USERS = 1000
```

Dentro desses 1.000:

```text
3 usuários conhecidos
+
997 usuários fake
=
1000 usuários
```

---

# USUÁRIOS PARA TESTE

Após a Migration + Seed, deverão estar disponíveis:

## Administrator

```text
Usuário:
admin@local.test

Senha:
Admin@123456
```

Deve possuir acesso administrativo completo conforme o IAM real implementado.

---

## Regular User

```text
Usuário:
user@local.test

Senha:
User@123456
```

Deve possuir permissões normais.

---

## ReadOnly

```text
Usuário:
readonly@local.test

Senha:
ReadOnly@123456
```

Deve possuir somente permissões de leitura quando esse perfil existir no IAM.

---

# SENHAS

As senhas conhecidas são exclusivamente para:

```text
LOCAL
DEV
TEST
```

O banco NÃO deve armazenar:

```text
Admin@123456
User@123456
ReadOnly@123456
```

em texto puro.

Devem passar pelo mesmo mecanismo de hashing utilizado pela autenticação real:

```text
Senha conhecida
      ↓
Password Hasher
      ↓
PasswordHash
      ↓
Database
```

---

# IDEMPOTÊNCIA

A execução automática torna a idempotência OBRIGATÓRIA.

Considere:

```text
Primeira inicialização
Migration
↓
Seed
↓
1000 usuários
```

Na próxima inicialização:

```text
Application Restart
↓
Migration
↓
Nenhuma nova migration
↓
Seed
↓
Detectar dados existentes
↓
Não duplicar
↓
1000 usuários
```

Portanto:

```text
1º start = 1000 usuários
2º start = 1000 usuários
3º start = 1000 usuários
10º start = 1000 usuários
```

Nunca:

```text
1000
2000
3000
4000
...
```

---

# NOVAS MIGRATIONS

O Seeder também deve suportar evolução do sistema.

Exemplo:

```text
Migration 001
↓
Seed
↓
Users + Roles + Permissions

Migration 002
↓
Nova tabela Groups
↓
Seed
↓
Criar Groups ausentes
↓
Relacionar dados necessários
```

O Seeder deve verificar individualmente quais dados estruturais estão ausentes.

Não utilizar apenas:

```text
if (Users.Any())
    return;
```

porque isso impediria Seeds futuros de outras entidades.

Preferir Seeders independentes:

```text
DatabaseSeeder
│
├── RoleSeeder
├── PermissionSeeder
├── GroupSeeder
├── TestUserSeeder
├── UserFakeSeeder
└── RelatedDataSeeder
```

Cada Seeder deve possuir sua própria estratégia de idempotência.

---

# ORDEM DE EXECUÇÃO DO SEED

Após as migrations:

```text
DatabaseSeeder
    ↓
PermissionSeeder
    ↓
RoleSeeder
    ↓
GroupSeeder
    ↓
TestUserSeeder
    ↓
UserFakeSeeder
    ↓
RelatedDataSeeder
    ↓
SeedValidator
```

A ordem deve respeitar Foreign Keys e dependências reais.

---

# FALHA NA MIGRATION

Se ocorrer erro:

```text
Migration
    ↓
ERROR
```

então:

```text
Seed = NÃO EXECUTAR
```

A aplicação deve registrar o erro e seguir a política de startup definida pelo projeto.

---

# FALHA NO SEED

Se ocorrer falha crítica:

```text
Migration
    ↓
SUCCESS
    ↓
Seed
    ↓
ERROR
```

não considerar a inicialização Demo concluída.

Registrar claramente:

```text
Seed failed
```

com diagnóstico suficiente, sem expor secrets.

---

# VALIDAÇÃO FINAL

Depois da carga automática:

```text
Migration
    ↓
Seed
    ↓
SeedValidator
```

Validar pelo menos:

```text
Users = 1000

admin@local.test exists
user@local.test exists
readonly@local.test exists

Roles exist
Permissions exist
Groups exist

User relationships valid

Duplicate emails = 0
Duplicate usernames = 0

Orphan relationships = 0
```

---

# LOGIN AUTOMÁTICO DE VALIDAÇÃO

Depois que a aplicação estiver disponível, os testes de integração deverão validar:

```text
POST Login
```

utilizando:

```text
admin@local.test
Admin@123456
```

Resultado esperado:

```text
Authentication = SUCCESS
```

Quando JWT estiver implementado:

```text
Access Token = generated
Refresh Token = generated
```

Também testar os usuários:

```text
user@local.test
readonly@local.test
```

---

# CONSOLE APÓS INICIALIZAÇÃO

Em Development, apresentar:

```text
============================================================
 DATABASE INITIALIZATION
============================================================

Migration................ SUCCESS
Seed Profile............. Demo
Seed..................... SUCCESS

Users.................... 1000
Relationships............ OK

============================================================
 LOCAL TEST CREDENTIALS
============================================================

ADMINISTRATOR
User:     admin@local.test
Password: Admin@123456

REGULAR USER
User:     user@local.test
Password: User@123456

READ ONLY
User:     readonly@local.test
Password: ReadOnly@123456

============================================================
```

As credenciais conhecidas nunca devem ser exibidas em HML ou Production.

---

# REGRA FINAL

O fluxo oficial do desenvolvimento local passa a ser:

```text
docker compose up
        ↓
Infrastructure
        ↓
Database Ready
        ↓
EF Core Migration
        ↓
Database Seed
        ↓
IAM
        ↓
1000 Users
        ↓
Related Data
        ↓
Validation
        ↓
Backend Ready
        ↓
Frontend Ready
        ↓
Login disponível
```

Portanto, para o ambiente local:

> Subir o projeto deve ser suficiente para criar/migrar o banco e disponibilizar automaticamente os dados necessários para desenvolvimento e teste.

O desenvolvedor não deve precisar popular manualmente a base após a primeira execução.