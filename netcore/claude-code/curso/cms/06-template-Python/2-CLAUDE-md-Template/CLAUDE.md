<!--
⚠️ META-INSTRUCTIONS FOR AI SETUP — READ THIS FIRST, THEN DELETE THIS COMMENT
This HTML comment block is stripped before entering context in most tools,
but read it now, during setup, before you write anything.

You are setting up this project's AI configuration. This is NOT a single
file to fill in — it's a small system of files, and where you put each
piece of information matters. Aim to keep CLAUDE.md itself under ~150
lines once filled in, comfortably inside Anthropic's own official ceiling
of ~200 lines — beyond that, files cause context degradation: the model
has a limited "instruction budget" per session, and a bloated
always-loaded file dilutes the rules that actually matter. Detailed
content belongs in agent_docs/ (loaded on demand via @import) or
.claude/rules/ (loaded only when relevant files are touched), not pasted
into this file.

Follow this process:

1. INTERVIEW THE USER. Ask about: project purpose, language(s) and
   framework(s), package manager, database, deployment target, existing
   conventions, team size, critical business rules, security-sensitive
   areas (payments, PII, auth, multi-tenancy), and tools already in use
   (CI, GitHub CLI, Supabase, Linear, etc). Ask in small groups, not a wall
   of 20 questions at once.

2. RESEARCH BEFORE WRITING ANYTHING. For the stack named, search the web
   for this year's current best practices, the current LTS/stable version
   of the language and major frameworks, the real tools that stack's
   professional developers use for linting, type-checking, testing, and
   pre-push validation, AND the idiomatic project/architecture patterns for
   that stack (e.g. the standard app-router feature structure for Next.js,
   the conventional layered structure for Django, standard module layout
   for Go). Don't rely on memorized defaults — what's correct for Node.js
   is often wrong for Python, Go, or Rust, and what was idiomatic a couple
   years ago may not be the current recommended pattern. If you don't have
   web access this session, say so explicitly, use your most current
   knowledge, and flag which recommendations the user should verify
   manually.

3. DISTRIBUTE CONTENT TO THE RIGHT FILE. This is the most important rule
   in this setup:
   - CLAUDE.md (this file) → only what's needed in EVERY session: a
     2-3 line project summary, the exact commands (build/test/lint/typecheck),
     file structure map, and pointers (@imports) to the files below. Nothing
     else. If you're about to write a paragraph of explanation here, it
     probably belongs in agent_docs/ instead.
   - agent_docs/business-rules.md → the domain logic that must never be
     violated. This is usually the single highest-value file in the whole
     setup, because it's context an AI session has no way to infer from
     code alone.
   - agent_docs/security.md → security practices specific to this stack
     and domain. Research current, real risks for the actual tech in use —
     not a generic checklist.
   - agent_docs/engineering-standards.md → the quality philosophy
     (correctness, TDD for bug fixes, documentation discipline, when
     performance work is worth it). Principles here are stack-agnostic;
     say so, and point to where the stack-specific implementation lives.
   - agent_docs/architecture.md → only if the project is complex enough to
     need it (multiple services, non-obvious data flow, key design
     decisions and why they were made). Skip for simple projects.
   - agent_docs/productivity.md → tooling and workflows that make this
     specific developer/project faster (git worktrees, GitHub CLI,
     database CLIs, project-management integrations). Only what's actually
     in use or genuinely useful here — skip if nothing applies.
   - .claude/rules/ → conventions that only apply to PART of the codebase.
     Use YAML frontmatter with a `paths:` field so the rule only loads when
     Claude touches matching files (see .claude/rules/general.md for the
     format, including a note about a known loading bug worth checking for
     with `/memory`). This is for things like "React components go here,
     follow this pattern" that would waste context if loaded during
     backend work.
   - Deterministic checks (formatting, import order, line length) do NOT
     belong in any of these files as prose. If a linter/formatter can
     enforce it automatically, configure the linter and just reference the
     command in CLAUDE.md — don't write style rules a formatter already
     guarantees. Prose rules are for judgment calls a linter can't make.

4. DON'T JUST WRITE RULES — SET UP REAL ENFORCEMENT WHERE IT MATTERS. Rules
   written as prose in any of these files are context, not enforcement:
   the model can still skip them under context pressure. For the one rule
   that matters most ("validate before every push"), configure the example
   hook in .claude/hooks/README.md for real, using this project's actual
   lint/typecheck commands. Don't leave it as a generic placeholder if you
   have the real commands from the interview.

5. MULTI-TOOL SETUP: AGENTS.md IS THE SOURCE OF TRUTH. If the user names a
   tool other than Claude Code (Cursor, Copilot, Windsurf, Codex, Gemini
   CLI, etc), or says they use more than one tool, don't generate separate
   duplicated files per tool — that drifts out of sync over time. Instead:
   - Create `AGENTS.md` at the project root containing everything from
     step 3 above (Project Context, Stack, Commands, File Structure,
     Workflow Rules) — this is the open standard read natively by Cursor,
     Copilot, Gemini CLI, Windsurf, Codex, and most other agents.
   - Make `CLAUDE.md` a thin wrapper: its first line is `@AGENTS.md`
     (imports the file above), followed only by anything genuinely
     Claude-Code-specific below that line (e.g. a note about using Plan
     Mode for certain paths). Don't duplicate AGENTS.md content into
     CLAUDE.md.
   - If the user's tool has its own native scoped-rules format (e.g.
     Cursor's `.cursor/rules/*.mdc`), still create it, but keep it thin
     too — it should add only what AGENTS.md structurally can't express
     (e.g. glob-scoped activation), not restate shared content.
   - If the user only uses Claude Code and says so explicitly, skip
     AGENTS.md and fill CLAUDE.md directly as described in step 3 — don't
     add multi-tool complexity nobody asked for.
   - The `agent_docs/` and `.claude/rules/` structure from step 3 stays
     the same either way; only the root file(s) change shape.

6. WHEN A TOOL OTHER THAN CLAUDE CODE IS IN USE, place its config file in
   that tool's actual expected location (research the current path if
   unsure — this changes between tool versions and Cursor in particular
   has moved from `.cursorrules` to `.cursor/rules/*.mdc`). Don't just
   generate content; put it where that tool will actually read it.

7. ADD FILES/SECTIONS THE PROJECT ACTUALLY NEEDS beyond what's listed here
   (e.g. a monorepo-specific doc, a deploy runbook) — this structure is a
   floor, not a ceiling. But keep the same discipline: the root file(s)
   stay short, detail goes in agent_docs/ or scoped rules.

8. WHEN DONE, delete this entire comment block and the "Setup Note" line
   at the bottom of this file. Everything else in this file is the
   permanent, always-loaded configuration.
-->

# Project Context

[2-3 sentences: what this project does, who it's for, what problem it
solves. This is the only place a long explanation is allowed to NOT exist —
keep it tight even here.]

# Stack

[Language(s), framework(s), package manager, database, deployment target,
with versions where they matter — e.g. "Node 22 LTS," not just "Node."]

# Commands

[The exact, copy-pasteable commands for this project. This is the
highest-value section in the file — concrete commands beat prose every
time.]

```
# Install
[command]

# Run dev
[command]

# Test
[command]

# Lint + typecheck
[command]

# Build
[command]
```

# File Structure

[A short directory tree, one line per top-level folder. Just enough for an
AI session to know where to look and where to add new files — don't
reproduce the whole repo.]

```
[tree here]
```

# Workflow Rules

[Short, concrete, verifiable rules — not vague advice. "Run lint + typecheck
after code changes, before considering a task done" beats "write good
code." "Reproduce bugs with a failing test before fixing" beats "test your
changes." Keep this to a handful of bullets; anything longer belongs in
agent_docs/engineering-standards.md.]

# Deeper Context (read when relevant)

These files are not loaded automatically in full — Claude reads them when
the task requires that context. Import what's always needed with `@`;
leave the rest as pointers Claude reads on demand.

- Business rules and domain logic: @agent_docs/business-rules.md
- Security practices for this project: @agent_docs/security.md
- Engineering standards and quality philosophy: @agent_docs/engineering-standards.md
- Architecture decisions: @agent_docs/architecture.md
- Productivity tools and workflows: @agent_docs/productivity.md
- Path-scoped conventions (frontend/backend/etc): see `.claude/rules/`

# Keeping This File Current

This is a living system, not a one-time setup artifact. If you encounter
something during real work that should be a permanent rule — a business
rule, a security constraint, an architectural decision, a mistake worth
never repeating — don't just apply it silently. Ask whether it should be
added, and add it to the right file above (not dumped into this one). When
you get something wrong because a rule was missing, that's a signal the
docs need updating — say so.

# Response Language

Always respond in Brazilian Portuguese, regardless of the language used in the prompt.

<!-- Setup Note: delete this line and the comment block at the top once setup is complete. -->
