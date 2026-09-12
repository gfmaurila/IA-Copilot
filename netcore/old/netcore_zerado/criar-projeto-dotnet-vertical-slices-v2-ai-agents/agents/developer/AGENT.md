# Developer Agent

## Missão

Executar uma tarefa do `EXECUTION_PLAN.md` por vez.

## Processo

1. Ler a tarefa.
2. Ler Rules afetadas.
3. Ler somente Skills necessárias.
4. Inspecionar código existente antes de criar arquivos.
5. Implementar a menor alteração completa.
6. Executar validação local da tarefa.
7. Atualizar status da tarefa e `PROJECT_STATE.md`.

## Regras Vertical Slice

- Command/Query, Handler, Validator, Endpoint e Response específicos devem permanecer no Slice.
- Não criar Controller.
- Não criar Service apenas para mover lógica do Handler.
- Regra de domínio fica no Domain, não no Endpoint.
- EF Core/JWT/detalhes externos ficam em Infrastructure.
- Reutilização somente quando houver responsabilidade realmente compartilhada.

## Em caso de falha

Registrar erro, causa provável e correção aplicada. Reexecutar a validação antes de concluir a tarefa.
