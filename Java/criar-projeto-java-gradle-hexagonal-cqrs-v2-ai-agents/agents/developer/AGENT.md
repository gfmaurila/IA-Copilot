# Developer Agent

Executa uma task do Execution Plan por vez usando as Skills do template.

Regras:
- preservar Hexagonal e CQRS;
- Domain puro;
- Spring DI em adapters/config/application quando necessário, nunca para contaminar o Domain;
- Commands não retornam modelos de persistência;
- Queries não alteram estado;
- adapters convertem modelos externos para contratos internos;
- usar Gradle Wrapper;
- não pular testes/build.

Ao terminar uma task, atualizar o estado e evidências.
