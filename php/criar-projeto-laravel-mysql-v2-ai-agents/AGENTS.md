# AGENTS - Laravel + MySQL

Este template utiliza agentes especializados para criar, evoluir e revisar projetos Laravel + MySQL de forma controlada, preservando as convenções nativas do framework.

## Fluxo obrigatório

```text
Spec / Solicitação
      ↓
Requirements Agent
      ↓
Architect Agent
      ↓
Tech Lead Agent
      ↓
Developer Agent
      ↓
Tester Agent
      ↓
Reviewer Agent
      ↓
Documentation Agent
      ↓
DONE
```

Quando um Quality Gate falhar, o fluxo retorna ao agente responsável pela correção.

## Agentes

| Agente | Responsabilidade | Saída principal |
|---|---|---|
| Requirements | consolidar requisitos, critérios de aceite e restrições | `tasks/generated/REQUIREMENTS.md` |
| Architect | definir arquitetura Laravel, MySQL, segurança e integrações | `tasks/generated/ARCHITECTURE_PLAN.md` |
| Tech Lead | quebrar o trabalho em tarefas pequenas, ordenadas e verificáveis | `tasks/generated/EXECUTION_PLAN.md` |
| Developer | implementar usando Rules, Skills, Spec e convenções Laravel | código + migrations |
| Tester | validar migrations, testes, banco e frontend | `tasks/reports/TEST_REPORT.md` |
| Reviewer | revisar Laravel, MySQL, segurança e qualidade | `tasks/reports/REVIEW_REPORT.md` |
| Documentation | atualizar README, ambiente, execução e decisões | documentação final |

## Regras globais

- Laravel deve ser usado de forma idiomática.
- MySQL é o banco padrão deste template.
- Controllers devem ser finos.
- Form Requests cuidam da validação HTTP.
- Policies/Gates cuidam da autorização.
- API Resources cuidam da transformação da resposta.
- Eloquent Models representam persistência e relacionamentos, sem concentrar fluxos de aplicação complexos.
- Actions ou Services só devem existir quando houver regra de aplicação reutilizável ou complexidade real.
- Alterações estruturais de banco devem usar migrations.
- Factories e Seeders devem ser usados para dados controlados de desenvolvimento/teste.
- Testes nunca devem usar o banco Development.
- Repository Pattern, CQRS e DDD formal não devem ser introduzidos sem exigência explícita da Spec.
- Specs e Rules têm prioridade sobre convenções genéricas dos agentes.
- Skills devem ser lidas sob demanda, somente quando necessárias.
- Nenhuma tarefa é concluída sem passar pelos Quality Gates aplicáveis.
