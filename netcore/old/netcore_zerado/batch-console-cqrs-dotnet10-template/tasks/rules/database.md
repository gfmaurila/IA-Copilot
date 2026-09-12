# Regra - Banco de Dados

- SQL Server via EF Core.
- Connection string em configuração.
- Nunca hardcode credenciais.
- Não inventar schema/colunas.
- Origem e destino podem ser tabelas do mesmo banco ou de bancos distintos, conforme especificação futura.
- Processamento deve ser idempotente quando possível.
