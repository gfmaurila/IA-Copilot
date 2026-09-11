# PROJECT STARTER — BACKEND PHP / LARAVEL

> Documento de bootstrap para criação inicial de um backend em PHP utilizando Laravel.
>
> O objetivo deste starter é **somente criar a estrutura técnica inicial do projeto**.
> Nenhuma regra de negócio, integração, persistência, autenticação ou feature deve ser implementada nesta etapa.
>
> A arquitetura inicial será um **Monólito Modular**, utilizando **uma única aplicação Laravel**.

---

# 1. Objetivo

Criar um backend Laravel contendo apenas:

- uma única aplicação Laravel;
- estrutura modular;
- módulos iniciais `Auth`, `Person`, `Admin` e `Site`;
- camada compartilhada `Shared`;
- separação arquitetural preparada para DDD e CQRS;
- namespaces e autoload PSR-4;
- rotas mínimas para validação;
- instalação via Composer funcionando;
- aplicação executável;
- testes de bootstrap mínimos, quando necessários.

Este starter **não implementa funcionalidades de negócio**.

---

# 2. Decisão arquitetural

A aplicação deve iniciar como:

```text
Monólito Modular
```

Não criar quatro aplicações Laravel independentes.

Estrutura conceitual:

```text
                    Laravel
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
1 aplicação Laravel
1 composer.json
1 bootstrap
1 configuração
1 processo de deploy
```

Os módulos devem possuir isolamento lógico através de:

```text
Namespaces
Diretórios
Contratos
Camadas
Regras de dependência
```

Não utilizar microserviços nesta etapa.

---

# 3. Informações do projeto

Preencher antes da criação.

| Campo | Valor |
|---|---|
| Nome do projeto | `A DEFINIR` |
| Namespace raiz | `A DEFINIR` |
| Versão PHP | `A DEFINIR` |
| Versão Laravel | `A DEFINIR` |
| Repositório | `A DEFINIR` |
| Responsável técnico | `A DEFINIR` |

Exemplo:

```text
Nome: MeuProjeto
Namespace: MeuProjeto
```

---

# 4. Escopo desta etapa

## Deve ser criado

- pasta `backend/`;
- uma aplicação Laravel;
- estrutura `app/Modules`;
- módulos `Auth`, `Person`, `Admin` e `Site`;
- estrutura `app/Shared`;
- estrutura mínima de `Application`, `Domain`, `Infrastructure` e `Http`;
- namespaces PSR-4;
- rotas mínimas de validação;
- `README.md`;
- `.gitignore`;
- `.env.example`;
- dependências padrão do Laravel;
- instalação via Composer funcionando;
- aplicação Laravel iniciando sem erro.

## Não deve ser criado

Nesta etapa, **não implementar**:

- frontend;
- CRUDs;
- regras de negócio;
- autenticação;
- autorização;
- JWT;
- Laravel Sanctum;
- Laravel Passport;
- banco de dados funcional;
- migrations de negócio;
- seeders;
- factories;
- Models de negócio;
- repositories concretos;
- Redis;
- MongoDB;
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

# 5. Estrutura esperada

Toda a aplicação deve ficar dentro de:

```text
backend/
```

Estrutura inicial:

```text
📂 backend
├── 📂 app
│   ├── 📂 Modules
│   │   ├── 📂 Auth
│   │   │   ├── 📂 Application
│   │   │   │   ├── 📂 Command
│   │   │   │   └── 📂 Query
│   │   │   ├── 📂 Domain
│   │   │   ├── 📂 Infrastructure
│   │   │   └── 📂 Http
│   │   │       ├── 📂 Controllers
│   │   │       ├── 📂 Requests
│   │   │       └── 📂 Resources
│   │   │
│   │   ├── 📂 Person
│   │   │   ├── 📂 Application
│   │   │   │   ├── 📂 Command
│   │   │   │   └── 📂 Query
│   │   │   ├── 📂 Domain
│   │   │   ├── 📂 Infrastructure
│   │   │   └── 📂 Http
│   │   │       ├── 📂 Controllers
│   │   │       ├── 📂 Requests
│   │   │       └── 📂 Resources
│   │   │
│   │   ├── 📂 Admin
│   │   │   ├── 📂 Application
│   │   │   │   ├── 📂 Command
│   │   │   │   └── 📂 Query
│   │   │   ├── 📂 Domain
│   │   │   ├── 📂 Infrastructure
│   │   │   └── 📂 Http
│   │   │       ├── 📂 Controllers
│   │   │       ├── 📂 Requests
│   │   │       └── 📂 Resources
│   │   │
│   │   └── 📂 Site
│   │       ├── 📂 Application
│   │       │   ├── 📂 Command
│   │       │   └── 📂 Query
│   │       ├── 📂 Domain
│   │       ├── 📂 Infrastructure
│   │       └── 📂 Http
│   │           ├── 📂 Controllers
│   │           ├── 📂 Requests
│   │           └── 📂 Resources
│   │
│   └── 📂 Shared
│       ├── 📂 Application
│       ├── 📂 Domain
│       ├── 📂 Infrastructure
│       └── 📂 CrossCutting
│
├── 📂 bootstrap
├── 📂 config
├── 📂 database
├── 📂 public
├── 📂 resources
├── 📂 routes
│   ├── 📄 web.php
│   ├── 📄 api.php
│   ├── 📄 auth.php
│   ├── 📄 person.php
│   ├── 📄 admin.php
│   └── 📄 site.php
│
├── 📂 storage
├── 📂 tests
│   ├── 📂 Unit
│   └── 📂 Feature
│
├── 📄 artisan
├── 📄 composer.json
├── 📄 .env.example
├── 📄 .gitignore
└── 📄 README.md
```

> Manter também os arquivos e diretórios padrão exigidos pela versão do Laravel utilizada.

---

# 6. Responsabilidade dos módulos

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

# 7. Estrutura interna de um módulo

Os módulos devem seguir inicialmente:

```text
Module
├── Application
│   ├── Command
│   └── Query
│
├── Domain
│
├── Infrastructure
│
└── Http
    ├── Controllers
    ├── Requests
    └── Resources
```

Essa estrutura representa a direção arquitetural futura.

Não é necessário preencher todas as pastas com classes artificiais apenas para mantê-las no Git.

Quando necessário, utilizar `.gitkeep`.

---

# 8. Application

A camada:

```text
Application
```

será responsável futuramente por casos de uso.

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
Command/
Query/
```

Não implementar classes funcionais.

---

# 9. Domain

A camada:

```text
Domain
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

O `Domain` não deve depender diretamente de:

```text
Laravel
Eloquent
Controllers
Requests HTTP
Infrastructure
Banco de dados
Redis
Kafka
Frameworks externos
```

O domínio deve permanecer o mais independente possível do framework.

---

# 10. Infrastructure

A camada:

```text
Infrastructure
```

poderá conter futuramente implementações técnicas:

```text
Eloquent
Persistence
Repository Implementations
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

# 11. Http

A camada:

```text
Http
```

é a porta de entrada HTTP do módulo.

Poderá conter:

```text
Controllers
Requests
Resources
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

# 12. Shared

Criar:

```text
app/Shared
```

Estrutura:

```text
Shared
├── Application
├── Domain
├── Infrastructure
└── CrossCutting
```

O `Shared` deve conter apenas componentes realmente compartilhados entre módulos.

Não utilizar `Shared` como pasta genérica para qualquer código.

---

# 13. Shared Domain

Poderá conter futuramente abstrações realmente compartilhadas:

```text
AggregateRoot
DomainEvent
ValueObject base
Identifiers
Clock abstractions
```

Nesta etapa não implementar essas abstrações.

---

# 14. CrossCutting

Poderá conter futuramente:

```text
Logging
Exceptions
CorrelationId
Middleware compartilhado
Health Checks
Observabilidade
Helpers técnicos
```

Nesta etapa deve permanecer mínimo.

---

# 15. Direção das dependências

Dentro de cada módulo:

```text
Http
 ↓
Application
 ↓
Domain
```

Infrastructure pode implementar contratos necessários por:

```text
Application
Domain
```

Representação:

```text
        Http
         ↓
    Application
         ↓
       Domain
         ↑
   Infrastructure
```

## Permitido

```text
Http -> Application
Application -> Domain
Infrastructure -> Application
Infrastructure -> Domain
```

## Não permitido

```text
Domain -> Infrastructure
Domain -> Http
Domain -> Laravel
Application -> Http
Application -> Controllers
```

---

# 16. Dependências entre módulos

Evitar dependências diretas entre módulos.

Exemplo a evitar:

```text
Admin\Domain
   ↓
Person\Infrastructure
```

Caso um módulo precise interagir com outro, a estratégia deverá ser definida em uma task específica.

Possíveis estratégias futuras:

```text
Application Contracts
Domain Events
Integration Events
Interfaces
Event Bus
```

Não implementar essas estratégias nesta etapa.

---

# 17. Composer

Utilizar somente o:

```text
backend/composer.json
```

da aplicação Laravel.

Não criar um `composer.json` separado para cada módulo.

A aplicação inteira utiliza:

```text
1 composer.json
```

---

# 18. Autoload PSR-4

Utilizar o autoload padrão do Laravel sempre que possível.

Estrutura padrão:

```json
{
    "autoload": {
        "psr-4": {
            "App\\": "app/"
        }
    }
}
```

Isso permite namespaces como:

```php
namespace App\Modules\Auth\Application;

namespace App\Modules\Auth\Domain;

namespace App\Modules\Auth\Infrastructure;

namespace App\Modules\Auth\Http\Controllers;
```

Não criar configuração PSR-4 desnecessária para cada módulo enquanto todos estiverem dentro de `app/`.

---

# 19. Namespaces

Exemplos:

```php
namespace App\Modules\Auth\Domain;
```

```php
namespace App\Modules\Auth\Application\Command;
```

```php
namespace App\Modules\Auth\Application\Query;
```

```php
namespace App\Modules\Auth\Infrastructure;
```

```php
namespace App\Modules\Auth\Http\Controllers;
```

Shared:

```php
namespace App\Shared\Domain;
```

```php
namespace App\Shared\Application;
```

```php
namespace App\Shared\Infrastructure;
```

```php
namespace App\Shared\CrossCutting;
```

---

# 20. Rotas

Utilizar uma única aplicação Laravel com arquivos de rotas separados logicamente.

Estrutura:

```text
routes/
├── api.php
├── auth.php
├── person.php
├── admin.php
└── site.php
```

Cada arquivo deve representar apenas seu contexto.

---

# 21. Rotas obrigatórias de validação

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

# 22. Exemplo de rota Auth

Exemplo conceitual:

```php
<?php

use Illuminate\Support\Facades\Route;

Route::get('/auth', function () {
    return 'Olá Mundo - Auth API';
});
```

A localização e o carregamento do arquivo de rotas devem respeitar a versão do Laravel definida no projeto.

Não alterar o bootstrap além do necessário para registrar os arquivos de rota.

---

# 23. Controllers

Nesta etapa não é obrigatório criar Controllers.

Os endpoints `Olá Mundo` podem utilizar closures para manter o bootstrap mínimo.

Exemplo:

```php
Route::get('/auth', function () {
    return 'Olá Mundo - Auth API';
});
```

Controllers devem ser introduzidos somente quando as primeiras features forem implementadas.

---

# 24. Service Providers

Não criar Service Providers customizados nesta etapa sem necessidade real.

Não registrar antecipadamente:

```text
Repositories
Handlers
Command Bus
Query Bus
Domain Event Dispatcher
Clients externos
Mensageria
```

Utilizar os mecanismos padrão do Laravel.

---

# 25. Banco de dados

Laravel possui suporte a persistência, porém nesta etapa ela não deve ser implementada para o domínio.

Não criar:

```text
Models de negócio
Migrations de negócio
Seeders
Factories
Repositories concretos
Queries de banco
```

Não executar migrations como parte obrigatória deste bootstrap.

---

# 26. Eloquent

Não utilizar Eloquent como representação automática das entidades de domínio.

Não criar antecipadamente:

```text
User.php
Person.php
Role.php
Permission.php
```

como Models de negócio apenas porque essas entidades poderão existir futuramente.

A estratégia entre:

```text
Domain
 ↕
Persistence / Eloquent
```

deverá ser definida quando a persistência for implementada.

---

# 27. CQRS

A aplicação será preparada conceitualmente para CQRS.

Estrutura:

```text
Application
├── Command
└── Query
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

CQRS será implementado através de tasks futuras.

---

# 28. Domain Events

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

# 29. Autenticação

Embora exista um módulo:

```text
Auth
```

não implementar autenticação nesta etapa.

Não instalar antecipadamente:

```text
Laravel Sanctum
Laravel Passport
JWT
OAuth
```

O módulo Auth nesta etapa representa somente uma divisão arquitetural futura.

---

# 30. Configuração `.env`

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

Não configurar integrações externas nesta etapa.

---

# 31. Dependências Composer

Não instalar bibliotecas adicionais sem uma task específica.

Evitar antecipadamente:

```text
Laravel Sanctum
Laravel Passport
Doctrine
MongoDB
Kafka clients
RabbitMQ clients
Laravel Horizon
Laravel Telescope
Laravel Octane
Spatie packages
CQRS libraries
Event Sourcing libraries
OpenTelemetry
Sentry
```

Utilizar apenas o Laravel e suas dependências padrão.

---

# 32. Testes

Manter:

```text
tests/
├── Unit
└── Feature
```

Nesta etapa os testes devem se limitar, quando necessários, ao bootstrap.

Não criar testes para regras de negócio inexistentes.

---

# 33. Instalação

Criar a aplicação Laravel conforme a versão definida.

Exemplo conceitual:

```bash
composer create-project laravel/laravel backend
```

Entrar:

```bash
cd backend
```

Instalar dependências:

```bash
composer install
```

Validar:

```bash
php artisan --version
```

---

# 34. Autoload

Após criar namespaces/classes, quando necessário:

```bash
composer dump-autoload
```

Resultado esperado:

```text
Generating optimized autoload files
```

Não devem existir erros PSR-4.

---

# 35. Validação das rotas

Executar:

```bash
php artisan route:list
```

Devem existir os endpoints de validação:

```text
GET /api/auth
GET /api/person
GET /api/admin
GET /api/site
```

---

# 36. Executar aplicação

Executar:

```bash
php artisan serve
```

Exemplo padrão:

```text
http://127.0.0.1:8000
```

Validar:

```text
GET /api/auth
GET /api/person
GET /api/admin
GET /api/site
```

Respostas esperadas:

```text
Olá Mundo - Auth API
Olá Mundo - Person API
Olá Mundo - Admin API
Olá Mundo - Site API
```

---

# 37. README inicial

O arquivo:

```text
backend/README.md
```

deve conter apenas informações essenciais.

Exemplo:

```markdown
# MeuProjeto Backend

Backend do projeto MeuProjeto.

## Tecnologia

- PHP
- Laravel
- Composer

## Arquitetura

Monólito Modular.

## Módulos

- Auth
- Person
- Admin
- Site

## Estrutura

- Modules
- Shared
- Application
- Domain
- Infrastructure
- Http

## Instalação

```bash
composer install
```

## Executar

```bash
php artisan serve
```

## Rotas

```bash
php artisan route:list
```
```

---

# 38. `.gitignore`

Utilizar o `.gitignore` padrão do Laravel.

Garantir que não sejam versionados:

```text
/vendor/
/node_modules/
.env
.phpunit.result.cache
.phpunit.cache
.idea/
.vscode/
.DS_Store
Thumbs.db
```

Não ignorar `.env.example`.

---

# 39. Convenções

Utilizar:

```text
PSR-4
PSR-12
Composer
Namespaces
Tipagem PHP quando aplicável
declare(strict_types=1) quando adotado pelo projeto
```

Evitar abstrações prematuras.

---

# 40. Evolução futura

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

# 41. Monólito Modular x Microserviços

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

# 42. Critérios de aceite

O starter está concluído somente quando:

- [ ] pasta `backend` criada;
- [ ] uma única aplicação Laravel criada;
- [ ] apenas um `composer.json` principal;
- [ ] `app/Modules` criado;
- [ ] módulo Auth criado;
- [ ] módulo Person criado;
- [ ] módulo Admin criado;
- [ ] módulo Site criado;
- [ ] `app/Shared` criado;
- [ ] estrutura Application criada;
- [ ] estrutura Domain criada;
- [ ] estrutura Infrastructure criada;
- [ ] estrutura Http criada;
- [ ] namespaces respeitam PSR-4;
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
- [ ] nenhum Model de negócio criado;
- [ ] nenhuma autenticação implementada;
- [ ] nenhuma mensageria configurada;
- [ ] nenhum frontend criado;
- [ ] nenhum Docker criado;
- [ ] `composer install` executa sem erro;
- [ ] `composer dump-autoload` executa sem erro;
- [ ] `php artisan --version` executa sem erro;
- [ ] `php artisan route:list` executa sem erro;
- [ ] `php artisan serve` inicia a aplicação.

---

# 43. Regras para IA / Copilot

Ao utilizar este arquivo como prompt/contexto para IA:

1. Criar somente o backend.
2. Utilizar PHP com Laravel.
3. Criar **uma única aplicação Laravel**.
4. Utilizar arquitetura de **Monólito Modular**.
5. Não criar quatro instalações Laravel.
6. Criar módulos `Auth`, `Person`, `Admin` e `Site`.
7. Criar `Shared`.
8. Não criar frontend.
9. Não implementar features.
10. Não criar CRUDs.
11. Não criar entidades de negócio.
12. Não criar Aggregates.
13. Não implementar Commands.
14. Não implementar Queries.
15. Não implementar Handlers.
16. Não implementar Domain Events.
17. Não configurar banco de dados de negócio.
18. Não criar migrations de negócio.
19. Não criar seeders.
20. Não criar factories.
21. Não criar Eloquent Models de negócio.
22. Não configurar MongoDB.
23. Não configurar Redis.
24. Não configurar Kafka.
25. Não configurar RabbitMQ.
26. Não implementar autenticação.
27. Não instalar Sanctum.
28. Não instalar Passport.
29. Não instalar JWT.
30. Não criar Jobs.
31. Não criar Queues.
32. Não criar Workers.
33. Não criar Scheduler customizado.
34. Não criar Docker.
35. Não criar Docker Compose.
36. Não instalar pacotes Composer antecipadamente.
37. Utilizar apenas um `composer.json` principal.
38. Utilizar autoload PSR-4 padrão `App\\`.
39. Manter o Domain independente do Laravel sempre que possível.
40. Não utilizar Eloquent diretamente como Domain Entity.
41. Não colocar regras de negócio em Controllers.
42. Não criar Service Providers customizados sem necessidade.
43. Não criar Middleware customizado sem necessidade.
44. Não criar integrações externas.
45. Não adicionar arquitetura complexa antecipadamente.
46. Criar somente as quatro rotas de validação definidas.
47. Manter o código mínimo e executável.
48. Respeitar a direção das dependências.
49. Evitar dependência direta entre módulos.
50. Caso alguma informação necessária não esteja definida, utilizar `A DEFINIR`.
51. Não inventar versões de PHP ou Laravel.
52. Não expandir o escopo sem solicitação explícita.

---

# 44. Resultado esperado

Ao final deve existir:

```text
                 HTTP
                  ↓
               Laravel
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

Http
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

Com apenas uma aplicação Laravel.

Sem microserviços.

Sem funcionalidades de negócio.

Sem persistência de negócio.

Sem autenticação.

Sem mensageria.

Sem frontend.

Sem Docker.

Sem CQRS funcional.

Sem Domain Events.

O desenvolvimento funcional começa somente após a aprovação deste bootstrap e criação das tasks específicas.
