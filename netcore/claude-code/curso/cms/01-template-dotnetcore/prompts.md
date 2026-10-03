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

- Outra ferramenta de IA de código compatível com instruções de projeto e/ou Agent Skills no padrão `SKILL.md`.

Para instalar skills:

1. Primeiro identifique onde a ferramenta utilizada espera encontrar Agent Skills.
2. Caso isso não esteja claro, consulte `Kit-IA-Dev/3-Skills/COMO-INSTALAR.md`.
3. Nunca copie apenas o `SKILL.md` quando a skill possuir arquivos auxiliares. Copie a pasta inteira da skill, incluindo `references/` e demais arquivos.

---

# 2. ARQUIVOS E PASTAS QUE POSSO FORNECER

Os seguintes contextos podem ser fornecidos como pasta ou ZIP:

## Kit principal

`Kit-IA-Dev/`

ou:

`Kit-IA-Dev.zip`

## Projeto

A raiz do repositório onde o Kit será instalado.

## Templates por Stack

`Order-Bump-Templates-por-Stack/`

ou:

`Kit-IA-Dev-Templates-por-Stack.zip`

## Skills Avançadas

`Upsell1-Kit-IA-Dev/`

ou:

`Kit-IA-Dev-Skills-Avancadas.zip`

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
- Não substitua a arquitetura definida neste prompt por uma arquitetura genérica.
- Não simplifique a estrutura para reduzir quantidade de projetos, camadas ou arquivos.
- Se houver ambiguidade relevante, faça no máximo 1 ou 2 perguntas objetivas.
- Conversa comigo em PT-BR.
- Conteúdo técnico destinado à IA, como `CLAUDE.md`, `AGENTS.md`, `agent_docs`, `SKILL.md` e documentação equivalente, deve permanecer em inglês, salvo quando o arquivo original estabelecer outro padrão.

Antes de sobrescrever arquivos existentes importantes, identifique o arquivo e explique brevemente a alteração.

---

# 4. OBJETIVO DO PROJETO

Este projeto é um template empresarial para criação de aplicações **CRUD/CMS com ASP.NET Core + React**.

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
- sistema de temas;
- widgets;
- page builder complexo;
- extensões instaláveis.

Não transforme o projeto em um clone arquitetural do WordPress.

---

# 5. ESTRUTURA OBRIGATÓRIA DO REPOSITÓRIO

A raiz do projeto deve seguir conceitualmente:

```text
/
├── backend/
├── frontend/
├── .claude/
│   └── skills/
├── docker-compose.yml
└── ...
```

Responsabilidades:

`backend/`
: API ASP.NET Core e seus projetos/camadas.

`frontend/`
: aplicação React contendo Admin, Site e Shared.

`.claude/skills/`
: skills específicas do projeto quando Claude Code for a das ferramentas utilizadas.

`docker-compose.yml`
: orquestra frontend, backend, banco DEV e banco TEST.

Caso outra ferramenta de IA utilize outro diretório para Agent Skills, instale também ou adapte as skills conforme as regras oficiais dessa ferramenta, sem perder a estrutura necessária ao Claude Code quando ela fizer parte do projeto.

---

# 6. REGRA ARQUITETURAL PRINCIPAL

Esta regra possui prioridade sobre sugestões genéricas existentes nos templates:

**NÃO simplifique, substitua ou descaracterize a arquitetura definida neste prompt.**

Todo novo CRUD deve respeitar as fronteiras entre:

- Domain
- Application
- Infrastructure
- API
- CrossCutting
- Frontend

Não concentre regras de negócio em controllers, endpoints, repositories ou componentes React.

Não substitua a estrutura por um CRUD genérico baseado apenas em Controller + Service + Repository.

As regras de domínio devem permanecer no domínio.

---

# 7. BACKEND

O backend utiliza ASP.NET Core.

A arquitetura deve utilizar, conforme a responsabilidade de cada caso:

- Domain Driven Design (DDD)
- CQRS
- Event Sourcing quando aplicável ao domínio
- Unit of Work
- Repository Pattern
- Result Pattern
- Domain Events
- Domain Notifications
- Domain Validations

Preserve os seguintes projetos e suas responsabilidades:

```text
backend/
├── Template.Api/
├── Template.Application/
├── Template.Domain/
├── Template.Infrastructure/
├── Template.CrossCutting/
├── Template.Consumer/
├── Template.Producer/
├── Template.Btc/
├── Template.Csm/
└── tests/
    ├── Template.UnitTests/
    └── Template.IntegrationTests/
```

`Template` representa o nome base do projeto e deve ser substituído pelo nome real quando ele for definido.

Não mantenha literalmente `Template` se o projeto já possuir nome.

## Template.Api

Responsável por:

- endpoints;
- middleware;
- autenticação/autorização na fronteira HTTP;
- configuração HTTP;
- composição da aplicação.

Não colocar regras de domínio diretamente nos endpoints.

## Template.Application

Responsável por:

- Commands;
- Queries;
- Handlers;
- DTOs;
- Use Cases;
- orquestração dos casos de uso.

## Template.Domain

Responsável por:

- Aggregates;
- Entities;
- Value Objects;
- Domain Events;
- Domain Validations;
- invariantes;
- contratos de repositories.

## Template.Infrastructure

Responsável por:

- persistência;
- implementação de repositories;
- Unit of Work;
- migrations;
- acesso a banco;
- integrações técnicas.

## Template.CrossCutting

Responsável por:

- Dependency Injection;
- configuração e preocupações transversais.

## Template.Consumer / Template.Producer

Responsáveis pela infraestrutura e fluxos de mensageria.

## Template.Btc / Template.Csm

Preserve responsabilidades equivalentes aos projetos de referência fornecidos.

Não invente uma nova responsabilidade para esses projetos.

Antes de alterá-los, analise os projetos de referência existentes.

---

# 8. DOMÍNIOS INICIAIS

Os domínios iniciais são:

```text
Identity
Content
Navigation
```

## Identity

Relacionamento conceitual:

```text
User -> Roles -> Permissions
```

`User`, `Role` e `Permission` são conceitos distintos.

As permissões devem representar operações autorizadas pelo sistema.

A API é sempre a autoridade final para autorização.

O frontend pode ocultar ou desabilitar funcionalidades conforme as permissões recebidas, mas isso nunca substitui a validação da API.

---

# 9. CONTENT

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
Draft -> Published
```

Quando implementado explicitamente pelo domínio, também podem existir operações como:

```text
Published -> Draft/Unpublished
Published -> Archived
```

Não introduza novos estados automaticamente.

As transições devem possuir regras explícitas de domínio.

## Content

Conteúdos devem ser modelados de acordo com a feature e suas invariantes.

Evite criar uma entidade universal `Content` apenas para armazenar estruturas arbitrárias quando o domínio exigir conceitos específicos.

Prefira modelos explícitos e semanticamente relevantes.

---

# 10. NAVIGATION

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

# 11. FRONTEND

O frontend utiliza React.

Estrutura conceitual obrigatória:

```text
frontend/
└── src/
    ├── admin/
    ├── site/
    └── shared/
```

Organize cada área por **feature**.

## src/admin

Responsável por:

- painel administrativo;
- autenticação;
- rotas protegidas;
- CRUDs;
- layouts administrativos;
- gerenciamento de usuários;
- gerenciamento de roles;
- gerenciamento de permissions;
- gerenciamento de páginas;
- gerenciamento de conteúdos;
- gerenciamento de menus.

## src/site

Responsável pela aplicação pública.

Deve consumir a API para resolver:

- páginas publicadas;
- conteúdos publicados;
- menus;
- navegação pública.

Páginas básicas administráveis devem poder mudar sem alteração manual de código no frontend.

## src/shared

Responsável por elementos reutilizados por Admin e Site:

- API client;
- contratos/modelos;
- componentes compartilhados;
- hooks;
- autenticação;
- segurança;
- utilities.

## Regra de isolamento

`admin` e `site` não devem importar internals um do outro.

Ambos devem depender somente dos contratos e recursos disponibilizados em `shared`.

---

# 12. SEGURANÇA

A arquitetura de segurança deve seguir:

```text
User
  -> Role
      -> Permission
```

Uma aplicação pode permitir múltiplas roles por usuário conforme o modelo definido durante a implementação.

Regras obrigatórias:

- autorização real acontece na API;
- frontend não é fronteira de segurança;
- esconder botão não significa autorizar/negar operação;
- endpoints devem validar as permissions necessárias;
- Admin adapta menus, rotas e ações conforme as permissões retornadas pela API.

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

---

# 13. CHECKLIST OBRIGATÓRIO PARA NOVOS CRUDS

Sempre que for solicitado um novo CRUD, verifique:

- [ ] Entidade/Aggregate criado no Domain
- [ ] Invariantes definidas no Domain
- [ ] Commands criados no Application
- [ ] Queries criadas no Application
- [ ] Handlers implementados
- [ ] Result Pattern aplicado
- [ ] Domain Notifications aplicadas quando necessárias
- [ ] Domain Validations implementadas
- [ ] Repository contract definido
- [ ] Unit of Work respeitado
- [ ] Persistência implementada na Infrastructure
- [ ] Migration criada quando necessária
- [ ] Endpoints implementados na API
- [ ] Permissions definidas por operação
- [ ] Autorização validada pela API
- [ ] Admin possui listagem
- [ ] Admin possui criação quando autorizada
- [ ] Admin possui edição quando autorizada
- [ ] Admin possui exclusão quando autorizada
- [ ] Site público implementado quando aplicável
- [ ] Unit Tests criados
- [ ] Integration Tests criados
- [ ] Docker atualizado quando necessário

Não considere um CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 14. TESTES

Devem existir:

```text
backend/tests/Template.UnitTests
backend/tests/Template.IntegrationTests
```

## Unit Tests

Devem validar principalmente:

- regras de domínio;
- invariantes;
- Value Objects;
- validações;
- Commands/Handlers quando apropriado;
- transições de estado;
- regras de autorização quando testáveis isoladamente.

## Integration Tests

Os testes de integração devem ser reais.

Devem poder:

1. iniciar as dependências necessárias;
2. utilizar banco TEST;
3. criar banco/schema/tabelas necessárias;
4. iniciar a aplicação ou infraestrutura necessária;
5. executar o cenário;
6. validar API e persistência;
7. limpar dados/schema após a execução.

Os testes de integração não devem utilizar o banco DEV.

---

# 15. DOCKER

O arquivo:

```text
/docker-compose.yml
```

deve permanecer na raiz do repositório.

Ele deve contemplar pelo menos:

- frontend;
- backend;
- banco DEV;
- banco TEST.

DEV e TEST devem possuir isolamento suficiente para impedir que testes alterem dados de desenvolvimento.

Quando novas dependências de infraestrutura forem adicionadas ao projeto, avalie se o Docker Compose também precisa ser atualizado.

---

# 16. INSTALAÇÃO DO TEMPLATE DO KIT

Minha stack não deve ser tratada como um dos templates simples predefinidos apenas por possuir React ou backend.

Este projeto possui uma arquitetura combinada e específica:

```text
ASP.NET Core + React + DDD + CQRS + CMS/CRUD
```

Portanto:

1. Analise os templates disponíveis.
2. Não force Next.js, Node API, React Native/Expo, Python, PHP/Laravel ou outro template incompatível.
3. Se não existir um template que preserve integralmente esta arquitetura, utilize como base o template genérico localizado em:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

4. Adapte o template genérico às regras deste prompt.
5. Não deixe instruções genéricas contradizerem as regras arquiteturais deste projeto.

---

# 17. CONFIGURAÇÃO DO CLAUDE.md E ARQUIVOS DE INSTRUÇÃO

Leia o bloco `SETUP NOTE` do `CLAUDE.md`.

Execute a entrevista necessária para substituir os `[FILL]`.

Ao preencher o arquivo:

- considere ASP.NET Core no backend;
- considere React no frontend;
- considere Admin + Site + Shared;
- registre DDD/CQRS e demais padrões definidos;
- registre a estrutura de projetos obrigatória;
- registre os domínios Identity, Content e Navigation;
- registre as regras de segurança;
- registre DEV e TEST;
- registre o checklist obrigatório para novos CRUDs.

Quando informações dependerem de versões atuais das tecnologias, consulte documentação atual/oficial quando a ferramenta possuir acesso à web.

Não altere versões existentes do projeto apenas porque existe uma versão mais recente.

Se o projeto ainda não possuir uma versão definida, apresente a versão identificada e peça confirmação antes de adotá-la.

Depois que todos os `[FILL]` forem resolvidos, remova o comentário/instrução temporária `SETUP NOTE`, conforme orientação do Kit.

---

# 18. MULTI-TOOL

Se a ferramenta utilizada não for apenas Claude Code, configure também os arquivos necessários para utilização por outras ferramentas, incluindo `AGENTS.md` ou equivalentes quando o Kit orientar dessa forma.

Existe uma única arquitetura de projeto.

Não crie regras arquiteturais divergentes entre:

- `CLAUDE.md`;
- `AGENTS.md`;
- Agent Skills;
- documentação de agentes.

Todos devem apontar para as mesmas regras fundamentais.

---

# 19. INSTALAÇÃO DAS SKILLS DO KIT

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

Para Claude Code, utilize a estrutura definida pelo projeto/Kit, incluindo `.claude/skills/` quando aplicável.

---

# 20. SKILLS AVANÇADAS

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

# 21. SKILLS ESPECÍFICAS DESTE PROJETO

Além das skills fornecidas pelo Kit, configure instruções/skills do projeto para que a IA compreenda pelo menos:

```text
project-architecture
backend-ddd-cqrs
frontend-react-architecture
crud-generation
identity-authorization
content-management
navigation-management
testing
docker-development
```

Antes de criar novas skills, verifique se uma skill existente do Kit pode ser estendida sem perder sua finalidade original.

Evite duplicação desnecessária de regras.

Entretanto, não deixe regras críticas deste projeto apenas implícitas.

As skills/instruções devem garantir que solicitações como:

```text
"crie um CRUD de produtos"
```

não resultem em um CRUD genérico.

A IA deverá automaticamente considerar:

```text
Domain
 -> Application
 -> Infrastructure
 -> API
 -> Permissions
 -> Admin
 -> Site, quando aplicável
 -> Unit Tests
 -> Integration Tests
 -> Docker, quando necessário
```

---

# 22. VALIDAÇÃO DA INSTALAÇÃO

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
- API;
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
- permissions;
- Admin;
- API;
- persistência;
- publicação;
- Site público;
- testes.

---

# 23. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar acesso ao Kit IA Dev.
2. Confirmar acesso ao pacote Templates.
3. Confirmar acesso ao pacote Skills Avançadas.
4. Confirmar a raiz do projeto.
5. Inspecionar a estrutura atual do projeto antes de copiar arquivos.
6. Identificar a ferramenta de IA utilizada.
7. Identificar onde essa ferramenta espera Agent Skills.
8. Analisar os templates disponíveis.
9. Utilizar o template genérico quando nenhum template preservar esta arquitetura.
10. Configurar `CLAUDE.md`.
11. Configurar suporte multi-tool quando necessário.
12. Instalar as 10 skills básicas.
13. Instalar as 8 skills avançadas novas.
14. Aplicar os 8 patches de skills existentes.
15. Criar/adaptar as instruções específicas deste projeto.
16. Validar conflitos ou duplicações entre skills.
17. Validar a arquitetura final.
18. Validar ativação das skills.
19. Apresentar resumo dos arquivos criados, alterados ou substituídos.

---

# 24. PROIBIÇÕES

Não faça nenhuma destas ações sem instrução explícita:

- substituir DDD por arquitetura simplificada;
- remover CQRS;
- eliminar projetos porque parecem desnecessários;
- colocar regra de negócio diretamente em controllers/endpoints;
- colocar regra de autorização somente no React;
- compartilhar banco DEV com testes;
- criar uma entidade `Content` genérica para qualquer tipo de informação sem avaliar as invariantes;
- permitir importações internas entre Admin e Site;
- transformar o projeto em arquitetura de plugins do WordPress;
- adicionar marketplace;
- adicionar sistema de temas;
- adicionar page builder;
- instalar dependências sem necessidade;
- atualizar versões indiscriminadamente;
- sobrescrever código existente sem antes analisá-lo;
- alterar as responsabilidades de Btc ou Csm sem analisar os projetos de referência.

Quando existir conflito entre uma sugestão genérica do Kit e as regras específicas deste projeto, **as regras específicas deste projeto têm precedência**.

---

# 25. RESULTADO ESPERADO

Ao terminar, quero possuir um projeto onde uma ferramenta de IA de código consiga entender que:

> Este é um template empresarial ASP.NET Core + React para aplicações CRUD/CMS, inspirado na experiência administrativa de conteúdo do WordPress, utilizando DDD/CQRS no backend, React separado entre Admin/Site/Shared, autorização baseada em User/Role/Permission, conteúdo publicável, menus administráveis, testes reais e ambientes Docker DEV/TEST.

A IA deve conseguir receber solicitações futuras de CRUDs e features e automaticamente respeitar essa arquitetura.

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