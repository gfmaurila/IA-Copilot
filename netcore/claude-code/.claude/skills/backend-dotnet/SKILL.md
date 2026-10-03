# Skill: Backend ASP.NET Core

Padrões obrigatórios: DDD, CQRS, Unit of Work, Repository Pattern, Result Pattern, Domain Events, Domain Notifications e Domain Validations. Event Sourcing deve seguir a infraestrutura/padrão definido pelo projeto e não ser simulado com CRUD comum.

Features iniciais:
- Identity: User, Role, Permission.
- Content: Page, Content.
- Navigation: Menu, MenuItem.

Endpoints públicos nunca retornam rascunhos. Slugs publicados devem ser resolvidos de forma determinística e única conforme regra de domínio.
