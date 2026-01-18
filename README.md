# Financee

## Create a migration
```zsh
cd src/
dotnet ef migrations add <MigrationName> --project Infrastructure --startup-project Presentation
```

## Run migrations
Migrations are automatically run when app is started.


## Run API
```zsh
docker-compose down && docker-compose up --build
```

