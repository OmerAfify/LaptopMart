# LaptopMart
A Web application for selling laptop products. ( created with asp.net core MVC )

***this project includes;***

### Data Manipulation ###
* SQL Database having more than 1300 laptop records with more that 10 categories.
* EF core 6 to manage records.
* Data Annotations and Flurent APIs
* code first.
* dependency Injection.
* Business Logic handles all the Data Accessing, and is decoples form the controllers.

### Views ###
* different views for each action in every controller.
* partial views are included for the footer, the header, as well as for a repeated product box html.  

### Authentication and Authorization ###
* User can Login, logout with cookie based auth.
* new users can sign-up.
* different roles are assigned to different users.
* JWT authentication scheme is included for API's Authentication and Authorization.

### Admin Panel ###
* only users with role admin can manage CRUD operations on the Laptops and thier categories.
* non-admins will be routed to an 'access denied' page.

### Shopping Cart ###
* non-logged in user's shopping cart is saved in a cookie file.
* logged in user's shopping cart is saved in a specifiec session for him so that it can be accessed any where.
* adding, updating, deleting, changing carts quantity are managed asyncronously with out the need to refresh the page with the help of JS and J-query.  

### Ordering ###
*user add his shipping info and places an order/s.
* orders are saved in the DB, users can track them too.
* order status are changed automatically pending -> shipped -> delivered with the help of HangFire Library that runs background code.

### Shop Page ###
* calls laptops data as well as categories list using Ajax Jquery call.


