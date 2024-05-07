#!/bin/sh
scons debug_symbols=yes platform=macos arch=arm64 module_mono_enabled=yes CCFLAGS="-fno-omit-frame-pointer -fno-inline -ggdb3"
