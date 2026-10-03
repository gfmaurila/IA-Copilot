# INSTALAÇÃO E CONFIGURAÇÃO DO KIT IA DEV

Você vai me ajudar a instalar, configurar e adaptar o **Kit IA Dev** ao meu projeto.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar arquivos do Kit.

Você deve configurar o Kit para que a ferramenta de IA de código compreenda e preserve:

- arquitetura;
- regras de negócio;
- organização do projeto;
- padrões C++;
- persistência;
- segurança;
- testes;
- Docker;
- convenções de build;
- padrões definidos neste prompt.

---

# 1. CONTEXTO

Pacotes disponíveis:

- Kit IA Dev
- Templates por Stack
- Skills Avançadas

Ferramenta de IA utilizada:

- Claude Code; ou
- outra ferramenta compatível com instruções de projeto e Agent Skills no padrão `SKILL.md`.

Stack principal:

```text
C++
```

O projeto é um **backend CRUD empresarial em C++**.

Não existe frontend neste cenário.

Não crie:

- React;
- Vue;
- Angular;
- páginas web;
- Admin UI;
- Site UI;
- templates HTML;

a menos que isso seja solicitado explicitamente posteriormente.

Antes de configurar o projeto, identifique:

- versão/padrão C++;
- compilador;
- sistema de build;
- package manager;
- framework HTTP;
- persistência;
- banco;
- migrations;
- bibliotecas de testes;
- serialização;
- logging;
- configuração;
- segurança.

Não escolha essas tecnologias automaticamente.

---

# 2. ARQUIVOS E PASTAS QUE POSSO FORNECER

## Kit principal

```text
Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev.zip
```

## Projeto

Raiz do repositório onde o Kit será instalado.

## Templates

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

Se algo necessário não estiver disponível, solicite:

- caminho absoluto; ou
- ZIP correspondente.

Não invente conteúdo que deveria ser obtido dos pacotes.

Não altere arquivos antes de confirmar a raiz correta do projeto.

---

# 3. FORMA DE CONDUÇÃO

Execute o processo em etapas.

Regras:

- execute um passo por vez;
- informe resumidamente o resultado;
- espere minha confirmação;
- não altere decisões arquiteturais silenciosamente;
- não simplifique a arquitetura;
- não introduza bibliotecas por preferência;
- preserve código e convenções existentes;
- adapte padrões ao ecossistema C++;
- não reproduza artificialmente arquitetura Java/C#/Node/Python em C++;
- faça no máximo 1 ou 2 perguntas quando existir ambiguidade relevante;
- converse comigo em PT-BR.

Arquivos técnicos destinados à IA, como:

```text
CLAUDE.md
AGENTS.md
SKILL.md
agent_docs/
```

devem permanecer em inglês, salvo quando o padrão existente determinar outra coisa.

Antes de sobrescrever arquivos importantes, explique a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para desenvolvimento de **APIs CRUD em C++**.

Deve fornecer uma base reutilizável para criação de recursos como:

```text
Users
Roles
Permissions
Products
Categories
Customers
Orders
Pages
Menus
```

quando esses domínios forem necessários.

O foco é:

```text
HTTP API
+
Domain
+
Application
+
Infrastructure
+
Persistence
+
Security
+
Tests
```

Não existe camada frontend obrigatória.

---

# 5. FILOSOFIA C++

A arquitetura deve seguir boas práticas de C++.

Não tente reproduzir literalmente estruturas de:

- Java;
- C#;
- NestJS;
- Laravel;
- Python.

Utilize naturalmente os recursos de C++:

- RAII;
- deterministic lifetime;
- value semantics;
- move semantics;
- smart pointers;
- templates quando apropriados;
- `std::optional`;
- `std::variant`;
- `std::expected` quando disponível e compatível;
- exceptions quando essa for a estratégia do projeto;
- interfaces abstratas somente quando necessárias;
- const-correctness;
- ownership explícito.

Arquitetura empresarial não significa criar abstrações artificiais.

Ao mesmo tempo:

**C++ idiomático não significa eliminar Domain, Application, Infrastructure e API.**

---

# 6. ESTRUTURA DO PROJETO

Primeiro inspecione a estrutura existente.

Uma estrutura conceitual possível:

```text
/
├── src/
│   ├── domain/
│   ├── application/
│   ├── infrastructure/
│   ├── api/
│   └── shared/
│
├── include/
├── tests/
│   ├── unit/
│   ├── integration/
│   └── e2e/
│
├── migrations/
├── cmake/
├── docker/
├── .claude/
│   └── skills/
├── CMakeLists.txt
├── CMakePresets.json
├── docker-compose.yml
└── ...
```

Essa estrutura é conceitual.

Não reorganize automaticamente um projeto existente somente para fazê-lo coincidir com esse exemplo.

---

# 7. ARQUITETURA PRINCIPAL

A arquitetura lógica deve preservar:

```text
Domain
    ↓
Application
    ↓
Infrastructure
    ↓
API
```

O sentido acima representa fluxo conceitual, não dependência obrigatória entre todos os módulos.

As dependências de código devem preservar Dependency Inversion.

O Domain deve permanecer independente de detalhes técnicos.

---

# 8. REGRA ARQUITETURAL PRINCIPAL

**NÃO simplifique, substitua ou descaracterize esta arquitetura.**

Não concentre regras de negócio em:

- HTTP Controllers;
- HTTP Handlers;
- Routes;
- ORM Models;
- SQL;
- Repository implementations;
- serializers;
- middleware.

Não considere suficiente:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Database
```

As regras de negócio pertencem ao Domain.

---

# 9. PADRÕES ARQUITETURAIS

Utilize quando aplicáveis:

- Domain Driven Design;
- CQRS;
- Repository Pattern;
- Unit of Work;
- Result Pattern;
- Domain Events;
- Domain Validations;
- Domain Notifications;
- Dependency Inversion;
- Event Sourcing quando realmente necessário.

Não implemente um padrão somente porque ele aparece nesta lista.

Cada abstração deve possuir responsabilidade concreta.

---

# 10. DOMAIN

Domain é responsável por:

- Aggregates;
- Entities;
- Value Objects;
- invariantes;
- regras de negócio;
- Domain Events;
- Domain Services;
- Domain Validations;
- contratos necessários.

Exemplo:

```text
src/domain/
├── identity/
├── product/
├── category/
└── order/
```

Dentro de um domínio:

```text
product/
├── product.hpp
├── product.cpp
├── product_id.hpp
├── product_events.hpp
├── product_repository.hpp
└── product_errors.hpp
```

Não crie uma pasta para cada conceito se isso fragmentar excessivamente o código.

---

# 11. ENTITIES

Entities possuem identidade e comportamento.

Exemplo conceitual:

```cpp
class Product {
public:
    [[nodiscard]] const ProductId& id() const noexcept;
    [[nodiscard]] const std::string& name() const noexcept;

    Result<void> rename(std::string name);
    Result<void> change_price(Money price);

private:
    ProductId id_;
    std::string name_;
    Money price_;
};
```

O exemplo é conceitual.

Não copie essa implementação automaticamente.

A implementação real deve seguir:

- padrão C++;
- versão C++;
- estratégia de erros;
- convenções existentes.

---

# 12. VALUE OBJECTS

Utilize Value Objects quando agregarem significado real.

Exemplos:

```text
ProductId
UserId
Email
Money
Slug
Quantity
```

Um Value Object pode encapsular:

- validação;
- normalização;
- comparação;
- invariantes;
- comportamento.

Não crie wrappers triviais para todos os tipos primitivos.

---

# 13. VALUE SEMANTICS

Prefira value semantics quando apropriado.

Evite alocação dinâmica desnecessária.

Não transforme todos os objetos em:

```cpp
std::shared_ptr<T>
```

Use pointers somente quando ownership, polimorfismo ou lifetime exigirem.

---

# 14. OWNERSHIP

Ownership deve ser explícito.

Analise antes de utilizar:

```cpp
T*
std::unique_ptr<T>
std::shared_ptr<T>
std::weak_ptr<T>
```

Preferências conceituais:

```text
value
↓
unique ownership
↓
shared ownership somente quando realmente necessário
```

Não utilize `shared_ptr` como solução padrão.

Raw pointers podem representar referências não proprietárias quando a convenção permitir, mas não devem criar ownership ambíguo.

---

# 15. RAII

Recursos devem utilizar RAII sempre que apropriado.

Isso inclui:

- memória;
- conexões;
- transactions;
- arquivos;
- locks;
- sockets;
- handles.

Evite:

```text
open
...
múltiplos returns
...
manual close
```

quando RAII puder garantir cleanup.

---

# 16. CONST CORRECTNESS

Preserve const-correctness.

Utilize `const` quando fizer parte correta do contrato.

Métodos somente de leitura devem ser marcados adequadamente.

Não utilize `mutable` para contornar design inadequado sem justificativa.

---

# 17. APPLICATION

Application coordena casos de uso.

Responsabilidades:

- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- Use Cases;
- DTOs;
- transações;
- coordenação de repositories;
- coordenação de Domain Events.

Exemplo:

```text
src/application/product/
├── create_product/
├── update_product/
├── delete_product/
├── get_product/
└── list_products/
```

ou organização equivalente.

Não crie classes artificiais apenas para aumentar a quantidade de camadas.

---

# 18. CQRS

Commands alteram estado.

Queries consultam estado.

Fluxo de escrita:

```text
HTTP
 ↓
Command
 ↓
Command Handler
 ↓
Domain
 ↓
Repository
 ↓
Persistence
```

Fluxo de leitura:

```text
HTTP
 ↓
Query
 ↓
Query Handler
 ↓
Read Repository
 ↓
Response
```

CQRS não exige:

- Event Sourcing;
- bancos separados;
- message broker;
- framework CQRS.

---

# 19. COMMANDS

Exemplos:

```text
CreateProductCommand
UpdateProductCommand
DeleteProductCommand
ActivateProductCommand
```

Commands devem representar intenção.

Não coloque infraestrutura dentro do Command.

---

# 20. QUERIES

Exemplos:

```text
GetProductQuery
ListProductsQuery
SearchProductsQuery
```

Queries podem utilizar modelos de leitura otimizados quando necessário.

Não obrigue leitura a reconstruir Aggregate quando isso não tiver benefício.

---

# 21. HANDLERS

Handlers coordenam casos de uso.

Exemplo conceitual:

```text
UpdateProductHandler
    ↓
ProductRepository
    ↓
Product
    ↓
product.rename(...)
    ↓
repository.save(...)
```

O Handler não deve reimplementar invariantes pertencentes ao Product.

---

# 22. RESULT / ERROR HANDLING

A estratégia depende da versão e convenção C++.

Pode utilizar:

- `std::expected` quando suportado;
- implementação equivalente já existente;
- `std::optional` para ausência simples;
- `std::variant`;
- error codes;
- exceptions;
- Result próprio.

Não introduza uma biblioteca de Result automaticamente.

Não misture indiscriminadamente:

```text
exceptions
+
error codes
+
Result
```

sem uma estratégia definida.

---

# 23. EXCEPTIONS

Primeiro identifique a estratégia existente.

Se exceptions forem utilizadas:

- preserve exception safety;
- diferencie falhas excepcionais de validações comuns;
- não utilize exceptions indiscriminadamente como fluxo normal.

Se o projeto estiver compilado sem exceptions, preserve essa decisão.

---

# 24. DOMAIN EVENTS

Exemplos:

```text
ProductCreated
ProductPriceChanged
UserRoleChanged
```

Domain Event representa algo relevante que ocorreu no Domain.

Não confunda:

```text
Domain Event
Integration Event
Broker Message
Database Trigger
HTTP Event
```

Esses conceitos podem estar relacionados, mas não são equivalentes.

---

# 25. EVENT SOURCING

Utilize somente quando houver necessidade explícita.

Não implemente Event Sourcing para CRUDs comuns.

Quando utilizado, defina:

- Aggregate;
- Event Stream;
- Event Store;
- versionamento;
- reconstrução;
- concorrência;
- snapshots quando necessários.

---

# 26. REPOSITORY

O contrato pertence à fronteira interna apropriada.

Exemplo conceitual:

```cpp
class ProductRepository {
public:
    virtual ~ProductRepository() = default;

    virtual Result<Product> find_by_id(const ProductId& id) = 0;
    virtual Result<void> save(const Product& product) = 0;
};
```

Não copie automaticamente esse formato.

Analise:

- estratégia de erros;
- ownership;
- lifetime;
- necessidade de polimorfismo;
- convenções existentes.

Não crie interface para toda classe.

---

# 27. INFRASTRUCTURE

Infrastructure implementa detalhes técnicos.

Exemplo:

```text
src/infrastructure/
├── persistence/
├── repositories/
├── messaging/
├── logging/
├── configuration/
└── integrations/
```

Pode conter:

```text
PostgresProductRepository
SqliteProductRepository
KafkaPublisher
RabbitMqPublisher
```

somente quando essas tecnologias realmente fizerem parte do projeto.

---

# 28. PERSISTÊNCIA

Não escolha automaticamente:

- PostgreSQL;
- MySQL;
- MariaDB;
- SQLite;
- SQL Server;
- MongoDB.

Primeiro analise o projeto.

Também não escolha automaticamente:

- SOCI;
- ODB;
- sqlpp11;
- SQLiteCpp;
- libpqxx;
- ORM específico;
- query builder específico.

Preserve a tecnologia existente.

---

# 29. DOMAIN MODEL VS PERSISTENCE MODEL

Não assuma:

```text
Database Model = Domain Entity
```

Quando necessário:

```text
Domain Entity
      ↕
Mapper
      ↕
Persistence Model
```

Exemplo:

```text
Product
ProductRecord
ProductMapper
```

Não crie duplicação se ela não proteger nenhuma fronteira real.

---

# 30. SQL

SQL deve permanecer na Infrastructure.

Não espalhe SQL por:

- Domain;
- Application;
- HTTP handlers.

Queries SQL devem:

- utilizar parâmetros;
- evitar SQL injection;
- respeitar transactions;
- tratar erros adequadamente.

Não concatene entrada do usuário diretamente em SQL.

---

# 31. UNIT OF WORK / TRANSACTIONS

Quando um caso de uso exigir atomicidade, utilize transactions.

A estratégia pode ser:

```text
Application
    ↓
Transaction Boundary
    ↓
Repositories
```

Não coloque `commit`/`rollback` dentro de Domain Entities.

Utilize RAII para transactions quando compatível com a biblioteca escolhida.

---

# 32. MIGRATIONS

Identifique a estratégia existente.

Pode utilizar:

- ferramenta própria;
- migrations SQL;
- ferramenta de banco;
- biblioteca externa.

Não escolha ferramenta automaticamente.

Migrations já aplicadas não devem ser alteradas indevidamente.

Novas mudanças devem gerar novas migrations quando apropriado.

---

# 33. API

A API é responsável pela fronteira HTTP.

Exemplo conceitual:

```text
src/api/
├── controllers/
├── handlers/
├── routes/
├── dto/
├── middleware/
├── authentication/
├── authorization/
└── serialization/
```

A estrutura concreta depende do framework utilizado.

---

# 34. FRAMEWORK HTTP

Não escolha automaticamente.

Primeiro identifique se existe:

- Drogon;
- Crow;
- oat++;
- Pistache;
- Boost.Beast;
- RESTinio;
- cpp-httplib;
- outro;
- implementação própria.

Preserve a decisão existente.

Se nenhum estiver definido, apresente opções e solicite confirmação.

---

# 35. HTTP HANDLERS

Handlers devem:

1. receber request;
2. extrair parâmetros;
3. validar transporte;
4. desserializar DTO;
5. executar Command/Query;
6. mapear resultado;
7. serializar response;
8. retornar status HTTP apropriado.

Não devem conter regras de negócio.

---

# 36. SERIALIZAÇÃO

Não escolha automaticamente biblioteca JSON.

Primeiro identifique se existe:

- nlohmann/json;
- RapidJSON;
- Boost.JSON;
- simdjson;
- biblioteca do framework;
- outra.

DTOs de transporte não são Domain Entities.

---

# 37. VALIDATION

Separe:

```text
Transport Validation
Domain Validation
```

Transport Validation:

- JSON válido;
- campos obrigatórios;
- formato;
- tipos.

Domain Validation:

- invariantes;
- transições;
- regras;
- consistência.

Validação HTTP nunca substitui Domain Validation.

---

# 38. IDENTITY

Quando o projeto possuir controle de usuários:

```text
User
  → Roles
      → Permissions
```

Os conceitos são distintos.

Permissions representam operações autorizadas.

---

# 39. AUTHENTICATION

Não escolha automaticamente:

- JWT;
- Session;
- OAuth 2;
- OpenID Connect;
- API Key.

Analise a aplicação.

Não implemente criptografia própria para substituir mecanismos consolidados.

Passwords nunca devem ser armazenadas em texto puro.

Secrets nunca devem ser versionados.

---

# 40. AUTHORIZATION

Cada CRUD deve definir permissions quando segurança por operação fizer parte do sistema.

Exemplo:

```text
Product.Read
Product.Create
Product.Update
Product.Delete
```

A API é responsável por aplicar autorização.

Não dependa de um futuro frontend para segurança.

---

# 41. CRUD BASE

Um CRUD comum pode possuir:

```text
Create
Read
List
Update
Delete
```

Operações adicionais devem representar comportamento real.

Exemplo:

```text
Product.Activate
Product.Deactivate
Order.Cancel
User.ChangeRole
```

Não transforme toda operação de negócio em update genérico.

---

# 42. EXEMPLO: PRODUCT

Modelo conceitual:

```text
Product
- Id
- Name
- Description
- Price
- Status
- CreatedAt
- UpdatedAt
- Version
```

Possíveis comportamentos:

```text
Rename
ChangePrice
Activate
Deactivate
```

Não adicione esses campos ou operações automaticamente a todos os projetos.

Eles servem apenas como exemplo de modelagem rica.

---

# 43. OPTIMISTIC CONCURRENCY

Quando necessário, considere versionamento de Aggregate/registro.

Exemplo conceitual:

```text
Version
```

Não implemente optimistic locking automaticamente.

Utilize quando houver requisito de concorrência.

---

# 44. MEMORY SAFETY

Evite:

- dangling pointers;
- use-after-free;
- double free;
- leaks;
- invalid references;
- ownership ambíguo.

Prefira mecanismos modernos de C++.

Não utilize `new`/`delete` manualmente quando RAII e smart pointers resolverem adequadamente.

---

# 45. MOVE SEMANTICS

Utilize move semantics quando apropriado.

Não utilize `std::move` indiscriminadamente.

Não mova objetos que ainda precisam ser utilizados.

Não sacrifique clareza por micro-otimizações não medidas.

---

# 46. TEMPLATES

Templates C++ devem ser utilizados quando agregarem valor real.

Não transforme toda arquitetura em template metaprogramming.

Evite aumentar:

- complexidade;
- compile time;
- mensagens de erro;
- acoplamento;

sem benefício concreto.

---

# 47. CONCURRENCY

Não introduza concorrência sem necessidade.

Quando houver:

```text
std::thread
std::jthread
std::async
mutex
atomic
condition_variable
coroutines
```

defina claramente:

- ownership;
- lifetime;
- cancellation;
- synchronization;
- error propagation.

Evite data races e deadlocks.

---

# 48. COROUTINES

Não introduza C++ coroutines automaticamente.

Use somente quando:

- versão C++ permitir;
- framework suportar;
- arquitetura justificar.

Preserve o modelo async existente.

---

# 49. LOGGING

Identifique a biblioteca existente.

Pode ser:

- spdlog;
- Boost.Log;
- framework logger;
- solução própria.

Não escolha automaticamente.

Logs não devem expor:

- passwords;
- tokens;
- secrets;
- dados sensíveis desnecessários.

---

# 50. CONFIGURAÇÃO

Identifique mecanismo existente.

Pode utilizar:

- environment variables;
- arquivos;
- command-line options;
- biblioteca específica.

Não espalhe leitura de environment variables pelo Domain.

Centralize configuração na composição/infrastructure.

---

# 51. DEPENDENCY INJECTION

Não instale framework de DI automaticamente.

Prefira composição explícita quando suficiente.

Exemplo conceitual:

```cpp
PostgresProductRepository repository{database};

CreateProductHandler createProduct{repository};

ProductController controller{createProduct};
```

Não crie Service Locator global.

Não transforme singleton em solução padrão de DI.

---

# 52. COMPOSITION ROOT

A inicialização da aplicação deve possuir ponto claro de composição.

Pode configurar:

- config;
- logger;
- database;
- repositories;
- application handlers;
- HTTP server;
- messaging.

Exemplo conceitual:

```text
main.cpp
```

ou bootstrap específico.

`main.cpp` não deve conter regras de negócio.

---

# 53. C++ STANDARD

Identifique primeiro o padrão utilizado:

```text
C++17
C++20
C++23
...
```

Não atualize automaticamente.

Não utilize APIs de C++23 em projeto C++20.

Não rebaixe a versão existente.

A versão deve ser obtida do build/configuração real.

---

# 54. COMPILADOR

Identifique:

- GCC;
- Clang;
- MSVC;
- Apple Clang;
- outro.

Preserve compatibilidade necessária.

Não utilize extensões específicas de compilador sem necessidade ou sem documentá-las.

---

# 55. WARNINGS

Preserve estratégia existente de warnings.

Quando apropriado, projetos podem utilizar warnings rigorosos.

Não adicione `-Werror` indiscriminadamente em todos os ambientes.

Não silencie warnings apenas para fazer o build passar.

Corrija a causa quando apropriado.

---

# 56. BUILD SYSTEM

Identifique o build system existente.

Pode ser:

- CMake;
- Meson;
- Bazel;
- Make;
- outro.

Não escolha CMake automaticamente se outro sistema já estiver definido.

Se nenhum estiver definido, apresente opções antes de decidir.

---

# 57. CMAKE

Se CMake estiver presente, preserve sua estrutura.

Analise:

```text
CMakeLists.txt
cmake/
CMakePresets.json
```

Prefira Modern CMake quando compatível com o projeto.

Utilize targets.

Evite configuração global desnecessária.

Conceitualmente:

```cmake
target_link_libraries(...)
target_include_directories(...)
target_compile_features(...)
```

devem ser preferidos a alterações globais indiscriminadas.

---

# 58. TARGETS

Quando CMake estiver presente, módulos podem ser representados por targets.

Conceitualmente:

```text
domain
application
infrastructure
api
```

As dependências entre targets devem refletir as fronteiras arquiteturais.

Não force um target para cada arquivo ou conceito.

---

# 59. PACKAGE MANAGEMENT

Identifique mecanismo existente.

Pode ser:

- Conan;
- vcpkg;
- CPM.cmake;
- FetchContent;
- package manager do sistema;
- dependências vendorizadas;
- outro.

Não introduza um novo gerenciador automaticamente.

Não misture Conan e vcpkg sem necessidade explícita.

---

# 60. DEPENDÊNCIAS

Antes de adicionar biblioteca:

1. verifique se já existe solução;
2. analise build;
3. analise package manager;
4. valide licença quando relevante;
5. valide compatibilidade;
6. avalie impacto;
7. adicione somente se necessário.

Não atualize todas as dependências apenas porque existe nova versão.

---

# 61. TESTES

Devem existir:

```text
Unit
Integration
E2E/API
```

## Unit Tests

Validam:

- Aggregates;
- Entities;
- Value Objects;
- invariantes;
- Domain Services;
- Commands/Handlers quando apropriado.

Não devem iniciar banco ou servidor HTTP sem necessidade.

## Integration Tests

Validam:

- repositories;
- SQL;
- database;
- migrations;
- adapters;
- mensageria;
- integrações.

Utilizam TEST.

## E2E/API Tests

Devem poder:

1. preparar banco TEST;
2. aplicar migrations;
3. iniciar API;
4. executar requests;
5. validar autenticação;
6. validar autorização;
7. validar persistência;
8. limpar ambiente.

Nunca utilizar DEV.

---

# 62. TEST FRAMEWORK

Identifique primeiro.

Pode existir:

- GoogleTest;
- Catch2;
- doctest;
- Boost.Test;
- outro.

Não escolha automaticamente.

Não substitua framework existente sem autorização.

---

# 63. MOCKS

Não faça mock de tudo.

Use mocks somente quando houver fronteira apropriada.

Se GoogleMock estiver presente, preserve seu uso.

Não adicione GoogleMock automaticamente.

Fakes podem ser mais simples e adequados para repositories em Unit Tests.

---

# 64. SANITIZERS

Quando suportados pelo ambiente e úteis, considere:

```text
AddressSanitizer
UndefinedBehaviorSanitizer
ThreadSanitizer
LeakSanitizer
```

Não habilite todos indiscriminadamente em todos os builds.

Integre-os conforme:

- compilador;
- plataforma;
- CI;
- tipo de teste.

---

# 65. STATIC ANALYSIS

Identifique ferramentas existentes.

Podem existir:

```text
clang-tidy
cppcheck
Sonar
```

Preserve configurações existentes.

Não instale todas automaticamente.

---

# 66. FORMATTING

Se existir:

```text
.clang-format
```

preserve-o.

Não substitua estilo existente por preferência pessoal.

Não faça reformatação massiva não relacionada à tarefa.

---

# 67. DEV E TEST DATABASE

Devem existir ambientes separados:

```text
database-dev
database-test
```

Regras:

- testes nunca usam DEV;
- migrations executam em TEST;
- cleanup de TEST não afeta DEV;
- credenciais/configurações devem ser isoladas.

---

# 68. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz quando Docker fizer parte do projeto.

Deve contemplar pelo menos:

- aplicação C++;
- banco DEV;
- banco TEST.

Quando realmente necessário:

- Redis;
- Kafka;
- RabbitMQ;
- mail testing;
- outras dependências.

Não adicione infraestrutura sem necessidade.

---

# 69. DOCKERFILE

Antes de alterar:

- identifique compiler;
- build system;
- package manager;
- dependências nativas;
- runtime requirements.

Multi-stage build pode ser utilizado quando apropriado:

```text
builder
runtime
```

Não force essa estrutura quando não fizer sentido.

---

# 70. CHECKLIST OBRIGATÓRIO PARA CRUD

Quando receber solicitação de CRUD, verifique:

- [ ] Domain model
- [ ] Aggregate/Entity quando aplicável
- [ ] Value Objects quando necessários
- [ ] Invariantes
- [ ] Domain Validations
- [ ] Domain Events quando necessários
- [ ] Repository contract
- [ ] Commands
- [ ] Queries
- [ ] Command Handlers
- [ ] Query Handlers
- [ ] Error/Result strategy
- [ ] Transaction boundary quando necessária
- [ ] Infrastructure
- [ ] Persistence Model quando necessário
- [ ] Mapper quando necessário
- [ ] Repository implementation
- [ ] Migration
- [ ] API Handler/Controller
- [ ] Routes
- [ ] Request DTO
- [ ] Response DTO
- [ ] Serialization
- [ ] Validation
- [ ] Permissions
- [ ] Authentication quando aplicável
- [ ] Authorization
- [ ] Unit Tests
- [ ] Integration Tests
- [ ] E2E/API Tests
- [ ] Build atualizado quando necessário
- [ ] Dependencies atualizadas somente quando necessárias
- [ ] Docker atualizado quando necessário

Não considere o CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 71. GERAÇÃO DE CRUD

Quando receber:

```text
"crie um CRUD de produtos"
```

não considere suficiente gerar:

```text
Product
ProductController
ProductService
ProductRepository
```

Analise:

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
Handlers
        ↓
Error / Result Strategy
        ↓
Infrastructure
        ↓
Persistence
        ↓
Mapper
        ↓
Repository Implementation
        ↓
Transaction
        ↓
Migration
        ↓
API
        ↓
Request / Response DTOs
        ↓
Serialization
        ↓
Validation
        ↓
Permissions
        ↓
Authorization
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E/API Tests
        ↓
Build
        ↓
Docker
```

---

# 72. SEGURANÇA DE MEMÓRIA E API

Toda implementação deve considerar:

- buffer overflows;
- integer overflow quando relevante;
- dangling references;
- use-after-free;
- unsafe casts;
- unchecked indexing;
- lifetime;
- input validation;
- SQL injection;
- command injection;
- path traversal;
- unsafe deserialization.

Não utilize C-style APIs inseguras quando alternativas adequadas estiverem disponíveis.

---

# 73. PERFORMANCE

Não faça micro-otimização prematura.

Primeiro preserve:

- correção;
- clareza;
- ownership;
- arquitetura;
- segurança.

Quando houver problema de performance:

1. medir;
2. identificar bottleneck;
3. criar benchmark quando apropriado;
4. otimizar;
5. medir novamente.

---

# 74. BENCHMARKS

Não crie benchmarks para todo código.

Utilize quando houver requisito real de performance.

Preserve ferramenta existente.

Não confunda benchmark com Unit Test.

---

# 75. SKILLS DO KIT

Instale as 10 skills existentes em:

```text
Kit-IA-Dev/3-Skills/
```

Copie as pastas completas.

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

# 76. SKILLS AVANÇADAS

Depois:

1. instale as 8 skills novas;
2. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

3. aplique os 8 patches correspondentes.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não remova essas skills.

Mesmo sem frontend, não altere arbitrariamente o conteúdo do pacote original.

Skills irrelevantes podem permanecer instaladas sem serem utilizadas para este projeto.

---

# 77. SKILLS ESPECÍFICAS DO PROJETO

Configure pelo menos:

```text
project-architecture
cpp-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
persistence
api-development
cpp-testing
docker-development
```

Quando necessário:

```text
cmake-build
cpp-memory-safety
```

Evite skills redundantes.

---

# 78. TEMPLATE DO KIT

Não trate esta stack apenas como:

```text
C++
```

A arquitetura real é:

```text
C++
+
Backend API
+
CRUD
+
DDD
+
CQRS
+
Persistence
+
Security
+
Tests
+
Docker DEV/TEST
```

Portanto:

1. analise os templates;
2. identifique templates C++;
3. identifique framework/build system existente;
4. não force template Java/C#/Node/Python;
5. valide se o template preserva a arquitetura;
6. rejeite template incompatível;
7. se nenhum template servir, utilize:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

8. adapte o template genérico.

As regras deste prompt têm precedência.

---

# 79. CLAUDE.md

Leia `SETUP NOTE`.

Resolva os `[FILL]`.

Registre:

- C++;
- C++ standard;
- compiler;
- build system;
- package manager;
- framework HTTP;
- DDD;
- CQRS;
- Domain/Application/Infrastructure/API;
- persistence;
- database;
- migrations;
- authentication;
- authorization;
- error strategy;
- ownership strategy;
- testing;
- DEV/TEST;
- Docker;
- CRUD checklist.

Não atualize versões apenas porque existem versões mais recentes.

Depois de resolver `[FILL]`, remova `SETUP NOTE` conforme orientação do Kit.

---

# 80. MULTI-TOOL

Se necessário, configure:

```text
AGENTS.md
```

ou equivalente.

Existe uma única arquitetura.

Não crie divergência entre:

- CLAUDE.md;
- AGENTS.md;
- Skills;
- documentação dos agentes.

---

# 81. VALIDAÇÃO

## Validação do Kit

Execute:

```text
"revise este código"
```

ou:

```text
"escreva o commit"
```

Confirme a skill apropriada.

## Validação arquitetural

Execute:

```text
"crie um CRUD de categorias"
```

Confirme:

```text
Domain
Application
Commands
Queries
Handlers
Infrastructure
Persistence
Migration
API
Permissions
Unit Tests
Integration Tests
E2E Tests
```

## Validação de domínio

Execute:

```text
"adicione alteração de preço de produto"
```

Confirme que a IA não implementa apenas:

```cpp
product.price = value;
```

quando existirem invariantes.

Ela deve considerar comportamento explícito do Domain.

---

# 82. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar Templates.
3. Confirmar Skills Avançadas.
4. Confirmar raiz do projeto.
5. Inspecionar estrutura.
6. Identificar ferramenta de IA.
7. Identificar diretório de Agent Skills.
8. Identificar versão/padrão C++.
9. Identificar compiler.
10. Identificar plataformas suportadas.
11. Identificar build system.
12. Analisar CMake quando existente.
13. Identificar package manager.
14. Identificar dependências.
15. Identificar framework HTTP.
16. Identificar serialização.
17. Identificar persistência.
18. Identificar banco.
19. Identificar migrations.
20. Identificar transaction strategy.
21. Identificar error strategy.
22. Identificar authentication.
23. Identificar authorization.
24. Identificar logging.
25. Identificar configuration.
26. Identificar framework de testes.
27. Identificar mocks/fakes.
28. Identificar sanitizers.
29. Identificar static analysis.
30. Identificar formatting.
31. Analisar Docker.
32. Analisar templates.
33. Avaliar template C++.
34. Utilizar template genérico quando necessário.
35. Configurar CLAUDE.md.
36. Configurar multi-tool.
37. Instalar as 10 skills.
38. Instalar as 8 skills avançadas.
39. Aplicar os 8 patches.
40. Criar/adaptar skills específicas.
41. Validar conflitos.
42. Validar arquitetura.
43. Validar skills.
44. Executar build.
45. Executar Unit Tests.
46. Executar Integration Tests quando ambiente estiver disponível.
47. Executar E2E/API Tests quando aplicável.
48. Apresentar resumo final.

---

# 83. PROIBIÇÕES

Não faça sem instrução explícita:

- adicionar frontend;
- criar Admin UI;
- criar Site UI;
- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar camadas;
- transformar tudo em Controller + Service + Repository;
- colocar regras de negócio em HTTP handlers;
- colocar regras de negócio no SQL;
- colocar invariantes apenas em validação HTTP;
- escolher framework HTTP automaticamente;
- escolher banco automaticamente;
- escolher ORM automaticamente;
- escolher biblioteca JSON automaticamente;
- escolher GoogleTest automaticamente;
- escolher Catch2 automaticamente;
- escolher Conan automaticamente;
- escolher vcpkg automaticamente;
- escolher CMake automaticamente quando outro build system existir;
- introduzir `shared_ptr` indiscriminadamente;
- introduzir raw ownership;
- utilizar `new/delete` sem necessidade;
- introduzir macros sem necessidade;
- introduzir template metaprogramming sem benefício;
- introduzir concorrência sem necessidade;
- introduzir coroutines automaticamente;
- utilizar exceptions sem verificar estratégia existente;
- desabilitar exceptions sem verificar arquitetura;
- atualizar C++ standard automaticamente;
- atualizar compiler requirements automaticamente;
- atualizar dependências indiscriminadamente;
- editar código gerado indevidamente;
- utilizar banco DEV nos testes;
- compartilhar DEV e TEST;
- implementar Event Sourcing indiscriminadamente;
- armazenar secrets;
- sobrescrever código sem análise.

Quando houver conflito entre:

```text
sugestão genérica do Kit
        vs
padrão trazido de outra linguagem
        vs
convenções idiomáticas C++
        vs
regras específicas deste projeto
```

a prioridade deve ser:

```text
1. Regras específicas deste projeto
2. Arquitetura definida
3. Segurança e correção
4. Convenções idiomáticas C++
5. Convenções do framework/bibliotecas existentes
6. Sugestões genéricas do Kit
```

---

# 84. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde a ferramenta de IA entenda que:

> Este é um template empresarial de backend CRUD/API em C++, sem frontend, utilizando uma arquitetura adaptada às convenções naturais da linguagem, com separação entre Domain, Application, Infrastructure e API, DDD/CQRS quando aplicáveis, persistência isolada do Domain, segurança, testes reais e ambientes Docker DEV/TEST.

A IA deve compreender que:

> Os padrões arquiteturais devem ser adaptados a C++, e não copiados literalmente de Java, C#, Node.js, Python ou PHP.

Também deve compreender que:

> C++ moderno exige atenção explícita a ownership, lifetime, RAII, const-correctness, value semantics, error handling, memory safety e gerenciamento de recursos.

Ao receber:

```text
"crie um CRUD de produtos"
```

ela deve analisar:

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
Commands / Queries
        ↓
Handlers
        ↓
Error Strategy
        ↓
Infrastructure
        ↓
Persistence
        ↓
Transactions
        ↓
Migration
        ↓
HTTP API
        ↓
Serialization / Validation
        ↓
Authentication / Authorization
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E/API Tests
        ↓
Build
        ↓
Docker
```

e implementar somente os elementos aplicáveis, preservando arquitetura e estilo idiomático C++.

---

# INÍCIO

Comece somente pela **Etapa 1**.

Confirme se você consegue acessar:

1. Kit IA Dev;
2. pacote Templates por Stack;
3. pacote Skills Avançadas;
4. raiz do meu projeto.

Se algum deles não estiver disponível no contexto, solicite apenas o caminho absoluto ou ZIP correspondente.

**Não copie, altere ou crie arquivos ainda.**

Espere minha confirmação antes de continuar.