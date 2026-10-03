# Skill: Usuários e permissões

Modele User, Role e Permission separadamente. Roles agrupam Permissions; autorização efetiva é verificada na API.

Convenção sugerida: `<resource>.<action>`, por exemplo users.read, users.create, pages.update, pages.publish, menus.update.

Toda operação mutável deve declarar a permissão necessária. Proteja também leituras administrativas. Nunca confie em permission flags enviados pelo cliente como prova de autorização.
