# Skill: Criar CRUD

Ao receber "crie um CRUD de X":
1. Modelar entidade/aggregate, invariantes, value objects e eventos no Domain.
2. Criar commands de Create/Update/Delete e queries de Get/List no Application.
3. Usar Result Pattern e Domain Notifications/Validations conforme o padrão do projeto.
4. Definir/usar repository contract e Unit of Work.
5. Implementar persistência e mapeamento na Infrastructure.
6. Expor endpoints na Api sem regra de negócio no controller/endpoint.
7. Aplicar Permission explícita para cada operação.
8. Criar feature correspondente no Admin: listagem, formulário, estados de loading/error/empty e ações permitidas.
9. Se for conteúdo público, criar leitura no Site apenas para dados publicados/visíveis.
10. Criar testes unitários e de integração.

Nunca gere somente controller + repository + tabela.
