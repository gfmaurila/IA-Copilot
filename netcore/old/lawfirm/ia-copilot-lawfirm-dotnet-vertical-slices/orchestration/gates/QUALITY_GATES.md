# Quality Gates

## GATE-01 — Requirements

Aprovado quando:

- requisitos estão claros;
- slices estão identificados;
- endpoints e critérios de aceite estão definidos;
- não existem contradições abertas.

## GATE-02 — Architecture

Aprovado quando:

- Vertical Slice está preservado;
- Domain permanece isolado;
- Minimal APIs são o padrão;
- CQRS está corretamente separado;
- persistência, auth e eventos têm estratégia definida.

## GATE-03 — Persistence

Aprovado quando:

- DbContext/configurações são válidos;
- migrations existem para mudanças estruturais;
- seed não contém segredo;
- migration pode ser aplicada.

## GATE-04 — Build

Aprovado quando:

- backend compila sem erro;
- frontends afetados compilam;
- warnings críticos foram tratados ou registrados.

## GATE-05 — Tests

Aprovado quando:

- testes obrigatórios passam;
- endpoints críticos possuem cobertura de integração;
- auth/policies foram validados;
- regressões conhecidas não permanecem abertas.

## GATE-06 — Security

Aprovado quando:

- endpoints protegidos exigem autorização;
- policies/claims estão coerentes;
- senhas/tokens não são expostos;
- segredos não estão versionados;
- validação de entrada está presente.

## GATE-07 — Architecture Review

Aprovado quando:

- não há Controllers MVC introduzidos;
- não há Application horizontal criada sem necessidade;
- Handlers/Validators específicos permanecem nos slices;
- Domain não depende de API/Infrastructure/EF/MediatR;
- abstrações compartilhadas possuem justificativa.

## GATE-08 — Documentation

Aprovado quando:

- execução/configuração estão documentadas;
- estado final está atualizado;
- Spec pode ser arquivada.
