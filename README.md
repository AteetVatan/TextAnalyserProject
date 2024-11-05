<div>

# 🥇ASP.NET Core Web API project for text analyses using Minimal API approach

Develop a microservice web API in the ASP.NET Core
Minimal API approach that covers the following functions:
1. Counting one or more words in a string.
2. Checking whether one or more words are contained in a string.
3. Counting one or more letters in a string.
4. Checking whether one or more letters are contained in a string.
5. Checking whether a string is Base64 encoded.
6. Checking whether a string is a valid email address



## Run the application
1. Clone or download this repository
2. Build the solution "AnalyseText" using command line in terminal with `dotnet build`
3. Run project using command line in terminal with `dotnet run`


https://localhost:port/count-words?input=check this method
https://localhost:port/count-words?input=124

https://localhost:port/contains-words?input=check this method &words= check,this
https://localhost:port/contains-words?input=check this method &words= check this

https://localhost:port/count-letters?input=check this method
https://localhost:port/count-letters?input=123 
https://localhost:port/count-letters?input=12.5

https://localhost:port/contains-letters?input=check this method&letters=c,t
https://localhost:port/contains-letters?input=check this method&letters=ct
https://localhost:port/contains-letters?input=check this method&letters=1

https://localhost:port/is-base64?input=check this method
https://localhost:port/is-base64?input=123.3


https://localhost:port/is-valid-email?input=sample@example.com
https://localhost:port/is-valid-email?input=sample@@example.com
https://localhost:port/is-valid-email?input=sampleexample.com

## For Testing
For the test project run "AnalyseText.Tests"

</div>
