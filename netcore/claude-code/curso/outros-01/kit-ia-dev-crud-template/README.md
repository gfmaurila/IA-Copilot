# Kit IA Dev — CRUD CMS Template

Template de instruções e estrutura para Claude Code criar aplicações CRUD inspiradas na experiência de administração de conteúdo do WordPress, sem plugins, temas ou marketplace.

## Escopo funcional
- Autenticação e validação de usuários
- Usuários, Roles e Permissions
- Páginas editáveis e publicáveis
- Conteúdos gerenciáveis
- Menus hierárquicos e ordenáveis
- Admin React e Site React
- API ASP.NET Core com DDD/CQRS
- Testes unitários e integração
- Docker Compose na raiz com ambientes DEV e TEST

## Estrutura
- `backend/`: API e camadas C#.
- `frontend/`: React dividido em `admin`, `site` e `shared`.
- `.claude/skills/`: regras que o Claude Code deve seguir.
- `docker-compose.yml`: orquestra frontend, backend, banco DEV e banco TEST.

## Regra principal
Não simplifique ou substitua a arquitetura definida por uma estrutura genérica. Novos CRUDs devem respeitar as fronteiras de Domain, Application, Infrastructure, API e Frontend.
