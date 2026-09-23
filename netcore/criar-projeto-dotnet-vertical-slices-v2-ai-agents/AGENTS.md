# AGENTS — .NET Vertical Slices AI Development Team

Este template usa agentes especializados para transformar uma Spec em implementação validada.

## Ordem padrão

1. Requirements Agent
2. Architect Agent
3. Tech Lead Agent
4. Developer Agent
5. Tester Agent
6. Reviewer Agent
7. Documentation Agent

## Regra principal

Nenhum agente pode quebrar os princípios do projeto:

- Vertical Slice Architecture
- Minimal APIs
- CQRS
- Domain Events
- Domain isolado
- EF Core + Migrations
- FluentValidation
- JWT + Policies
- testes unitários e integração

## Proibições

- Controllers MVC como padrão.
- Handlers globais fora da feature.
- Validators globais de funcionalidades específicas.
- Services genéricos sem responsabilidade clara.
- Camada Application horizontal apenas para acomodar CQRS.
- Compartilhamento prematuro entre slices.

## Handoff entre agentes

Cada agente deve produzir um artefato verificável antes de passar o trabalho adiante:

- Requirements → `tasks/generated/REQUIREMENTS.md`
- Architect → `tasks/generated/ARCHITECTURE_PLAN.md`
- Tech Lead → `tasks/generated/EXECUTION_PLAN.md`
- Tester → `tasks/reports/TEST_REPORT.md`
- Reviewer → `tasks/reports/REVIEW_REPORT.md`
- Documentation → documentação final e atualização do estado

## Continuidade e compatibilidade multi-IA

Este é o ponto de entrada do Codex. O mesmo repositório pode ser trabalhado por Claude Code e GitHub Copilot.

Antes de implementar, leia `PROJECT.md`, `PROJECT-STATE.md`, `AI-WORKFLOW.md`, documentação, solution/projects, código e testes existentes.

O projeto já possui estrutura. Não recrie o scaffold, não substitua Vertical Slices, não apague trabalho existente e não avance além da task solicitada. Preserve contratos, testes, migrations, Docker e padrões existentes.
