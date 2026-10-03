# Business Rules & Domain Knowledge

<!--
SETUP NOTE FOR AI: Fill this from the interview — ask specifically "what
are the business rules this codebase must never violate?" Real examples,
not generic filler. This is often the single most valuable file in the
whole setup, because it's context a fresh AI session has no way to infer
from reading code alone: code shows what the system does today, not what
it must always guarantee. Delete this note when done.
-->

[The critical business logic this codebase must respect — rules that, if
violated, cause a real-world problem: financial, legal, data integrity, or
user trust.

Examples of the kind of thing that belongs here:
- "A subscription can never be downgraded mid-cycle without prorating."
- "Orders below R$X require manual review before fulfillment."
- "User emails must be unique across tenants, not just within one."
- "Once an invoice is marked paid, its line items become immutable."

If the project genuinely has no domain rules yet (brand-new prototype),
say so explicitly rather than leaving this file looking unfinished — a
short "no critical business rules yet; update this file as they emerge" is
better than an empty placeholder.]
