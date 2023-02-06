### HttpGet
```
curl http://localhost:5211/set_items | jq
```

### HttpPost
```
curl -X POST -H "Content-Type: application/json" -d @payloads/setItem.json http://localhost:5211/set_items | jq

```

### Add SQLServer Dependencies for EntityFramework
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
### Add the entity Framework Design Package 
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
### Add the Dotnet EF Tool
```
dotnet tool install --global dotnet-ef
```

### Migrate Database
```
dotnet ef migrations add ADDED.......
```

## Update Database
```
dotnet ef database update
```