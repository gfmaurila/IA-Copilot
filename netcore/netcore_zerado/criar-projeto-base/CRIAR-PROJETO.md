# CRIAR-PROJETO

## Objetivo
Gerar uma solução Full Stack com backend C#/.NET e frontend React + TypeScript, separada em Admin e Site.

## Aplicações
- Backend: `MeuProjeto.API.Admin` e `MeuProjeto.API.Site`
- Frontend: `frontend/admin` e `frontend/site`

## Backend
Usar DDD, CQRS, Domain Events, Repository Pattern, Dependency Injection, EF Core, Mediator/MediatR, FluentValidation, AutoMapper, JWT, Swagger/OpenAPI, Serilog, ProblemDetails, async/await e CancellationToken.

### Dependências
`API -> Application -> Domain`

`Infrastructure -> Application + Domain`

O Domain não depende de API, Application ou Infrastructure.

## Frontend
Usar React, TypeScript, Vite, React Router, Axios, React Hook Form, Zod e TanStack Query. Estado global simples pode usar Context API ou Zustand. Evitar `any`, URLs hardcoded e chamadas HTTP dentro dos componentes.

## Admin inicial
Módulos: auth, dashboard, users, settings.

CRUDs devem ter List, Create, Edit e Details, além de paginação, busca, validação, loading, tratamento de erro e confirmação de exclusão.

## Site inicial
Módulos: home, auth, account e contact. Páginas: Home, Login, Cadastro, Recuperar Senha, Perfil, Contato e 404.

## Organização das instruções
- `tasks/rules`: regras obrigatórias da arquitetura.
- `tasks/skills`: receitas reutilizáveis de implementação.
- `tasks/specs/changes`: funcionalidades a implementar.
- `tasks/specs/archive`: specs concluídas.

## Fluxo da IA
1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules`.
3. Ler a Spec solicitada.
4. Identificar e ler somente as Skills necessárias.
5. Implementar respeitando arquitetura e padrões existentes.
6. Executar build e testes.
7. Corrigir erros.
8. Mover a Spec concluída para `archive` quando solicitado.

## Portas sugeridas
- Admin React: 8081
- Site React: 8082
- Admin API: 5001
- Site API: 5002
- SQL Server: 1433
- Redis: 6379

## Ordem de geração inicial
1. Estrutura de diretórios
2. Solution e projetos .NET
3. Referências entre projetos
4. Domain
5. Application
6. Infrastructure
7. CrossCutting
8. APIs
9. Swagger, logging e exception handling
10. Persistência
11. Testes
12. React Admin
13. React Site
14. Rotas e HTTP services
15. Auth
16. Dockerfiles e docker-compose
17. `.env.example`
18. README
19. Build backend/frontend
20. Testes e correções
