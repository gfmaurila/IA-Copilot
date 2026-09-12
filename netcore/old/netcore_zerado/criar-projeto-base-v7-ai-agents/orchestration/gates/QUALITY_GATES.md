# Quality Gates

## GATE-01 Requirements

PASS quando:

- requisitos possuem IDs;
- critérios de aceite são verificáveis;
- conflitos com Specs foram resolvidos usando a fonte oficial.

## GATE-02 Architecture

PASS quando:

- Domain não depende de Infrastructure/API;
- persistência está em Infrastructure;
- APIs são finas;
- regras de segurança e testes foram contempladas.

## GATE-03 Persistence

Quando houver banco relacional, PASS quando:

- DbContext criado;
- mappings explícitos criados;
- migration obrigatória criada;
- script de migration validado;
- Development e Test separados.

## GATE-04 Build

PASS somente quando o build obrigatório terminar sem erro.

## GATE-05 Tests

PASS somente quando testes obrigatórios passarem.

Testes ignorados precisam de justificativa registrada no relatório.

## GATE-06 Security

PASS quando:

- secrets não estão hardcoded;
- senha não está em texto puro;
- autorização segue as rules;
- tokens/secrets completos não são logados.

## GATE-07 Review

Status possíveis:

```text
APPROVED
APPROVED_WITH_NOTES
CHANGES_REQUESTED
BLOCKED
```

A entrega final exige `APPROVED` ou `APPROVED_WITH_NOTES` sem blocker.

## GATE-08 Documentation

PASS quando README e instruções de execução refletem o código entregue.
