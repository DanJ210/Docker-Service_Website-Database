# README #

### What is this repository for? ###

* This web app was made to replace the product/server locations on the confluence page that the NOC team uses to keep track of which servers host which products. [Confluence Product/Location Page](https://ecndev1.atlassian.net/wiki/display/ECN/Product+Location)
* Version 1 - Currently live temporarily at [NocUtilityWebApp URL](http://nocwebutilityapp.azurewebsites.net/)
* Versino 2 - In Progress - Dockerized container on VM to replace temporary Azure hosting above.

** User will need admin username and password to make changes to any table cell. See developer contact below. **

### How do I get set up? ###
## To run Docker version ##
* Clone Repo.
* Run `docker-compose up` command to run all services needed, confirm service is up.
* Navigate to http://localhost:80 to view site.
## Run Non-Docker Version ##
* Configured to run via IIS but could also run Kestrel.
* Will need an active SQL Server DB in one of two ways. Connection string may need adjustments accordingly.
    1. Connection string points to the container SQL Server
    2. Connection string points to local SQL Server instance
    3. Connection string points to Temporary Azure Database (Currently, no changes needed after clone.)
* If DB is not Azure, migrations need to first be run to create the DB and seed the data needed that the tables use.
* All dependencies are in the .csproj file, running `dotnet restore` from terminal will restore dependencies, `dotnet build` ensures all are restored, `dotnet run` **or** green debug button will then run the application.
* Once connection string is set correctly to a DB with the created schema, should be able to run application locally.
* See developer below for username and password to change data through the running app, otherwise un-authorized is read only.

### Contribution guidelines ###

* .NET Core
* Linux VM Server w/ Docker service support OR Swarm setup for deployment.

### Who do I talk to? ###

* Developer Daniel Jackson