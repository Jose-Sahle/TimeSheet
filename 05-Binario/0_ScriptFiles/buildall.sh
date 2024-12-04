#!/bin/bash

function error
{
		echo 
		echo "****************************"
		echo "Erro na compilação"
		echo "****************************"
		echo 
		exit 1
}

compile=$1

FILE=allprojects-to-build

while read LINE; do 
	IFS='|' read -ra NAMES <<< "$LINE"
	project=${NAMES[0]}

	bash ./build.sh $project $compile || {
        error
        exit 1
    } 
done < $FILE
