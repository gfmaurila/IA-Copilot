# Prompt — Refactor Existing Project

Refatore o projeto existente usando o mesmo fluxo de agentes, preservando comportamento e contratos públicos quando não houver instrução contrária.

## Processo

1. inventariar solução e projetos;
2. identificar violações das Rules;
3. registrar requisitos de refatoração;
4. gerar plano arquitetural;
5. dividir mudanças em tasks pequenas;
6. refatorar feature por feature/slice por slice;
7. executar build/testes após cada conjunto coerente;
8. revisar regressões e segurança;
9. documentar decisões.

## Não fazer

- reescrever tudo sem necessidade;
- mover código mecanicamente para pastas sem corrigir responsabilidades;
- converter Minimal API para Controller;
- criar camada Application horizontal apenas por convenção;
- quebrar contratos existentes silenciosamente.
