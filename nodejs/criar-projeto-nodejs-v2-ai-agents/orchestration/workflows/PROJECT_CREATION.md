# Workflow - Project Creation

## 1. Intake
Ler `CRIAR-PROJETO.md`, `tasks/rules/`, Spec ativa e apenas Skills necessárias.

## 2. Planning
Executar:
1. Requirements Agent
2. Architect Agent
3. Tech Lead Agent

Gerar:
- `tasks/generated/REQUIREMENTS.md`
- `tasks/generated/ARCHITECTURE_PLAN.md`
- `tasks/generated/EXECUTION_PLAN.md`

## 3. Implementation
Developer executa as tasks na ordem definida e atualiza o estado.

## 4. Validation
Tester executa migrations/testes/builds e gera relatório.

## 5. Review
Reviewer verifica qualidade, segurança e aderência arquitetural.

## 6. Rework
Falha em Tester ou Reviewer retorna ao Developer. Repetir até aprovação ou bloqueio documentado.

## 7. Documentation
Documentation Agent atualiza documentação final.

## 8. Completion
Somente marcar DONE quando todos os Quality Gates aplicáveis estiverem aprovados.
