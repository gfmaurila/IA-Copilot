# Rule - MySQL

## Banco padrão
Este template utiliza MySQL como banco relacional principal.

## Regras
- toda alteração estrutural deve ser feita por Migration;
- migrations devem possuir ordem/dependências coerentes;
- preferir foreign keys reais para integridade referencial quando aplicável;
- usar `unique` para regras de unicidade de persistência;
- criar índices com base nas consultas e relacionamentos relevantes, evitando indexação indiscriminada;
- definir tamanhos/tipos de coluna conscientemente;
- usar `decimal` para valores monetários, evitando `float`;
- usar transações para fluxos multi-etapas que precisam ser atômicos;
- evitar SQL concatenado; preferir Query Builder/Eloquent e bindings;
- evitar N+1 com eager loading quando necessário;
- separar banco Development e banco Test;
- nunca executar testes automatizados contra Production.

## Testes
Validar pelo menos:

```bash
php artisan migrate:fresh --env=testing
php artisan test
```

Quando rollback for parte relevante da mudança, validar também o caminho de reversão.
