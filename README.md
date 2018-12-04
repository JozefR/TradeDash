# TradeDash

### Description
A simple ASP.NET Core TradeDash project that I am working in my free time. I am going to develop simple [Blue Chips/Stocks](https://www.investopedia.com/terms/b/bluechip.asp) trading simulation with trading sheets and some statistics. This project is very basic, anyone who has interest in Stocks and learn ASP. Core is welcome to join :).

### Domain Objects so far
The base entity will be **Strategy**. Each strategy has its own: **MoneyManagement**, **EstaminateReturn**
and **ReturnOnStrategy** entities.

For each strategy with specific **strategy type** can be recorded **StockTrades** and **OptionTrades**.

Each Stock trade can have Status: **StockStatus** - Open/Close.

Each [Option](https://www.investopedia.com/terms/s/stockoption.asp) trade can have Status:**OptionStatus** - Open/Close.

Each Option is of Type **Call,Put**. And additionally each open option can be: **buy**,**write**.
And each close option can be **Expired,Sold,Assigned**.

### List of features
                   
#### Front End 
 - [X] Implement npm package manager with task runner.     
 - [X] Start with basic bootstrap components and set up first css lines. 
 - [X] Implement left-side nav bar. 
 - [X] Implement basics tables without real data based on excel option trade sheets.
 - [ ] Build simple header in the home page (just for learning purpose)
 - [ ] Find simple, easy to use and free dashboard for my home page.

#### Back End
 - [X] Create basic EF model.
 - [X] Register Db context service.
 - [X] Configure EF migrations.
 - [X] Scaffold simple strategy Api Controller.
 - [x] Testing the API using the Swashbuckle
 - [X] Create entities 
 - [ ] Add DTO project 
 - [X] Map Strategy entity to DTO and wire up with Front End.
 - [X] Implement automapper
 - [X] CRUD operations for strategy.
 - [ ] Handle exceptions thrown from backend controller.
 - [ ] Create background task to consume external api.
 - [ ] Find free stocks data provider and implement it into background task.
 - [ ] Add basic price [indicators.](https://www.investopedia.com/terms/m/market_indicators.asp)


####Free Data Provider
Data provided for free by [IEX](https://iextrading.com/developer/). View [IEX’s Terms of Use](https://iextrading.com/api-exhibit-a/).