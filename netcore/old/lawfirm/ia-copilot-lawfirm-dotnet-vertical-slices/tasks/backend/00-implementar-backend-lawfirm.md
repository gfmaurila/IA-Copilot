# BE-00 — Implementar Backend LawFirm

## Objetivo
Implementar o backend do projeto **LawFirm** em .NET, seguindo a **Vertical Slice Architecture** já existente no repositório e fornecendo as APIs necessárias para `Front End - Site` e `Front End - Admin`.

## Regras obrigatórias
1. Antes de codificar, analisar Solution, README, `tasks/rules/`, documentação e padrões existentes.
2. Reutilizar as abstrações e convenções atuais; não criar arquitetura paralela.
3. Manter namespaces `LawFirm` e organização por Feature/Vertical Slice.
4. Usar async/await e `CancellationToken` nas operações assíncronas.
5. Não expor entidades EF diretamente na API.
6. Validar entrada no backend, independentemente da validação do frontend.
7. Garantir build e testes após cada módulo antes de avançar.
8. Conferir `tasks/frontend/admin/`, `tasks/frontend/site/` e `docs/screens/1. Front End/` para definir os contratos reais da API.

## Stack e padrões
- .NET / ASP.NET Core Web API
- Vertical Slice Architecture
- Entity Framework Core + migrations
- Dependency Injection
- FluentValidation ou padrão de validação já existente
- JWT + Refresh Token
- Roles/Policies
- OpenAPI/Swagger
- ProblemDetails/padrão de erros existente
- Testes unitários e de integração

## Features a implementar

### 01 — Fundação / Infrastructure
Revisar configuração da aplicação, DI, persistência, tratamento global de exceções, configuração por ambiente, CORS, rate limiting, logging e infraestrutura compartilhada sem quebrar a arquitetura existente.

### 02 — Banco de Dados
Criar/ajustar entidades, configurações EF Core e migrations. Aplicar FKs, índices, unique constraints, limites de tamanho, campos obrigatórios e delete behaviors. Priorizar índices para `Slug`, `Email`, `Status`, `CreatedAt` e `PublishedAt`.

### 03 — Autenticação
Implementar:
- `POST /api/auth/login`
- `POST /api/auth/refresh`
- `POST /api/auth/forgot-password`
- `POST /api/auth/reset-password`
- `GET /api/profile`
- `PUT /api/profile`
- `PUT /api/profile/password`

Nunca armazenar senha em texto puro. Tratar tokens inválidos/expirados e refresh tokens com segurança.

### 04 — Usuários
CRUD administrativo com nome, e-mail, telefone, avatar, cargo, status, role, criação e último acesso.
- `GET /api/admin/users`
- `GET /api/admin/users/{id}`
- `POST /api/admin/users`
- `PUT /api/admin/users/{id}`
- `DELETE /api/admin/users/{id}`

Listagens devem suportar paginação, pesquisa, filtros e ordenação.

### 05 — Roles / Permissões
Implementar roles/policies, associação usuário→role e proteção dos endpoints administrativos. Preparar evolução futura de permissões sem acoplamento a cada endpoint.

### 06 — Configurações Gerais
Gerenciar nome do escritório, logo, favicon, descrição, endereço, telefone, WhatsApp, e-mail, horário e copyright.
- `GET /api/settings`
- `GET /api/admin/settings`
- `PUT /api/admin/settings`

### 07 — Mídia
Biblioteca de mídia com PNG, JPG/JPEG, WEBP, SVG seguro e PDF quando necessário.
- `GET /api/admin/media`
- `POST /api/admin/media`
- `DELETE /api/admin/media/{id}`

Validar extensão, MIME type, conteúdo/tipo permitido e tamanho. Criar abstração de storage preparada para provider externo.

### 08 — Áreas de Atuação
Campos: Id, Nome, Slug, Ícone, Resumo, Conteúdo, Imagem, Ordem, Destaque, Status, MetaTitle, MetaDescription.
- `GET /api/practice-areas`
- `GET /api/practice-areas/{slug}`
- `GET /api/admin/practice-areas`
- `GET /api/admin/practice-areas/{id}`
- `POST /api/admin/practice-areas`
- `PUT /api/admin/practice-areas/{id}`
- `DELETE /api/admin/practice-areas/{id}`

### 09 — Equipe / Advogados
CRUD com foto, nome, cargo, OAB, biografia, contatos, redes sociais, ordem, destaque, status, SEO e slug. Criar relacionamento N:N entre advogado e área de atuação. Disponibilizar endpoints públicos e administrativos.

### 10 — Artigos
CRUD e publicação com título, slug, resumo, conteúdo, imagem, autor, data de publicação, status, destaque e SEO. Implementar listagem, paginação, pesquisa, filtros, detalhe por slug, publicar/despublicar.

### 11 — Depoimentos
CRUD com nome, cargo/empresa, foto, depoimento, avaliação, ordem, destaque e status. Endpoint público deve retornar apenas registros ativos.

### 12 — Páginas Institucionais
Gerenciar Sobre Nós, Política de Privacidade, Termos de Uso, Política de Cookies e outras páginas por slug. Campos: título, slug, conteúdo, status e SEO. Criar endpoints públicos e CRUD administrativo.

### 13 — Home
Configurar banner, sobre, áreas em destaque, diferenciais, equipe, depoimentos, artigos recentes, CTA, vídeo e números/resultados, incluindo ordem das seções.
- `GET /api/home`
- `GET /api/admin/home`
- `PUT /api/admin/home`

O endpoint público deve agregar os dados necessários evitando requisições desnecessárias.

### 14 — Menu
Menu hierárquico com Id, Título, URL, Ordem, ParentId, Target e Status.
- `GET /api/menu`
- CRUD administrativo correspondente.

### 15 — Contato
- `POST /api/contact`
- `GET /api/admin/contact-messages`
- `GET /api/admin/contact-messages/{id}`
- `PUT /api/admin/contact-messages/{id}/status`
- `PUT /api/admin/contact-messages/{id}/notes`
- `DELETE /api/admin/contact-messages/{id}`

Status: `Unread`, `Read`, `Replied`, `Archived`. Registrar nome, e-mail, telefone, assunto, mensagem, data e origem; IP/User-Agent somente quando apropriado. Aplicar rate limiting/antispam.

### 16 — Redes Sociais
Gerenciar Instagram, LinkedIn, Facebook, YouTube, X e WhatsApp com URL, status e ordem.
- `GET /api/social-networks`
- CRUD/configuração administrativa correspondente.

### 17 — SEO
Configurar meta title/description, keywords, Open Graph, imagem padrão, robots, indexação e sitemap.
- `GET /api/seo`
- `GET /sitemap.xml`
- `GET /robots.txt`

Gerar sitemap dinamicamente com conteúdos públicos quando aplicável.

### 18 — Integrações
Configurar Google Analytics, Google Tag Manager, Google Maps, WhatsApp e reCAPTCHA. Separar dados públicos de credenciais privadas. Nunca retornar secrets ao frontend nem versioná-los no repositório.

### 19 — Rodapé
- `GET /api/footer`

Retornar logo, descrição, links, áreas de atuação, contato, redes sociais e copyright.

### 20 — Busca
- `GET /api/search?q={term}`

Pesquisar artigos, áreas de atuação, advogados e páginas. Retornar resultados agrupados por tipo.

### 21 — Formulários
Criar estrutura extensível de formulários. Implementar inicialmente o formulário de contato sem acoplar o domínio exclusivamente a ele.

### 22 — Notificações
Notificações administrativas, inicialmente para novas mensagens de contato.
- `GET /api/admin/notifications`
- `PUT /api/admin/notifications/{id}/read`

### 23 — Auditoria
Registrar operações administrativas relevantes: login, criação, alteração, exclusão, publicação e configurações. Quando aplicável: usuário, operação, entidade, EntityId, data/hora, IP e metadados seguros. Nunca registrar senha, token ou secret.

### 24 — Logs
Logging estruturado para erros, exceptions, requests relevantes, falhas de autenticação e integrações. Nunca registrar senha, JWT, refresh token, API key ou secret.

### 25 — Health Checks
- `GET /health`

Validar API e banco, deixando estrutura preparada para serviços externos.

### 26 — Seed
Criar dados de desenvolvimento: administrador, configurações básicas, áreas, advogados, artigos e depoimentos de exemplo. Credenciais de desenvolvimento não podem ser aplicadas automaticamente em produção.

### 27 — Swagger / OpenAPI
Documentar requests, responses, status codes, autenticação e parâmetros. Configurar Bearer Authentication no Swagger.

## Paginação padrão
Listagens administrativas devem aceitar, quando aplicável:
`?page=1&pageSize=20&search=&status=&sort=`

Resposta paginada deve informar: `items`, `page`, `pageSize`, `totalItems`, `totalPages`.

## Segurança
Implementar JWT, refresh tokens, authorization, roles/policies, CORS configurável, rate limiting, proteção do contato, validação de uploads, sanitização quando necessária, proteção contra mass assignment e exception handling global. Atenção especial a `/api/auth/*`, `/api/contact` e `/api/admin/*`.

## Erros
Manter padrão consistente, preferencialmente ProblemDetails quando compatível:
- 400 Validation Error
- 401 Unauthorized
- 403 Forbidden
- 404 Not Found
- 409 Conflict
- 422 Business Rule Error
- 500 Internal Server Error

Nunca retornar stack trace em produção.

## Testes
Priorizar autenticação/autorização, áreas de atuação, advogados, artigos, contato, usuários e configurações. Criar testes de Handler, Validator e Endpoint/Integration quando aplicável.

## Ordem de execução
1. Fundação / Infrastructure
2. Banco de Dados
3. Authentication
4. Users
5. Roles / Permissions
6. Settings
7. Media
8. Practice Areas
9. Lawyers / Team
10. Articles
11. Testimonials
12. Pages
13. Home
14. Menu
15. Contact
16. Social Networks
17. SEO
18. Integrations
19. Footer
20. Search
21. Notifications
22. Audit
23. Logs
24. Health Checks
25. Tests
26. Seed
27. Swagger / documentação final

## Processo por módulo
1. Analisar dependências e contratos das tasks frontend.
2. Criar/ajustar entidade e configuração EF.
3. Criar migration quando necessária.
4. Implementar Commands/Queries, Handlers, Validators, DTOs/Responses e Endpoints conforme o padrão existente.
5. Configurar autorização.
6. Criar testes.
7. Executar build e testes.
8. Corrigir erros/warnings introduzidos.
9. Atualizar documentação necessária.
10. Só então avançar ao próximo módulo.

## Não fazer
- Não reescrever a arquitetura.
- Não criar Controllers tradicionais se o projeto usa Minimal APIs/endpoints por slice.
- Não duplicar abstrações.
- Não colocar regra de negócio diretamente no endpoint.
- Não expor entidades EF.
- Não expor/versionar secrets.
- Não ignorar `CancellationToken`.
- Não adicionar dependências sem necessidade.
- Não alterar contratos existentes sem verificar impacto.
- Não implementar nesta etapa gestão processual, clientes, agenda jurídica, financeiro, documentos privados, portal do cliente ou portal do advogado.

## Escopo
Esta task atende exclusivamente os módulos públicos/administrativos definidos em:
- `tasks/frontend/site/`
- `tasks/frontend/admin/`

Os módulos `Client` e `Lawyers` deverão ser implementados em tasks próprias posteriormente.

## Critérios de aceite
- Solution compila sem erros.
- Banco pode ser criado do zero pelas migrations.
- Autenticação e autorização funcionam.
- Endpoints públicos e administrativos necessários estão implementados.
- Endpoints administrativos estão protegidos.
- CRUDs, filtros e paginação funcionam.
- Uploads são validados.
- Swagger/OpenAPI está atualizado.
- Health Check funciona.
- Testes principais passam.
- Nenhum secret está versionado ou exposto.
- APIs atendem aos contratos necessários às 70 telas/tasks do Site e Admin.
- README/documentação relevante está atualizado.

## Resultado esperado
Backend **LawFirm** funcional, modular e pronto para integração com os frontends React `Site` e `Admin`, preservando a arquitetura para futura inclusão dos módulos `Client` e `Lawyers`.
