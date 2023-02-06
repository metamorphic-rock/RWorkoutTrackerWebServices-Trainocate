### HttpGet
```
curl http://localhost:5211/set_items | jq
```

### HttpPost
```
curl -X POST -H "Content-Type: application/json" -d @payloads/setItem.json http://localhost:5211/set_items | jq

```