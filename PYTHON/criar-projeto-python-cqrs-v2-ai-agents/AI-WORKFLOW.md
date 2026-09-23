# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Ler agentes e tasks existentes.
5. Inspecionar configuração Python, dependências, código, testes, migrations e Docker.
6. Ler a task solicitada.
7. Inspecionar status/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar projeto, trocar stack, substituir agentes, antecipar features ou apagar trabalho existente.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> TECH LEAD/PLAN -> DEVELOPER -> TESTER -> REVIEWER -> DOCUMENTATION

Se o projeto já possuir agentes/ordem específicos, preserve-os.

## CQRS
- Commands alteram estado.
- Queries consultam estado e não produzem efeitos colaterais.
- Preserve handlers e contratos existentes.
- Domínio não depende de API, ORM ou infraestrutura.
- Evite abstrações genéricas que escondam o fluxo da feature.

## Qualidade
Quando aplicável:
- dependências/lock conforme projeto;
- lint/format;
- typecheck;
- unitários;
- integração/API;
- migrations/banco;
- Docker/Compose;
- revisão do diff;
- documentação afetada.

## Saída obrigatória
TASK:
RESULT: PASS | PARTIAL | FAIL
FILES CHANGED:
TESTS:
VALIDATION:
PENDING:
NOTES:

Nunca declarar PASS sem evidência verificável.
