# Skill: Create Command

## Objetivo

Criar uma operação de escrita usando CQRS.

## Estrutura

```text
app/Application/Commands/{Modulo}/{Nome}Command.php
app/Application/Handlers/Commands/{Modulo}/{Nome}Handler.php
```

## Regras

- Command representa intenção de alteração.
- Não executar consulta complexa.
- Handler deve ser invocável.
- Handler deve ser testável.
- Não colocar lógica HTTP no Handler.
