#!/bin/sh
echo BUILDING GODOT . . .
echo BUILDING GODOT . . .
echo BUILDING GODOT . . .

scons debug_symbols=yes platform=macos arch=arm64 module_mono_enabled=yes CCFLAGS="-fno-omit-frame-pointer -fno-inline -ggdb3" vulkan_sdk_path="/Users/marcsh/prj/tools/VulkanSDK/1.3.283.0"

echo BUILT 
echo BUILT 
echo BUILT 
echo 
echo Use build2.sh to build the C#
echo Use buildt.sh to build the templates

