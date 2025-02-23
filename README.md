# PhoneBook

This project is a phone book application with web services developed with .Net 5.

## Tech

- .Net 5.0
- MS-SQL

## About Architecture

- The layers created in the project are as follows.

![image](https://user-images.githubusercontent.com/93819969/171655264-bb4c6a15-03fc-4a2d-ac93-68cc4c530a0f.png)

- For the project setup, you need to replace the connection string inside the "PhoneBookDbContext.cs" file in the PhoneBook.DAL layer with your own connection string.

![image](https://user-images.githubusercontent.com/93819969/171656856-a0160580-d47a-4ce5-9307-58a38b675ab2.png)

- Then, you need to run the following command in the Package Manager Console ```update-database```. This command will update the database and insert sample data into it.

## Running The Project

When the project runs, you will be greeted by the `swagger` screen.

- The APIs written to handle requests for adding, updating, deleting a person, listing all users, and retrieving all information related to a specific user are as follows.

![image](https://user-images.githubusercontent.com/93819969/171660300-c6e8e5cf-13a1-46c1-8fec-5225e5a660c9.png)

- The APIs written for adding and deleting contact information, as well as retrieving location-based contact details, are as follows.

![image](https://user-images.githubusercontent.com/93819969/171661030-953def39-8026-4950-9c5f-6bb1220b3288.png)

- For the `InfoType` parameter in the POST method written for Contact, you can use the following values; 
     - PhoneNumber
     - EmailAddress
     - Location
- Similarly, if the `InfoType` value in the POST method for Contact is set to `Location` the `InfoContent` value can be entered as the desired city name in lowercase letters. For example: istanbul, ankara, izmir, etc.
