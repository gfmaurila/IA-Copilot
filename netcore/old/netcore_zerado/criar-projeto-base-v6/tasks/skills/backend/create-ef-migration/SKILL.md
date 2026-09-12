# Skill: Create EF Core Migration

## Objetivo

Criar e validar a persistência inicial ou uma nova migration usando Entity Framework Core e SQL Server.

## Regras

- EF Core deve existir somente na camada `Infrastructure`.
- O `Domain` não referencia EF Core.
- Usar `ApplicationDbContext`.
- Usar `IEntityTypeConfiguration<T>` para todos os mappings.
- Usar Fluent API para nomes, tipos, tamanhos, PKs, FKs, índices e constraints.
- Nomes de tabelas e colunas devem respeitar a Spec de dados.
- Migrations devem ficar em `Persistence/Migrations`.
- A primeira migration deve se chamar `InitialCreate`.
- Não usar `EnsureCreated()` como substituto de migrations.
- Não editar manualmente o arquivo de migration para mascarar problema no model/mapping; corrigir o model/configuration e recriar quando necessário.

## Pacotes

```text
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
```

## Sequência

1. Criar/validar entidades do Domain.
2. Criar/validar `ApplicationDbContext`.
3. Criar/validar configurations EF Core.
4. Registrar `UseSqlServer` no DI.
5. Garantir que a startup API fornece configuration/connection string ao design-time.
6. Criar migration.
7. Gerar script SQL para validação.
8. Executar build.
9. Aplicar migration somente no banco correto do ambiente.

## Comando de referência

```bash
dotnet ef migrations add InitialCreate \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext \
  --output-dir Persistence/Migrations
```

## Validação

```bash
dotnet ef migrations script \
  --project src/MeuProjeto.Infrastructure \
  --startup-project src/MeuProjeto.API.Admin \
  --context ApplicationDbContext
```

## Critérios de aceite

- `dotnet build` sem erros.
- Migration criada na Infrastructure.
- Snapshot do EF Core criado/atualizado.
- Script SQL da migration pode ser gerado sem erros.
- PKs, FKs, índices e constraints refletem a Spec.
- Nenhuma senha/connection string sensível está hardcoded no código.
