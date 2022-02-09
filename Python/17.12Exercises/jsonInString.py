import json
json_in_string = '{"name": "Plamena"}'
dictionary = json.loads(json_in_string)
print(dictionary["name"])