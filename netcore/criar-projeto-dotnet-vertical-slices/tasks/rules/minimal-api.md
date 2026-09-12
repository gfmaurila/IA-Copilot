# Minimal API Rules

- Não usar Controllers MVC como padrão.
- Endpoints devem ser pequenos.
- Cada Slice registra seu endpoint.
- Usar RouteGroupBuilder.
- Usar TypedResults quando fizer sentido.
- Usar Policies para autorização.
- Usar ProblemDetails para erros.
