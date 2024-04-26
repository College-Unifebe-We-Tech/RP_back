create-migration:
	dotnet ef migrations add $(name)

execute-migrations:
	dotnet ef database update