---
name: codebase-memory-team-setup
description: Rules for setting up codebase-memory-mcp for a cross-platform team in a closed repository.
---

# Team Setup Requirements for codebase-memory-mcp

When instructed to set up `codebase-memory-mcp` for a team or cross-platform closed repository, you MUST do two things:

1. **Persistent Artifact**: Run `codebase-memory-mcp cli index_repository` with `"persistence": true` and commit the `.codebase-memory/` directory to Git.
2. **Teammate Installation**: You must ensure teammates can easily install the binary. Do this by either appending the installation commands to the project's existing `setup`/`build` scripts, or adding explicit instructions to the `README.md`.
   - **Linux/macOS**: `curl -fsSL https://raw.githubusercontent.com/DeusData/codebase-memory-mcp/main/install.sh | bash`
   - **Windows (PowerShell)**: `Invoke-WebRequest -Uri https://raw.githubusercontent.com/DeusData/codebase-memory-mcp/main/install.ps1 -OutFile install.ps1; Unblock-File .\install.ps1; .\install.ps1`
