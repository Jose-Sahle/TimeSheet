#!/bin/bash

#docker-compose down

if [ "$1" != "" ]; then
	selectedproject=$1
fi

FILE=allprojects-to-build

while read LINE; do 
	IFS='|' read -ra NAMES <<< "$LINE"
	dockerimagename=${NAMES[1]}

    if [ "$selectedproject" == "" ] || [ "$selectedproject" == "$dockerimagename" ]; then
		docker stop $dockerimagename
		docker rm $dockerimagename

		[ -z $(docker images -q $dockerimagename) ] || docker rmi $dockerimagename    
	fi
done < $FILE
