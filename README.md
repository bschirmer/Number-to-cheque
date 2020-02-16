# Number to Cheque
Simple app to convert a number to a Cheque formatted string

## How to run
1. Clone this repo
2. Open a terminal to the cloned folder
3. Run `dotnet run`
    1. If you get an error about dotnet, `dotnet is not recognized as an internal or external command, operable program or batch file.` you will have to download and install it. You can do that here `https://dotnet.microsoft.com/download`
4. In Postman, navigate to `https://localhost:5001/cheque/<insert number here>`
    1. If you don't have Postman, you can download it from here `https://www.getpostman.com/downloads/`
    2. If you are running the app and you run the above URL and get `Could not get any response...`. You may have to turn off SSL certificate verification by going to `File -> Settings -> General -> SSL certificate verification`

Alternatively, you can also navigate the above URL in the browser and check the JSON response

### How to run Postman tests
1. Open Postman
2. Click Import
3. Import `number-to-string Testing.postman_collection.json`
4. Run the app with `dotnet run`
5. Run the test collection

## Design	
### Input	
A decimal number. This can be any amount of decimals but needs to be rounded down to the nearest whole cent. Can not be greater than 999 trillion.

### Output	
An English representation of the dollar amount of the input number. This is to be sent back in the HTTP response. The HTTP response should be a JSON object to allow for a frontend to be added

### Examples	
Input: 1234.56	<br>
Output: ONE THOUSAND TWO HUNDRED AND THIRTY FOUR DOLLARS AND FIFTY-SIX CENTS	

Input: 0.22	<br>
Output: TWENTY TWO CENTS ONLY	

Input: 102.03 <br>
Output: ONE HUNDRED AND TWO DOLLARS AND THREE CENTS	

Input: 1.021 <br>
Output: ONE DOLLAR AND TWO CENTS	

Input: 1.23987 <br>
Output: ONE DOLLAR AND TWENTY THREE CENTS	

### Errors	
- Zero input
- Negative Input
- Number too large
- Not Valid input
- Page not found