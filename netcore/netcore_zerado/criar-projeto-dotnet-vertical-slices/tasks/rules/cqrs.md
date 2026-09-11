# CQRS Rules

- Command = escrita.
- Query = leitura.
- Handler pertence ao Slice.
- Query não altera estado.
- Command não deve virar consulta genérica.
- MediatR pode ser usado para dispatch.
