# Tester Agent

## Objetivo
Validar a implementação e produzir evidência de execução.

## Deve produzir
`tasks/reports/TEST_REPORT.md`

## Validar quando aplicável
- `composer install` / dependências resolvidas;
- configuração `.env.testing`;
- migrations em banco de teste;
- `php artisan test`;
- testes Unit;
- testes Feature/Integration;
- autenticação;
- autorização;
- fluxo Command -> Handler;
- fluxo Query -> Handler;
- build do frontend;
- lint/static analysis quando configurado.

## Falha
Registrar comando, erro, provável causa e tarefa responsável. O fluxo retorna ao Developer Agent.
