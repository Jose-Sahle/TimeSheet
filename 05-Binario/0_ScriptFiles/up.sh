#!/bin/bash

FILE=allprojects-to-build

while read LINE; do 
	IFS='|' read -ra NAMES <<< "$LINE"
	image=${NAMES[1]}

	docker start $image
done < $FILE
