#!/bin/bash

pastaatual=$(pwd)

if [ -d "$(pwd)/Publish" ]; then
    rm -R "$(pwd)/Publish"
fi

FILE=$(pwd)/allprojects-to-prod

mkdir "$(pwd)/Publish"
cd "$(pwd)/Publish"

touch publish-load.sh

while read LINE; do 
    IFS='|' read -ra NAMES <<< "$LINE"
	project=${NAMES[0]}
	dockerimagename=${NAMES[1]}
    port=${NAMES[2]}
	volume=${NAMES[3]}

    docker save -o $dockerimagename.tar $dockerimagename

    echo docker stop $dockerimagename >> publish-load.sh
    echo docker rm $dockerimagename >> publish-load.sh
    echo docker rmi $dockerimagename >> publish-load.sh
    echo docker load -i $dockerimagename.tar >> publish-load.sh
    echo docker run -d --name $dockerimagename $port $volume --network nginx-nt $dockerimagename >> publish-load.sh
done < $FILE

cd "$pastaatual"