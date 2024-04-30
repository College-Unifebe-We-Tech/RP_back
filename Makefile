run: 
	dotnet run

create-migration:
	dotnet ef migrations add $(name)

execute-migrations:
	dotnet ef database update

execute_in_container:
	podman-compose down
	podman-compose build
	podman-compose up