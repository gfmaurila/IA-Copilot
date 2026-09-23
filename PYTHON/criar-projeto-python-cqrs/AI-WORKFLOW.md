# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Inspecionar configuração Python, dependências, código, testes, migrations e Docker.
5. Ler a task solicitada.
6. Inspecionar status/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar projeto, trocar stack, antecipar features ou apagar trabalho existente.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT

## CQRS
- Commands alteram estado.
- Queries consultam estado.
- Não misturar responsabilidades sem justificativa explícita.
- Handlers seguem os contratos existentes.
- Domínio não deve depender de API, ORM ou infraestrutura.
- Evitar abstrações genéricas que escondam o fluxo da feature.

## Qualidade
Quando aplicável:
- instalação/lock de dependências conforme projeto;
- lint/format;
- typecheck;
- testes unitários;
- integração/API;
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
