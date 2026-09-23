# AI WORKFLOW

Fluxo comum para Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Inspecionar `build.gradle*`, `settings.gradle*`, código e testes existentes.
5. Ler a task solicitada.
6. Inspecionar o diff/status quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar o projeto, não trocar arquitetura, não antecipar features e não apagar trabalho existente.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT

## Regras arquiteturais
- domínio não depende de adapters/frameworks;
- ports definem contratos;
- adapters implementam integrações;
- CQRS mantém comandos e consultas separados conforme padrão existente;
- dependências apontam para dentro;
- infraestrutura não vaza para o domínio;
- não introduzir biblioteca sem necessidade comprovada.

## Qualidade
Quando aplicável:
- Gradle build;
- testes unitários;
- testes de integração;
- testes de arquitetura;
- validação de banco/migrations;
- validação Docker/Compose;
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
