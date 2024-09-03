#!/bin/sh
echo PROFILE GODOT . . .
echo PROFILE GODOT . . .
echo PROFILE GODOT . . .

scons debug_symbols=yes platform=macos arch=arm64 module_mono_enabled=yes module_tracy_enable=yes tracy_enable=yes CCFLAGS="-fno-omit-frame-pointer -fno-inline -ggdb3"  vulkan_sdk_path="/Users/marcsh/prj/tools/VulkanSDK/1.3.283.0"
codesign --force --timestamp --options=runtime --entitlements misc/dist/macos/editor.entitlements -s - bin/godot.macos.editor.arm64.mono

echo BUILT 
echo BUILT 
echo BUILT 
echo 
echo Use build2.sh to build the C#
echo Use buildt.sh to build the templates

