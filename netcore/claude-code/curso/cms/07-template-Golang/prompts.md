# INSTALAÇÃO E CONFIGURAÇÃO DO KIT IA DEV

Você vai me ajudar a instalar, configurar e adaptar o **Kit IA Dev** ao meu projeto.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar arquivos do Kit. Você deve configurar o Kit para que a ferramenta de IA de código compreenda e preserve a arquitetura, as regras de negócio e os padrões definidos neste prompt.

---

# 1. CONTEXTO

Pacotes disponíveis:

- Kit IA Dev
- Templates por Stack
- Skills Avançadas

Ferramenta de IA utilizada:

- Claude Code; ou
- outra ferramenta de IA de código compatível com instruções de projeto e/ou Agent Skills no padrão `SKILL.md`.

Stack principal:

```text
Go
Golang
Go Modules
```

Go é a linguagem principal.

Não escolha automaticamente:

- framework HTTP;
- router;
- ORM;
- query builder;
- banco;
- migration tool;
- mensageria;
- cache;
- dependency injection framework.

Antes de configurar o projeto, identifique se ele utiliza:

### HTTP / Web

- `net/http`;
- Gin;
- Echo;
- Fiber;
- Chi;
- outro framework/router.

### Persistência

- `database/sql`;
- pgx;
- GORM;
- Ent;
- sqlc;
- Bun;
- outro mecanismo.

### Dependências

Identifique:

```text
go.mod
go.sum
```

e preserve Go Modules.

Se alguma decisão ainda não estiver definida, apresente opções relevantes e solicite confirmação antes de adotar uma.

---

# 2. ARQUIVOS E PASTAS QUE POSSO FORNECER

Os contextos podem ser fornecidos como pasta ou ZIP.

## Kit principal

```text
Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev.zip
```

## Projeto

A raiz do repositório onde o Kit será instalado.

## Templates por Stack

```text
Order-Bump-Templates-por-Stack/
```

ou:

```text
Kit-IA-Dev-Templates-por-Stack.zip
```

## Skills Avançadas

```text
Upsell1-Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev-Skills-Avancadas.zip
```

Se algum arquivo necessário não estiver disponível, solicite:

- caminho absoluto; ou
- ZIP correspondente.

Não invente conteúdo que deveria ser obtido desses pacotes.

Não copie arquivos antes de confirmar a raiz correta do projeto.

---

# 3. FORMA DE CONDUÇÃO

Execute o processo em etapas.

Regras obrigatórias:

- execute um passo por vez;
- informe resumidamente o resultado de cada etapa;
- espere minha confirmação antes da próxima etapa;
- não altere silenciosamente decisões arquiteturais;
- não substitua esta arquitetura por uma arquitetura Go genérica;
- não simplifique camadas apenas porque Go favorece soluções simples;
- não introduza frameworks ou bibliotecas por preferência;
- não crie abstrações sem responsabilidade real;
- se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas objetivas;
- converse comigo em PT-BR.

Conteúdo técnico destinado à IA, como:

```text
CLAUDE.md
AGENTS.md
agent_docs/
SKILL.md
```

deve permanecer em inglês, salvo quando o arquivo original estabelecer outro padrão.

Antes de sobrescrever arquivos importantes, identifique-os e explique brevemente a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para aplicações **CRUD/CMS com Golang**.

A experiência administrativa é inspirada no gerenciamento de conteúdo do WordPress.

Administradores devem conseguir gerenciar:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação.

O site público deve refletir páginas, menus e conteúdos publicados sem exigir alteração manual de código para páginas básicas.

A inspiração no WordPress é exclusivamente relacionada à experiência administrativa de conteúdo.

Não fazem parte do escopo:

- plugins;
- marketplace;
- temas instaláveis;
- widgets;
- page builder complexo;
- extensões instaláveis.

Não transforme o projeto em um clone arquitetural do WordPress.

---

# 5. ESTRUTURA DO REPOSITÓRIO

Primeiro inspecione a estrutura existente.

Uma organização conceitual possível:

```text
/
├── cmd/
│   └── api/
│       └── main.go
│
├── internal/
│   ├── domain/
│   ├── application/
│   ├── infrastructure/
│   ├── api/
│   └── shared/
│
├── migrations/
├── tests/
├── .claude/
│   └── skills/
├── docker/
├── docker-compose.yml
├── go.mod
├── go.sum
└── ...
```

Essa estrutura não deve ser imposta literalmente quando o projeto existente utilizar outra organização válida.

A arquitetura lógica obrigatória é:

```text
Domain
Application
Infrastructure
API
Presentation
```

As fronteiras devem ser preservadas independentemente da organização física.

---

# 6. CONVENÇÕES GO

Respeite convenções idiomáticas de Go.

Não tente reproduzir literalmente estruturas de:

- C#;
- Java;
- NestJS;
- Laravel;
- Python.

DDD e CQRS devem ser adaptados ao estilo de Go.

Evite:

- abstrações sem necessidade;
- interfaces gigantes;
- inheritance-style design;
- packages artificiais;
- excesso de factories;
- excesso de wrappers;
- interfaces criadas apenas para “seguir arquitetura”.

Arquitetura empresarial não significa abandonar simplicidade idiomática.

Ao mesmo tempo:

**simplicidade não significa remover as fronteiras arquiteturais obrigatórias deste projeto.**

---

# 7. REGRA ARQUITETURAL PRINCIPAL

**NÃO simplifique, substitua ou descaracterize a arquitetura definida neste prompt.**

Todo CRUD deve respeitar conceitualmente:

```text
Domain
    ↓
Application
    ↓
Infrastructure
    ↓
API
    ↓
Presentation
```

O Domain não deve depender diretamente de:

- HTTP;
- router;
- Gin;
- Echo;
- Fiber;
- Chi;
- GORM;
- SQL;
- banco;
- mensageria;
- frontend.

Não concentre regras de negócio em:

- HTTP handlers;
- routes;
- database models;
- repository implementations;
- middleware;
- frontend.

Não transforme toda aplicação em:

```text
Handler
   ↓
Service
   ↓
Repository
   ↓
Database
```

apenas porque essa estrutura é simples.

As regras de negócio permanecem no Domain.

---

# 8. ARQUITETURA

Utilize, conforme responsabilidade:

- Domain Driven Design;
- CQRS;
- Event Sourcing quando aplicável;
- Unit of Work quando necessário;
- Repository Pattern;
- Result Pattern quando apropriado à convenção do projeto;
- Domain Events;
- Domain Notifications quando apropriadas;
- Domain Validations;
- Dependency Inversion.

Não utilize um padrão apenas porque ele está listado.

Cada padrão deve possuir responsabilidade real.

---

# 9. DOMÍNIOS INICIAIS

Os domínios iniciais são:

```text
Identity
Content
Navigation
```

Uma organização conceitual pode seguir:

```text
internal/
├── domain/
│   ├── identity/
│   ├── content/
│   └── navigation/
│
├── application/
│   ├── identity/
│   ├── content/
│   └── navigation/
│
├── infrastructure/
└── api/
```

Preserve nomes e organização existentes quando equivalentes.

---

# 10. DOMAIN

O Domain é responsável por:

- Aggregates;
- Entities;
- Value Objects;
- Domain Events;
- Domain Services;
- Domain Validations;
- invariantes;
- regras de negócio;
- contratos necessários para acesso externo.

Exemplo conceitual:

```text
internal/domain/content/
├── page.go
├── page_status.go
├── page_events.go
├── page_repository.go
├── errors.go
└── ...
```

Não crie obrigatoriamente uma pasta para cada tipo.

Em Go, arquivos coesos dentro do mesmo package podem ser preferíveis.

Evite estruturas como:

```text
entities/
valueobjects/
repositories/
events/
services/
```

quando elas fragmentarem artificialmente um package pequeno.

A separação conceitual continua obrigatória mesmo quando os arquivos compartilham o mesmo package.

---

# 11. PACKAGES

Packages devem possuir propósito claro.

Prefira packages orientados a:

- domínio;
- feature;
- bounded context;
- responsabilidade arquitetural.

Evite packages genéricos gigantes como:

```text
utils
helpers
common
misc
models
services
```

sem responsabilidade claramente definida.

`internal/` deve ser considerado quando fizer sentido para impedir imports externos indevidos.

Não utilize `pkg/` automaticamente.

Use `pkg/` somente quando o projeto realmente possuir packages destinados ao consumo externo.

---

# 12. ENTITIES

Entities possuem identidade e comportamento.

Exemplo conceitual:

```go
type Page struct {
    id          PageID
    title       string
    slug        Slug
    status      PageStatus
    publishedAt *time.Time
}
```

O exemplo é conceitual.

Não copie literalmente sem analisar as convenções do projeto.

Evite structs completamente anêmicas quando o domínio possuir comportamento.

---

# 13. VALUE OBJECTS

Value Objects podem representar conceitos como:

```text
PageID
UserID
Slug
Email
MenuLocation
```

Não transforme todos os tipos primitivos em Value Objects.

Crie-os quando encapsularem:

- validação;
- normalização;
- invariantes;
- comportamento;
- semântica relevante.

---

# 14. ENCAPSULAMENTO

Preserve invariantes utilizando encapsulamento apropriado.

Evite expor campos mutáveis quando isso permitir violar regras do Aggregate.

Prefira comportamentos explícitos.

Exemplo:

```go
page.Publish(now)
```

em vez de:

```go
page.Status = StatusPublished
```

quando publicação possuir regras de domínio.

---

# 15. APPLICATION

Application é responsável por:

- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- Use Cases;
- DTOs internos;
- orquestração.

Estrutura conceitual:

```text
internal/application/content/page/
├── create/
├── update/
├── delete/
├── publish/
├── get/
└── list/
```

ou organização equivalente.

Não crie dezenas de packages minúsculos sem necessidade.

Preserve coesão.

---

# 16. CQRS

Fluxo de escrita:

```text
HTTP Request
      ↓
Command
      ↓
Command Handler
      ↓
Domain Aggregate
      ↓
Repository
      ↓
Persistence
```

Fluxo de leitura:

```text
HTTP Request
      ↓
Query
      ↓
Query Handler
      ↓
Read Repository / Read Model
      ↓
Response
```

Exemplo:

```text
PublishPageCommand
        ↓
PublishPageHandler
        ↓
Page Aggregate
        ↓
Publish()
        ↓
PagePublished
        ↓
Repository
```

CQRS não exige automaticamente bancos separados.

CQRS não exige automaticamente Event Sourcing.

CQRS não exige automaticamente uma biblioteca externa.

---

# 17. COMMANDS E QUERIES

Commands representam intenção de alteração.

Queries representam leitura.

Exemplos:

```text
CreatePageCommand
UpdatePageCommand
DeletePageCommand
PublishPageCommand

GetPageQuery
ListPagesQuery
```

Não crie Commands/Queries vazios apenas para afirmar que CQRS existe.

Handlers devem possuir responsabilidade clara.

Invariantes permanecem no Domain.

---

# 18. CONTEXT

Utilize `context.Context` corretamente nas fronteiras de operações.

Quando apropriado, propague:

```go
context.Context
```

por:

- handlers;
- repositories;
- database operations;
- chamadas externas;
- mensageria.

Não armazene `context.Context` dentro de structs de longa duração sem necessidade.

Não utilize `context.Background()` para ignorar contexto recebido de uma requisição.

Domain puro não deve depender de `context.Context` quando a regra de negócio não necessita de preocupação operacional.

---

# 19. ERRORS

Utilize errors de forma idiomática.

Pode existir:

```go
var ErrPageNotFound = errors.New("page not found")
```

ou tipos de erro específicos quando necessário.

Preserve:

```go
errors.Is
errors.As
```

quando aplicável.

Não compare mensagens de erro como contrato.

Não utilize panic para fluxo comum de negócio.

Panic deve ficar reservado a condições realmente excepcionais ou invariantes de inicialização quando apropriado.

---

# 20. RESULT PATTERN

O projeto original utiliza Result Pattern como princípio arquitetural.

Em Go, primeiro analise a convenção existente.

Go possui naturalmente:

```go
value, err := operation()
```

Portanto, não crie automaticamente uma abstração genérica complexa `Result[T]` se ela apenas duplicar o mecanismo idiomático de `error`.

Quando o projeto exigir Result Pattern para representar múltiplas informações de negócio, implemente-o de maneira simples e explícita.

A adaptação deve preservar a intenção do padrão sem lutar contra a linguagem.

---

# 21. DOMAIN NOTIFICATIONS

Domain Notifications podem existir quando houver necessidade de acumular ou transportar múltiplas violações/regras.

Não crie um framework de notifications apenas por obrigação.

Mantenha separação entre:

```text
Domain Error
Domain Notification
Validation Error
Application Error
HTTP Error
Infrastructure Error
```

quando esses conceitos forem realmente utilizados.

---

# 22. DOMAIN VALIDATIONS

Validação de transporte não substitui validação de domínio.

Domain Validation protege:

- invariantes;
- transições;
- consistência;
- regras de negócio.

Exemplo:

```go
func (p *Page) Publish(now time.Time) error {
    // domain invariants
}
```

O comportamento exato deve seguir o modelo do projeto.

---

# 23. INFRASTRUCTURE

Infrastructure é responsável por:

- banco;
- persistência;
- repositories concretos;
- migrations;
- mensageria;
- cache;
- filesystem;
- e-mail;
- integrações;
- adapters externos.

Exemplo:

```text
internal/infrastructure/
├── persistence/
├── repository/
├── messaging/
├── cache/
├── mail/
└── integrations/
```

Não deixe detalhes técnicos vazarem para Domain.

---

# 24. REPOSITORY PATTERN

Contratos devem ser definidos próximos de quem os consome ou conforme convenção arquitetural existente.

Exemplo conceitual:

```go
type PageRepository interface {
    FindByID(ctx context.Context, id PageID) (*Page, error)
    Save(ctx context.Context, page *Page) error
}
```

Não crie interfaces gigantes.

Não crie interfaces antecipadamente para todo struct.

Em Go, prefira interfaces pequenas e orientadas ao consumidor.

A implementação concreta pertence à Infrastructure.

---

# 25. PERSISTÊNCIA

Não escolha automaticamente:

- GORM;
- Ent;
- sqlc;
- Bun;
- pgx;
- `database/sql`.

Primeiro analise o projeto.

Preserve a tecnologia existente.

Se nenhuma estiver definida, apresente opções antes de escolher.

Não transforme automaticamente:

```text
Persistence Model = Domain Entity
```

Quando separados:

```text
Domain Entity
      ↕
Mapper
      ↕
Persistence Model
```

---

# 26. DATABASE/SQL

Se o projeto utilizar `database/sql`, preserve essa decisão.

Não introduza ORM apenas para reduzir SQL.

Se utilizar pgx, preserve pgx.

Se utilizar sqlc, preserve:

- queries;
- generated code;
- configuração;
- separação entre generated persistence code e Domain.

Código gerado não deve receber regras de negócio manuais.

---

# 27. ORM

Se GORM, Ent, Bun ou outro ORM estiver presente, trate-o como detalhe de Infrastructure.

Não deixe tags ou APIs específicas do ORM contaminarem Domain quando houver separação de modelos.

Exemplo conceitual:

```text
Domain:
Page

Infrastructure:
PageModel
PageMapper
```

Não crie duplicação sem necessidade.

A separação deve existir quando proteger as fronteiras arquiteturais.

---

# 28. UNIT OF WORK / TRANSAÇÕES

Utilize transações quando um caso de uso exigir atomicidade.

Não crie Unit of Work artificial se a tecnologia existente já fornecer abstração adequada.

Não espalhe:

```go
tx.Commit()
tx.Rollback()
```

por regras de domínio.

A Application/Infrastructure deve controlar fronteiras transacionais.

---

# 29. MIGRATIONS

Identifique a ferramenta existente.

Pode existir:

- golang-migrate;
- Goose;
- Atlas;
- migrations próprias;
- mecanismo de ORM;
- outro.

Não escolha ferramenta automaticamente.

Preserve migrations históricas.

Para mudanças novas, crie nova migration quando apropriado.

Não altere migrations já aplicadas em ambientes compartilhados apenas para simplificar histórico.

---

# 30. API / HTTP

A camada API é a fronteira HTTP.

Pode conter:

```text
internal/api/
├── handlers/
├── routes/
├── middleware/
├── request/
├── response/
└── errors/
```

Handlers devem:

1. receber a requisição;
2. extrair parâmetros;
3. validar aspectos de transporte;
4. converter entrada;
5. executar Command/Query/Use Case;
6. converter resultado;
7. retornar resposta HTTP.

Handlers não devem possuir regras de domínio.

---

# 31. NET/HTTP

Se o projeto utilizar apenas:

```text
net/http
```

preserve essa decisão.

Não introduza framework HTTP apenas porque é mais conveniente.

A standard library é uma opção válida.

Use recursos da versão Go existente.

Não adote APIs de versões mais recentes sem verificar `go.mod`.

---

# 32. FRAMEWORK HTTP

Se o projeto utilizar:

- Gin;
- Echo;
- Fiber;
- Chi;
- outro;

preserve a escolha.

Framework HTTP é detalhe de entrada.

Não deixe APIs específicas do framework se propagarem para Application e Domain.

Por exemplo, não passe:

```text
gin.Context
echo.Context
fiber.Ctx
```

para Domain.

---

# 33. REQUEST / RESPONSE DTOs

DTOs HTTP representam contratos de transporte.

Exemplo:

```go
type CreatePageRequest struct {
    Title string `json:"title"`
    Slug  string `json:"slug"`
}
```

Não utilize DTO HTTP como Domain Entity.

Não exponha diretamente modelos de persistência na API sem analisar riscos e contratos.

---

# 34. JSON

Preserve contratos JSON existentes.

Não altere nomes de campos silenciosamente.

Não exponha campos internos/sensíveis.

Não dependa apenas de `omitempty` para definir regras de domínio.

Validação JSON e validação de negócio são responsabilidades diferentes.

---

# 35. MIDDLEWARE

Middleware pode cuidar de responsabilidades transversais como:

- authentication;
- tracing;
- correlation ID;
- logging;
- CORS;
- rate limiting;
- recovery.

Middleware não deve concentrar regras específicas do Domain.

---

# 36. IDENTITY

Relacionamento:

```text
User
  → Roles
      → Permissions
```

User, Role e Permission são conceitos distintos.

Permissions representam operações autorizadas.

A API é a autoridade final para autorização.

Frontend não é fronteira de segurança.

---

# 37. AUTENTICAÇÃO

Antes de implementar, analise o projeto.

Pode existir:

- sessão;
- JWT;
- OAuth 2;
- OpenID Connect;
- Identity Provider;
- outro mecanismo.

Não escolha JWT automaticamente.

Não implemente autenticação própria quando já existir mecanismo apropriado.

Passwords nunca devem ser armazenadas em texto puro.

Secrets nunca devem ser versionados.

---

# 38. AUTORIZAÇÃO

Cada CRUD deve definir permissions.

Exemplo:

```text
Page.Read
Page.Create
Page.Update
Page.Delete
Page.Publish
```

O backend deve validar permissions.

A UI pode ocultar ações, mas isso não substitui autorização real.

Middleware pode realizar autenticação/autorização de fronteira.

Casos de uso também devem proteger operações quando necessário.

---

# 39. CONTENT

## Page

Modelo inicial:

```text
Page
- Id
- Title
- Slug
- Body/Content
- Status
- PublishedAt
- CreatedAt
- UpdatedAt
- Version
```

Estados iniciais:

```text
Draft → Published
```

Quando explicitamente definidos:

```text
Published → Draft/Unpublished
Published → Archived
```

Não introduza novos estados automaticamente.

Transições devem possuir regras explícitas.

Prefira:

```go
page.Publish(now)
```

a alterar diretamente o status quando houver invariantes.

---

# 40. NAVIGATION

## Menu

```text
Menu
- Id
- Name
- Location
- Items
```

## MenuItem

```text
MenuItem
- Id
- MenuId
- Label
- PageId ou Url
- ParentId
- Order
- IsVisible
```

Menus devem permitir:

- hierarquia;
- ordenação;
- páginas internas;
- URLs externas;
- visibilidade;
- resolução pública.

As invariantes permanecem no Domain.

---

# 41. ADMIN E SITE

O sistema possui:

```text
Admin
Site
```

Admin deve gerenciar:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação.

Site deve resolver:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação pública.

Não escolha frontend automaticamente.

Se existir frontend separado, preserve a tecnologia existente.

---

# 42. DOMAIN EVENTS

Exemplos:

```text
PagePublished
UserRoleChanged
MenuUpdated
```

Não confunda:

```text
Domain Event
```

com:

```text
Message Broker Event
Database Hook
Integration Event
HTTP Event
```

Domain Events pertencem ao modelo de negócio.

Integration Events pertencem à integração entre sistemas/processos.

---

# 43. EVENT SOURCING

Utilize Event Sourcing somente quando aplicável.

Não transforme CRUDs simples em Event Sourcing.

Quando utilizado, defina:

- Aggregate;
- Event Stream;
- Event Store;
- versão;
- reconstrução;
- concorrência;
- snapshots quando necessários.

CQRS não implica Event Sourcing.

---

# 44. MENSAGERIA

Quando necessária, preserve separação entre:

```text
Domain Event
Integration Event
Message
```

Tecnologias podem incluir, quando já definidas ou aprovadas:

- Kafka;
- RabbitMQ;
- NATS;
- SQS;
- Google Pub/Sub;
- Redis Streams;
- outras.

Não instale broker automaticamente.

---

# 45. GOROUTINES

Não crie goroutines indiscriminadamente.

Antes de:

```go
go doSomething()
```

considere:

- lifecycle;
- cancellation;
- context;
- error handling;
- backpressure;
- shutdown;
- observabilidade.

Não utilize goroutines para esconder latência ou ignorar erros.

---

# 46. CHANNELS

Use channels quando comunicação concorrente realmente exigir.

Não utilize channels apenas porque são característica de Go.

Não transforme fluxo simples em arquitetura concorrente desnecessária.

Defina claramente:

- produtor;
- consumidor;
- ownership;
- fechamento;
- cancelamento.

---

# 47. CONCURRENCY

Código concorrente deve evitar:

- data races;
- goroutine leaks;
- deadlocks;
- writes concorrentes inseguras;
- ausência de cancelamento.

Quando apropriado, valide com:

```text
go test -race
```

Não introduza mutexes ou atomics sem necessidade.

---

# 48. BACKGROUND WORKERS

Quando houver processamento assíncrono, workers devem consumir Application Use Cases quando apropriado.

Não duplique regras de negócio dentro de consumers.

Exemplo conceitual:

```text
Message
   ↓
Consumer
   ↓
Application Command
   ↓
Handler
   ↓
Domain
```

---

# 49. CACHE

Cache não é fonte primária da verdade.

Se páginas ou menus publicados forem armazenados em cache, defina estratégia explícita de invalidação.

Não instale Redis automaticamente.

Preserve mecanismo existente.

---

# 50. LOGGING

Identifique a estratégia existente.

Pode utilizar:

- `log/slog`;
- biblioteca existente;
- logging estruturado definido pelo projeto.

Não adicione biblioteca apenas por preferência.

Logs não devem expor:

- passwords;
- tokens;
- secrets;
- dados sensíveis desnecessários.

---

# 51. CONFIGURAÇÃO

Identifique mecanismo existente.

Pode utilizar:

- environment variables;
- flags;
- arquivos de configuração;
- biblioteca específica.

Não instale Viper automaticamente.

Não acesse environment variables diretamente em todo Domain.

Centralize configuração na composição/infrastructure quando apropriado.

---

# 52. DEPENDENCY INJECTION

Go não exige container de Dependency Injection.

Prefira composição explícita quando apropriado.

Exemplo conceitual:

```go
repository := NewPostgresPageRepository(db)
handler := NewPublishPageHandler(repository)
controller := NewPageHandler(handler)
```

Não instale automaticamente:

- Wire;
- Fx;
- Dig;
- outro container.

Se o projeto já utilizar uma dessas ferramentas, preserve-a.

---

# 53. COMPOSITION ROOT

A composição da aplicação pode ocorrer em:

```text
cmd/api/main.go
```

ou package de bootstrap apropriado.

O Composition Root pode configurar:

- config;
- logger;
- database;
- repositories;
- handlers;
- HTTP server;
- messaging;
- graceful shutdown.

Não coloque regras de negócio em `main.go`.

---

# 54. GO MODULES

Preserve:

```text
go.mod
go.sum
```

Antes de adicionar dependências:

1. analise `go.mod`;
2. verifique se já existe solução;
3. valide compatibilidade com a versão Go;
4. adicione apenas quando necessário.

Não altere o module path sem autorização.

Não execute upgrades indiscriminados.

Não remova dependências sem analisar seu uso.

---

# 55. GO VERSION

Identifique a versão em:

```text
go.mod
Dockerfile
CI
toolchain
```

quando disponível.

Não atualize a versão automaticamente.

Não utilize funcionalidades incompatíveis com a versão declarada.

Se a versão não estiver definida de forma suficiente, peça confirmação antes de adotar uma.

---

# 56. GENERATED CODE

Identifique código gerado.

Pode existir:

- sqlc;
- Ent;
- mocks;
- protobuf;
- OpenAPI;
- GraphQL;
- outro gerador.

Não edite manualmente arquivos gerados quando a alteração deva ocorrer na fonte do gerador.

Identifique comentários como:

```text
Code generated ... DO NOT EDIT.
```

e preserve o fluxo de geração.

---

# 57. CODE GENERATION

Se o projeto utilizar:

```go
//go:generate
```

preserve os comandos existentes.

Não introduza code generation sem necessidade.

Documente claramente a origem de código gerado.

---

# 58. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

Sempre que for solicitado um novo CRUD, verifique:

- [ ] Aggregate/Entity criado no Domain quando aplicável
- [ ] Invariantes definidas
- [ ] Value Objects criados quando necessários
- [ ] Domain Events definidos quando necessários
- [ ] Domain Validations implementadas
- [ ] Repository contract definido quando necessário
- [ ] Commands criados
- [ ] Queries criadas
- [ ] Command Handlers implementados
- [ ] Query Handlers implementados
- [ ] Use Cases implementados quando apropriado
- [ ] Result/error strategy respeitada
- [ ] Domain Notifications aplicadas quando necessárias
- [ ] Persistence Model criado quando necessário
- [ ] Mapper criado quando Domain/Persistence estiverem separados
- [ ] Repository concreto implementado
- [ ] Transaction/Unit of Work respeitado quando aplicável
- [ ] Migration criada quando necessária
- [ ] Composition/Dependency Injection atualizada
- [ ] HTTP Handler implementado
- [ ] Routes atualizadas
- [ ] Request/Response DTOs implementados
- [ ] Validation implementada
- [ ] Permissions definidas
- [ ] Autorização validada no backend
- [ ] Admin implementado
- [ ] Site implementado quando aplicável
- [ ] Unit Tests criados
- [ ] Integration Tests criados
- [ ] E2E/API Tests criados quando apropriado
- [ ] `go.mod` atualizado somente quando necessário
- [ ] Docker atualizado quando necessário

Não considere o CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 59. TESTES

Devem existir conceitualmente:

```text
Unit
Integration
E2E/API
```

A organização física deve seguir as convenções Go existentes.

Não é obrigatório criar uma árvore Java-style de testes se o projeto utiliza `_test.go` próximo ao código.

## Unit Tests

Devem validar:

- Aggregates;
- Entities;
- Value Objects;
- invariantes;
- Domain Services;
- Domain Validations;
- transições;
- Commands/Handlers quando apropriado.

Utilize:

```text
*_test.go
```

conforme convenções Go.

Domain Unit Tests não devem iniciar banco ou servidor HTTP desnecessariamente.

---

# 60. TABLE-DRIVEN TESTS

Quando apropriado, utilize table-driven tests.

Exemplo conceitual:

```go
tests := []struct {
    name    string
    input   ...
    want    ...
    wantErr bool
}{
    // cases
}
```

Não force table-driven tests quando um teste direto for mais legível.

Legibilidade possui prioridade sobre ritual.

---

# 61. INTEGRATION TESTS

Devem validar integrações reais quando necessário:

- repositories;
- SQL;
- ORM;
- migrations;
- banco;
- cache;
- mensageria.

Devem utilizar ambiente TEST.

Nunca DEV.

Podem utilizar:

- banco TEST do Docker Compose;
- containers descartáveis;
- mecanismo já adotado pelo projeto.

Não escolha automaticamente uma biblioteca de containers.

---

# 62. E2E/API TESTS

Devem poder:

1. iniciar dependências necessárias;
2. utilizar banco TEST;
3. aplicar migrations;
4. iniciar API;
5. executar HTTP requests;
6. validar autenticação;
7. validar autorização;
8. validar persistência;
9. limpar estado.

O teste deve ser repetível.

---

# 63. MOCKS

Não gere mocks para tudo automaticamente.

Prefira fakes/stubs simples quando forem suficientes.

Se o projeto utilizar geração de mocks, preserve a ferramenta existente.

Não instale mockgen, mockery ou equivalente automaticamente.

Interfaces pequenas tornam testes mais simples.

---

# 64. TEST COMMANDS

Preserve comandos existentes.

Conceitualmente:

```text
go test ./...
```

Quando apropriado:

```text
go test -race ./...
```

Se o projeto possuir tags para integration tests, preserve a convenção.

Não introduza build tags sem necessidade.

---

# 65. BANCO DEV E TEST

Devem existir ambientes isolados:

```text
database-dev
database-test
```

Regras:

- testes nunca utilizam DEV;
- migrations devem executar em TEST;
- limpeza de TEST não afeta DEV;
- configurações devem tornar a separação explícita;
- credenciais podem ser distintas.

---

# 66. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz.

Deve contemplar pelo menos:

- aplicação Go;
- banco DEV;
- banco TEST.

Quando necessário:

- frontend;
- Redis;
- Kafka;
- RabbitMQ;
- NATS;
- mail testing;
- workers;
- outras dependências realmente utilizadas.

Não adicione infraestrutura sem necessidade.

---

# 67. DOCKERFILE

Antes de alterar:

- identifique versão Go;
- analise build existente;
- preserve multi-stage build quando apropriado;
- identifique CGO;
- identifique dependências nativas;
- identifique arquitetura alvo.

Uma estratégia comum pode separar:

```text
builder
runtime
```

mas não force um modelo quando o projeto possuir requisitos diferentes.

Não utilize automaticamente `latest`.

---

# 68. GRACEFUL SHUTDOWN

Servidores e workers devem possuir shutdown adequado quando necessário.

Considere:

- sinais do sistema;
- HTTP server shutdown;
- database connections;
- consumers;
- workers;
- goroutines;
- timeouts.

Não deixe goroutines ou conexões abertas durante encerramento normal.

---

# 69. HEALTH CHECKS

Quando necessários, health checks podem representar:

```text
liveness
readiness
```

Não coloque lógica de negócio nesses endpoints.

Não exponha informações sensíveis.

Preserve padrão existente.

---

# 70. FRONTEND

Se existir frontend separado:

```text
/
├── backend/
├── frontend/
├── .claude/
│   └── skills/
└── docker-compose.yml
```

Se React estiver presente:

```text
frontend/src/
├── admin/
├── site/
└── shared/
```

Admin e Site não devem importar internals um do outro.

O backend Go permanece a autoridade final para autorização.

---

# 71. TEMPLATE DO KIT

Não trate esta stack simplesmente como:

```text
Go
```

A arquitetura real é:

```text
Go
+ DDD
+ CQRS
+ CMS/CRUD
+ Admin/Site
+ User/Role/Permission
```

Portanto:

1. analise os templates;
2. identifique templates Go/Golang;
3. identifique template do framework/router quando existir;
4. não force Node.js, Java, Python ou PHP;
5. verifique se o template preserva Domain/Application/Infrastructure/API;
6. rejeite template simplificado incompatível;
7. se nenhum preservar a arquitetura, utilize:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

8. adapte o template genérico;
9. as regras deste prompt têm precedência.

---

# 72. CONFIGURAÇÃO DO CLAUDE.md

Leia `SETUP NOTE`.

Resolva todos os `[FILL]`.

Registre:

- Go;
- versão Go;
- module path;
- framework/router;
- DDD/CQRS;
- Domain/Application/Infrastructure/API;
- Identity/Content/Navigation;
- User/Role/Permission;
- persistência;
- migrations;
- transações;
- segurança;
- mensageria quando aplicável;
- DEV/TEST;
- testes;
- Docker;
- Admin/Site;
- checklist obrigatório de CRUD.

Não atualize versões apenas porque existem versões mais recentes.

Depois de resolver os `[FILL]`, remova `SETUP NOTE` conforme orientação do Kit.

---

# 73. MULTI-TOOL

Se necessário, configure:

```text
AGENTS.md
```

ou equivalente.

Existe uma única arquitetura.

Não crie regras divergentes entre:

- CLAUDE.md;
- AGENTS.md;
- Agent Skills;
- documentação dos agentes.

---

# 74. SKILLS DO KIT

Instale as 10 skills existentes em:

```text
Kit-IA-Dev/3-Skills/
```

Copie pastas completas.

Preserve:

```text
SKILL.md
references/
arquivos auxiliares
```

Para Claude Code:

```text
.claude/skills/
```

quando aplicável.

---

# 75. SKILLS AVANÇADAS

Depois:

1. localize as 8 skills novas;
2. instale as pastas completas;
3. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

4. aplique os 8 patches correspondentes.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não remova essas skills.

---

# 76. SKILLS ESPECÍFICAS DO PROJETO

Configure pelo menos:

```text
project-architecture
golang-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
content-management
navigation-management
persistence
testing
docker-development
```

Quando necessário, adapte instruções específicas para a tecnologia real.

Exemplos:

```text
go-http-api
go-sql-persistence
go-messaging
```

Evite criar skills redundantes.

---

# 77. GERAÇÃO DE CRUD

Quando receber:

```text
"crie um CRUD de produtos"
```

não gere apenas:

```text
Product struct
ProductHandler
ProductService
ProductRepository
```

A IA deve considerar:

```text
Product Domain
        ↓
Aggregate / Entity
        ↓
Value Objects
        ↓
Invariants
        ↓
Domain Events
        ↓
Repository Contract
        ↓
Commands
        ↓
Queries
        ↓
Handlers / Use Cases
        ↓
Result / Error Strategy
        ↓
Infrastructure
        ↓
Persistence Model
        ↓
Mapper, quando necessário
        ↓
Repository Implementation
        ↓
Transaction / Unit of Work
        ↓
Migration
        ↓
Composition Root
        ↓
HTTP Handler
        ↓
Routes
        ↓
Request / Response DTOs
        ↓
Permissions
        ↓
Authorization
        ↓
Admin
        ↓
Site, quando aplicável
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E/API Tests
        ↓
go.mod, quando necessário
        ↓
Docker, quando necessário
```

---

# 78. VALIDAÇÃO DA INSTALAÇÃO

## Validação 1 — Kit

Execute:

```text
"revise este código"
```

ou:

```text
"escreva o commit"
```

ou:

```text
"isso está lento"
```

Confirme que a skill apropriada foi utilizada.

## Validação 2 — Arquitetura

Execute:

```text
"crie um CRUD de categorias"
```

Confirme:

- Domain;
- Application;
- Commands;
- Queries;
- Infrastructure;
- Persistence;
- API;
- Permissions;
- Admin;
- testes;
- Site quando aplicável.

## Validação 3 — CMS

Execute:

```text
"adicione gerenciamento de páginas"
```

Confirme:

- Page;
- Draft/Published;
- invariantes;
- Commands;
- Queries;
- permissions;
- Admin;
- API;
- persistência;
- migrations;
- publicação;
- Site;
- testes.

---

# 79. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso aos Templates.
3. Confirmar acesso às Skills Avançadas.
4. Confirmar raiz do projeto.
5. Inspecionar estrutura existente.
6. Identificar ferramenta de IA.
7. Identificar diretório de Agent Skills.
8. Identificar versão Go.
9. Analisar `go.mod`.
10. Identificar module path.
11. Analisar `go.sum`.
12. Identificar organização de packages.
13. Identificar `cmd/`, `internal/` e `pkg/` quando existentes.
14. Identificar framework/router HTTP.
15. Identificar persistência.
16. Identificar banco.
17. Identificar migrations.
18. Identificar transações/Unit of Work.
19. Identificar autenticação.
20. Identificar autorização.
21. Identificar mensageria.
22. Identificar cache.
23. Identificar estratégia de logging.
24. Identificar testes.
25. Identificar geração de código.
26. Identificar frontend.
27. Analisar Docker.
28. Analisar templates.
29. Avaliar template Go.
30. Utilizar template genérico quando necessário.
31. Configurar `CLAUDE.md`.
32. Configurar multi-tool.
33. Instalar as 10 skills básicas.
34. Instalar as 8 skills avançadas.
35. Aplicar os 8 patches.
36. Criar/adaptar skills específicas.
37. Validar conflitos/duplicações.
38. Validar arquitetura.
39. Validar ativação das skills.
40. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 80. PROIBIÇÕES

Não faça sem instrução explícita:

- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar fronteiras arquiteturais;
- transformar tudo em Handler + Service + Repository;
- colocar regras de negócio em HTTP Handlers;
- colocar invariantes somente em validação HTTP;
- transformar Persistence Model automaticamente em Domain Entity;
- colocar autorização somente no frontend;
- utilizar banco DEV nos testes;
- compartilhar DEV e TEST;
- criar entidade `Content` universal sem analisar invariantes;
- criar arquitetura de plugins WordPress;
- adicionar marketplace;
- adicionar sistema de temas;
- adicionar page builder;
- escolher Gin automaticamente;
- escolher Echo automaticamente;
- escolher Fiber automaticamente;
- escolher Chi automaticamente;
- escolher GORM automaticamente;
- escolher Ent automaticamente;
- escolher sqlc automaticamente;
- escolher pgx automaticamente;
- escolher PostgreSQL automaticamente;
- escolher Redis automaticamente;
- escolher Kafka/RabbitMQ/NATS automaticamente;
- instalar framework de Dependency Injection automaticamente;
- criar interfaces para todo struct;
- criar packages artificiais apenas para reproduzir Java/C#;
- utilizar goroutines indiscriminadamente;
- utilizar channels indiscriminadamente;
- ignorar erros;
- utilizar panic como fluxo comum;
- atualizar Go indiscriminadamente;
- atualizar dependências indiscriminadamente;
- alterar module path sem autorização;
- editar manualmente código gerado quando a fonte deve ser alterada;
- implementar Event Sourcing indiscriminadamente;
- confundir Integration Events com Domain Events;
- armazenar secrets no repositório;
- sobrescrever código existente sem análise prévia.

Quando houver conflito entre:

```text
sugestão genérica do Kit
        vs
convenção simplificada da biblioteca/framework Go
        vs
regras específicas deste projeto
```

**AS REGRAS ESPECÍFICAS DESTE PROJETO TÊM PRECEDÊNCIA.**

Ao mesmo tempo, adapte os padrões ao estilo idiomático de Go.

Não crie arquitetura cerimonial apenas para imitar outras linguagens.

---

# 81. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial Golang para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS, separação entre Domain/Application/Infrastructure/API, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, persistência isolada das regras de domínio, testes reais e ambientes Docker DEV/TEST.

A IA deve compreender que:

> Go idiomático e arquitetura empresarial não são objetivos conflitantes.

DDD e CQRS devem ser implementados preservando as fronteiras necessárias sem reproduzir artificialmente padrões específicos de Java, C#, Node.js ou outros ecossistemas.

Ao receber:

```text
"crie um CRUD de produtos"
```

ela não deve considerar suficiente criar:

```text
Product
ProductHandler
ProductService
ProductRepository
```

Ela deve analisar os itens aplicáveis:

```text
Product Domain
        ↓
Aggregate / Entity
        ↓
Value Objects / Invariants
        ↓
Domain Events
        ↓
Repository Contract
        ↓
Commands / Queries
        ↓
Handlers / Use Cases
        ↓
Error / Result Strategy
        ↓
Infrastructure
        ↓
Persistence Model / Mapper
        ↓
Repository Implementation
        ↓
Transaction
        ↓
Migration
        ↓
Composition Root
        ↓
HTTP API
        ↓
Permissions / Authorization
        ↓
Admin
        ↓
Site, quando aplicável
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E/API Tests
        ↓
go.mod, quando necessário
        ↓
Docker, quando necessário
```

---

# INÍCIO

Comece somente pela **Etapa 1**.

Confirme se você consegue acessar:

1. Kit IA Dev;
2. pacote Templates por Stack;
3. pacote Skills Avançadas;
4. raiz do meu projeto.

Se algum deles não estiver disponível no contexto, solicite apenas o caminho absoluto ou o ZIP correspondente.

**Não copie, altere ou crie arquivos ainda.**

Espere minha confirmação antes de continuar para a próxima etapa.