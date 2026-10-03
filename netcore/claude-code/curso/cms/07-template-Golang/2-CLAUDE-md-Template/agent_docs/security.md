# Security Considerations

<!--
SETUP NOTE FOR AI: Research current best practices for the ACTUAL stack in
use before filling this in — the real risks differ significantly between,
say, a Node/Express API, a Python/Django app, and a serverless setup. Don't
paste a generic OWASP checklist; make it specific to what this project
actually does and touches. Delete this note when done.
-->

[Security practices specific to this project's stack and domain.

Cover what's actually relevant:
- **Authentication/authorization approach** — how it works in this project,
  what to never bypass.
- **Secrets and environment variables** — where they live, confirmation
  they're never committed, how they're loaded in each environment.
- **Input validation and injection risks** — specific to the data layer in
  use (SQL, NoSQL, ORM-mediated, etc).
- **PII or payment data handling**, if applicable — what's stored, what
  isn't, what's encrypted.
- **Stack/infra-specific risks worth flagging** — e.g. serverless
  cold-start considerations, multi-tenant data isolation, dependency
  supply-chain risk for this ecosystem.

If the project has no special security surface yet, still cover the
baseline for the stack (secrets never committed, standard auth practices)
rather than leaving this empty.]
