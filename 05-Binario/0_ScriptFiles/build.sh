#!/bin/bash

project=$1
compile=$2

echo "****************************"
echo $project
echo $target
echo $compile
echo "****************************"
pastaatual=$(pwd)

cd "../../04-Source/$project"    

echo "Compilando o projeto '$project'" 
dotnet build  --verbosity q -c $compile .  || {
	echo "Erro 1"
	cd "$pastaatual"
	exit 1
}

cd "$pastaatual"