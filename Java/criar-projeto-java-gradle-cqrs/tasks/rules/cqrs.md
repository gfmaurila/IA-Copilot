# CQRS Rules
- escrita: Command + Handler.
- leitura: Query + Handler.
- Query nunca altera estado.
- Controller não contém regra de negócio.
- Handler coordena o caso de uso.
- não criar um framework de mediator desnecessário.
