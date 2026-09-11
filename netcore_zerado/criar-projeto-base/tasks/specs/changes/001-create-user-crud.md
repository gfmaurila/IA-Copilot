# Spec 001 - CRUD de Usuários

## Objetivo
Criar gerenciamento completo de usuários no Admin.

## Domain
Criar `User` com Id, Name, Email, PasswordHash, Active, CreatedAt e UpdatedAt.

Criar Domain Events: UserCreated, UserUpdated e UserDeleted.

## Backend
Commands: CreateUser, UpdateUser, DeleteUser.

Queries: GetUserById e GetPagedUsers.

Endpoints:
- GET `/api/users`
- GET `/api/users/{id}`
- POST `/api/users`
- PUT `/api/users/{id}`
- DELETE `/api/users/{id}`

Validação: nome obrigatório (3-150), email obrigatório e válido, senha mínima de 8 caracteres no cadastro.

## Frontend Admin
Criar `src/modules/users` com List, Create, Edit, Details, Form, schemas, services e types.

Listagem deve possuir paginação, busca por nome/email, ordenação e ações Novo, Editar, Detalhes e Excluir.

Formulário deve usar React Hook Form + Zod.

## Skills sugeridas
Backend: create-entity, create-command, create-query, create-validator, create-domain-event, create-repository, create-endpoint, create-unit-test, create-integration-test.

Frontend: create-module, create-page, create-form, create-service, create-table, create-crud.

## Critérios de aceite
- Backend compila.
- Frontend compila.
- CRUD funciona.
- Validações funcionam.
- Paginação funciona.
- Erros HTTP seguem ProblemDetails.
- Testes passam.
