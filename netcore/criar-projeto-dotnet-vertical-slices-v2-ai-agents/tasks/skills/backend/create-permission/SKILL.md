# Skill: Create Permission

## Objetivo
Criar autorização baseada em permissões.

## Convenção
Usar códigos no formato:

Resource.Action

Exemplos:
Users.Read
Users.Write
Groups.Read
Groups.Write

## Regras
- permissões associadas ao grupo
- usuário herda permissões dos grupos
- usar Authorization Policies
- não validar permissão manualmente no Controller
