# PROJECT STARTER — BACKEND NODE.JS / NESTJS

> Documento de bootstrap para criação inicial de um backend em Node.js utilizando TypeScript e NestJS.
>
> O objetivo deste starter é **somente criar a estrutura técnica inicial do projeto**.
> Nenhuma regra de negócio, integração, persistência, autenticação ou feature deve ser implementada nesta etapa.
>
> A arquitetura inicial será um **Monólito Modular**, utilizando **uma única aplicação NestJS**.

---

# 1. Objetivo

Criar um backend Node.js/NestJS contendo apenas:

- uma única aplicação NestJS;
- TypeScript;
- estrutura modular;
- módulos iniciais `Auth`, `Person`, `Admin` e `Site`;
- camada compartilhada `Shared`;
- separação arquitetural preparada para DDD e CQRS;
- rotas mínimas para validação;
- gerenciamento de dependências via npm;
- aplicação executável;
- build funcionando;
- lint/testes de bootstrap mínimos, quando aplicável.

Este starter **não implementa funcionalidades de negócio**.

---

# 2. Decisão arquitetural

A aplicação deve iniciar como:

```text
Monólito Modular
```

Não criar quatro aplicações Node.js independentes.

Estrutura conceitual:

```text
                    NestJS
                      │
       ┌──────────────┼──────────────┐
       │              │              │
     Auth           Person         Admin
       │              │              │
       └──────────────┼──────────────┘
                      │
                     Site
                      │
                    Shared
```

Todos os módulos executam dentro:

```text
1 aplicação NestJS
1 package.json
1 bootstrap
1 configuração
1 processo de deploy
```

Os módulos devem possuir isolamento lógico através de:

```text
Modules
Diretórios
Contratos
Camadas
Dependency Injection
Regras de dependência
```

Não utilizar microserviços nesta etapa.

---

# 3. Informações do projeto

Preencher antes da criação.

| Campo | Valor |
|---|---|
| Nome do projeto | `A DEFINIR` |
| Namespace / escopo npm | `A DEFINIR` |
| Versão Node.js | `A DEFINIR` |
| Versão NestJS | `A DEFINIR` |
| Package Manager | `npm` |
| Repositório | `A DEFINIR` |
| Responsável técnico | `A DEFINIR` |

Exemplo:

```text
Nome: meu-projeto
Namespace: @meuprojeto
```

---

# 4. Tecnologias base

Utilizar inicialmente:

```text
Node.js
TypeScript
NestJS
npm
```

Não adicionar bibliotecas externas sem necessidade explícita.

---

# 5. Escopo desta etapa

## Deve ser criado

- pasta `backend/`;
- uma aplicação NestJS;
- estrutura `src/modules`;
- módulos `Auth`, `Person`, `Admin` e `Site`;
- estrutura `src/shared`;
- estrutura mínima de `application`, `domain`, `infrastructure` e `presentation`;
- rotas mínimas de validação;
- `README.md`;
- `.gitignore`;
- `.env.example`;
- `package.json`;
- `tsconfig.json`;
- dependências padrão do NestJS;
- build funcionando;
- aplicação iniciando sem erro.

## Não deve ser criado

Nesta etapa, **não implementar**:

- frontend;
- CRUDs;
- regras de negócio;
- autenticação;
- autorização;
- JWT;
- Passport;
- banco de dados funcional;
- migrations;
- seeds;
- entities de ORM;
- repositories concretos;
- Prisma;
- TypeORM;
- Sequelize;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- Docker;
- Docker Compose;
- Commands funcionais;
- Queries funcionais;
- Handlers;
- Domain Events;
- Aggregates;
- Value Objects de negócio;
- Jobs;
- Queues;
- Workers;
- Schedulers;
- integrações externas.

Esses recursos devem ser adicionados posteriormente através de tasks específicas.

---

# 6. Estrutura esperada

Toda a aplicação deve ficar dentro de:

```text
backend/
```

Estrutura inicial:

```text
📂 backend
├── 📂 src
│   ├── 📂 modules
│   │   ├── 📂 auth
│   │   │   ├── 📂 application
│   │   │   │   ├── 📂 command
│   │   │   │   └── 📂 query
│   │   │   ├── 📂 domain
│   │   │   ├── 📂 infrastructure
│   │   │   ├── 📂 presentation
│   │   │   │   ├── 📂 controllers
│   │   │   │   ├── 📂 dto
│   │   │   │   └── 📂 presenters
│   │   │   └── 📄 auth.module.ts
│   │   │
│   │   ├── 📂 person
│   │   │   ├── 📂 application
│   │   │   │   ├── 📂 command
│   │   │   │   └── 📂 query
│   │   │   ├── 📂 domain
│   │   │   ├── 📂 infrastructure
│   │   │   ├── 📂 presentation
│   │   │   │   ├── 📂 controllers
│   │   │   │   ├── 📂 dto
│   │   │   │   └── 📂 presenters
│   │   │   └── 📄 person.module.ts
│   │   │
│   │   ├── 📂 admin
│   │   │   ├── 📂 application
│   │   │   │   ├── 📂 command
│   │   │   │   └── 📂 query
│   │   │   ├── 📂 domain
│   │   │   ├── 📂 infrastructure
│   │   │   ├── 📂 presentation
│   │   │   │   ├── 📂 controllers
│   │   │   │   ├── 📂 dto
│   │   │   │   └── 📂 presenters
│   │   │   └── 📄 admin.module.ts
│   │   │
│   │   └── 📂 site
│   │       ├── 📂 application
│   │       │   ├── 📂 command
│   │       │   └── 📂 query
│   │       ├── 📂 domain
│   │       ├── 📂 infrastructure
│   │       ├── 📂 presentation
│   │       │   ├── 📂 controllers
│   │       │   ├── 📂 dto
│   │       │   └── 📂 presenters
│   │       └── 📄 site.module.ts
│   │
│   ├── 📂 shared
│   │   ├── 📂 application
│   │   ├── 📂 domain
│   │   ├── 📂 infrastructure
│   │   └── 📂 cross-cutting
│   │
│   ├── 📄 app.module.ts
│   └── 📄 main.ts
│
├── 📂 test
│   ├── 📂 unit
│   └── 📂 integration
│
├── 📄 package.json
├── 📄 package-lock.json
├── 📄 tsconfig.json
├── 📄 tsconfig.build.json
├── 📄 nest-cli.json
├── 📄 eslint.config.mjs
├── 📄 .env.example
├── 📄 .gitignore
└── 📄 README.md
```

> Manter também os arquivos mínimos exigidos pela versão do NestJS adotada.

---

# 7. Responsabilidade dos módulos

## Auth

Responsável futuramente por:

```text
Login
Logout
Recuperação de senha
Tokens
Identidade
Autenticação
Autorização
```

Nesta etapa não implementar nenhuma dessas funcionalidades.

Criar apenas estrutura.

---

## Person

Responsável futuramente por:

```text
Pessoa
Usuário
Perfil
Dados pessoais
```

Nesta etapa não implementar regras de negócio.

---

## Admin

Responsável futuramente pelas funcionalidades administrativas.

Exemplos futuros:

```text
Dashboard
Gestão de usuários
Configurações administrativas
Permissões
```

Nesta etapa não implementar essas funcionalidades.

---

## Site

Responsável futuramente pelas funcionalidades públicas consumidas pelo frontend/site.

Nesta etapa criar apenas a estrutura.

---

# 8. Estrutura interna de um módulo

Os módulos devem seguir inicialmente:

```text
module
├── application
│   ├── command
│   └── query
│
├── domain
│
├── infrastructure
│
├── presentation
│   ├── controllers
│   ├── dto
│   └── presenters
│
└── module-name.module.ts
```

Essa estrutura representa a direção arquitetural futura.

Não criar classes artificiais apenas para preencher pastas.

Quando necessário, utilizar `.gitkeep`.

---

# 9. Application

A camada:

```text
application
```

será responsável futuramente pelos casos de uso.

Poderá conter:

```text
Commands
Queries
Handlers
DTOs
Validators
Use Cases
Application Services
```

Nesta etapa criar somente:

```text
command/
query/
```

Não implementar classes funcionais.

---

# 10. Domain

A camada:

```text
domain
```

representará o núcleo de negócio de cada módulo.

Poderá conter futuramente:

```text
Entities
Aggregates
Value Objects
Domain Events
Domain Services
Repository Interfaces
Specifications
Business Rules
```

Nesta etapa deve permanecer vazia.

## Regra fundamental

O `domain` não deve depender diretamente de:

```text
NestJS
Controllers
Decorators HTTP
Infrastructure
Banco de dados
Prisma
TypeORM
Redis
Kafka
Frameworks externos
```

O domínio deve permanecer o mais independente possível do framework.

---

# 11. Infrastructure

A camada:

```text
infrastructure
```

poderá conter futuramente implementações técnicas:

```text
Persistence
Repository Implementations
Prisma
TypeORM
Cache
Redis
Kafka
RabbitMQ
MongoDB
HTTP Clients
Filesystem
Outbox
Integrações externas
```

Nesta etapa deve permanecer vazia.

---

# 12. Presentation

A camada:

```text
presentation
```

é a porta de entrada da aplicação.

Poderá conter:

```text
Controllers
DTOs
Presenters
Guards
Interceptors específicos do módulo
```

Fluxo futuro:

```text
HTTP
 ↓
Controller
 ↓
Application
 ↓
Domain
```

Controllers não devem conter regras de negócio.

---

# 13. Shared

Criar:

```text
src/shared
```

Estrutura:

```text
shared
├── application
├── domain
├── infrastructure
└── cross-cutting
```

O `shared` deve conter apenas componentes realmente compartilhados entre módulos.

Não utilizar `shared` como pasta genérica para qualquer código.

---

# 14. Shared Domain

Poderá conter futuramente abstrações realmente compartilhadas:

```text
AggregateRoot
DomainEvent
ValueObject base
Identifiers
Clock abstractions
Result
Either
```

Nesta etapa não implementar essas abstrações.

---

# 15. Cross-Cutting

Poderá conter futuramente:

```text
Logging
Exceptions
CorrelationId
Global Filters
Interceptors
Guards compartilhados
Health Checks
Observabilidade
Helpers técnicos
```

Nesta etapa deve permanecer mínimo.

---

# 16. Direção das dependências

Dentro de cada módulo:

```text
presentation
 ↓
application
 ↓
domain
```

Infrastructure pode implementar contratos necessários por:

```text
application
domain
```

Representação:

```text
      presentation
           ↓
      application
           ↓
         domain
           ↑
     infrastructure
```

## Permitido

```text
presentation -> application
application -> domain
infrastructure -> application
infrastructure -> domain
```

## Não permitido

```text
domain -> infrastructure
domain -> presentation
domain -> NestJS
application -> presentation
application -> controllers
```

---

# 17. Dependências entre módulos

Evitar dependências diretas entre módulos.

Exemplo a evitar:

```text
admin/domain
   ↓
person/infrastructure
```

Caso um módulo precise interagir com outro, a estratégia deverá ser definida em uma task específica.

Possíveis estratégias futuras:

```text
Application Contracts
Domain Events
Integration Events
Interfaces
Event Bus
Facade
```

Não implementar essas estratégias nesta etapa.

---

# 18. AppModule

Criar um único:

```text
src/app.module.ts
```

Responsável apenas por registrar os módulos principais.

Exemplo conceitual:

```ts
@Module({
  imports: [
    AuthModule,
    PersonModule,
    AdminModule,
    SiteModule,
  ],
})
export class AppModule {}
```

Não registrar banco, mensageria ou integrações externas nesta etapa.

---

# 19. Módulos NestJS

Cada contexto deve possuir um módulo próprio:

```text
auth.module.ts
person.module.ts
admin.module.ts
site.module.ts
```

Exemplo conceitual:

```ts
import { Module } from '@nestjs/common';

@Module({})
export class AuthModule {}
```

Nesta etapa manter os módulos mínimos.

---

# 20. main.ts

O arquivo:

```text
src/main.ts
```

deve permanecer simples.

Exemplo conceitual:

```ts
import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);

  await app.listen(process.env.PORT ?? 3000);
}

bootstrap();
```

Não adicionar antecipadamente:

```text
Swagger
ValidationPipe global
CORS customizado
Helmet
Compression
Rate Limit
OpenTelemetry
Sentry
```

Esses recursos devem entrar somente quando uma task exigir.

---

# 21. Endpoints obrigatórios de validação

Criar inicialmente:

```text
GET /api/auth
GET /api/person
GET /api/admin
GET /api/site
```

Respostas:

```text
Olá Mundo - Auth API
Olá Mundo - Person API
Olá Mundo - Admin API
Olá Mundo - Site API
```

Não criar endpoints adicionais de negócio.

---

# 22. Controllers mínimos

Para validar cada módulo, pode existir um controller mínimo.

Exemplo:

```ts
import { Controller, Get } from '@nestjs/common';

@Controller('api/auth')
export class AuthController {
  @Get()
  index(): string {
    return 'Olá Mundo - Auth API';
  }
}
```

Cada módulo deve possuir somente o endpoint de validação nesta etapa.

---

# 23. DTOs

Nesta etapa não criar DTOs de negócio.

As pastas:

```text
presentation/dto
```

podem permanecer vazias.

DTOs devem ser adicionados quando existirem features reais.

---

# 24. Providers

Não registrar providers de negócio nesta etapa.

Não criar antecipadamente:

```text
Repositories
Handlers
Command Bus
Query Bus
Domain Event Dispatcher
Database Client
External API Client
Message Bus
```

Utilizar somente providers mínimos necessários para os controllers de validação.

---

# 25. Banco de dados

Nesta etapa não configurar persistência.

Não instalar:

```text
Prisma
TypeORM
Sequelize
Mongoose
Knex
```

Não criar:

```text
Schema
Migration
Entity ORM
Repository concreto
Database Module
```

Nenhum banco deve ser necessário para executar o starter.

---

# 26. CQRS

A aplicação será preparada conceitualmente para CQRS.

Estrutura:

```text
application
├── command
└── query
```

Nesta etapa não criar:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
GetUserQuery
ListUserQuery
CommandHandler
QueryHandler
CommandBus
QueryBus
Mediator
```

Também não instalar:

```text
@nestjs/cqrs
```

nesta etapa.

CQRS será implementado através de tasks futuras.

---

# 27. Domain Events

A arquitetura poderá utilizar Domain Events futuramente.

Possíveis componentes:

```text
DomainEvent
DomainEventDispatcher
DomainEventHandler
AggregateRoot
IntegrationEvent
Outbox
```

Nesta etapa não implementar nenhum deles.

---

# 28. Autenticação

Embora exista um módulo:

```text
auth
```

não implementar autenticação nesta etapa.

Não instalar antecipadamente:

```text
@nestjs/passport
passport
passport-jwt
jsonwebtoken
bcrypt
argon2
```

O módulo Auth nesta etapa representa somente uma divisão arquitetural futura.

---

# 29. Configuração `.env`

Manter:

```text
.env.example
```

Não versionar:

```text
.env
```

Não incluir:

```text
senhas
tokens
API keys
credenciais reais
secrets
```

Nesta etapa, pode existir apenas:

```env
PORT=3000
```

---

# 30. package.json

Utilizar apenas um:

```text
backend/package.json
```

Não criar `package.json` separado por módulo.

A aplicação inteira utiliza:

```text
1 package.json
```

---

# 31. Dependências npm

Não instalar bibliotecas adicionais sem uma task específica.

Evitar antecipadamente:

```text
@nestjs/cqrs
@nestjs/passport
@nestjs/jwt
Prisma
TypeORM
Sequelize
Mongoose
Redis clients
Kafka clients
RabbitMQ clients
BullMQ
Swagger
OpenTelemetry
Sentry
Winston
Pino
```

Utilizar apenas as dependências padrão do NestJS e TypeScript.

---

# 32. TypeScript

Utilizar TypeScript em todo o backend.

Não criar arquivos JavaScript para regras da aplicação.

Utilizar:

```text
.ts
```

para:

```text
Modules
Controllers
Application
Domain
Infrastructure
Shared
```

---

# 33. Path Aliases

Path aliases podem ser utilizados futuramente.

Exemplo conceitual:

```json
{
  "compilerOptions": {
    "paths": {
      "@modules/*": ["src/modules/*"],
      "@shared/*": ["src/shared/*"]
    }
  }
}
```

Nesta etapa, não configurar aliases se não houver necessidade real.

Preferir manter o bootstrap simples.

---

# 34. Testes

Manter estrutura inicial:

```text
test/
├── unit
└── integration
```

Nesta etapa os testes devem se limitar, quando necessários, ao bootstrap.

Não criar testes para regras de negócio inexistentes.

---

# 35. Criação do projeto

Criar a aplicação NestJS.

Exemplo:

```bash
npx @nestjs/cli new backend
```

Escolher:

```text
npm
```

como package manager.

Entrar:

```bash
cd backend
```

---

# 36. Instalação

Executar:

```bash
npm install
```

Resultado esperado:

```text
dependências instaladas sem erro
```

---

# 37. Build obrigatório

Executar:

```bash
npm run build
```

Resultado esperado:

```text
build concluído sem erros
```

Nenhum erro TypeScript deve existir.

---

# 38. Execução

Executar:

```bash
npm run start:dev
```

ou:

```bash
npm run start
```

Exemplo:

```text
http://localhost:3000
```

---

# 39. Validação dos endpoints

Validar:

```text
GET http://localhost:3000/api/auth
GET http://localhost:3000/api/person
GET http://localhost:3000/api/admin
GET http://localhost:3000/api/site
```

Respostas esperadas:

```text
Olá Mundo - Auth API
Olá Mundo - Person API
Olá Mundo - Admin API
Olá Mundo - Site API
```

---

# 40. Lint

Caso o template utilizado já possua ESLint configurado:

```bash
npm run lint
```

Não instalar ou trocar ferramentas de lint nesta etapa sem necessidade.

---

# 41. Formatação

Caso o template utilizado já possua Prettier:

```bash
npm run format
```

Não criar convenções extras além das existentes no projeto inicial.

---

# 42. README inicial

O arquivo:

```text
backend/README.md
```

deve conter somente informações essenciais.

Exemplo:

```markdown
# MeuProjeto Backend

Backend do projeto MeuProjeto.

## Tecnologia

- Node.js
- TypeScript
- NestJS
- npm

## Arquitetura

Monólito Modular.

## Módulos

- Auth
- Person
- Admin
- Site

## Estrutura

- modules
- shared
- application
- domain
- infrastructure
- presentation

## Instalação

```bash
npm install
```

## Executar

```bash
npm run start:dev
```

## Build

```bash
npm run build
```
```

---

# 43. `.gitignore`

Utilizar o `.gitignore` padrão para Node.js/NestJS.

Garantir que não sejam versionados:

```text
node_modules/
dist/
.env
coverage/
.nyc_output/
.idea/
.vscode/
.DS_Store
Thumbs.db
npm-debug.log*
yarn-debug.log*
yarn-error.log*
pnpm-debug.log*
```

Não ignorar:

```text
.env.example
```

---

# 44. Convenções

Utilizar:

```text
TypeScript
ESLint
Prettier quando fornecido pelo template
NestJS Modules
Dependency Injection
camelCase para variáveis e métodos
PascalCase para classes
kebab-case para nomes de arquivos
```

Evitar abstrações prematuras.

---

# 45. Naming

Exemplos:

```text
auth.module.ts
auth.controller.ts
create-user.command.ts
get-user.query.ts
user.repository.ts
user.entity.ts
```

Nesta etapa, criar somente os arquivos realmente necessários para o bootstrap.

Não antecipar os exemplos acima.

---

# 46. Evolução futura

A arquitetura poderá evoluir para:

```text
HTTP
 ↓
Controller
 ↓
Command / Query
 ↓
Handler
 ↓
Domain
 ↓
Repository Interface
 ↑
Infrastructure
```

E:

```text
Domain
 ↓
Domain Event
 ↓
Handler
 ↓
Infrastructure / Integration
```

Nenhum desses fluxos deve ser implementado durante o bootstrap.

---

# 47. Monólito Modular x Microserviços

A aplicação deve iniciar como:

```text
Monólito Modular
```

Não criar:

```text
Auth Service separado
Person Service separado
Admin Service separado
Site Service separado
```

Caso futuramente exista necessidade comprovada de:

```text
deploy independente
escala independente
banco independente
times independentes
isolamento operacional
```

um módulo poderá ser avaliado para extração como serviço.

Essa decisão não pertence ao bootstrap inicial.

---

# 48. Critérios de aceite

O starter está concluído somente quando:

- [ ] pasta `backend` criada;
- [ ] uma única aplicação NestJS criada;
- [ ] apenas um `package.json`;
- [ ] TypeScript configurado;
- [ ] `src/modules` criado;
- [ ] módulo Auth criado;
- [ ] módulo Person criado;
- [ ] módulo Admin criado;
- [ ] módulo Site criado;
- [ ] `src/shared` criado;
- [ ] estrutura application criada;
- [ ] estrutura domain criada;
- [ ] estrutura infrastructure criada;
- [ ] estrutura presentation criada;
- [ ] `app.module.ts` registra os quatro módulos;
- [ ] rota `/api/auth` criada;
- [ ] rota `/api/person` criada;
- [ ] rota `/api/admin` criada;
- [ ] rota `/api/site` criada;
- [ ] todas retornam `Olá Mundo`;
- [ ] nenhuma regra de negócio criada;
- [ ] nenhum CRUD criado;
- [ ] nenhuma Entity de negócio criada;
- [ ] nenhum Aggregate criado;
- [ ] nenhum Domain Event criado;
- [ ] nenhum Command funcional criado;
- [ ] nenhuma Query funcional criada;
- [ ] nenhum Handler criado;
- [ ] nenhuma persistência configurada;
- [ ] nenhuma autenticação implementada;
- [ ] nenhuma mensageria configurada;
- [ ] nenhum frontend criado;
- [ ] nenhum Docker criado;
- [ ] `npm install` executa sem erro;
- [ ] `npm run build` executa sem erro;
- [ ] aplicação inicia sem erro;
- [ ] os quatro endpoints respondem corretamente.

---

# 49. Regras para IA / Copilot

Ao utilizar este arquivo como prompt/contexto para IA:

1. Criar somente o backend.
2. Utilizar Node.js.
3. Utilizar TypeScript.
4. Utilizar NestJS.
5. Utilizar npm.
6. Criar **uma única aplicação NestJS**.
7. Utilizar arquitetura de **Monólito Modular**.
8. Não criar quatro aplicações independentes.
9. Criar módulos `Auth`, `Person`, `Admin` e `Site`.
10. Criar `Shared`.
11. Não criar frontend.
12. Não implementar features.
13. Não criar CRUDs.
14. Não criar entidades de negócio.
15. Não criar Aggregates.
16. Não implementar Commands.
17. Não implementar Queries.
18. Não implementar Handlers.
19. Não implementar Domain Events.
20. Não configurar banco de dados.
21. Não instalar Prisma.
22. Não instalar TypeORM.
23. Não instalar Sequelize.
24. Não instalar Mongoose.
25. Não criar migrations.
26. Não configurar MongoDB.
27. Não configurar Redis.
28. Não configurar Kafka.
29. Não configurar RabbitMQ.
30. Não implementar autenticação.
31. Não instalar Passport.
32. Não instalar JWT.
33. Não instalar `@nestjs/cqrs`.
34. Não criar Jobs.
35. Não criar Queues.
36. Não criar Workers.
37. Não criar Scheduler customizado.
38. Não criar Docker.
39. Não criar Docker Compose.
40. Não instalar pacotes npm antecipadamente.
41. Utilizar apenas um `package.json`.
42. Manter o Domain independente do NestJS sempre que possível.
43. Não utilizar decorators NestJS no Domain.
44. Não colocar regras de negócio em Controllers.
45. Não criar providers customizados sem necessidade.
46. Não criar Guards customizados sem necessidade.
47. Não criar Interceptors customizados sem necessidade.
48. Não criar integrações externas.
49. Não adicionar arquitetura complexa antecipadamente.
50. Criar somente os quatro endpoints de validação definidos.
51. Manter o código mínimo e executável.
52. Respeitar a direção das dependências.
53. Evitar dependência direta entre módulos.
54. Caso alguma informação necessária não esteja definida, utilizar `A DEFINIR`.
55. Não inventar versões de Node.js ou NestJS.
56. Não expandir o escopo sem solicitação explícita.

---

# 50. Resultado esperado

Ao final deve existir:

```text
                 HTTP
                  ↓
                NestJS
                  ↓
                Modules
       ┌──────────┼──────────┐
       │          │          │
      Auth      Person     Admin
       │          │          │
       └──────────┼──────────┘
                  │
                 Site

Dentro dos módulos:

Presentation
     ↓
Application
     ↓
Domain

Infrastructure
     ↑
implementações técnicas futuras

Shared
     ↓
componentes realmente compartilhados
```

Com apenas uma aplicação NestJS.

Sem microserviços.

Sem funcionalidades de negócio.

Sem persistência.

Sem autenticação.

Sem mensageria.

Sem frontend.

Sem Docker.

Sem CQRS funcional.

Sem Domain Events.

O desenvolvimento funcional começa somente após a aprovação deste bootstrap e criação das tasks específicas.
