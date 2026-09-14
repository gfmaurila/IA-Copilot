# Prompt - Create Project

Execute o workflow definido em:

```text
orchestration/workflows/PROJECT_CREATION.md
```

Spec ativa:

```text
{{SPEC}}
```

## Regras de execução

1. Não iniciar implementação antes de Requirements, Architecture e Execution Plan.
2. Usar `tasks/rules/` como regras globais.
3. Usar a Spec como fonte funcional oficial.
4. Ler somente as Skills necessárias para cada task.
5. Implementar uma task por vez.
6. Após cada bloco relevante, executar validações adequadas.
7. Se build/test falhar, corrigir antes de continuar quando a falha for causada pela task atual.
8. Não declarar conclusão com gate obrigatório falhando.
9. Atualizar `orchestration/state/PROJECT_STATE.md` durante a execução.
10. Consolidar resultado final nos relatórios.
