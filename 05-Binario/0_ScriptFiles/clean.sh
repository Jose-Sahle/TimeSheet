#!/bin/bash

if [ -d "$1/bin" ]; then
	echo "$1/bin" 
	rm -r "$1/bin"
fi

if [ -d "$1/obj" ]; then
	echo "$1/obj" 
	rm -r "$1/obj"
fi