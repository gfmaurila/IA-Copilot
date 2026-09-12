# Skill: Create EF Core Development Seed Migration

## Objetivo

Criar uma migration `DevelopmentSeed` com dados fake coerentes para desenvolvimento, conforme `001-project-foundation.md`.

## Regras

- usar EF Core migrations (`InsertData`, SQL controlado ou equivalente dentro da migration);
- usar IDs determinísticos;
- respeitar a ordem das FKs no `Up()`;
- remover dados na ordem inversa no `Down()`;
- nunca usar dados pessoais reais;
- nunca inserir tokens/secrets válidos;
- incluir exemplos completos de PERSON com múltiplos documentos, contatos e endereços;
- incluir CONTACT_TYPE: PHONE, MOBILE, EMAIL, WHATSAPP, TELEGRAM e OTHER;
- incluir organizations, groups, users, roles, resources, permissions, preferences, login attempts e audit logs;
- marcar a migration como exclusiva de desenvolvimento/demo no processo de deploy;
- validar com `dotnet ef migrations script`.
