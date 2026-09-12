# AI Orchestration

Esta versão aplica um modelo multiagente inspirado em ferramentas modernas de engenharia assistida por IA, mas adaptado ao formato simples de arquivos Markdown do IA Copilot.

O objetivo não é executar vários modelos simultaneamente. Os "agentes" são papéis especializados com entradas, responsabilidades e saídas bem definidas.

## Benefícios

- reduz improvisação da IA;
- melhora rastreabilidade;
- permite retomar tarefas sem reler todo o projeto;
- reduz consumo desnecessário de contexto;
- cria checkpoints claros;
- facilita revisão e correção automática.

## Artefatos persistentes

```text
tasks/generated/REQUIREMENTS.md
tasks/generated/ARCHITECTURE_PLAN.md
tasks/generated/EXECUTION_PLAN.md
tasks/reports/TEST_REPORT.md
tasks/reports/REVIEW_REPORT.md
orchestration/state/PROJECT_STATE.md
```

Esses arquivos funcionam como memória operacional do trabalho em andamento.
