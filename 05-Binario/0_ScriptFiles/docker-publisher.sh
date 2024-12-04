#!/bin/bash

function ajuda 
{
	echo "docker-publisher <projeto> <nome da imagem> <pasta do projeto> <pasta de trabalho> <pasta de publicação> <Debug | Release>"
}

function verificarparametros  
{	
	if [ "$1" == "" ]; then
		echo 
		echo "****************************"
		echo "Não foi informado <projeto>"
		echo "****************************"
		echo 
		ajuda
		exit 1
	fi
	
	if [ "$2" == "" ]; then
		echo 
		echo "***********************************"
		echo "Não foi informado <nome da imagem>"
		echo "***********************************"
		echo 
		ajuda
		exit 1
	fi
	
	if [ "$3" == "" ]; then
		echo 
		echo "*************************************"
		echo "Não foi informado <pasta do projeto>"
		echo "*************************************"
		echo 
		ajuda
		exit 1
	fi

	if [ "$4" == "" ]; then
		echo 
		echo "**************************************"
		echo "Não foi informado <pasta de trabalho>"
		echo "**************************************"
		echo 
		ajuda
		exit 1
	fi
	
	if [ "$5" == "" ]; then
		echo 
		echo "****************************************"
		echo "Não foi informado <pasta de publicação>"
		echo "****************************************"
		echo 
		ajuda
		exit 1
	fi

	if [ "$6" != "Debug" ]; then
		if [ "$6" != "Release" ]; then 
			echo 
			echo "***********************************"
			echo "Não foi informado <Debug | Release>"
			echo "***********************************"
			echo 
			ajuda
			exit 1
		fi
	fi
}

projeto=$1
dockerimage=$2
projectfolder=$3
jobfolder=$4
publishfolder=$5
compile=$6
pastaatual=$(pwd)
dockeraspnetimage=""

verificarparametros "$projeto" "$dockerimage" "$projectfolder" "$jobfolder" "$publishfolder" "$compile"

dockeraspnetimage="microsoft/dotnet:2.1-aspnetcore-runtime"

if [ -d "$publishfolder" ]; then
	rm -R "$publishfolder" || {
		cd "$pastaatual"
		exit 1
	}
fi

mkdir -p "$publishfolder" || {
	cd "$pastaatual"
	exit 1
}

cd "$projectfolder" || {
	cd "$pastaatual"
	exit 1
}

echo dotnet publish $projeto.csproj --verbosity q -o "$publishfolder" -c $compile
dotnet publish $projeto.csproj --verbosity q -o "$publishfolder" -c $compile || {
	cd "$pastaatual"
	exit 1
}

cd "$jobfolder/$projeto"

if [ $? != 0 ]; then
	echo "Pasta: '$jobfolder/$projeto' não existe"  
	cd "$pastaatual"
	exit 1
fi

cat << EOF | tee "run.sh"
#!/bin/bash

cd "/opt/$projeto"

dotnet $projeto.dll
EOF

cat << EOF | tee Dockerfile
FROM $dockeraspnetimage AS base
WORKDIR .
COPY run.sh .
RUN chmod a+x ./run.sh
WORKDIR /opt/$projeto
COPY app /opt/$projeto

EXPOSE 80
ENTRYPOINT ["/run.sh"]
EOF

docker build -t $dockerimage .

if [ $? != 0 ]; then
	cd "$pastaatual"
	exit 1
fi

cd "$pastaatual"


exit 0