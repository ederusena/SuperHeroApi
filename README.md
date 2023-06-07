# criacao de um global.json, pra definir as configuracoes do projeto e versao do dotnet.

{
	"sdk": {
		"version": "6.0.116"
	}
}

# Criar projeto
dotnet new mvc -o AspNetCore_EFCore

# Criar arquivo de solution Sln
dotnet new sln

# Adicionar Projeto a Solucao
dotnet sln add AspNetCore_EFCore/AspNetCore_EFCore.csproj%  

# Criar container com banco SQL Server
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest 
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=9766" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
# Acessar container 


docker exec -it <container_id|container_name> /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P <your_password>
docker exec -it 0b9 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 9766


# Criar migrations
dotnet ef migrations add CreateInitial

# Criar o banco de fato no SGBD
dotnet ef database update

// // "DefaultConnection": "jdbc:sqlserver://;serverName=localhost:1433;databaseName=superherodb"
