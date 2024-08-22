
# JSON Serialization and Deserialization Example

This is a custom JsonConverted implemented using the famous [Newtonsoft](https://www.newtonsoft.com/json) Library.

## JSON Structure

The JSON object we will be working with has the following structure:

```json
{
  "PersonnelId": 1,
  "Name": "Ali",
  "Age": 22,
  "StartDate": "2024/08/22",
  "EndDate": "2024/08/29"
}
```


## Usage

### Serialization
```C#
var vacation = new Vacation(1, "amir", 22, DateTime.Now, DateTime.Now.AddDays(+5));
var serilizeTest = JsonConvert.SerializeObject(vacation, Formatting.Indented, new PersianDateConverter());

//OutPut:
{
  "PersonnelId": 1,
  "Name": "amir",
  "Age": 22,
  "StartDate": "1403/06/01",
  "EndDate": "1403/06/06"
}
```


### Deserialization
```C#
var json = "{\"PersonnelId\": 1, \"Name\": \"Ali\", \"Age\": 22,  \"StartDate\": \"2024/08/22\", \"EndDate\": \"2024/08/29\"}";
var deserilizedObject = JsonConvert.DeserializeObject<Vacation>(json, new PersianDateConverter());

//
```


## ToDo
make the converted Generic so it can be used on any given Types.
