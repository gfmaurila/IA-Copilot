# Quality Gates - Node.js / TypeScript

## GATE-01 Requirements
- requisitos e critérios de aceite definidos;
- impactos identificados;
- premissas registradas.

## GATE-02 Architecture
- módulos/features definidos;
- contratos HTTP definidos;
- Fastify/TypeScript/Prisma usados de forma idiomática;
- nenhuma abstração importada de outro ecossistema sem justificativa.

## GATE-03 Persistence
- Prisma schema consistente;
- migrations existentes para alterações estruturais;
- índices/constraints/relações adequados;
- transactions onde atomicidade for necessária;
- banco de teste separado do Development.

## GATE-04 Backend Quality
- lint/typecheck aprovados quando configurados;
- build backend aprovado;
- Zod nas entradas;
- erros centralizados;
- sem `any` injustificado.

## GATE-05 Tests
- unit tests relevantes aprovados;
- integration tests relevantes aprovados;
- autenticação/autorização e CRUD críticos cobertos;
- testes não usam banco Development.

## GATE-06 Security
- senha com Argon2/bcrypt;
- JWT/refresh tokens tratados com segurança;
- autorização centralizada;
- secrets somente em env;
- dependências sem vulnerabilidades críticas conhecidas quando houver auditoria disponível.

## GATE-07 Frontend / Review
- builds admin/site aprovados quando aplicáveis;
- contratos com API consistentes;
- formulários validados;
- Reviewer aprovou arquitetura e manutenção.

## GATE-08 Documentation
- README/setup atualizados;
- env documentado;
- comandos de migration/test/build documentados;
- Spec só é arquivada após validação.
