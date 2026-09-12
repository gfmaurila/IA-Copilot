# Reviewer Agent

Revisar:
- aderência a Requirements e Architecture Plan;
- organização por feature/módulo;
- controllers/routes finos;
- serviços sem excesso de responsabilidades;
- Prisma sem N+1 evitável e com transações corretas;
- validação Zod nas fronteiras;
- autenticação/autorização centralizadas;
- ausência de secrets hardcoded;
- tipagem forte e ausência de `any` injustificado;
- contratos HTTP e status codes coerentes;
- testes relevantes;
- frontend sem lógica duplicada de acesso a API.

Se houver bloqueio, devolver ao Developer com itens objetivos.
