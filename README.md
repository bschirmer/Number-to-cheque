# entegy-backend	

## How to run
1. Clone this repo
2. Open a terminal to the cloned folder
3. Run `dotnet run`
    1. If you get an error about dotnet, `dotnet is not recognized as an internal or external command, operable program or batch file.` you will have to download and install it. You can do that here `https://dotnet.microsoft.com/download`
4. In Postman, navigate to `https://localhost:5001/cheque/<insert number here>`
    1. If you don't have Postman, you can download it from here `https://www.getpostman.com/downloads/`
    2. If you are running the app and you run the above url and get `Could not get any response...`. You may have to turn off SSL certificate verification by going to `File -> Settings -> General -> SSL certificate verification`

Alternatively, you can also nagivate the the above url in browser and check the Json response

### How to run Postman tests
1. Open Postman
2. Click Import
3. Import `Entegy Testing.postman_collection.json`
4. Run the app with `dotnet run`
5. Run the test collection

## Assumptions
- The service will only take english numbers from 0.01 to 999,999,999,999,999.99. This is because even the richest company in the world wouldn't write a cheque that big. They would be taking a fair risk to trust a program to do it if they did.
- .Net is already installed
- You already have Postman


## Testing
- I have included 20 Postman tests in this repo to make testing easier. The tests cover basic edge cases and tries to cover as many combinations of English numbers as possible. 
- My first iteration did have a front end (in MVC) but I wanted to test with Postman and it was taking too long to figure out why it wasn't working through Postman. 

## Bugs?
- None that I know of

## Security and Longevity
- This is only in English making it very specific.
- It has a max of 999,999,999,999,999. This is reasonable until people are writing cheques for more. 
- Because this is just converting a number to a string I don't believe it needs to be secure as there is no personal information. If this was to become and automatic cheque writer and actually print out cheques, there would have to be a whole world of security implmented.
- The response is a Json object to be able to add a frontend easily

## Design	
### Input	
A decimal number. This can be any amount of decimals but needs to be rounded down to the nearest whole cent. Can not be greater than 999 trillion.

### Output	
An english representation of the dollar amount of the input number. This is to be sent back in the http response. The http response should be a Json object to allow for a frontend to be added

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

### Edge Cases
- Input 0	
- Negative numbers
- Greater than 999 trillion
- String input
- x,0xx - e.g. ONE THOUSAND AND TWELVE DOLLARS
- x.0x - e.g. EIGHT DOLLARS AND THREE CENTS
- 0.xx - e.g. SEVEN CENTS ONLY
- Dollar and Dollars
- Cent and Cents

### Errors	
- Zero input
- Negative Input
- Number too large
- Not Valid input
- Page not found

### Tests
Postman tests to cover as many different combinations of the English represenation of the input numbers. This makes it easy for testers and for any future code changes. <br>
I would usually unit tests to cover any services. As there is no database and there is only one simple function, I decided that the Postman tests were sufficent 

## Front end	
The task does not ask for a GUI but it would be easier for testing to implement a simple GUI. 

## A little bit from me
Time: ~2 hours setting up various projects to decided which want to go, ~3 hours core logic, ~2 hours error handling, ~1 hour tests, ~1 hour redoing a git error that hurt. This is all very genralised and I think I spent a total of about 7 hours on it. 

Git: I would usually branch from master and check into the branch before making a pull request into master. I chose not to do that for this test as it is such a small project. For a bigger project with releases I would set up git flow to make it easier to release software. 

Originally, I was going to do a ASP.NET MVC and I had the core logic working with a very basic frontend. However, when I went to test it in Postman, it didn't work so I changed it to a WebApi. I feel like there was a rookie error in there somewhere and if I took another look, I think I could find it. 

After getting everything working and tests written, I wanted to then copy the code back into the original ASP.NET project and get it working. I decided against this because of time constraints. This is where I accidentely discarded changed that I needed. Luckily I had all of my tests written and I only lost some minor logic changes to fix. 

### Future enhancments
- A simple, nice looking front end
- Multiple langues
- Ablity to print
- Sign up with banks and add login and authentication so you can print bank specific cheques. Not sure if they will trust me though. 