# Skill: Arquitetura do projeto

Antes de gerar código, identifique a feature e respeite as fronteiras existentes.

Fluxo de dependência: Api -> Application -> Domain; Infrastructure implementa contratos definidos para o núcleo e é registrada por CrossCutting. Domain não depende de Infrastructure ou API.

Frontend: admin e site são módulos independentes; shared contém apenas contratos e elementos realmente compartilháveis.

Nunca mova regras de domínio para controllers, componentes React ou repositories.
