# Workout-Tracker-Trainocate-WebServices
Workout Tracker Backend

### httpGet Command
```
curl http://localhost:5211/set_items | jq
```

### httpPost Command
```
curl -X POST -H "Content-Type: application/json" -d @payloads/setItem.json http://localhost:5211/set_items | jq
```
