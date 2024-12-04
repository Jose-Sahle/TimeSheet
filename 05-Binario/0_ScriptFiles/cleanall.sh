#!/bin/bash

FILE=allprojects

if [ -d "$(pwd)/Containers" ]; then
	echo "$(pwd)/Containers" 
	rm -R "$(pwd)/Containers"
fi

if [ -d "$(pwd)/Publish" ]; then
	echo "$(pwd)/Publish" 
	rm -R "$(pwd)/Publish"
fi

while read LINE; 
    do bash ./clean.sh "$(pwd)/../../04-Source/$LINE" || {
        error
        exit 1
    } 
done < $FILE
