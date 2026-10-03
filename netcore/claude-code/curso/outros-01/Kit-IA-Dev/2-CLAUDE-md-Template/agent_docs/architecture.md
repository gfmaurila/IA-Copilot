# Architecture

<!--
SETUP NOTE FOR AI: This file is OPTIONAL. Only fill it in if the project
is complex enough to need it — multiple services, non-obvious data flow,
or key design decisions a new session would otherwise get wrong. For a
simple single-app project, delete this file entirely rather than leaving
it as filler; an unnecessary file that Claude checks and finds empty still
costs a tool call. Delete this note when done (or delete the whole file).
-->

[Key architectural decisions and why they were made — not a full system
diagram in prose, just what a new session needs to avoid working against
the grain of the system.

Consider covering, where relevant:
- **Idiomatic structure for this stack** — the standard project/architecture
  pattern for the framework in use (e.g. feature-based structure for
  Next.js App Router, layered structure for Django, standard module layout
  for Go), researched fresh rather than assumed, and whether this project
  follows it or deliberately deviates.
- **Service boundaries** — what talks to what, and why they're separated
  this way.
- **Data flow** — for anything non-obvious (e.g. events vs. direct calls,
  caching layers, eventual consistency points).
- **Key decisions and their trade-offs** — e.g. "we use optimistic locking
  here instead of pessimistic because—," so a future session doesn't
  "fix" something that was deliberate.
- **What NOT to do** — patterns the team deliberately moved away from, and
  why, so they don't get silently reintroduced.

Use `file:line` references to point at real code instead of pasting code
blocks that will go stale — e.g. "see the event dispatcher in
`src/events/dispatcher.ts:12-40`."]
