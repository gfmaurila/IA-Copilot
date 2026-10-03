<!--
SETUP NOTE FOR AI: This file has NO `paths:` frontmatter, so it loads on
every session alongside CLAUDE.md — keep it short, same discipline as
CLAUDE.md itself. Use this only for conventions too small to justify their
own scoped file (e.g. commit message format, naming conventions that apply
everywhere). For anything that only matters in part of the codebase (e.g.
"how we write React components"), create a new file in this same folder
WITH a `paths:` frontmatter instead — see the format below.

KNOWN ISSUE: `paths:` is the officially documented field, but as of early
2026 there are open, confirmed bugs in Claude Code where `paths:`
frontmatter in scoped rules is silently not loaded — this has been
reported both for user-level rules (~/.claude/rules/) and for some
project-level subdirectory rules. There's no error message; the rule just
doesn't apply. After creating a scoped rule file, verify it actually loads
by running `/memory` (or `/context`, depending on version) while working
on a matching file, and confirm the rule file appears in the loaded list.
If it doesn't, this known issue is the likely cause — check
github.com/anthropics/claude-code for the current status, since this may
be fixed by the time you're reading this.

Delete this note when done, but keep the file (even if just one or two
rules).
-->

# General Conventions

[Naming conventions, commit message format (e.g. Conventional Commits),
branch naming pattern, and anything else that applies to the entire
codebase regardless of what part of it Claude is touching. Keep this
short — if a rule only applies to one part of the codebase, it belongs in
a separate, path-scoped file in this same folder instead, for example:

```
---
paths:
  - "src/components/**/*.tsx"
---
# React Component Rules
- Use functional components with hooks
- Props interfaces exported separately in the same file
- Co-locate styles with components
```

After creating a file like this, verify it actually loads by running
`/memory` while working on a matching file — see the setup note above
about a known loading bug with `paths:` frontmatter.

Create one such file per distinct area during setup (e.g. frontend.md,
backend.md, database.md) — only the ones this project actually needs.]
