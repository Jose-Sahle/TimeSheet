#!/bin/bash

FILE=allprojects-to-build

while read LINE; do 
	IFS='|' read -ra NAMES <<< "$LINE"
	dockerimagename=${NAMES[1]}

	docker start $dockerimagename

done < $FILE
