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

Para instalar skills:

1. Primeiro identifique onde a ferramenta utilizada espera encontrar Agent Skills.
2. Caso isso não esteja claro, consulte `Kit-IA-Dev/3-Skills/COMO-INSTALAR.md`.
3. Nunca copie apenas o `SKILL.md` quando a skill possuir arquivos auxiliares. Copie a pasta inteira da skill, incluindo `references/` e demais arquivos.

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
- Não substitua a arquitetura definida neste prompt por uma arquitetura Laravel genérica.
- Não simplifique a estrutura para reduzir quantidade de camadas, módulos ou arquivos.
- Se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas objetivas.
- Converse comigo em PT-BR.
- Conteúdo técnico destinado à IA, como `CLAUDE.md`, `AGENTS.md`, `agent_docs`, `SKILL.md` e documentação equivalente, deve permanecer em inglês, salvo quando o arquivo original estabelecer outro padrão.

Antes de sobrescrever arquivos existentes importantes, identifique o arquivo e explique brevemente a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para criação de aplicações **CRUD/CMS com PHP + Laravel**.

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

A raiz do projeto deve seguir conceitualmente:

```text
/
├── app/
├── bootstrap/
├── config/
├── database/
├── public/
├── resources/
├── routes/
├── storage/
├── tests/
├── .claude/
│   └── skills/
├── docker/
├── docker-compose.yml
├── artisan
├── composer.json
└── ...
```

A estrutura padrão necessária ao funcionamento do Laravel deve ser preservada.

A arquitetura da aplicação deve ser organizada principalmente dentro de:

```text
app/
├── Domain/
├── Application/
├── Infrastructure/
├── Http/
└── Providers/
```

Responsabilidades:

`app/Domain/`
: regras de negócio, Aggregates, Entities, Value Objects, Domain Events, contratos e invariantes.

`app/Application/`
: casos de uso, Commands, Queries, Handlers, DTOs e orquestração da aplicação.

`app/Infrastructure/`
: persistência, Eloquent, implementação de repositories, integrações e serviços técnicos.

`app/Http/`
: Controllers, Requests, Resources, Middleware e fronteira HTTP.

`resources/`
: interface administrativa e site público conforme a tecnologia de apresentação adotada pelo projeto.

`tests/`
: testes Unit e Feature/Integration.

`.claude/skills/`
: skills específicas do projeto quando Claude Code for uma das ferramentas utilizadas.

`docker-compose.yml`
: orquestra aplicação, banco DEV, banco TEST e demais dependências necessárias.

Não reorganize diretórios fundamentais do Laravel de maneira que prejudique convenções essenciais do framework.

Ao mesmo tempo, não use as convenções do Laravel como justificativa para eliminar as fronteiras arquiteturais definidas neste prompt.

---

# 6. REGRA ARQUITETURAL PRINCIPAL

Esta regra possui prioridade sobre sugestões genéricas existentes nos templates:

**NÃO simplifique, substitua ou descaracterize a arquitetura definida neste prompt.**

Todo novo CRUD deve respeitar as fronteiras entre:

```text
Domain
    ↓
Application
    ↓
Infrastructure
    ↓
HTTP/API
    ↓
Presentation
```

As dependências devem respeitar as fronteiras arquiteturais.

O Domain não deve depender diretamente de:

- Controllers;
- Requests HTTP;
- Eloquent quando isso acoplar regras de domínio ao ORM;
- banco de dados;
- framework HTTP;
- interface administrativa.

Não concentre regras de negócio em:

- Controllers;
- Form Requests;
- Models Eloquent;
- Repositories;
- Blade Components;
- componentes frontend.

Não substitua a estrutura por um CRUD genérico baseado apenas em:

```text
Route
→ Controller
→ Eloquent Model
→ Database
```

As regras de negócio devem permanecer no domínio.

---

# 7. BACKEND / LARAVEL

O backend utiliza PHP + Laravel.

A arquitetura deve utilizar, conforme a responsabilidade de cada caso:

- Domain Driven Design (DDD);
- CQRS;
- Event Sourcing quando realmente aplicável ao domínio;
- Unit of Work quando necessário;
- Repository Pattern;
- Result Pattern;
- Domain Events;
- Domain Notifications;
- Domain Validations;
- Dependency Injection;
- Laravel Service Container.

Estrutura conceitual:

```text
app/
├── Domain/
│   ├── Identity/
│   ├── Content/
│   └── Navigation/
│
├── Application/
│   ├── Identity/
│   ├── Content/
│   └── Navigation/
│
├── Infrastructure/
│   ├── Persistence/
│   ├── Repositories/
│   ├── Messaging/
│   └── Services/
│
└── Http/
    ├── Controllers/
    ├── Requests/
    ├── Resources/
    └── Middleware/
```

A organização interna deve ser orientada por domínio/feature sempre que isso melhorar a separação de responsabilidades.

---

# 8. DOMAIN

`app/Domain` é responsável por:

- Aggregates;
- Entities;
- Value Objects;
- Domain Events;
- Domain Validations;
- invariantes;
- regras de negócio;
- contratos de repositories;
- serviços de domínio quando necessários.

Exemplo:

```text
app/Domain/
├── Identity/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   ├── Repositories/
│   ├── Services/
│   └── Exceptions/
│
├── Content/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   ├── Repositories/
│   ├── Services/
│   └── Exceptions/
│
└── Navigation/
    ├── Entities/
    ├── ValueObjects/
    ├── Events/
    ├── Repositories/
    ├── Services/
    └── Exceptions/
```

O Domain não deve depender diretamente de detalhes técnicos do Laravel quando essa dependência comprometer o isolamento das regras de negócio.

Evite colocar regras de negócio importantes diretamente em Models Eloquent.

---

# 9. APPLICATION

`app/Application` é responsável por:

- Commands;
- Queries;
- Command Handlers;
- Query Handlers;
- DTOs;
- Use Cases;
- Application Services quando necessários;
- Result Pattern;
- orquestração dos casos de uso.

Exemplo:

```text
app/Application/
└── Content/
    └── Pages/
        ├── Commands/
        │   ├── CreatePage/
        │   ├── UpdatePage/
        │   ├── DeletePage/
        │   └── PublishPage/
        │
        ├── Queries/
        │   ├── GetPage/
        │   └── ListPages/
        │
        └── DTOs/
```

Commands representam intenção de alteração.

Queries representam leitura.

Não utilize CQRS apenas como nomenclatura.

A separação entre leitura e escrita deve possuir responsabilidade clara.

---

# 10. INFRASTRUCTURE

`app/Infrastructure` é responsável por:

- Eloquent;
- persistência;
- implementação de repositories;
- banco de dados;
- cache;
- filas;
- mensageria;
- integrações externas;
- serviços técnicos;
- filesystem;
- mail;
- implementação de contratos definidos pelas camadas internas.

Exemplo:

```text
app/Infrastructure/
├── Persistence/
│   └── Eloquent/
│       ├── Models/
│       ├── Repositories/
│       └── Mappers/
│
├── Messaging/
├── Cache/
├── Mail/
└── Services/
```

Quando Domain Entities forem separadas dos Models Eloquent, utilize mapeamento explícito entre persistência e domínio.

Não transforme Eloquent Model automaticamente em Domain Entity sem avaliar se isso preserva as invariantes e o isolamento do domínio.

---

# 11. HTTP / API

`app/Http` é responsável pela fronteira HTTP.

Pode conter:

```text
app/Http/
├── Controllers/
│   ├── Admin/
│   ├── Api/
│   └── Site/
├── Requests/
├── Resources/
└── Middleware/
```

Controllers devem:

1. receber a requisição;
2. validar aspectos HTTP;
3. executar o caso de uso apropriado;
4. transformar o resultado em resposta HTTP.

Controllers não devem conter regras de domínio.

Form Requests devem tratar validações relacionadas à entrada HTTP.

Uma validação em Form Request não substitui invariantes do Domain.

API Resources devem ser utilizados para transformação de respostas quando apropriado.

---

# 12. DOMÍNIOS INICIAIS

Os domínios iniciais são:

```text
Identity
Content
Navigation
```

## Identity

Relacionamento conceitual:

```text
User
  → Roles
      → Permissions
```

`User`, `Role` e `Permission` são conceitos distintos.

As permissões devem representar operações autorizadas pelo sistema.

O backend Laravel é sempre a autoridade final para autorização.

A interface pode ocultar ou desabilitar funcionalidades conforme as permissões recebidas, mas isso nunca substitui a validação no servidor.

---

# 13. CONTENT

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

Quando implementado explicitamente pelo domínio, também podem existir operações como:

```text
Published → Draft/Unpublished
Published → Archived
```

Não introduza novos estados automaticamente.

As transições devem possuir regras explícitas de domínio.

Não permita que um simples:

```php
$page->status = 'published';
$page->save();
```

substitua a operação de domínio quando publicar uma página possuir invariantes.

A publicação deve ocorrer através de comportamento/caso de uso explícito.

## Content

Conteúdos devem ser modelados de acordo com a feature e suas invariantes.

Evite criar uma entidade universal `Content` apenas para armazenar estruturas arbitrárias quando o domínio exigir conceitos específicos.

Prefira modelos explícitos e semanticamente relevantes.

---

# 14. NAVIGATION

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

# 15. APRESENTAÇÃO

O projeto possui duas experiências conceituais:

```text
Admin
Site
```

## Admin

Responsável por:

- painel administrativo;
- autenticação;
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

Deve resolver:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação pública.

Páginas básicas administráveis devem poder mudar sem alteração manual de código.

A tecnologia concreta de apresentação deve respeitar o projeto existente.

Ela pode utilizar, conforme definido pelo projeto:

- Blade;
- Livewire;
- Inertia;
- React;
- Vue;
- outra tecnologia explicitamente aprovada.

Não introduza uma tecnologia frontend diferente apenas por preferência da IA.

Se o projeto ainda não possuir tecnologia de apresentação definida, apresente as opções identificadas antes de adotar uma.

---

# 16. SEGURANÇA

A arquitetura de segurança deve seguir:

```text
User
  → Role
      → Permission
```

Uma aplicação pode permitir múltiplas roles por usuário conforme o modelo definido durante a implementação.

Regras obrigatórias:

- autorização real acontece no backend;
- frontend não é fronteira de segurança;
- esconder botão não significa autorizar ou negar operação;
- rotas/controllers/casos de uso devem validar as permissions necessárias;
- Admin adapta menus, rotas e ações conforme as permissões do usuário;
- Policies e Gates do Laravel podem participar da autorização;
- Middleware pode proteger fronteiras HTTP;
- regras críticas também devem estar protegidas no caso de uso/domínio quando necessário.

Cada CRUD deve definir permissões por operação.

Exemplo conceitual:

```text
Page.Read
Page.Create
Page.Update
Page.Delete
Page.Publish
```

Os nomes definitivos devem seguir a convenção estabelecida pelo projeto.

Não dependa apenas de:

```php
@if($user->can(...))
```

ou de qualquer verificação visual na interface.

A autorização deve ser validada pelo backend.

---

# 17. ELOQUENT

Eloquent é uma tecnologia de persistência e não deve automaticamente definir o modelo de domínio.

Models Eloquent podem ser utilizados na Infrastructure.

Exemplo conceitual:

```text
Domain
Page

Infrastructure
PageModel
```

Quando o domínio for simples e o projeto explicitamente permitir aproximação entre Domain Entity e Eloquent Model, avalie a decisão antes de implementá-la.

Não acople invariantes importantes exclusivamente a:

- observers;
- mutators;
- accessors;
- events de Eloquent;
- controllers;
- Form Requests.

Esses recursos podem ser utilizados tecnicamente, mas não devem esconder regras centrais do domínio.

---

# 18. MIGRATIONS, SEEDERS E FACTORIES

Migrations devem representar a evolução do banco de dados.

Não altere migrations antigas já utilizadas em ambientes compartilhados para simular uma nova mudança.

Crie uma nova migration quando apropriado.

Factories devem facilitar:

- testes;
- geração de dados;
- cenários de desenvolvimento.

Seeders devem ser utilizados para dados necessários ao ambiente quando apropriado.

Dados iniciais de autorização podem incluir:

- roles padrão;
- permissions;
- usuário administrativo inicial quando explicitamente definido.

Nunca coloque credenciais reais no código-fonte.

---

# 19. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

Sempre que for solicitado um novo CRUD, verifique:

- [ ] Entidade/Aggregate criado no Domain quando aplicável
- [ ] Invariantes definidas no Domain
- [ ] Value Objects criados quando necessários
- [ ] Commands criados no Application
- [ ] Queries criadas no Application
- [ ] Handlers/Use Cases implementados
- [ ] Result Pattern aplicado
- [ ] Domain Events aplicados quando necessários
- [ ] Domain Notifications aplicadas quando necessárias
- [ ] Domain Validations implementadas
- [ ] Repository contract definido quando necessário
- [ ] Persistência implementada na Infrastructure
- [ ] Eloquent Model criado quando necessário
- [ ] Mapper criado quando Domain e Eloquent estiverem separados
- [ ] Migration criada quando necessária
- [ ] Factory criada quando apropriada
- [ ] Seeder atualizado quando necessário
- [ ] Routes implementadas
- [ ] Controllers implementados
- [ ] Form Requests implementados quando apropriado
- [ ] API Resources implementados quando apropriado
- [ ] Permissions definidas por operação
- [ ] Policies/Gates/Middleware configurados quando apropriado
- [ ] Autorização validada pelo backend
- [ ] Admin possui listagem
- [ ] Admin possui criação quando autorizada
- [ ] Admin possui edição quando autorizada
- [ ] Admin possui exclusão quando autorizada
- [ ] Site público implementado quando aplicável
- [ ] Unit Tests criados
- [ ] Feature/Integration Tests criados
- [ ] Docker atualizado quando necessário

Não considere um CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 20. TESTES

Devem existir testes separados conceitualmente em:

```text
tests/
├── Unit/
└── Feature/
```

Podem existir estruturas adicionais de Integration quando necessárias.

## Unit Tests

Devem validar principalmente:

- regras de domínio;
- invariantes;
- Value Objects;
- validações;
- Commands/Handlers quando apropriado;
- transições de estado;
- regras de autorização quando testáveis isoladamente.

Unit Tests de domínio não devem exigir banco de dados quando a regra puder ser testada isoladamente.

## Feature / Integration Tests

Os testes de integração devem ser reais.

Devem poder:

1. iniciar as dependências necessárias;
2. utilizar banco TEST;
3. executar migrations;
4. preparar os dados necessários;
5. iniciar/executar a aplicação;
6. executar o cenário;
7. validar HTTP/API;
8. validar autorização;
9. validar persistência;
10. limpar ou reconstruir o estado após a execução.

Os testes não devem utilizar o banco DEV.

Utilize os mecanismos de testes do Laravel quando apropriado, incluindo:

- PHPUnit ou framework de testes já adotado pelo projeto;
- HTTP testing;
- database assertions;
- factories;
- migrations;
- transações;
- `RefreshDatabase` quando compatível com o cenário.

Não introduza Pest ou substitua PHPUnit, ou vice-versa, sem verificar primeiro qual ferramenta o projeto utiliza.

---

# 21. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz do repositório.

Ele deve contemplar pelo menos:

- aplicação PHP/Laravel;
- servidor web quando necessário;
- banco DEV;
- banco TEST.

Quando aplicável, também pode contemplar:

- Redis;
- queue worker;
- scheduler;
- mail testing;
- cache;
- outros serviços realmente utilizados pelo projeto.

DEV e TEST devem possuir isolamento suficiente para impedir que testes alterem dados de desenvolvimento.

Exemplo conceitual:

```text
laravel
database-dev
database-test
```

Nunca configure os testes para utilizarem acidentalmente as credenciais do banco DEV.

Quando novas dependências de infraestrutura forem adicionadas, avalie se o Docker Compose também precisa ser atualizado.

---

# 22. FILAS E JOBS

Quando uma operação for assíncrona, utilize os mecanismos apropriados do Laravel.

Podem existir:

```text
Jobs
Queues
Events
Listeners
```

Não utilize Jobs para esconder regras de domínio.

Um Job pode coordenar execução assíncrona, mas as regras do negócio devem continuar nas camadas apropriadas.

Domain Events e Laravel Events não devem ser tratados automaticamente como a mesma coisa.

Avalie a responsabilidade de cada evento.

---

# 23. EVENTS

Domain Events representam acontecimentos relevantes do domínio.

Exemplo:

```text
PagePublished
UserRoleChanged
MenuUpdated
```

Eventos técnicos do Laravel podem ser utilizados para integração com infraestrutura.

Não substitua automaticamente Domain Events por Eloquent Events.

---

# 24. CACHE

Cache é uma otimização técnica.

Não utilize cache como fonte primária da verdade.

Quando páginas, menus ou conteúdos publicados forem armazenados em cache, alterações relevantes devem possuir estratégia explícita de invalidação.

---

# 25. INSTALAÇÃO DO TEMPLATE DO KIT

Minha stack não deve ser tratada automaticamente como um template Laravel simples.

Este projeto possui uma arquitetura combinada e específica:

```text
PHP
+ Laravel
+ DDD
+ CQRS
+ CMS/CRUD
+ Admin
+ Site
+ User/Role/Permission
```

Portanto:

1. Analise os templates disponíveis.
2. Identifique se existe template PHP/Laravel.
3. Não force Next.js, Node API, React Native/Expo, Python ou outro template incompatível.
4. Se existir template Laravel, analise antes se ele preserva a arquitetura definida neste prompt.
5. Não utilize um template Laravel simples se ele eliminar Domain/Application/Infrastructure ou outras regras obrigatórias.
6. Se nenhum template preservar integralmente esta arquitetura, utilize como base o template genérico localizado em:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

7. Adapte o template genérico às regras deste prompt.
8. Não deixe instruções genéricas contradizerem as regras arquiteturais deste projeto.

---

# 26. CONFIGURAÇÃO DO CLAUDE.md E ARQUIVOS DE INSTRUÇÃO

Leia o bloco `SETUP NOTE` do `CLAUDE.md`.

Execute a entrevista necessária para substituir os `[FILL]`.

Ao preencher o arquivo:

- considere PHP;
- considere Laravel;
- registre DDD/CQRS e demais padrões definidos;
- registre Domain/Application/Infrastructure/HTTP;
- registre Admin + Site;
- registre os domínios Identity, Content e Navigation;
- registre User/Role/Permission;
- registre as regras de segurança;
- registre Eloquent como detalhe de persistência;
- registre DEV e TEST;
- registre o checklist obrigatório para novos CRUDs;
- registre as regras de migrations;
- registre as regras de testes;
- registre Docker.

Quando informações dependerem de versões atuais das tecnologias, consulte documentação atual/oficial quando a ferramenta possuir acesso à web.

Não altere versões existentes do projeto apenas porque existe uma versão mais recente.

Se o projeto ainda não possuir versões definidas para PHP/Laravel, identifique as versões disponíveis e peça confirmação antes de adotá-las.

Depois que todos os `[FILL]` forem resolvidos, remova o comentário/instrução temporária `SETUP NOTE`, conforme orientação do Kit.

---

# 27. MULTI-TOOL

Se a ferramenta utilizada não for apenas Claude Code, configure também os arquivos necessários para utilização por outras ferramentas, incluindo `AGENTS.md` ou equivalentes quando o Kit orientar dessa forma.

Existe uma única arquitetura de projeto.

Não crie regras arquiteturais divergentes entre:

- `CLAUDE.md`;
- `AGENTS.md`;
- Agent Skills;
- documentação de agentes.

Todos devem apontar para as mesmas regras fundamentais.

---

# 28. INSTALAÇÃO DAS SKILLS DO KIT

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

Não copie apenas o arquivo `SKILL.md`.

Instale no local correto para a ferramenta utilizada.

Para Claude Code, utilize a estrutura definida pelo projeto/Kit, incluindo:

```text
.claude/skills/
```

quando aplicável.

---

# 29. SKILLS AVANÇADAS

Depois das skills básicas:

1. localize as 8 skills novas do pacote Skills Avançadas;
2. instale suas pastas completas;
3. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

4. substitua os 8 `SKILL.md` correspondentes sobre as skills instaladas pelo Kit.

`code-review` e `frontend-design` não possuem patch nesse conjunto.

Não interprete ausência de patch como autorização para remover essas skills.

---

# 30. SKILLS ESPECÍFICAS DESTE PROJETO

Além das skills fornecidas pelo Kit, configure instruções/skills do projeto para que a IA compreenda pelo menos:

```text
project-architecture
laravel-architecture
backend-ddd-cqrs
crud-generation
identity-authorization
content-management
navigation-management
eloquent-persistence
laravel-testing
docker-development
```

Antes de criar novas skills, verifique se uma skill existente do Kit pode ser estendida sem perder sua finalidade original.

Evite duplicação desnecessária de regras.

Entretanto, não deixe regras críticas deste projeto apenas implícitas.

As skills/instruções devem garantir que solicitações como:

```text
"crie um CRUD de produtos"
```

não resultem simplesmente em:

```text
php artisan make:model Product -mcr
```

seguido de lógica colocada diretamente no Controller e no Model.

A IA deverá automaticamente considerar:

```text
Domain
  ↓
Application
  ↓
Infrastructure
  ↓
Eloquent/Persistence
  ↓
HTTP/API
  ↓
Permissions
  ↓
Admin
  ↓
Site, quando aplicável
  ↓
Unit Tests
  ↓
Feature/Integration Tests
  ↓
Docker, quando necessário
```

---

# 31. VALIDAÇÃO DA INSTALAÇÃO

Depois da instalação, valide três níveis.

## Validação 1 — Kit

Execute uma solicitação evidente para uma skill do Kit, por exemplo:

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

Faça uma solicitação conceitual como:

```text
"crie um CRUD de categorias"
```

Verifique se a IA identifica que precisa considerar:

- Domain;
- Application;
- Infrastructure;
- Eloquent/Persistence;
- HTTP/API;
- Permissions;
- Admin;
- testes;
- Site quando aplicável.

Ela não deve sugerir um CRUD simplificado incompatível com esta arquitetura.

## Validação 3 — CMS

Faça uma solicitação conceitual relacionada ao conteúdo:

```text
"adicione gerenciamento de páginas"
```

Confirme que a IA considera:

- Page;
- estados Draft/Published;
- regras de domínio;
- Commands;
- Queries;
- permissions;
- Admin;
- HTTP/API;
- Eloquent/persistência;
- migrations;
- publicação;
- Site público;
- testes.

---

# 32. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso ao pacote Templates.
3. Confirmar acesso ao pacote Skills Avançadas.
4. Confirmar a raiz do projeto.
5. Inspecionar a estrutura atual do projeto antes de copiar arquivos.
6. Identificar a ferramenta de IA utilizada.
7. Identificar onde essa ferramenta espera Agent Skills.
8. Identificar as versões atuais do PHP e Laravel já definidas pelo projeto.
9. Identificar a tecnologia de apresentação já utilizada pelo projeto.
10. Analisar os templates disponíveis.
11. Avaliar o template PHP/Laravel, caso exista.
12. Utilizar o template genérico quando nenhum template preservar esta arquitetura.
13. Configurar `CLAUDE.md`.
14. Configurar suporte multi-tool quando necessário.
15. Instalar as 10 skills básicas.
16. Instalar as 8 skills avançadas novas.
17. Aplicar os 8 patches de skills existentes.
18. Criar/adaptar as instruções específicas deste projeto.
19. Validar conflitos ou duplicações entre skills.
20. Validar a arquitetura final.
21. Validar ativação das skills.
22. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 33. PROIBIÇÕES

Não faça nenhuma destas ações sem instrução explícita:

- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar camadas porque parecem desnecessárias;
- implementar todos os CRUDs somente com Controller + Eloquent;
- colocar regra de negócio diretamente em Controllers;
- colocar invariantes exclusivamente em Form Requests;
- transformar Eloquent Models automaticamente em todo o modelo de domínio;
- colocar regra de autorização somente na interface;
- compartilhar banco DEV com testes;
- criar uma entidade `Content` genérica para qualquer tipo de informação sem avaliar as invariantes;
- transformar o projeto em arquitetura de plugins do WordPress;
- adicionar marketplace;
- adicionar sistema de temas instaláveis;
- adicionar page builder;
- instalar packages Composer sem necessidade;
- instalar packages NPM sem necessidade;
- atualizar PHP indiscriminadamente;
- atualizar Laravel indiscriminadamente;
- atualizar dependências indiscriminadamente;
- substituir PHPUnit por Pest ou Pest por PHPUnit sem analisar o projeto;
- introduzir Livewire, React, Vue ou Inertia sem verificar a tecnologia já adotada;
- sobrescrever código existente sem antes analisá-lo;
- alterar migrations históricas utilizadas em ambientes compartilhados quando uma nova migration for apropriada;
- utilizar banco DEV em testes;
- armazenar secrets ou credenciais reais no repositório;
- utilizar Eloquent Events como substitutos automáticos de Domain Events;
- utilizar observers para esconder regras críticas de negócio.

Quando existir conflito entre uma sugestão genérica do Kit, uma convenção simplificada de Laravel e as regras específicas deste projeto:

**AS REGRAS ESPECÍFICAS DESTE PROJETO TÊM PRECEDÊNCIA.**

Isso não significa ignorar Laravel.

Significa utilizar Laravel como framework e infraestrutura sem permitir que convenções simplificadas eliminem as fronteiras e regras arquiteturais definidas.

---

# 34. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial PHP + Laravel para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS, separação entre Domain/Application/Infrastructure/HTTP, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, persistência Laravel/Eloquent isolada conforme as responsabilidades arquiteturais, testes reais e ambientes Docker DEV/TEST.

A IA deve conseguir receber solicitações futuras de CRUDs e features e automaticamente respeitar essa arquitetura.

Por exemplo, ao receber:

```text
"crie um CRUD de produtos"
```

ela não deve criar apenas:

```text
Product Model
ProductController
Migration
Routes
Blade
```

Ela deve primeiro analisar o domínio e então considerar:

```text
Product Domain Model
        ↓
Invariants / Value Objects
        ↓
Repository Contract
        ↓
Commands / Queries
        ↓
Handlers / Use Cases
        ↓
Infrastructure Repository
        ↓
Eloquent Model / Mapper
        ↓
Migration
        ↓
HTTP Controller / Request / Resource
        ↓
Permissions / Policies
        ↓
Admin
        ↓
Site, quando aplicável
        ↓
Unit Tests
        ↓
Feature / Integration Tests
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