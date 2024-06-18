#!/bin/sh
eco BUILDING GODOT . . .
scons debug_symbols=yes platform=macos arch=arm64 module_mono_enabled=yes CCFLAGS="-fno-omit-frame-pointer -fno-inline -ggdb3"
./bin/godot.macos.editor.arm64.mono  --headless --generate-mono-glue modules/mono/glue
echo BUILT 
echo Use build2.sh to build the C#
