#!/bin/sh
./bin/godot.macos.editor.arm64.mono  --headless --generate-mono-glue modules/mono/glue
./modules/mono/build_scripts/build_assemblies.py --godot-output-dir ./bin --push-nupkgs-local /Users/marcsh/prj/tools/Nuget
