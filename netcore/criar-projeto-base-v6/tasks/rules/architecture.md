# Architecture Rules

- DDD + CQRS + Domain Events.
- Domain não depende de Application, Infrastructure ou API.
- Application depende de Domain.
- Infrastructure implementa contratos.
- API deve ser fina.


## Entity Framework Core / Persistence

- EF Core pertence à camada `Infrastructure`; o `Domain` não deve depender de EF Core.
- Usar SQL Server como provider inicial.
- O `DbContext` principal deve se chamar `ApplicationDbContext`, salvo exigência explícita da Spec.
- Mapeamentos devem usar `IEntityTypeConfiguration<T>` e Fluent API.
- Toda nova entidade persistente deve possuir configuração EF explícita.
- Tabelas e colunas devem seguir os nomes definidos pela modelagem, em inglês.
- Criar a migration inicial `InitialCreate` durante a fundação do projeto, antes de CQRS/JWT/APIs.
- Migrations devem ficar na camada `Infrastructure`, preferencialmente em `Persistence/Migrations`.
- Nunca executar `EnsureCreated()` como substituto de migrations em ambiente normal.
- Bancos de desenvolvimento e testes devem ser atualizados por migrations.
- Testes de integração devem aplicar migrations antes dos cenários.
