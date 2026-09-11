# MeuProjeto - Base

Template inicial para geração de projeto Full Stack.

## Primeira entrega

- CRUD usuários
- CRUD grupos
- permissões Read/Write
- JWT
- testes unitários
- testes de integração
- SQL Server Dev/Test
- React Admin/Site

## Documentos principais

- `CRIAR-PROJETO.md`
- `tasks/specs/changes/001-project-foundation.md`
- `tasks/rules/`
- `tasks/skills/`


## Docker Compose

O arquivo `docker-compose.yml` começa vazio e deve ser gerado pelo Copilot
durante a execução da Spec.

A senha SQL Server segue o padrão:

```text
Gfm@d{dia}m{mes}a{ano}
```


## Topologia Docker inicial

```text
Browser
├── http://localhost:8081 -> frontend-admin -> api-admin -> sqlserver
└── http://localhost:8082 -> frontend-site  -> api-site  -> sqlserver
```

Portas sugeridas:

```text
Admin Frontend : 8081
Site Frontend  : 8082
Admin API      : 5001
Site API       : 5002
SQL Server     : 1433
```
