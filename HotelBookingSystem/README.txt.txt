CIS-2261 Final Project
Members: Behn McIlwaine, Manon Miron, Marco Saad

Description: 
A reservation system for a hotel. Data is stored on a central database that all consoles will be able to connect
to, and view/write data in real time. 

Install notes:
-A database is needed to be running on localhost. Please install XAMPP, and start both Apache and MySQL.
-Launch the MySQL admin (PHPMyAdmin). Import the Database.
-You can use one of two databases. In the root of the unzipped folder is a subfolder named "TestDatabaseToUse".
 Inside this folder is a "sleepeasydb.sql" file which can be imported to PHPMyAdmin which has the tables 
 pre-loaded with data. However, if you'd like a blank database to import, this can be found in
 HotelBookingSystem/SleepEasyDBCreate.sql.
-.exe file is located in HotelBookingSystem/bin/Debug. Running this exe without the database imported and
 running on localhost will result in an error. Please make sure database is imported, and runnin on localhost.
-Project can be run in Visual Studio, and run properly from here as well, if you would like.

Test information:
-Credit card information to use for processing payments
	Card number: 5554555455545554
	Card Type: Visa
	CSV: 999
-Admin login information 
	Username: admin
	Password: admin123