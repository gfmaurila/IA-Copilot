# Docker Rules

O docker-compose.yml começa vazio.

Gerar durante a Spec.

Por padrão:

frontend-admin -> api
frontend-site -> api
api -> database

Se a Spec definir APIs separadas:

frontend-admin -> api-admin
frontend-site -> api-site

Não usar localhost entre containers.
