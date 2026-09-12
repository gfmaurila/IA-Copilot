# Skill: Create Complete User Registration Wizard

## Objetivo

Criar o fluxo completo de cadastro de usuário em etapas reutilizando os CRUDs da fundação.

## Etapas

1. Person
2. Documents (N)
3. Contacts (N)
4. Addresses (N)
5. User Account
6. Roles
7. Preferences
8. Review & Complete

## Regras

- usar Vertical Slice + CQRS conforme arquitetura do projeto;
- validar cada etapa com FluentValidation;
- permitir salvar progresso;
- uma PERSON pode ter N PERSON_CONTACT;
- PERSON_CONTACT deve referenciar CONTACT_TYPE por `CONTACT_TYPE_ID`;
- aceitar múltiplos contatos do mesmo tipo;
- aceitar múltiplos documentos e endereços;
- persistir somente PASSWORD_HASH;
- finalizar o cadastro de forma transacional;
- criar AUDIT_LOG na conclusão;
- retornar PERSON_ID e USER_ACCOUNT_ID;
- cobrir o fluxo completo com testes de integração.
