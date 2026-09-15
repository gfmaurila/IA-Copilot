# Workflow — Project Creation

## 1. Intake

Ler:

1. `CRIAR-PROJETO.md`
2. `AGENTS.md`
3. todas as `tasks/rules/**`
4. Spec ativa

## 2. Requirements Gate

Executar Requirements Agent.

Saída obrigatória:

`tasks/generated/REQUIREMENTS.md`

## 3. Architecture Gate

Executar Architect Agent.

Saída obrigatória:

`tasks/generated/ARCHITECTURE_PLAN.md`

## 4. Planning Gate

Executar Tech Lead Agent.

Saída obrigatória:

`tasks/generated/EXECUTION_PLAN.md`

## 5. Implementation Loop

Para cada tarefa:

```text
Tech Lead Task
     ↓
Developer
     ↓
Validation
     ↓
PASS → próxima tarefa
FAIL → corrigir → validar novamente
```

Implementar por slice, não por camada horizontal.

## 6. Test Gate

Executar Tester Agent e gerar `TEST_REPORT.md`.

Se houver falha bloqueante, retornar ao Developer.

## 7. Review Gate

Executar Reviewer Agent e gerar `REVIEW_REPORT.md`.

`CHANGES_REQUIRED` retorna ao Developer e exige nova validação.

## 8. Documentation Gate

Executar Documentation Agent.

## 9. Finalização

A Spec só pode ser arquivada após todos os gates obrigatórios aprovados.
