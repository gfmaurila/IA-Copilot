# Prompt — Refactor Project

Analise o projeto atual e refatore usando o workflow de agentes.

Prioridades:
1. detectar violações de dependência Hexagonal;
2. remover Spring/JPA/infra do Domain;
3. impedir Application -> Adapter;
4. separar Input/Output Ports;
5. corrigir CQRS;
6. adicionar testes antes de mudanças arriscadas;
7. executar build, testes e review.

Não reescreva código saudável sem justificativa.
