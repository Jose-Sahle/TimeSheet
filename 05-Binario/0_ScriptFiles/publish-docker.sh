#!/bin/bash

function displaytime {
  local T=$1
  local H=$((T/60/60%24))
  local M=$((T/60%60))
  local S=$((T%60))
  printf "Tempo decorrido: %02dh%02dm%02ds\n" $H $M $S
}

function ajuda {
	echo "publish-docker <Debug | Release>"
	exit 1
}

function error {
	final=$SECONDS	
	diferenca=($final-$inicial)
	displaytime $diferenca
	exit 2
}

function sair {
	final=$SECONDS	
	diferenca=($final-$inicial)
	displaytime $diferenca
	exit 2
}

inicial=$SECONDS

if [ "$1" == "Debug" ]; then 
	compile=$1
fi

if [ "$2" == "Debug" ]; then
	 compile=$2
fi

if [ "$1" == "Release" ]; then
	 compile=$1
fi

if [ "$2" == "Release" ]; then
	 compile=$2
fi

if [ "$1" != "Debug" ] && [ "$1" != "Release" ]; then
	 oneproject=$1
fi

if [ "$2" != "Debug" ] && [ "$2" != "Release" ]; then
	 oneproject=$2
fi

if [ "$compile" == "" ]; then
	ajuda
fi

if [ ! "$compile" == "Debug" ];then
	if [ ! "$compile" == "Release" ]; then
		ajuda
	fi
fi

if [ -d "$(pwd)/Containers" ]; then
	echo "$(pwd)/Containers" 
	rm -R "$(pwd)/Containers"
fi

bash ./icleanall.sh $oneproject

FILE=allprojects-to-build

while read LINE; do 
	IFS='|' read -ra NAMES <<< "$LINE"
	project=${NAMES[0]}
	dockerimagename=${NAMES[1]}
    port=${NAMES[2]}
	volume=${NAMES[3]}
	if [ "$oneproject" == "" ] || [ "$oneproject"  == "$dockerimagename" ]; then
		bash ./docker-publisher.sh "$project" "$dockerimagename" "$(pwd)/../../04-Source/$project" "$(pwd)/Containers" "$(pwd)/Containers/$project/app" $compile || {
			error
		}

		docker run -d --name $dockerimagename $port $volume --network nginx-nt $dockerimagename  || {
			error
		}
	fi
done < $FILE

#docker-compose up -d

sair

