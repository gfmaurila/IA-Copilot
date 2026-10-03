# Quality Gates

Uma tarefa só pode receber PASS quando todos os gates aplicáveis forem satisfeitos:

1. Scope Gate — somente o escopo autorizado foi alterado.
2. Build Gate — build/compilação aplicável concluído com sucesso.
3. Test Gate — testes aplicáveis executados e aprovados.
4. Architecture Gate — regras arquiteturais preservadas.
5. Regression Gate — nenhuma regressão conhecida introduzida.
6. Documentation Gate — documentação/estado atualizados quando exigidos.
7. Evidence Gate — relatório final contém comandos/validações e arquivos alterados.

Se um gate aplicável não puder ser executado, o resultado máximo é PARTIAL e o motivo deve ser informado.
