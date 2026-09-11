# Skill: Create Query

## Objetivo
Criar uma Query CQRS somente para leitura.

## Estrutura
`Application/{Modulo}/Queries/{Nome}/`

Criar Query, Handler e DTO/Response quando necessário.

## Regras
- Não modificar estado.
- Usar async/await e CancellationToken.
- Suportar paginação quando a consulta retornar coleções grandes.
