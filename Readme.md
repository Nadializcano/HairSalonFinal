# Hair Salon

#### Project to practice C#, testing, MVC. May 9th, 2019.

#### By **Nadia Lizcano**

## Description

An web aplication for a hair salon, The owner is able to add all the stylists on the salon, and add the clients of each stylists, also edit and delete stylists names and clients from stylists.



### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **Homepage** | User accesses localhost:5000 | Homepage with start will show index page. |
| **Program Gathers stylists names and shows them as a list** | User input: "Jon" "Mike" | Output: "Jon" "Mike" |
| **Program gathers clients names for each stylist name and shows a list of the clients for the stylist**| User Input: Add Noah for Jon | Output: Jon client Noah |
| **Program deletes clients names from stylist name**| Input: delete Noah | Output: Jon has no clients |
| **Program edits clients names** | Input: clients name Noah edit for Maria | Output: clients name Maria |
| **Program deletes stylist name including the clients for that name** | Input:  | Output: |
| **Program edits stylist name withouth changing the clients list for that name** | Input:  | Output: |

## Setup Instructions to re-create databases, columns and tables.

> CREATE DATABASE to_do;
> USE to_do;
> CREATE TABLE categories (id serial PRIMARY KEY, name VARCHAR(255));
> CREATE TABLE tasks (id serial PRIMARY KEY, description VARCHAR(255));


1. Start MAMP and click Open Webstart page in the MAMP window.
2. In the website click on phpMyAdmin fron Tools option.
3. Click on databases and select creat database adding the name of your database.
4. After you can add columns names and number of columns.

## Setup/Installation Requirements

1. Download .NET Core 2.2.103 Sdk install it.
2. Clone this repository: $ git clone repo name.
3. To edit the project, open it in your prefer editor.
4. To run the program, navigate to the location of the HairSalon folder then execute: $ dotnet restore $dotnet build $dotnet run.
5. Open localhost:5000.
6. To run the tests, use these commands: $ cd WordCounter.Tests $ dotnet test
7. Enjoy!
## Known Bugs

## Technologies Used
  * C#
  * .NET Core App 2.2.103 & ASP.NET Core
  * Atom
  * Github


## Support and contact details

_Email prisicla.lizcano@gmail with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Nadia P Lizcano}_**
