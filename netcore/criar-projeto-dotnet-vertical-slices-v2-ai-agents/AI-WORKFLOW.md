# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Inspecionar `.sln`, `.csproj`, código, testes, migrations e Docker existentes.
5. Ler a task solicitada.
6. Inspecionar status/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar projeto, trocar arquitetura, antecipar features ou apagar trabalho existente.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT

## Vertical Slices
- preservar organização por feature/use case;
- evitar camadas genéricas desnecessárias;
- manter contratos e dependências existentes;
- regras de domínio não devem vazar para UI/infraestrutura;
- dependência nova exige necessidade comprovada.

## Qualidade
Quando aplicável:
- `dotnet restore`;
- `dotnet build`;
- testes unitários;
- testes de integração/API;
- testes de arquitetura;
- migrations/banco;
- Docker/Compose;
- revisão do diff.

## Saída obrigatória
TASK:
RESULT: PASS | PARTIAL | FAIL
FILES CHANGED:
TESTS:
VALIDATION:
PENDING:
NOTES:

Nunca declarar PASS sem evidência verificável.
