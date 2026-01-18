# Financee

## Database
### Create a migration
```zsh
cd src/
dotnet ef migrations add <MigrationName> --project Infrastructure --startup-project Presentation
```

### Run migrations
Migrations are automatically run when app is started.


## Setup
### Run API
```zsh
docker-compose down && docker-compose up --build
```

## Auth
Auth0 is used as an OAuth provider to facilitate both authentication and authorisation.