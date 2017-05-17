# README #

This README would normally document whatever steps are necessary to get your application up and running.

### What is this repository for? ###

* This web app was made to replace the product/server locations on the confluence page that the NOC team uses to keep track of which servers host which products. [Confluence Product/Location Page](https://ecndev1.atlassian.net/wiki/display/ECN/Product+Location)
* Version 1

### How do I get set up? ###

* Clone Repo.
* Configured to run via IIS but could also run Kestrel.
* Will need a SQL Server DB in one of two ways. Connection string may need adjustments accordingly.
    1. Connection string points to the container SQL Server
    2. Connection string points to local SQL Server instance
* If DB is local, migrations need to first be run to create the DB and seed the data needed that the tables use.
* All dependencies are in the .csproj file, running `dotnet restore` from terminal will restore dependencies, `dotnet build` ensures all are restored, `dotnet run` **or** green debug button will then run the application.
* Once connection string is set correctly to a DB with the created schema, should be able to run application locally.
* See developer below for username and password to change data through the running app, otherwise un-authorized is read only.

### Contribution guidelines ###

* Writing tests
* Code review
* Other guidelines

### Who do I talk to? ###

* Developer Daniel Jackson