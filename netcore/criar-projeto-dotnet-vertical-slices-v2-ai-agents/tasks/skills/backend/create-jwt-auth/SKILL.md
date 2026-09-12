# Skill: Create JWT Authentication

## Objetivo
Criar autenticação JWT padronizada.

## Criar
- LoginCommand
- LoginCommandHandler
- LoginCommandValidator
- TokenService
- RefreshToken
- endpoints de login e refresh

## Regras
- senha nunca em texto puro
- usar hash seguro
- validar usuário ativo
- Access Token de curta duração
- Refresh Token separado
- usar IConfiguration/Options
- segredo fora do código
- incluir claims necessárias para autorização
