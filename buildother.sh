#!/bin/sh

echo BUILDING WINDOWS TEMPLATES for GODOT . . .
echo WINDOWS X86_64
scons platform=windows target=template_release arch=x86_64
scons platform=windows target=template_debug arch=x86_64
echo LINUX X86_64
scons platform=linuxbsd target=template_release arch=x86_64
scons platform=linuxbsd target=template_debug arch=x86_64
echo 
echo Built!
