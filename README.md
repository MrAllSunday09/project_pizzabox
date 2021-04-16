### Pizzabox

Not impressed with UberEats, DoorDash, GrubHub pizza offerings? You can now try PizzaBox, the latest food delivery service. It is a command line-based application focused on nothing but pizzas.

### As a Customer

+ Should be able to launch the application

+ Should be able to view all stores

+ Should be able to select a store

+ Should be to place an order

+ Should be able to choose either custom or pre-set pizzas
for a custom pizza

    + Should be able to choose crust, size and toppings
    for a preset pizza

    + Should be able to choose pizza and size

+ Should be able to view a preview of the order in progress

+ Should be able to modify the order in progress (add/remove pizza)

+ Should be able to place/checkout the order in progress

+ Should be able to view order history

+ Should be able to make new order

### As a Store

+ Should be able to launch the application

+ Should be able to select options

+ For order history

    + Should be able to view all orders (including pizza count and total cost)

    + Should be able to view orders by customer

+ For sales

    + Should be able to view revenue by week (inluding pizza type and count)
    + Should be able to view revenue by month (including pizza type and count)

### Architecture

+ [solution] PizzaBox.sln
    + [project - console] PizzaBox.Client.csproj
    + [project - classlib] PizzaBox.Domain.csproj
        + [directory] Abstracts
        + [directory] Models
        + [directory] Singletons
    + [project - classlib ] PizzaBox.Storing.csproj
        + [directory] Repositories
    + [project - xunit] PizzaBox.Testing.csproj
        + [directory] Tests

### Requirements

The application is centered around the interaction of 4 main objects:

+ Customer
+ Order
+ Pizza
+ Store

Store

+ [required] there should exist at least 2 stores for a customer to choose from
+ [required] each store should be able to view any and all of their placed orders
+ [required] each store should be able to view any and all of their sales (weekly, monthly, quarterly)

Order

+ [required] each order must be able to modify its collection of pizzas
+ [required] each order must be able to compute its pricing
+ [required] each order must be limited to a total pricing of no more than $250
+ [required] each order must be limited to a collection of pizzas of no more than 50

Pizza

+ [required] each pizza must be able to have a crust
+ [required] each pizza must be able to have a size
+ [required] each pizza must be able to have toppings
+ [required] each pizza must be able to compute its pricing
+ [required] each pizza must have no less than 2 default toppings
+ [required] each pizza must have no more than 5 total toppings

Customer

+ [required] must be able to view its order history
+ [required] must be able to only order from 1 location in a 24-hour period with no reset
+ [required] must be able to only order once in a 2-hour period

### Technologies
+ .NET Core - C#
+ .NET Core - EF + SQL
+ .NET Core - xUnit