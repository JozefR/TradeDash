# TradeDash

### Description
A simple ASP.NET Core TradeDash project that I am working in my free time. I am going to develop simple [Blue Chips/Stocks](https://www.investopedia.com/terms/b/bluechip.asp) trading simulation with trading sheets and some statistics. This project is very basic, anyone who has interest in Stocks and learn ASP. Core is welcome to join :).

### Domain Objects so far
The base entity will be 
    
    Strategy. 
    
Each strategy has its own:

    1. MoneyManagement
    2. EstaminateReturn
    3. ReturnOnStrategy

For each strategy with specific **strategy type** can be recorded **StockTrades** and **OptionTrades**.

#####StockTrades

Each Stock record can have Status: 

    StockStatus - Open/Close.

#####OptionTrades

Each [Option](https://www.investopedia.com/terms/s/stockoption.asp) record can have Status:

    OptionStatus - Open/Close.

Each Option is of Type

    Call
    Put

And additionally each open option can be: 

    buy
    write
And each close option can be
    
    Expired
    Sold
    Assigned

### List of features
                   
#### Front End 
 - [X] Implement npm package manager with task runner.     
 - [X] Start with basic bootstrap components and set up first css lines. 
 - [X] Implement left-side nav bar. 
 - [X] Implement basics tables without real data based on excel option trade sheets.
 - [ ] Build simple header in the home page (just for learning purpose)
 - [ ] Find simple, easy to use and free dashboard for my home page.

#### Back End
 - [ ] Make some research about how to structure and build the backend.
 - [X] Create a basic EF model.
 - [X] Register Db context service.
 - [X] Configuring EF migrations.
 - [X] Scaffold simple strategy Api Controller.
 - [x] Testing the APi using the Swashbuckle
 - [X] Create entities 
 - [X] Add DTO project 