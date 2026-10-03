# INSTALAÇÃO E CONFIGURAÇÃO DO KIT IA DEV

Você vai me ajudar a instalar, configurar e adaptar o **Kit IA Dev** ao meu projeto.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar os arquivos do Kit. Você deve configurar o Kit para que a ferramenta de IA de código compreenda e preserve a arquitetura, as regras de negócio e os padrões de desenvolvimento definidos neste prompt.

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
Node.js
TypeScript
NestJS
```

Para instalar skills:

1. Primeiro identifique onde a ferramenta utilizada espera encontrar Agent Skills.
2. Caso isso não esteja claro, consulte `Kit-IA-Dev/3-Skills/COMO-INSTALAR.md`.
3. Nunca copie apenas o `SKILL.md` quando a skill possuir arquivos auxiliares.
4. Copie a pasta inteira da skill, incluindo `references/` e demais arquivos.

---

# 2. ARQUIVOS E PASTAS QUE POSSO FORNECER

Os seguintes contextos podem ser fornecidos como pasta ou ZIP.

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

Se algum arquivo necessário não estiver disponível no contexto, solicite:

- o caminho absoluto da pasta; ou
- o ZIP correspondente.

Não invente conteúdo que deveria ser obtido desses pacotes.

Não copie arquivos antes de confirmar que está trabalhando na raiz correta do projeto.

---

# 3. FORMA DE CONDUÇÃO

Execute o processo em etapas.

Regras obrigatórias:

- Execute um passo por vez.
- Ao final de cada etapa, informe resumidamente o que foi realizado.
- Espere minha confirmação antes de iniciar a próxima etapa.
- Não altere silenciosamente decisões arquiteturais.
- Não substitua a arquitetura definida neste prompt por uma arquitetura NestJS genérica.
- Não simplifique a estrutura para reduzir quantidade de camadas, módulos ou arquivos.
- Se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas objetivas.
- Converse comigo em PT-BR.
- Conteúdo técnico destinado à IA, como `CLAUDE.md`, `AGENTS.md`, `agent_docs`, `SKILL.md` e documentação equivalente, deve permanecer em inglês, salvo quando o arquivo original estabelecer outro padrão.

Antes de sobrescrever arquivos existentes importantes, identifique o arquivo e explique brevemente a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para criação de aplicações **CRUD/CMS com Node.js + NestJS + TypeScript**.

A experiência administrativa é inspirada no gerenciamento de conteúdo do WordPress.

Isso significa que administradores devem conseguir gerenciar:

- usuários;
- roles;
- permissions;
- páginas;
- conteúdos;
- menus;
- publicação de conteúdo.

O site público deve refletir páginas, menus e conteúdos publicados sem exigir alteração manual de código para páginas básicas.

A inspiração no WordPress é exclusivamente relacionada à experiência de administração de conteúdo.

Não fazem parte do escopo:

- plugins;
- marketplace;
- sistema de temas instaláveis;
- widgets;
- page builder complexo;
- extensões instaláveis.

Não transforme o projeto em um clone arquitetural do WordPress.

---

# 5. ESTRUTURA OBRIGATÓRIA DO REPOSITÓRIO

A raiz deve seguir conceitualmente:

```text
/
├── src/
├── test/
├── .claude/
│   └── skills/
├── docker/
├── docker-compose.yml
├── package.json
├── tsconfig.json
├── nest-cli.json
└── ...
```

A aplicação deve ser organizada conceitualmente em:

```text
src/
├── domain/
├── application/
├── infrastructure/
├── api/
├── modules/
└── shared/
```

Responsabilidades:

`src/domain/`
: regras de negócio, Aggregates, Entities, Value Objects, Domain Events, contratos e invariantes.

`src/application/`
: Commands, Queries, Handlers, DTOs e casos de uso.

`src/infrastructure/`
: persistência, repositories concretos, ORM, cache, filas, mensageria e integrações técnicas.

`src/api/`
: Controllers, Guards, Pipes, Interceptors, Filters, Decorators e fronteira HTTP.

`src/modules/`
: composição dos módulos NestJS e conexão das dependências.

`src/shared/`
: recursos realmente compartilhados e independentes de domínio específico.

`test/`
: testes de integração e E2E quando a estrutura do projeto os mantiver fora de `src`.

`.claude/skills/`
: skills específicas do projeto para Claude Code.

`docker-compose.yml`
: orquestra aplicação, banco DEV, banco TEST e demais dependências necessárias.

---

# 6. REGRA ARQUITETURAL PRINCIPAL

Esta regra possui prioridade sobre sugestões genéricas existentes nos templates:

**NÃO simplifique, substitua ou descaracterize a arquitetura definida neste prompt.**

Todo novo CRUD deve respeitar conceitualmente:

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

As dependências devem respeitar as fronteiras arquiteturais.

O Domain não deve depender diretamente de:

- NestJS;
- Controllers;
- DTOs HTTP;
- ORM;
- banco de dados;
- Express;
- Fastify;
- interface administrativa.

Não concentre regras de negócio em:

- Controllers;
- Services genéricos do NestJS;
- ORM Entities/Models;
- Repositories;
- Guards;
- DTOs;
- frontend.

Não substitua a arquitetura por:

```text
Controller
    ↓
Service
    ↓
ORM
    ↓
Database
```

As regras de negócio devem permanecer no domínio.

---

# 7. BACKEND

O backend utiliza:

```text
Node.js
TypeScript
NestJS
```

A arquitetura deve utilizar, conforme a responsabilidade de cada caso:

- Domain Driven Design (DDD);
- CQRS;
- Event Sourcing quando aplicável ao domínio;
- Unit of Work quando necessário;
- Repository Pattern;
- Result Pattern;
- Domain Events;
- Domain Notifications;
- Domain Validations;
- Dependency Injection;
- NestJS Dependency Injection Container.

Não utilize um padrão apenas porque ele está listado.

Utilize cada padrão quando sua responsabilidade arquitetural exigir.

---

# 8. DOMAIN

Estrutura conceitual:

```text
src/domain/
├── identity/
├── content/
└── navigation/
```

Cada domínio pode possuir:

```text
domain-name/
├── aggregates/
├── entities/
├── value-objects/
├── events/
├── repositories/
├── services/
├── validations/
└── exceptions/
```

O Domain é responsável por:

- Aggregates;
- Entities;
- Value Objects;
- Domain Events;
- Domain Validations;
- invariantes;
- regras de negócio;
- contratos de repositories;
- serviços de domínio.

O Domain deve permanecer independente de NestJS sempre que possível.

Não utilize decorators do NestJS em Domain Entities apenas por conveniência.

Não transforme automaticamente entidades do ORM em Domain Entities.

---

# 9. APPLICATION

Estrutura conceitual:

```text
src/application/
├── identity/
├── content/
└── navigation/
```

Uma feature pode seguir:

```text
content/
└── pages/
    ├── commands/
    │   ├── create-page/
    │   ├── update-page/
    │   ├── delete-page/
    │   └── publish-page/
    │
    ├── queries/
    │   ├── get-page/
    │   └── list-pages/
    │
    ├── handlers/
    └── dto/
```

A camada Application é responsável por:

- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- Use Cases;
- DTOs internos;
- Result Pattern;
- orquestração dos casos de uso.

Commands representam intenção de alteração.

Queries representam leitura.

Não utilize CQRS apenas como nomenclatura.

Não crie Commands e Queries vazios apenas para afirmar que CQRS está sendo utilizado.

---

# 10. NESTJS CQRS

O projeto pode utilizar `@nestjs/cqrs` quando essa for a decisão existente ou aprovada.

Nesse cenário podem existir:

```text
Command
CommandHandler

Query
QueryHandler

Event
EventHandler
```

Entretanto:

**NestJS CQRS não substitui o Domain.**

Um `CommandHandler` não deve se transformar em local para todas as regras de negócio.

Exemplo conceitual:

```text
PublishPageCommand
        ↓
PublishPageHandler
        ↓
Page Aggregate
        ↓
page.publish()
        ↓
PagePublished Domain Event
        ↓
Repository
```

A operação:

```text
page.publish()
```

deve proteger as invariantes relacionadas à publicação.

---

# 11. INFRASTRUCTURE

Estrutura conceitual:

```text
src/infrastructure/
├── persistence/
├── repositories/
├── messaging/
├── cache/
├── mail/
├── filesystem/
└── services/
```

Infrastructure é responsável por:

- banco de dados;
- ORM;
- implementação de repositories;
- Unit of Work;
- cache;
- filas;
- mensageria;
- filesystem;
- e-mail;
- integrações externas;
- implementação de contratos das camadas internas.

Não deixe detalhes de infraestrutura vazarem para o Domain sem necessidade.

---

# 12. ORM / PERSISTÊNCIA

O prompt não deve escolher automaticamente um ORM.

Antes de configurar persistência, verifique se o projeto já utiliza:

- Prisma;
- TypeORM;
- MikroORM;
- Sequelize;
- outro mecanismo;
- acesso SQL específico.

Se já existir ORM definido, preserve a decisão.

Se não existir, apresente as opções identificadas e solicite confirmação antes de adotar uma.

Não instale Prisma simplesmente por preferência.

Não instale TypeORM simplesmente porque NestJS possui integração comum com ele.

Não transforme automaticamente:

```text
ORM Entity
=
Domain Entity
```

Quando Domain e persistência estiverem separados, utilize mapeamento explícito.

Exemplo:

```text
Domain
Product

Infrastructure
ProductPersistenceModel

Mapper
ProductMapper
```

O Repository concreto deve converter entre os modelos quando necessário.

---

# 13. API / HTTP

Estrutura conceitual:

```text
src/api/
├── controllers/
├── dto/
├── guards/
├── decorators/
├── pipes/
├── interceptors/
├── filters/
└── middleware/
```

Controllers devem:

1. receber a requisição;
2. validar aspectos HTTP;
3. converter entrada quando necessário;
4. executar Command/Query/Use Case;
5. converter o resultado em resposta HTTP.

Controllers não devem conter regras de domínio.

DTOs HTTP não devem substituir Value Objects de domínio.

Pipes não devem substituir Domain Validations.

Guards não devem substituir regras de autorização existentes no domínio ou caso de uso quando elas forem necessárias fora da fronteira HTTP.

---

# 14. MODULES

NestJS Modules são responsáveis pela composição da aplicação.

Exemplo:

```text
src/modules/
├── identity.module.ts
├── content.module.ts
└── navigation.module.ts
```

Os módulos podem registrar:

- Controllers;
- Handlers;
- Repository implementations;
- providers;
- adapters;
- infraestrutura necessária.

Modules não devem possuir regras de negócio.

Evite módulos gigantes.

Prefira composição coerente com bounded contexts/features.

---

# 15. DOMÍNIOS INICIAIS

Os domínios iniciais são:

```text
Identity
Content
Navigation
```

---

# 16. IDENTITY

Relacionamento conceitual:

```text
User
  → Roles
      → Permissions
```

`User`, `Role` e `Permission` são conceitos distintos.

As Permissions devem representar operações autorizadas pelo sistema.

A API é sempre a autoridade final para autorização.

A interface pode ocultar ou desabilitar funcionalidades conforme as permissões recebidas, mas isso nunca substitui a validação da API.

Uma aplicação pode permitir múltiplas Roles por User conforme o modelo definido durante a implementação.

---

# 17. SEGURANÇA E AUTORIZAÇÃO

A arquitetura deve seguir:

```text
User
  → Role
      → Permission
```

Regras obrigatórias:

- autorização real acontece no backend;
- frontend não é fronteira de segurança;
- esconder botão não significa autorizar ou negar operação;
- endpoints devem validar permissions;
- Guards podem proteger endpoints;
- Decorators podem declarar permissions necessárias;
- casos de uso devem proteger operações quando necessário;
- regras críticas não devem depender exclusivamente da camada HTTP.

Exemplo conceitual:

```typescript
@Permissions('Page.Publish')
@Post(':id/publish')
publish() {}
```

Esse decorator não deve ser considerado suficiente sozinho.

Deve existir mecanismo efetivo de autorização por Guard ou infraestrutura equivalente.

Cada CRUD deve definir permissões por operação.

Exemplo:

```text
Page.Read
Page.Create
Page.Update
Page.Delete
Page.Publish
```

Os nomes definitivos devem seguir a convenção estabelecida pelo projeto.

---

# 18. AUTENTICAÇÃO

Antes de implementar autenticação, analise o projeto existente.

Pode utilizar, conforme decisão arquitetural:

- JWT;
- access token;
- refresh token;
- sessão;
- OAuth/OIDC;
- provedor externo.

Não escolha automaticamente uma estratégia sem analisar o projeto.

Passwords nunca devem ser armazenadas em texto puro.

Secrets não devem ser armazenados no código-fonte.

Configurações sensíveis devem utilizar mecanismos apropriados de ambiente/secrets.

Autenticação e autorização são responsabilidades diferentes.

---

# 19. CONTENT

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

Quando implementado explicitamente pelo domínio, também podem existir:

```text
Published → Draft/Unpublished
Published → Archived
```

Não introduza novos estados automaticamente.

As transições devem possuir regras explícitas de domínio.

Não permita que uma operação equivalente a:

```typescript
page.status = 'published';
await repository.save(page);
```

substitua o comportamento de domínio quando publicação possuir invariantes.

Prefira:

```typescript
page.publish();
```

onde `publish()` aplica as invariantes necessárias.

## Content

Conteúdos devem ser modelados de acordo com a feature e suas invariantes.

Evite criar uma entidade universal `Content` apenas para armazenar qualquer estrutura arbitrária.

Prefira modelos explícitos e semanticamente relevantes.

---

# 20. NAVIGATION

## Menu

Modelo inicial:

```text
Menu
- Id
- Name
- Location
- Items
```

## MenuItem

Modelo inicial:

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
- associação com páginas internas;
- URLs externas;
- visibilidade;
- resolução no Site público.

As regras de hierarquia e ordenação devem ser tratadas como regras do domínio quando possuírem invariantes.

---

# 21. ADMIN E SITE

O projeto possui duas experiências conceituais:

```text
Admin
Site
```

## Admin

Responsável por:

- autenticação;
- dashboard;
- rotas protegidas;
- CRUDs;
- gerenciamento de usuários;
- gerenciamento de roles;
- gerenciamento de permissions;
- gerenciamento de páginas;
- gerenciamento de conteúdos;
- gerenciamento de menus.

## Site

Responsável pela aplicação pública.

Deve consumir a API para resolver:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação pública.

Páginas básicas administráveis devem poder mudar sem alteração manual de código.

A tecnologia concreta do frontend deve respeitar o projeto existente.

Ela pode ser:

- React;
- Next.js;
- Vue;
- Angular;
- outra tecnologia explicitamente aprovada.

Não introduza framework frontend apenas por preferência da IA.

Se o frontend ainda não estiver definido, apresente as opções antes de escolher.

---

# 22. EVENTS

Domain Events representam acontecimentos relevantes do domínio.

Exemplos:

```text
PagePublished
UserRoleChanged
MenuUpdated
```

Domain Events devem ser definidos pelo significado no domínio.

Não confunda automaticamente:

```text
Domain Event
```

com:

```text
NestJS Event
ORM Hook
Message Broker Event
```

Um Domain Event pode posteriormente ser convertido em mensagem de integração.

Mas são responsabilidades diferentes.

---

# 23. EVENT SOURCING

Event Sourcing deve ser utilizado **quando aplicável ao domínio**.

Não implemente Event Sourcing em todo CRUD automaticamente.

Não transforme simples CRUDs em Event Sourcing sem justificativa arquitetural.

Quando utilizado, deve existir clareza sobre:

- Aggregate;
- Event Stream;
- versão;
- reconstrução de estado;
- persistência dos eventos;
- concorrência;
- snapshots quando necessários.

---

# 24. MENSAGERIA

Quando existir processamento assíncrono ou integração por mensagens, mantenha separação entre:

```text
Domain Event
Integration Event
Message
```

A infraestrutura pode utilizar tecnologias como:

```text
RabbitMQ
Kafka
SQS
Redis Streams
ou outra definida pelo projeto
```

Não instale broker automaticamente.

Primeiro verifique as dependências existentes e os requisitos do projeto.

---

# 25. CACHE

Cache é uma otimização técnica.

Não utilize cache como fonte primária da verdade.

Quando páginas, menus ou conteúdos publicados forem armazenados em cache, alterações relevantes devem possuir estratégia explícita de invalidação.

A tecnologia de cache deve respeitar o projeto.

Não instale Redis automaticamente se ele não for necessário.

---

# 26. RESULT PATTERN

Casos de uso devem utilizar Result Pattern conforme a convenção definida no projeto.

Exemplo conceitual:

```text
Result<T>
├── success
├── value
└── errors
```

Não utilize exceptions como mecanismo comum de controle de fluxo de negócio quando Result Pattern for mais apropriado.

Exceptions continuam válidas para situações excepcionais.

O padrão definitivo deve ser consistente no projeto.

---

# 27. DOMAIN NOTIFICATIONS

Domain Notifications podem representar falhas, violações ou informações de domínio quando apropriado.

Não utilize Domain Notifications apenas por obrigação.

Quando utilizadas, mantenha separação entre:

```text
Domain Notification
HTTP Error
Exception
Validation Error
```

A API deve converter os resultados do domínio/aplicação para respostas HTTP adequadas.

---

# 28. VALIDATIONS

Existem diferentes níveis de validação.

## HTTP Validation

Pode utilizar:

```text
DTO
class-validator
Pipes
```

quando essa for a configuração adotada pelo projeto.

Responsável por aspectos como:

- formato;
- campos obrigatórios da requisição;
- tipos;
- estrutura da entrada.

## Domain Validation

Responsável por:

- invariantes;
- regras de negócio;
- transições válidas;
- consistência da entidade/agregado.

Validação HTTP nunca substitui validação de domínio.

---

# 29. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

Sempre que for solicitado um novo CRUD, verifique:

- [ ] Aggregate/Entity criado no Domain quando aplicável
- [ ] Invariantes definidas no Domain
- [ ] Value Objects criados quando necessários
- [ ] Domain Events definidos quando necessários
- [ ] Domain Validations implementadas
- [ ] Repository contract definido quando necessário
- [ ] Commands criados
- [ ] Queries criadas
- [ ] Command Handlers implementados
- [ ] Query Handlers implementados
- [ ] Use Cases implementados quando apropriado
- [ ] Result Pattern aplicado
- [ ] Domain Notifications aplicadas quando necessárias
- [ ] Persistência implementada na Infrastructure
- [ ] ORM Model/Entity criado quando necessário
- [ ] Mapper criado quando Domain e ORM estiverem separados
- [ ] Migration criada quando necessária
- [ ] Repository concreto implementado
- [ ] Unit of Work respeitado quando aplicável
- [ ] Module atualizado
- [ ] Controller implementado
- [ ] DTOs HTTP implementados
- [ ] Pipes/validation configurados
- [ ] Permissions definidas por operação
- [ ] Guards configurados quando apropriado
- [ ] Autorização validada pela API
- [ ] Admin possui listagem
- [ ] Admin possui criação quando autorizada
- [ ] Admin possui edição quando autorizada
- [ ] Admin possui exclusão quando autorizada
- [ ] Site público implementado quando aplicável
- [ ] Unit Tests criados
- [ ] Integration Tests criados
- [ ] E2E Tests criados quando apropriado
- [ ] Docker atualizado quando necessário

Não considere um CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 30. TESTES

Devem existir conceitualmente:

```text
test/
├── unit/
├── integration/
└── e2e/
```

ou estrutura equivalente já adotada pelo projeto.

## Unit Tests

Devem validar principalmente:

- regras de domínio;
- invariantes;
- Aggregates;
- Entities;
- Value Objects;
- Domain Services;
- Domain Validations;
- Commands/Handlers quando apropriado;
- transições de estado;
- autorização quando testável isoladamente.

Unit Tests de domínio não devem depender de NestJS ou banco quando a regra puder ser testada isoladamente.

## Integration Tests

Devem testar integrações reais quando apropriado.

Podem validar:

- repositories;
- ORM;
- banco;
- migrations;
- módulos;
- infraestrutura;
- mensageria.

Devem utilizar banco TEST.

## E2E Tests

Devem poder:

1. iniciar dependências necessárias;
2. utilizar banco TEST;
3. aplicar migrations/schema;
4. iniciar a aplicação NestJS;
5. executar chamadas HTTP;
6. validar autenticação;
7. validar autorização;
8. validar API;
9. validar persistência;
10. limpar o estado após execução.

Testes não devem utilizar o banco DEV.

---

# 31. FRAMEWORK DE TESTES

Antes de alterar ferramentas de testes, analise o projeto.

Pode existir:

```text
Jest
Vitest
ou outra ferramenta
```

NestJS frequentemente possui configuração com Jest, mas isso não autoriza substituição automática de outra ferramenta já adotada.

Não substitua framework de testes apenas por preferência.

---

# 32. BANCO DEV E TEST

Devem existir ambientes isolados.

Conceitualmente:

```text
database-dev
database-test
```

Regras obrigatórias:

- testes nunca utilizam banco DEV;
- credenciais devem ser diferentes quando apropriado;
- containers devem ser isolados;
- limpeza dos testes não deve afetar desenvolvimento;
- migrations devem poder ser executadas no TEST;
- configuração de ambiente deve deixar clara a diferença.

---

# 33. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz do repositório.

Ele deve contemplar pelo menos:

- backend NestJS;
- banco DEV;
- banco TEST.

Quando existir frontend no mesmo repositório:

- frontend.

Quando necessário, também pode contemplar:

- Redis;
- RabbitMQ;
- Kafka;
- LocalStack;
- mail testing;
- workers;
- outras dependências realmente utilizadas.

Não adicione infraestrutura sem necessidade.

DEV e TEST devem possuir isolamento suficiente para impedir que testes alterem dados de desenvolvimento.

---

# 34. CONFIGURAÇÃO

Configuração deve utilizar mecanismos apropriados do NestJS/projeto.

Podem existir:

```text
.env
.env.example
ConfigModule
config/
```

Nunca coloque secrets reais em:

```text
.env.example
Git
CLAUDE.md
AGENTS.md
SKILL.md
```

`.env.example` deve conter apenas nomes de variáveis e valores seguros de exemplo quando apropriado.

---

# 35. LOGGING

Utilize o mecanismo de logging já definido pelo projeto.

Logs devem permitir diagnosticar problemas sem expor:

- passwords;
- tokens;
- secrets;
- dados sensíveis desnecessários.

Não espalhe `console.log` como estratégia permanente de observabilidade.

---

# 36. FRONTEND

Se existir frontend no mesmo repositório, mantenha separação clara.

Exemplo conceitual:

```text
/
├── backend/
├── frontend/
├── .claude/
│   └── skills/
└── docker-compose.yml
```

Se React for utilizado, a estrutura conceitual recomendada pelo projeto é:

```text
frontend/src/
├── admin/
├── site/
└── shared/
```

`admin` e `site` não devem importar internals um do outro.

Ambos devem depender de contratos e recursos compartilhados.

A API NestJS continua sendo a autoridade final de autorização.

---

# 37. INSTALAÇÃO DO TEMPLATE DO KIT

Minha stack não deve ser tratada automaticamente como um template Node.js simples.

Este projeto possui uma arquitetura combinada e específica:

```text
Node.js
+ TypeScript
+ NestJS
+ DDD
+ CQRS
+ CMS/CRUD
+ Admin/Site
+ User/Role/Permission
```

Portanto:

1. Analise os templates disponíveis.
2. Identifique se existe template Node.js/NestJS.
3. Não force Next.js full-stack, React Native/Expo, Python, PHP/Laravel ou outra stack incompatível.
4. Se existir template NestJS, analise se ele preserva a arquitetura definida neste prompt.
5. Não utilize template Node/NestJS simplificado se ele eliminar Domain/Application/Infrastructure.
6. Se nenhum template preservar integralmente esta arquitetura, utilize como base:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

7. Adapte o template genérico às regras deste prompt.
8. Não deixe instruções genéricas contradizerem as regras arquiteturais deste projeto.

---

# 38. CONFIGURAÇÃO DO CLAUDE.md

Leia o bloco `SETUP NOTE` do `CLAUDE.md`.

Execute a entrevista necessária para substituir os `[FILL]`.

Ao preencher o arquivo:

- considere Node.js;
- considere TypeScript;
- considere NestJS;
- registre DDD/CQRS;
- registre Domain/Application/Infrastructure/API;
- registre os domínios Identity, Content e Navigation;
- registre User/Role/Permission;
- registre as regras de segurança;
- registre ORM/persistência;
- registre DEV e TEST;
- registre o checklist obrigatório para CRUDs;
- registre testes;
- registre Docker;
- registre Admin/Site quando aplicável.

Quando informações dependerem de versões atuais, consulte documentação oficial quando houver acesso à web.

Não altere versões existentes apenas porque existe versão mais recente.

Se Node.js, TypeScript ou NestJS ainda não possuírem versões definidas, identifique as versões disponíveis e peça confirmação antes de adotá-las.

Depois que todos os `[FILL]` forem resolvidos, remova o `SETUP NOTE` conforme orientação do Kit.

---

# 39. MULTI-TOOL

Se a ferramenta utilizada não for apenas Claude Code, configure também arquivos necessários para outras ferramentas, incluindo:

```text
AGENTS.md
```

ou equivalentes quando o Kit orientar.

Existe uma única arquitetura de projeto.

Não crie regras divergentes entre:

- `CLAUDE.md`;
- `AGENTS.md`;
- Agent Skills;
- documentação de agentes.

Todos devem apontar para as mesmas regras fundamentais.

---

# 40. INSTALAÇÃO DAS SKILLS DO KIT

Instale as 10 skills existentes em:

```text
Kit-IA-Dev/3-Skills/
```

Para cada skill:

1. identifique a pasta completa;
2. copie a pasta inteira;
3. preserve `SKILL.md`;
4. preserve `references/`;
5. preserve demais arquivos auxiliares.

Não copie apenas `SKILL.md`.

Para Claude Code, utilize:

```text
.claude/skills/
```

quando aplicável.

---

# 41. SKILLS AVANÇADAS

Depois das skills básicas:

1. localize as 8 skills novas do pacote Skills Avançadas;
2. instale suas pastas completas;
3. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

4. substitua os 8 `SKILL.md` correspondentes.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não interprete ausência de patch como autorização para remover essas skills.

---

# 42. SKILLS ESPECÍFICAS DO PROJETO

Configure instruções/skills para que a IA compreenda pelo menos:

```text
project-architecture
nestjs-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
content-management
navigation-management
persistence
testing
docker-development
```

Antes de criar novas skills, verifique se uma skill existente pode ser estendida.

Evite duplicação desnecessária.

Entretanto, não deixe regras críticas apenas implícitas.

Uma solicitação como:

```text
"crie um CRUD de produtos"
```

não deve resultar simplesmente em:

```text
ProductsController
ProductsService
Product ORM Entity
```

A IA deverá automaticamente considerar:

```text
Product Domain
      ↓
Aggregate / Entity
      ↓
Value Objects / Invariants
      ↓
Repository Contract
      ↓
Commands
      ↓
Queries
      ↓
Handlers / Use Cases
      ↓
Infrastructure
      ↓
ORM / Persistence
      ↓
Mapper
      ↓
Repository Implementation
      ↓
NestJS Module
      ↓
Controller
      ↓
DTO / Validation
      ↓
Permissions / Guards
      ↓
Admin
      ↓
Site, quando aplicável
      ↓
Unit Tests
      ↓
Integration Tests
      ↓
E2E Tests
      ↓
Docker, quando necessário
```

---

# 43. VALIDAÇÃO DA INSTALAÇÃO

Depois da instalação, valide três níveis.

## Validação 1 — Kit

Execute uma solicitação evidente para uma skill:

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

Confirme que a skill correta é identificada/utilizada.

## Validação 2 — Arquitetura

Faça:

```text
"crie um CRUD de categorias"
```

Verifique se a IA considera:

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

Ela não deve sugerir CRUD simplificado incompatível com esta arquitetura.

## Validação 3 — CMS

Faça:

```text
"adicione gerenciamento de páginas"
```

Confirme que a IA considera:

- Page;
- Draft/Published;
- invariantes;
- Commands;
- Queries;
- permissions;
- Admin;
- API;
- persistência;
- publicação;
- Site público;
- testes.

---

# 44. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso ao pacote Templates.
3. Confirmar acesso ao pacote Skills Avançadas.
4. Confirmar a raiz do projeto.
5. Inspecionar a estrutura atual antes de copiar arquivos.
6. Identificar a ferramenta de IA utilizada.
7. Identificar onde essa ferramenta espera Agent Skills.
8. Identificar versões existentes de Node.js, TypeScript e NestJS.
9. Identificar package manager existente.
10. Identificar ORM/persistência existente.
11. Identificar banco de dados existente.
12. Identificar tecnologia frontend quando aplicável.
13. Analisar templates disponíveis.
14. Avaliar template Node.js/NestJS quando existir.
15. Utilizar template genérico quando nenhum template preservar esta arquitetura.
16. Configurar `CLAUDE.md`.
17. Configurar suporte multi-tool quando necessário.
18. Instalar as 10 skills básicas.
19. Instalar as 8 skills avançadas.
20. Aplicar os 8 patches de skills existentes.
21. Criar/adaptar instruções específicas do projeto.
22. Validar conflitos ou duplicações entre skills.
23. Validar arquitetura final.
24. Validar ativação das skills.
25. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 45. PACKAGE MANAGER

Antes de executar comandos, identifique qual package manager o projeto utiliza.

Pode ser:

```text
npm
pnpm
yarn
```

Preserve o package manager existente.

Utilize o lockfile como evidência:

```text
package-lock.json
pnpm-lock.yaml
yarn.lock
```

Não troque package manager sem instrução explícita.

Não gere múltiplos lockfiles.

---

# 46. PROIBIÇÕES

Não faça nenhuma destas ações sem instrução explícita:

- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar camadas porque parecem desnecessárias;
- transformar tudo em Controller + Service + ORM;
- colocar regra de negócio diretamente em Controllers;
- colocar regra de negócio em Guards;
- colocar invariantes exclusivamente em DTO validation;
- transformar ORM Entities automaticamente em Domain Entities;
- colocar autorização somente no frontend;
- compartilhar banco DEV com TEST;
- utilizar banco DEV nos testes;
- criar entidade `Content` universal sem avaliar invariantes;
- transformar o projeto em arquitetura de plugins do WordPress;
- adicionar marketplace;
- adicionar sistema de temas instaláveis;
- adicionar page builder;
- instalar packages NPM sem necessidade;
- atualizar Node.js indiscriminadamente;
- atualizar NestJS indiscriminadamente;
- atualizar TypeScript indiscriminadamente;
- atualizar dependências indiscriminadamente;
- escolher Prisma automaticamente;
- escolher TypeORM automaticamente;
- escolher banco de dados automaticamente;
- substituir Jest/Vitest sem analisar o projeto;
- trocar npm/pnpm/yarn sem autorização;
- gerar lockfiles conflitantes;
- introduzir frontend framework sem verificar a tecnologia existente;
- introduzir Redis sem necessidade;
- introduzir broker sem necessidade;
- utilizar NestJS Events como substitutos automáticos de Domain Events;
- implementar Event Sourcing indiscriminadamente;
- sobrescrever código existente sem antes analisá-lo;
- armazenar secrets no repositório.

Quando existir conflito entre:

```text
sugestão genérica do Kit
        vs
convenção simplificada do NestJS
        vs
regras específicas deste projeto
```

**AS REGRAS ESPECÍFICAS DESTE PROJETO TÊM PRECEDÊNCIA.**

Isso não significa ignorar NestJS.

Significa utilizar NestJS como framework de aplicação sem permitir que suas convenções simplificadas eliminem as fronteiras arquiteturais definidas.

---

# 47. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial Node.js + TypeScript + NestJS para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS, separação entre Domain/Application/Infrastructure/API, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, persistência isolada das regras de domínio, testes reais e ambientes Docker DEV/TEST.

A IA deve conseguir receber solicitações futuras de CRUDs e features e automaticamente respeitar essa arquitetura.

Ao receber:

```text
"crie um CRUD de produtos"
```

ela não deve criar somente:

```text
ProductController
ProductService
ProductEntity
ProductModule
```

Ela deve analisar e implementar os itens aplicáveis:

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
Create/Update/Delete Commands
        ↓
Read/List Queries
        ↓
Handlers / Use Cases
        ↓
Result Pattern
        ↓
Infrastructure
        ↓
ORM Persistence Model
        ↓
Mapper
        ↓
Repository Implementation
        ↓
Migration / Schema
        ↓
NestJS Module
        ↓
Controller
        ↓
Request DTOs
        ↓
Validation
        ↓
Permissions
        ↓
Guards
        ↓
Admin
        ↓
Site, quando aplicável
        ↓
Unit Tests
        ↓
Integration Tests
        ↓
E2E Tests
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