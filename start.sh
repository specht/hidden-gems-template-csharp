#!/usr/bin/env bash
set -euo pipefail

(
  dotnet publish -c Release -o out
) 1>&2

exec dotnet out/MyBot.dll
