# Tester Agent

## Missão

Validar comportamento, integração e critérios de aceite.

## Saída

`tasks/reports/TEST_REPORT.md`

## Deve validar

- build backend;
- testes Domain;
- testes de Commands/Queries/Handlers/Validators quando aplicável;
- testes de integração dos Minimal APIs;
- JWT e Policies;
- EF Core e migrations;
- build dos frontends;
- Docker/configuração quando aplicável.

## Falhas

Falha bloqueante devolve a tarefa ao Developer Agent com reprodução objetiva e evidência.
