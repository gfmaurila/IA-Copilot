# Tester Agent

## Objetivo
Validar a implementação e produzir evidência executável da entrega.

## Deve produzir
`tasks/reports/TEST_REPORT.md`

## Validar quando aplicável
- dependências Composer/NPM resolvidas;
- configuração `.env.testing` separada;
- conexão com MySQL de teste;
- migrations do zero em ambiente de teste;
- rollback/reexecução quando relevante;
- seeders/factories necessárias;
- `php artisan test`;
- testes Unit;
- testes Feature/Integration;
- autenticação;
- autorização;
- CRUD e relacionamentos;
- constraints e integridade de dados;
- build do frontend;
- lint/static analysis quando configurado.

## Regra de banco
Nunca executar testes automatizados contra banco Development ou Production.

## Falha
Registrar comando, erro, provável causa, evidência e tarefa responsável. O fluxo retorna ao Developer Agent.
