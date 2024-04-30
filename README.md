![Banner canal deploy](./docs/banner.png?raw=true)

Projeto criado para demonstração de algumas capacidades do Github Copilot.

OBS: A apresentação utilizada na live, esta dentro da pasta docs em formato PDF!

# 1. Como montar o ambiente local

Pré-requisito: .NET 8, Docker, Docker-Compose, WSL2

Pacotes:

1.1. Clone o repositorio

```
git clone https://github.com/felipementel/DEPLOY.BookStore.Copilot.git
```

1.2. Dentro da pasta da aplicação, no root, execute o seguinte comando para provisionar o Mongodb e o Mongo-Express

navegue ate o diretório abaixo
```
cd /mnt/c/proj/deploy/deploy.bookstore.copilot/docker/
```
e execute o comando abaixo para provisionar a infra local
```
docker-compose -f docker-infra.yml up -d
```

# 2. Criando o projeto de testes

```
dotnet new xunit -o .\src\Tests\DEPLOY.BookStore.Api.Tests -n DEPLOY.BookStore.Api.Tests
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests reference .\src\DEPLOY.BookStore.Api
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests reference .\src\DEPLOY.BookStore.Application
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests reference .\src\DEPLOY.BookStore.Domain
```

```
dotnet sln .\src\DEPLOY.BookStore.sln add .\src\Tests\DEPLOY.BookStore.Api.Tests
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests package Moq --version 4.20.70
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests package Bogus --version 35.5.0
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests package FluentAssertions --version 7.0.0-alpha.3
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests package coverlet.msbuild --version 6.0.2
```

```
dotnet add .\src\Tests\DEPLOY.BookStore.Api.Tests package coverlet.collector --version 6.0.2
```

# 3. Testes de unidade

3.1. Instalar os seguintes pacotes utilizando powershell

```
dotnet tool install --global dotnet-reportgenerator-globaltool
```

```
dotnet tool install --global dotnet-coverage
```

3.2 Geração dos relatórios

### Como Executar:

3.2.1 A partir da pasta **_src_** execute o comando:

```
dotnet test
```

3.3. Geração de relatório de testes

3.3.1. A partir da pasta **_src_** execute o comando:

```
dotnet test --collect:"XPlat Code Coverage" --logger "console;verbosity=detailed" --results-directory ..\TestResults\XPlatCodeCoverage\
```

e depois execute:

```
reportgenerator -reports:..\TestResults\XPlatCodeCoverage\**\coverage.cobertura.xml  -targetdir:..\TestResults\XPlatCodeCoverage\CoverageReport -reporttypes:"Html;SonarQube;JsonSummary;Badges" -classfilters:"-*.Migrations.*" -verbosity:Verbose -title:DEPLOY.BookStore -tag:canal-deploy
```

ou

```
$var = (Get-Date).ToString("yyyyMMdd-HHmmss"); dotnet-coverage collect "dotnet test" -f xml -o "..\TestResults\DotnetCoverageCollect\$var\coverage.cobertura.xml"
```

e depois execute:

```
reportgenerator -reports:..\TestResults\DotnetCoverageCollect\**\coverage.cobertura.xml  -targetdir:..\TestResults\DotnetCoverageCollect\CoverageReport -reporttypes:"Html;SonarQube;JsonSummary;Badges" -verbosity:Verbose -title:DEPLOY.BookStore -tag:canal-deploy
```

# 4. Para executar o projeto

```
dotnet run --project .\src\DEPLOY.BookStore.Api\DEPLOY.BookStore.Api.csproj --launch-profile DEPLOY.BookStore.Api
```

# Github.cli

> winget install GitHub.cli

> gh auth login

> gh extension install github/gh-copilot

    (to update: gh extension upgrade gh-copilot)

> gh copilot --help

> gh copilot explain "sudo apt-get"

# Exemplos de pompts

@terminal how can I build this application?

@vscode how to format on save?

@workspace what version of .NET is this application?

--> depois abra todos os csproj e execute novamente

```
dotnet run --project .\src\DEPLOY.BookStore.Api\DEPLOY.BookStore.Api.csproj --launch-profile DEPLOY.BookStore.Api
```

@workspace What is the purpose of the `DEPLOY.BookStore.Infra.Repository` directory in the application?

@workspace What are the steps to add a new book using the BookService in the application?

@workspace How can I update an existing book using the BookService in the application?

how can I create a struct to a new object, the Customer. So I will need a LocationController, LocationDto .... Location Domain, Location Repository. Can you help me with all?

@workspace I can create a Book with the existeds name. How can us verify the name before to submit to persist? lets use the .Must of FluentValidation and create a repository method.

@workspace /tests I want to create a unit test using xUnit and Moq for #file:BookPublisherService.cs . Can you help me?
