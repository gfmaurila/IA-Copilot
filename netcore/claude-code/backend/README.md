# Backend

Estrutura alvo:
- Template.Api: endpoints, middleware, auth boundary e composição HTTP.
- Template.Application: commands, queries, handlers, DTOs, use cases.
- Template.Domain: aggregates, entities, value objects, events, validations, repository contracts.
- Template.Infrastructure: persistência, repositories, Unit of Work, migrations e integrações técnicas.
- Template.CrossCutting: DI e preocupações transversais.
- Template.Consumer / Producer: mensageria.
- Template.Btc / Csm: preservar responsabilidades equivalentes aos projetos de referência ao adaptar o template.
- tests/Template.UnitTests e tests/Template.IntegrationTests.

Domínios iniciais: Identity (User/Role/Permission), Content (Page/Content) e Navigation (Menu/MenuItem).
