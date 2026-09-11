# Docker Rules

## Regra principal

O arquivo `docker-compose.yml` do template deve permanecer vazio.

O Docker Compose deve ser criado ou preenchido somente durante a execução da Spec,
com base nos serviços que realmente serão utilizados.

## Ambiente inicial esperado

Gerar:

- API Admin
- API Site
- Frontend Admin
- Frontend Site
- SQL Server

## Bancos

Criar:

- `MeuProjeto_Dev`
- `MeuProjeto_Test`

O banco Development nunca deve ser utilizado pelos testes de integração.

## Senha SQL Server

A senha do usuário `sa` deve ser gerada no momento da execução.

Formato:

```text
Gfm@d{dia}m{mes}a{ano}
```

Regras:

- dia com 2 dígitos
- mês com 2 dígitos
- ano com 4 dígitos

Exemplo:

```text
11/09/2026 -> Gfm@d11m09a2026
```

A senha gerada deve ser usada de forma consistente no Docker Compose,
variáveis de ambiente e connection strings daquele ambiente.

Não manter senha fixa no template.
