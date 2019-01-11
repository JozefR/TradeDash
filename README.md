# TradeDash

### Description
A simple ASP.NET Core TradeDash project that I am working in my free time. I am going to develop simple [Blue Chips/Stocks](https://www.investopedia.com/terms/b/bluechip.asp) trading simulation with trading sheets and some statistics. This project is very basic, anyone who has interest in Stocks and learn ASP. Core is welcome to join :).

![TradeDash.Components](https://github.com/JozefR/TradeDash/blob/master/TradeDash.Components.png)

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
 - [ ] For stock view implement dropdown with strategies and calculate indicators based on picked strategy.

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
 - [X] Create background task to consume external api.
 - [X] Find free stocks data provider. 
 - [X] Build example controller to consume data from external api using background task.
 - [X] Add page to show data for given stocks.
 - [ ] Find free library for showing data in charts.
 - [X] Add basic price [indicators.](https://www.investopedia.com/terms/m/market_indicators.asp)
 - [ ] Build simple stock strategy.
 
 ## Strategies
 
 ### Simple Cross Moving Average Strategy
 
 1. Pick stock
 2. Trade only once a day at close price.
 3. Buy one contract when price goes up and cross Long Moving average from bottom up.
 3. Sell one contract when price goes down and cross Long Moving average from up to bottom.
 4. No Stop Loss.
 
 ### Connors Rsi Strategy
 
 1. Pick some stock
 2. We are going to trade only once a day at close price.
 3. Price must be above long SMA.
 4. We are buying stock only when price is below Rsi(2).
 6. Sell only when price is above short SMA.
 7. At first we are always buying 100 ks of picked stock.

#### Free Data Provider
Data provided for free by [IEX](https://iextrading.com/developer/). View [IEX’s Terms of Use](https://iextrading.com/api-exhibit-a/).
