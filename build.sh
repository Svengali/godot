#!/bin/sh
eco BUILDING GODOT . . .
scons debug_symbols=yes platform=macos arch=arm64 module_mono_enabled=yes CCFLAGS="-fno-omit-frame-pointer -fno-inline -ggdb3"
echo BUILT 
echo BUILT 
echo BUILT 
echo 
echo Use build2.sh to build the C#
