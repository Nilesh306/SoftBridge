# SoftBridge

#SoftBridge API

SoftBridge Api is the API which sends data to the the FrontEnd Applications.It retreives and store all the interactions data in SQL Server database. All the Functions Get, Post & Delete are served to the Frontend Application.
To start the SoftBridge Api you need to follow the below Steps:
•	You need to set the ErrorLogFile path in the ProductController.cs Page . So that it will capture the Exception errors generated within the Application.
 
•	After running the SoftBridge Api to Get the Information you need to enter the url "https://YourlocalhostServername/api/Product".This Url will fetch all the stored data in our database.

 •	To get the Specific Product you need to enter the ProductID in the Url "https://YourlocalhostServername/api/Product/1".


#SoftBridge Application
SoftBridge Application is the front end application which consumes the SoftBridge API data. It have capability to Create new product, Show all Products in list, Delete Product from list and Shows the full details of the Product when product from list is clicked.
To start the SoftBridge App you need to follow the below Steps:
•	You need to set the ErrorLogFile path in the ProductController.cs Page . So that it will capture the Exception errors generated within the Application.
 
•	To run the SoftBridge Application first you need to run the SoftBridge API so that SoftBridge Application is able to consume the data send from API. To acces the SoftBridge Application you need to enter the url "https://YourlocalhostServername/Product/AddNewProduct".
 
•	In the Add Product form you need to enter all the information as all the fields are required field. After submission of the data your product is showing under productList as shown in above image.To get the full details of the product when you click on the product then you will be redirect to the Product Detail page where you will get the All the informations related to the product.
