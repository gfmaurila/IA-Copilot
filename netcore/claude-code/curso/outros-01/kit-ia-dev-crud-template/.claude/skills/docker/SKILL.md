# Skill: Docker

O Compose principal fica na raiz. Deve permitir ambiente de desenvolvimento completo e fornecer banco de teste isolado para integração. DEV pode usar volume persistente; TEST deve privilegiar isolamento e descarte.

Ao adicionar dependência de infraestrutura, avaliar separadamente sua necessidade em DEV e TEST e atualizar healthchecks/dependencies.
