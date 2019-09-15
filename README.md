# entegy-backend	

## How to run
[] clone this repo
[] open a terminal to the cloned folder
[] run `dotnet run`
[] in Postman, navigate to `https://localhost:5001/cheque/<insert number here>`
Alternatively, you can also nagivate the the above url in browser and check the Json response

### How to run Postman tests
[] Open Postman
[] Click Import
[] Import `Entegy Testing.postman_collection.json`
[] Run the app with `dotnet run`
[] Run the test collection

## Assumptions
- The service will only take english numbers from 0.01 to 999,999,999,999,999.99. This is because even the richest company in the world wouldn't write a cheque that big. They would be taking a fair risk to trust a program to do it if they did.
- You already have Postman

## Testing
- I have included 20 Postman tests in this repo to make testing easier. The tests cover basic edge cases and tries to cover as many combinations of English numbers as possible. 
- My first iteration did have a front end (in MVC) but I wanted to test with Postman and it was taking too long to figure out why it wasn't working through Postman. 

## Bugs?
- None that I know of

## Security and Longevity
- english only, very specific
- only goes up to 999,999,999,999,999
- doesnt really need to be secure as there is no personal information. If this was to become and automatic cheque writer and actually print out cheques, there would have to be a whole world of security implmented
- The response is a Json object to be able to add a frontend easily

## Design	
### Input	
A decimal number. This can be any amount of decimals but needs to be rounded down to the nearest whole cent. Can not be greater than 999 trillion.

### Output	
An english representation of the dollar amount of the input number. This is to be sent back in the http response. The http response should be a Json object to allow for a frontend to be added

### Examples	
Input: 1234.56	
Output: ONE THOUSAND TWO HUNDRED THIRTY-FOUR DOLLARS AND FIFTY-SIX CENTS	

Input: 0.22	
Output: TWENTY-TWO CENTS ONLY	

Input: 102.03	
Output: ONE HUNDRED TWO DOLLARS AND THREE CENTS	

Input: 1.021	
Output: ONE DOLLAR AND TWO CENTS	

Input: 1.23987	
Output: ONE DOLLAR AND TWENTY-THREE CENTS	

### Edge Cases
Input 0	
Negative numbers
Greater than 999 trillion
String input
x,0xx - e.g. ONE THOUSAND AND TWELVE DOLLARS
x.0x - e.g. EIGHT DOLLARS AND THREE CENTS
0.xx - e.g. SEVEN CENTS ONLY
Dollar and Dollars
Cent and Cents

### Errors	
Zero input
Negative Input
Number too large
Not Valid input
Page not found

### Tests
Postman tests to cover as many different combinations of the English represenation of the input numbers. This makes it easy for testers and for any future code changes. 

## Front end	
The task does not ask for a GUI but it would be easier for testing to implement a simple GUI. 

## A little bit from me
Time: 3 hours core logic, 2 hours error handling, 1 hour tests, 2 hours redoing a git error that hurt

Git: I would usually branch from master and check into the branch before making a pull request into master. I chose not to do that for this test as it is such a small project. For a bigger project with releases I would set up git flow to make it easier to release software. 