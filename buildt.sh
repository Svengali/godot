#!/bin/sh

echo BUILDING TEMPLATES for GODOT . . .
echo Arm64
scons platform=macos target=template_release arch=arm64 vulkan_sdk_path="/Users/marcsh/prj/tools/VulkanSDK/1.3.283.0"
scons platform=macos target=template_debug arch=arm64 vulkan_sdk_path="/Users/marcsh/prj/tools/VulkanSDK/1.3.283.0"
echo X86_64
scons platform=macos target=template_release arch=x86_64 vulkan_sdk_path="/Users/marcsh/prj/tools/VulkanSDK/1.3.283.0"
scons platform=macos target=template_debug arch=x86_64 vulkan_sdk_path="/Users/marcsh/prj/tools/VulkanSDK/1.3.283.0"
echo 
echo Built!
