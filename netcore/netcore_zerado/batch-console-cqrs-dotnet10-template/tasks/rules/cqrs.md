# Regra - CQRS

- Query: leitura sem alteração de estado.
- Command: operação que altera estado ou coordena processamento.
- Handlers pequenos e testáveis.
- Usar Mediator para dispatch.
- Propagar CancellationToken.
