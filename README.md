# CampaignModule
- This application is a module application based on Campaign, product and order.
- These technologies are needed on your computer in order to run and compile the application.(Net 6.0 ,Docker ,Vs Code or Visual Studio 2022)
- The module consists of 2 projects, api backend and simulation application. In order for the simulation application to work, the api project must be run with docker compose.When the docker compose command is completed, the Api services to be used in the simulation application and the Mssql server will be automatically ready for use in the docker environment.
### Workflow


STEP 1 - The following command is run in the folder where the Docker Compose File is path.
```go
Docker compose up --build

```
STEP 2 - Input commands are added to the Input.txt file in the Defaulth Path:C:\Input.txt".Commands must be entered in the following format.
```go
create_product PRODUCTCODE PRICE STOCK
get_product_info PRODUCTCODE
create_order PRODUCTCODE QUANTITY
create_campaign NAME PRODUCTCODE DURATION PMLIMIT TARGETSALESCOUNT
get_campaign_info NAME 
increase_time HOUR 
```

STEP 3  You can see the output of the application on the terminal screen by running the simulation project.You have to run the simulation application yourself, not in the docker environment.
