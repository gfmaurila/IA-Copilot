# AGENTS - Laravel + CQRS

Este template utiliza agentes especializados para criar e evoluir projetos Laravel + CQRS de forma controlada.

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

Quando um gate falhar, o fluxo retorna ao agente responsável pela correção.

## Agentes

| Agente | Responsabilidade | Saída principal |
|---|---|---|
| Requirements | consolidar requisitos, critérios de aceite e restrições | `tasks/generated/REQUIREMENTS.md` |
| Architect | definir arquitetura, módulos, CQRS, persistência e integrações | `tasks/generated/ARCHITECTURE_PLAN.md` |
| Tech Lead | quebrar o trabalho em tarefas pequenas e ordenadas | `tasks/generated/EXECUTION_PLAN.md` |
| Developer | implementar usando Rules, Skills e Spec | código + migrations |
| Tester | validar migrations, testes backend e build frontend | `tasks/reports/TEST_REPORT.md` |
| Reviewer | revisar arquitetura, segurança, CQRS e qualidade | `tasks/reports/REVIEW_REPORT.md` |
| Documentation | atualizar README, decisões e instruções de execução | documentação final |

## Regras globais

- Laravel deve ser usado de forma idiomática.
- CQRS é obrigatório quando a operação alterar ou consultar estado de negócio.
- Command altera estado; Query consulta estado.
- Controllers devem ser finos.
- Form Requests cuidam da validação HTTP.
- Policies/Gates cuidam de autorização.
- API Resources cuidam da transformação da resposta.
- Eloquent não deve carregar regra de negócio complexa para Controllers.
- Alterações estruturais de banco devem usar migrations.
- Specs e Rules têm prioridade sobre convenções genéricas do agente.
- Skills devem ser lidas sob demanda, somente quando necessárias.
- Nenhuma tarefa é concluída sem passar pelos Quality Gates aplicáveis.
