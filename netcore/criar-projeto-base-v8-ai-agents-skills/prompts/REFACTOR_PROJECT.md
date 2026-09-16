# Prompt - Refactor Existing Project

Objetivo: refatorar projeto existente preservando comportamento esperado.

Fluxo:

```text
Analyze existing repository
 -> Requirements/Constraints
 -> Architecture gap analysis
 -> Refactor execution plan
 -> Developer loop
 -> Tester
 -> Reviewer
 -> Documentation
```

Regras:

- não reescrever por preferência estética;
- registrar comportamento que precisa ser preservado;
- priorizar mudanças incrementais;
- separar mudança estrutural de mudança funcional;
- manter build/test executáveis ao longo da refatoração sempre que possível.
