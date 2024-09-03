#!/bin/sh
scons debug_symbols=yes platform=macos arch=arm64 module_mono_enabled=yes module_tracy_enable=yes tracy_enable=yes CCFLAGS="-fno-omit-frame-pointer -fno-inline -ggdb3"
