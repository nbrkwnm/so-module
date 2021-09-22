Desafio .NET Módulo de Ordens de Serviço

# Running Front-End application
```
# Require yarn

# At front-end folder, install project dependencies running
yarn

# Then run the project
yarn serve
``` 

# Running Back-End application

```cs
# Require .NET SDK 5.0 and PostgreSQL

# Check Connection Strings appsettings.json at SOModule.API

# At back-end folder, run migrations
dotnet ef --startup-project .\SOModule.API\SOModule.API.csproj --project .\SOModule.Infrastructure\SOModule.Infrastructure.csproj database update

# Then Build and Run
dotnet run -p SOModule.API
``` 

# Tempo gasto nas etapas
```
# Desenvolvimento back-end: 4 horas
# Desenvolvimento front-end: 6 horas
```