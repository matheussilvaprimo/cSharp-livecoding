#!/bin/bash

domainName=$1
slnPath=$2
fullPath="${slnPath}/${domainName}"
domainCsproj="${domainName}.Domain"
appCsproj="${domainName}.Application"
dataCsproj="${domainName}.Data.Infrastructure"
apiCsproj="${domainName}.Web.API"

mkdir -p $fullPath

cd $fullPath

echo "Creating dotnet SLN.."
    dotnet new sln -n $domainName

echo "Creating domain project.."
    dotnet new classlib -o $domainCsproj -f netcoreapp3.1

echo "Creating data infrastructure project.."
    dotnet new classlib -o $dataCsproj -f netcoreapp3.1

echo "Creating application layer.."
    dotnet new classlib -o $appCsproj -f netcoreapp3.1

echo "Creating Web API.."
    dotnet new webapi -o $apiCsproj

echo "Installing Data Infrastructure dependencies.."
cd $dataCsproj

    dotnet add package Microsoft.EntityFrameworkCore --version 3.1.3
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.3
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.3
    dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 3.1.3
    dotnet add reference "../${domainCsproj}"

cd ..

echo "Intalling Application layer dependencies.."
cd $appCsproj
    dotnet add reference "../${dataCsproj}"
    dotnet add reference "../${domainCsproj}"

cd ..

echo "Installing Web API dependencies.."
cd $apiCsproj   
    dotnet add package Microsoft.EntityFrameworkCore --version 3.1.3
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.3
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.3
    dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 3.1.3
    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
    dotnet add reference "../${appCsproj}"
    dotnet add reference "../${dataCsproj}"
    dotnet add reference "../${domainCsproj}"

cd ..

echo "Adding references to SLN ${domainName}.sln"
cd $fullPath
    dotnet sln add "${apiCsproj}/${apiCsproj}.csproj"
    dotnet sln add "${appCsproj}/${appCsproj}.csproj"
    dotnet sln add "${dataCsproj}/${dataCsproj}.csproj"
    dotnet sln add "${domainCsproj}/${domainCsproj}.csproj"

cd ..
cd ..
chmod -R 777 ./
