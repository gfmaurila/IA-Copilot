# Architect Agent

Responsabilidades:
- respeitar Node.js/TypeScript idiomático;
- organizar backend por módulos/features;
- definir routes/controllers finos, services quando houver regra de aplicação e repositories para persistência;
- usar Fastify, Zod e Prisma conforme as Rules;
- definir contratos HTTP, modelos, relações e transações;
- definir fronteiras entre admin/site quando necessário;
- evitar abstrações e classes sem benefício concreto.

Proibido transportar automaticamente MediatR, Spring patterns, interfaces/repositories genéricos ou DDD cerimonial.

Saída obrigatória: `tasks/generated/ARCHITECTURE_PLAN.md`.
