# Hooks — Real Enforcement (not just instructions in text)

## Why this exists

Every rule written as prose inside CLAUDE.md or the files in `agent_docs/`
is **context**, not **enforcement**. Even written in all caps with
"ALWAYS" or "NEVER," the AI can still skip the rule under context
pressure — it's a strong suggestion, not a hard gate.

Hooks are different: they're real shell commands, triggered automatically
by Claude Code lifecycle events (before a tool runs, after an edit, at
session start). They run **regardless of what the AI decides to do**. It's
the difference between politely asking someone to validate code before
pushing, and having a system that blocks the push if validation fails.

## What this example does

The hook below runs **before** any commit (the `PreToolUse` event,
triggered when the bash tool tries to run `git commit`), executes lint and
type-check, and **blocks the commit if anything fails** — the AI gets the
error back and has to fix it before trying again.

## Setup

<!--
SETUP NOTE FOR AI: Replace [LINT_COMMAND] and [TYPECHECK_COMMAND] below
with the real commands for this project's stack (the same ones in
CLAUDE.md's Commands section). This is meant to be one working example,
not a generic system — configure it for real during the interview if the
user confirms they want it active immediately. Otherwise leave the
placeholders and let the user fill them in when ready. Delete this note
when done.
-->

Create (or edit) the `.claude/settings.json` file in the project:

```json
{
  "hooks": {
    "PreToolUse": [
      {
        "matcher": "Bash",
        "hooks": [
          {
            "type": "command",
            "command": "if echo \"$CLAUDE_TOOL_INPUT\" | grep -q 'git commit'; then [LINT_COMMAND] && [TYPECHECK_COMMAND] || exit 1; fi"
          }
        ]
      }
    ]
  }
}
```

Example already filled in for a Node/TypeScript project with ESLint:

```json
{
  "hooks": {
    "PreToolUse": [
      {
        "matcher": "Bash",
        "hooks": [
          {
            "type": "command",
            "command": "if echo \"$CLAUDE_TOOL_INPUT\" | grep -q 'git commit'; then npm run lint && npm run typecheck || exit 1; fi"
          }
        ]
      }
    ]
  }
}
```

## Adapting to other stacks

The logic is always the same — only the command changes:

| Stack | Example command |
|---|---|
| Node/TypeScript | `npm run lint && npm run typecheck` |
| Python | `ruff check . && mypy .` |
| Go | `golangci-lint run && go vet ./...` |
| Rust | `cargo clippy && cargo check` |

Look up the project's real command (it usually already exists in
`package.json`, a `Makefile`, or similar) instead of assuming.

## This is just the start

This is **one** hook, on the most critical event (pre-commit). The full
hooks system — multiple events (PreToolUse, PostToolUse, SessionStart),
custom slash commands, and subagent orchestration — is out of scope for
this kit. If that's what you need, it's covered in the advanced guide
(upsell).
