# PROJECT STARTER — BACKEND PYTHON / FASTAPI

> Documento de bootstrap para criação inicial de um backend em Python utilizando FastAPI.
>
> O objetivo deste starter é **somente criar a estrutura técnica inicial do projeto**.
> Nenhuma regra de negócio, integração, persistência, autenticação ou feature deve ser implementada nesta etapa.
>
> A arquitetura inicial será um **Monólito Modular**, utilizando **uma única aplicação FastAPI**.

---

# 1. Objetivo

Criar um backend Python/FastAPI contendo apenas:

- uma única aplicação FastAPI;
- estrutura modular;
- módulos iniciais `Auth`, `Person`, `Admin` e `Site`;
- camada compartilhada `Shared`;
- separação arquitetural preparada para DDD e CQRS;
- rotas mínimas para validação;
- ambiente virtual;
- gerenciamento de dependências;
- aplicação executável;
- testes de bootstrap mínimos, quando aplicável.

Este starter **não implementa funcionalidades de negócio**.

---

# 2. Decisão arquitetural

A aplicação deve iniciar como:

```text
Monólito Modular
```

Não criar quatro aplicações Python independentes.

Estrutura conceitual:

```text
                    FastAPI
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
1 aplicação FastAPI
1 ambiente virtual
1 configuração principal
1 bootstrap
1 processo de deploy
```

Os módulos devem possuir isolamento lógico através de:

```text
Packages
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
| Package raiz | `app` |
| Versão Python | `A DEFINIR` |
| Versão FastAPI | `A DEFINIR` |
| Gerenciador de dependências | `A DEFINIR` |
| Repositório | `A DEFINIR` |
| Responsável técnico | `A DEFINIR` |

Gerenciadores possíveis:

```text
pip
Poetry
uv
```

Nesta etapa não escolher automaticamente se o projeto não definir.

---

# 4. Tecnologias base

Utilizar inicialmente:

```text
Python
FastAPI
Pydantic
Uvicorn
```

Não adicionar bibliotecas externas sem necessidade explícita.

---

# 5. Escopo desta etapa

## Deve ser criado

- pasta `backend/`;
- uma única aplicação FastAPI;
- estrutura `app/modules`;
- módulos `Auth`, `Person`, `Admin` e `Site`;
- estrutura `app/shared`;
- estrutura mínima de `application`, `domain`, `infrastructure` e `presentation`;
- rotas mínimas de validação;
- `README.md`;
- `.gitignore`;
- `.env.example`;
- arquivo de dependências;
- aplicação iniciando sem erro;
- imports funcionando;
- testes de bootstrap mínimos, quando necessários.

## Não deve ser criado

Nesta etapa, **não implementar**:

- frontend;
- CRUDs;
- regras de negócio;
- autenticação;
- autorização;
- JWT;
- OAuth;
- banco de dados funcional;
- migrations;
- seeds;
- models ORM de negócio;
- repositories concretos;
- SQLAlchemy;
- SQLModel;
- Django ORM;
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
├── 📂 app
│   ├── 📂 modules
│   │   ├── 📂 auth
│   │   │   ├── 📂 application
│   │   │   │   ├── 📂 command
│   │   │   │   └── 📂 query
│   │   │   ├── 📂 domain
│   │   │   ├── 📂 infrastructure
│   │   │   ├── 📂 presentation
│   │   │   │   ├── 📂 routers
│   │   │   │   ├── 📂 schemas
│   │   │   │   └── 📂 presenters
│   │   │   └── 📄 __init__.py
│   │   │
│   │   ├── 📂 person
│   │   │   ├── 📂 application
│   │   │   │   ├── 📂 command
│   │   │   │   └── 📂 query
│   │   │   ├── 📂 domain
│   │   │   ├── 📂 infrastructure
│   │   │   ├── 📂 presentation
│   │   │   │   ├── 📂 routers
│   │   │   │   ├── 📂 schemas
│   │   │   │   └── 📂 presenters
│   │   │   └── 📄 __init__.py
│   │   │
│   │   ├── 📂 admin
│   │   │   ├── 📂 application
│   │   │   │   ├── 📂 command
│   │   │   │   └── 📂 query
│   │   │   ├── 📂 domain
│   │   │   ├── 📂 infrastructure
│   │   │   ├── 📂 presentation
│   │   │   │   ├── 📂 routers
│   │   │   │   ├── 📂 schemas
│   │   │   │   └── 📂 presenters
│   │   │   └── 📄 __init__.py
│   │   │
│   │   └── 📂 site
│   │       ├── 📂 application
│   │       │   ├── 📂 command
│   │       │   └── 📂 query
│   │       ├── 📂 domain
│   │       ├── 📂 infrastructure
│   │       ├── 📂 presentation
│   │       │   ├── 📂 routers
│   │       │   ├── 📂 schemas
│   │       │   └── 📂 presenters
│   │       └── 📄 __init__.py
│   │
│   ├── 📂 shared
│   │   ├── 📂 application
│   │   ├── 📂 domain
│   │   ├── 📂 infrastructure
│   │   └── 📂 cross_cutting
│   │
│   ├── 📄 __init__.py
│   └── 📄 main.py
│
├── 📂 tests
│   ├── 📂 unit
│   └── 📂 integration
│
├── 📄 pyproject.toml
├── 📄 requirements.txt
├── 📄 .env.example
├── 📄 .gitignore
└── 📄 README.md
```

> Utilizar **apenas um** mecanismo principal de dependências.
>
> Se o projeto utilizar `pyproject.toml`, `requirements.txt` poderá ser dispensado conforme a ferramenta escolhida.

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
└── presentation
    ├── routers
    ├── schemas
    └── presenters
```

Essa estrutura representa a direção arquitetural futura.

Não criar classes artificiais apenas para preencher pastas.

Utilizar `__init__.py` somente onde necessário para organização/imports do package.

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
FastAPI
Pydantic
Routers
HTTP
Infrastructure
Banco de dados
SQLAlchemy
SQLModel
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
SQLAlchemy
SQLModel
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
Routers
Schemas
Presenters
Dependencies HTTP
Middlewares específicos
```

Fluxo futuro:

```text
HTTP
 ↓
Router
 ↓
Application
 ↓
Domain
```

Routers não devem conter regras de negócio.

---

# 13. Shared

Criar:

```text
app/shared
```

Estrutura:

```text
shared
├── application
├── domain
├── infrastructure
└── cross_cutting
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
Middlewares
Exception Handlers
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
domain -> FastAPI
domain -> Pydantic
application -> presentation
application -> routers
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
Protocols
Interfaces
Event Bus
Facade
```

Não implementar essas estratégias nesta etapa.

---

# 18. main.py

Criar um único:

```text
app/main.py
```

Responsável por:

```text
Criar a aplicação FastAPI
Registrar routers
Iniciar o bootstrap da API
```

Exemplo conceitual:

```python
from fastapi import FastAPI

app = FastAPI()
```

Não adicionar antecipadamente:

```text
CORS customizado
Swagger customizado
Middlewares customizados
Observabilidade
Tracing
Sentry
Rate Limit
```

---

# 19. Routers

Cada módulo deve possuir um router mínimo para validação.

Exemplo:

```text
app/modules/auth/presentation/routers/auth_router.py
```

Exemplo conceitual:

```python
from fastapi import APIRouter

router = APIRouter(prefix="/api/auth")


@router.get("")
def index() -> str:
    return "Olá Mundo - Auth API"
```

---

# 20. Registro dos routers

O `main.py` deve registrar somente os routers necessários.

Exemplo conceitual:

```python
from fastapi import FastAPI

from app.modules.auth.presentation.routers.auth_router import router as auth_router

app = FastAPI()

app.include_router(auth_router)
```

Registrar também os routers:

```text
Person
Admin
Site
```

Não registrar integrações externas nesta etapa.

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

# 22. Schemas

Nesta etapa não criar schemas de negócio.

As pastas:

```text
presentation/schemas
```

podem permanecer vazias.

Pydantic Models devem ser adicionados somente quando existirem features reais.

---

# 23. Dependency Injection

FastAPI possui mecanismo próprio de dependências.

Nesta etapa não criar dependências de negócio.

Não criar antecipadamente:

```text
Repository Providers
Database Session
Auth Dependencies
Command Bus
Query Bus
Event Dispatcher
External Clients
```

Dependency Injection será utilizada conforme as features forem implementadas.

---

# 24. Banco de dados

Nesta etapa não configurar persistência.

Não instalar:

```text
SQLAlchemy
SQLModel
Tortoise ORM
Django ORM
PyMongo
```

Não criar:

```text
ORM Models
Migrations
Database Session
Repository concreto
Database Module
```

Nenhum banco deve ser necessário para executar o starter.

---

# 25. CQRS

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

Não instalar bibliotecas CQRS antecipadamente.

CQRS será implementado através de tasks futuras.

---

# 26. Domain Events

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

# 27. Autenticação

Embora exista um módulo:

```text
auth
```

não implementar autenticação nesta etapa.

Não instalar antecipadamente bibliotecas específicas para:

```text
JWT
OAuth2 customizado
Password Hashing
External Identity Provider
```

O módulo Auth nesta etapa representa somente uma divisão arquitetural futura.

---

# 28. Configuração `.env`

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
PORT=8000
```

---

# 29. Dependências

Utilizar apenas um mecanismo principal de gerenciamento de dependências.

Possibilidades:

```text
requirements.txt
pyproject.toml
Poetry
uv
```

Não manter múltiplos gerenciadores concorrentes sem necessidade.

---

# 30. Dependências iniciais

Dependências mínimas conceituais:

```text
fastapi
uvicorn
```

Pydantic já faz parte do ecossistema FastAPI e deve ser utilizado conforme a versão definida.

Não adicionar pacotes de infraestrutura nesta etapa.

---

# 31. Dependências proibidas nesta etapa

Evitar antecipadamente:

```text
SQLAlchemy
SQLModel
Alembic
PyMongo
Redis
Celery
Dramatiq
Kafka clients
RabbitMQ clients
Sentry
OpenTelemetry
Auth libraries adicionais
CQRS libraries
Event Sourcing libraries
```

---

# 32. Python

Utilizar Python tipado sempre que aplicável.

Exemplo:

```python
def hello() -> str:
    return "Olá Mundo"
```

Evitar código dinâmico desnecessário quando a tipagem puder tornar o contrato mais claro.

---

# 33. Imports

Preferir imports absolutos.

Exemplo:

```python
from app.modules.auth.presentation.routers.auth_router import router
```

Evitar imports relativos excessivos como:

```python
from ....domain import something
```

---

# 34. Naming

Utilizar convenções Python:

```text
snake_case para arquivos, funções e variáveis
PascalCase para classes
UPPER_CASE para constantes
```

Exemplos:

```text
auth_router.py
create_user_command.py
get_user_query.py
user_repository.py
user.py
```

Nesta etapa criar somente os arquivos realmente necessários.

---

# 35. Testes

Manter:

```text
tests/
├── unit
└── integration
```

Nesta etapa os testes devem se limitar, quando necessários, ao bootstrap.

Não criar testes para regras de negócio inexistentes.

---

# 36. Ambiente virtual

Criar ambiente virtual.

Exemplo:

```bash
python -m venv .venv
```

Windows:

```bash
.venv\Scripts\activate
```

Linux/macOS:

```bash
source .venv/bin/activate
```

Não versionar:

```text
.venv/
```

---

# 37. Instalação

Caso utilize `requirements.txt`:

```bash
pip install -r requirements.txt
```

Caso utilize outro gerenciador, utilizar os comandos correspondentes.

Não assumir Poetry ou uv sem definição do projeto.

---

# 38. requirements.txt

Se `pip` for o gerenciador definido, manter inicialmente:

```text
fastapi
uvicorn
```

As versões devem ser definidas pela task ou política do projeto.

Não inventar versões.

---

# 39. pyproject.toml

Caso seja adotado como fonte principal de configuração/dependências, manter o arquivo mínimo.

Não duplicar dependências entre:

```text
pyproject.toml
requirements.txt
```

sem necessidade explícita.

---

# 40. Executar aplicação

Exemplo:

```bash
uvicorn app.main:app --reload
```

Exemplo padrão:

```text
http://127.0.0.1:8000
```

---

# 41. Validação dos endpoints

Validar:

```text
GET http://127.0.0.1:8000/api/auth
GET http://127.0.0.1:8000/api/person
GET http://127.0.0.1:8000/api/admin
GET http://127.0.0.1:8000/api/site
```

Respostas esperadas:

```text
Olá Mundo - Auth API
Olá Mundo - Person API
Olá Mundo - Admin API
Olá Mundo - Site API
```

---

# 42. Qualidade de código

Ferramentas como:

```text
Ruff
Black
Mypy
Pyright
```

podem ser utilizadas futuramente.

Nesta etapa não instalar automaticamente ferramentas adicionais se elas não fizerem parte da definição do projeto.

---

# 43. README inicial

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

- Python
- FastAPI
- Pydantic
- Uvicorn

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

## Ambiente virtual

```bash
python -m venv .venv
```

## Executar

```bash
uvicorn app.main:app --reload
```
```

---

# 44. `.gitignore`

Garantir que não sejam versionados:

```text
.venv/
venv/
__pycache__/
*.py[cod]
.pytest_cache/
.mypy_cache/
.ruff_cache/
.coverage
htmlcov/
dist/
build/
.env
.idea/
.vscode/
.DS_Store
Thumbs.db
```

Não ignorar:

```text
.env.example
```

---

# 45. Convenções

Utilizar:

```text
PEP 8
Type Hints
Packages Python
Imports absolutos
snake_case
PascalCase para classes
```

Evitar abstrações prematuras.

---

# 46. Evolução futura

A arquitetura poderá evoluir para:

```text
HTTP
 ↓
Router
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
- [ ] uma única aplicação FastAPI criada;
- [ ] ambiente virtual documentado;
- [ ] mecanismo de dependências definido;
- [ ] `app/modules` criado;
- [ ] módulo Auth criado;
- [ ] módulo Person criado;
- [ ] módulo Admin criado;
- [ ] módulo Site criado;
- [ ] `app/shared` criado;
- [ ] estrutura application criada;
- [ ] estrutura domain criada;
- [ ] estrutura infrastructure criada;
- [ ] estrutura presentation criada;
- [ ] `app/main.py` criado;
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
- [ ] aplicação inicia sem erro;
- [ ] os quatro endpoints respondem corretamente.

---

# 49. Regras para IA / Copilot

Ao utilizar este arquivo como prompt/contexto para IA:

1. Criar somente o backend.
2. Utilizar Python.
3. Utilizar FastAPI.
4. Utilizar Type Hints.
5. Criar **uma única aplicação FastAPI**.
6. Utilizar arquitetura de **Monólito Modular**.
7. Não criar quatro aplicações independentes.
8. Criar módulos `Auth`, `Person`, `Admin` e `Site`.
9. Criar `Shared`.
10. Não criar frontend.
11. Não implementar features.
12. Não criar CRUDs.
13. Não criar entidades de negócio.
14. Não criar Aggregates.
15. Não implementar Commands.
16. Não implementar Queries.
17. Não implementar Handlers.
18. Não implementar Domain Events.
19. Não configurar banco de dados.
20. Não instalar SQLAlchemy.
21. Não instalar SQLModel.
22. Não instalar Alembic.
23. Não criar migrations.
24. Não configurar MongoDB.
25. Não configurar Redis.
26. Não configurar Kafka.
27. Não configurar RabbitMQ.
28. Não implementar autenticação.
29. Não implementar JWT.
30. Não criar Jobs.
31. Não criar Queues.
32. Não criar Workers.
33. Não criar Scheduler customizado.
34. Não criar Docker.
35. Não criar Docker Compose.
36. Não instalar pacotes antecipadamente.
37. Manter o Domain independente do FastAPI.
38. Não utilizar Pydantic Models como Domain Entities.
39. Não colocar regras de negócio em Routers.
40. Não criar Dependencies customizadas sem necessidade.
41. Não criar Middlewares customizados sem necessidade.
42. Não criar integrações externas.
43. Não adicionar arquitetura complexa antecipadamente.
44. Criar somente os quatro endpoints de validação definidos.
45. Manter o código mínimo e executável.
46. Respeitar a direção das dependências.
47. Evitar dependência direta entre módulos.
48. Utilizar imports absolutos sempre que possível.
49. Utilizar convenções PEP 8.
50. Caso alguma informação necessária não esteja definida, utilizar `A DEFINIR`.
51. Não inventar versões de Python ou FastAPI.
52. Não expandir o escopo sem solicitação explícita.

---

# 50. Resultado esperado

Ao final deve existir:

```text
                 HTTP
                  ↓
                FastAPI
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

Com apenas uma aplicação FastAPI.

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
