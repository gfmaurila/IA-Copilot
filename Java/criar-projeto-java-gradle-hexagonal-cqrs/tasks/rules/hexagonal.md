# Hexagonal Architecture Rules

- Domain fica no centro.
- Domain não conhece Spring, JPA, HTTP ou MySQL.
- Application define Input Ports e Output Ports.
- Adapter In chama Input Ports.
- Adapter Out implementa Output Ports.
- Dependências sempre apontam para dentro.
- Controller nunca acessa JpaRepository.
- Domain Entity e JPA Entity são separadas.
