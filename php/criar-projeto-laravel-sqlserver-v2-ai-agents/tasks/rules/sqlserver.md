# Rule - SQL Server

## Banco padrão
Este template utiliza Microsoft SQL Server como banco relacional principal através do driver `sqlsrv` do Laravel/PDO.

## Configuração
Usar por padrão:

```env
DB_CONNECTION=sqlsrv
DB_HOST=database
DB_PORT=1433
DB_DATABASE=meuprojeto_dev
DB_USERNAME=sa
DB_PASSWORD=Your_strong_password123!
DB_ENCRYPT=yes
DB_TRUST_SERVER_CERTIFICATE=true
```

Credenciais reais nunca devem ser versionadas. Ajustar criptografia/certificado conforme o ambiente corporativo.

## Regras de modelagem
- toda alteração estrutural deve ser feita por Migration;
- migrations devem respeitar dependências entre tabelas e foreign keys;
- usar `unique` para regras reais de unicidade;
- criar índices a partir de consultas, filtros, joins e ordenações relevantes;
- evitar índices redundantes ou indiscriminados;
- preferir `nvarchar`/Unicode para conteúdo textual quando houver necessidade de caracteres internacionais;
- definir comprimentos de strings conscientemente;
- usar `decimal(precision, scale)` para valores monetários; nunca `float` para dinheiro;
- preferir `datetime2` quando precisão temporal for relevante;
- avaliar `date`, `time`, `bigInteger`, `uniqueidentifier` e demais tipos conforme domínio;
- considerar limite de tamanho/chave de índices do SQL Server ao indexar strings extensas;
- nomes de constraints e índices devem ser estáveis quando manutenção/DBA exigir previsibilidade.

## Laravel / Eloquent
- preferir Eloquent e Query Builder com bindings;
- evitar SQL concatenado;
- ao usar SQL nativo, usar parâmetros/bindings;
- validar diferenças de sintaxe do SQL Server antes de usar funções específicas de MySQL/PostgreSQL;
- não usar `LIMIT`; paginação/limitação deve ser feita pelas APIs do Laravel ou sintaxe compatível com SQL Server;
- evitar N+1 com eager loading quando aplicável;
- usar transactions para operações multi-etapas que precisam de atomicidade;
- considerar deadlocks e concorrência em rotinas críticas;
- não adicionar hints (`NOLOCK`, `UPDLOCK`, etc.) sem justificativa explícita e documentação.

## Identidade e chaves
- IDs incrementais podem usar `id()`/`bigIncrements()` quando apropriado;
- UUIDs podem ser usados quando a Spec exigir; validar mapeamento para `uniqueidentifier`;
- foreign keys devem usar tipos compatíveis com suas PKs;
- cascade delete/update deve ser adotado conscientemente e não por padrão em relacionamentos sensíveis.

## Bancos por ambiente
Manter bancos separados, por exemplo:

```text
meuprojeto_dev
meuprojeto_test
```

Nunca executar testes automatizados em Development, Homologação compartilhada ou Production.

## Testes mínimos
Validar pelo menos:

```bash
php artisan migrate:fresh --env=testing
php artisan test
```

Quando rollback for relevante, validar também:

```bash
php artisan migrate --env=testing
php artisan migrate:rollback --env=testing
php artisan migrate --env=testing
```

## Docker
Ao gerar ambiente Docker, preferir imagem oficial compatível do SQL Server, aceitar o EULA explicitamente e usar healthcheck antes de iniciar dependências da API.
