# Microservices

# Projeto de Microserviços com Docker, SQL Server e RabbitMQ

Este projeto demonstra a implementação de microserviços utilizando .NET, Docker para containerização, SQL Server para persistência de dados e RabbitMQ para mensageria assíncrona.

## Pré-requisitos

- Windows Subsystem for Linux (WSL) instalado. [Guia de instalação](https://learn.microsoft.com/en-us/windows/wsl/install)
- Docker instalado. [Download do Docker](https://www.docker.com/get-started)
- Azure Data Studio ou outra ferramenta de design de banco de dados.

## Configuração do Banco de Dados

1. **Baixar e executar a imagem do SQL Server:**
   
   docker pull mcr.microsoft.com/mssql/server:2022-latest
   
   docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name <Server_Name> --hostname <Host_Name> -d mcr.microsoft.com/mssql/server:2022-latest

2. **Configurar as tabelas no banco de dados:**

Após o contêiner iniciar, utilize o Azure Data Studio ou qualquer ferramenta de sua preferência para criar as tabelas necessárias. Você pode criar as tabelas utilizando as migrações do Entity Framework:

dotnet ef migrations add NomeDaMigration

dotnet ef database update

## Configuração do RabbitMQ

1. **Baixar e executar a imagem do RabbitMQ:**

docker run -d --hostname my-rabbit --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management

2. **Acessar o RabbitMQ Management Interface:**

Acesse o RabbitMQ Management Interface em seu navegador:

http://localhost:15672

Utilize o IP `127.0.0.1:15672` caso o acesso pelo hostname não funcione.

## Instalação e Execução do Projeto

1. **Baixar pacotes do projeto:**

No terminal do Developer PowerShell, execute o seguinte comando para restaurar os pacotes do projeto:

dotnet restore

2. **Build e execução do projeto:**

Compile e execute o projeto usando o Visual Studio ou o Visual Studio Code.

## Detalhes Adicionais

Este projeto utiliza Docker para facilitar a configuração e execução do ambiente de desenvolvimento. Certifique-se de ajustar as configurações de segurança e credenciais conforme necessário para seu ambiente de produção.


