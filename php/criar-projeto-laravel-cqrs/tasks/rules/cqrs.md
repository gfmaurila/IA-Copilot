# CQRS Rules

## Commands

Usar para alteração de estado.

Exemplos:

- CreateUserCommand
- UpdateUserCommand
- DeleteUserCommand

Cada Command deve possuir Handler correspondente.

## Queries

Usar somente para leitura.

Exemplos:

- GetUserByIdQuery
- GetPagedUsersQuery

Cada Query deve possuir Handler correspondente.

## Controllers

Controllers apenas:

- recebem request
- autorizam
- criam Command/Query
- despacham para Handler/Bus
- retornam Resource/Response

## Handlers

Handlers coordenam a operação.

Evitar regra de negócio complexa no Controller.

## Persistência

Eloquent continua sendo o ORM padrão.

Não criar Repository para tudo sem necessidade.

Use Repository quando a abstração trouxer benefício real.
