# UK Driving Licence

Original here: https://www.codewars.com/kata/586a1af1c66d18ad81000134/train/python

Sample solution here: https://github.com/ambersariya/katas/tree/main/driving-licence

## Rules
```
1–5: The first five characters of the surname (padded with 9s if less than 5 characters)

6: The decade digit from the year of birth (e.g. for 1987 it would be 8)

7–8: The month of birth (7th character incremented by 5 if driver is female i.e. 51–62 instead of 01–12)

9–10: The date within the month of birth

11: The year digit from the year of birth (e.g. for 1987 it would be 7)

12–13: The first two initials of the first name and middle name, padded with a 9 if no middle name

14: Arbitrary digit – usually 9, but decremented to differentiate drivers with the first 13 characters in common. We will always use 9

15–16: Two computer check digits. We will always use "AA"
```
## Input

Your task is to code a UK driving license number using an Array of data. The Array will look like

data = ["John","James","Smith","01-Jan-2000","M"]
Where the elements are as follows:

```
0 = Forename
1 = Middle Name (if any)
2 = Surname
3 = Date of Birth (In the format Day Month Year, this could include the full Month name or just shorthand ie September or Sep)
4 = M-Male or F-Female
```

## Examples
`["John", "James", "Smith", "01-Jan-2000", "M"]` should return `SMITH001010JJ9AA`

`["Jonny", "Jimmy", "Smithson", "01-Jan-2000", "M"]` should return `SMITH001010JJ9AA`
    
`["Johanna", "", "Gibbs", "13-Dec-1981", "F"]` should return `GIBBS862131J99AA`

`["Dave", "", "Doh", "13-Nov-1976", "M"]` should return `DOH99711136D99AA`


## Running the tests
```
poetry shell
pytest
```


## Running the app
Uses FastAPI framework and uvicorn web server.

To run in dev with hot-reload: 
```
poetry shell
uvicorn app:driving_license_app --reload
```
Then navigate to `http://127.0.0.1:8000` to see "Hello World".

To post to the `/license` endpoint:
- Open Postman (or a similar tool)
- Create a new POST request to `http://127.0.0.1:8000/license`
- Set the body type to be JSON (i.e. the `content-type` request header should be `application/json`)
- Set the body content to:
```
{
    "forename": "John",
    "middle_name": "James",
    "surname": "Smith",
    "date_of_birth": "01-Jan-2000",
    "gender": "M"
}
```

The response should be:
```
{
    "license": "SMITH001010JJ9AA"
}
```
