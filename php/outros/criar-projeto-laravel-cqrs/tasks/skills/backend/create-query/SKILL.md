# Skill: Create Query

## Objetivo

Criar uma operação de leitura usando CQRS.

## Estrutura

```text
app/Application/Queries/{Modulo}/{Nome}Query.php
app/Application/Handlers/Queries/{Modulo}/{Nome}Handler.php
```

## Regras

- Query não altera estado.
- Handler pode usar Eloquent ou abstração de leitura.
- Retornar DTO/Collection apropriado.
