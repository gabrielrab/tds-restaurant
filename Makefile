run-api-watch:
	cd src/Restaurant.Api && dotnet watch run

run-api-watch:
	cd src/Restaurant.View && dotnet watch run

migration:
	dotnet ef migrations add Inital --project src/Restaurant.Data --startup-project src/Restaurant.Api
	dotnet ef database update --project src/Restaurant.Data --startup-project src/Restaurant.Api
