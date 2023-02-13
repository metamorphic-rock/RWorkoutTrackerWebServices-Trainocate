# WorkoutTrackerWebServices
This will serve as the backend for the Workout Tracker Webapp.
It contains the models, interface, commands, and controllers for the SetItem, ExerciseItem and WorkoutItem. 
The backend process the request of the angular app to fetch and sava data into the database.
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
### Drop Database
```
dotnet ef database drop
```
### Migrate Database
```
dotnet ef migrations add ADDED.......
```

## Update Database
```
dotnet ef database update
```
