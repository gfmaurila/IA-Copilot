# Skill: Create Command

## Objetivo
Criar um Command seguindo CQRS para uma operação que altera estado.

## Entrada
- módulo
- nome do Command
- propriedades
- retorno esperado
- validações

## Estrutura
`Application/{Modulo}/Commands/{Nome}/`

Criar:
- `{Nome}Command.cs`
- `{Nome}CommandHandler.cs`
- `{Nome}CommandValidator.cs`

## Regras
- Usar Mediator/MediatR.
- Usar FluentValidation.
- Usar async/await e CancellationToken.
- Não acessar DbContext diretamente.
- Utilizar abstrações/repositories.
- Regras de negócio pertencem ao Domain.
