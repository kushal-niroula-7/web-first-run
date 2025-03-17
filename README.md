Database
	- Impedence mismatch
C#
	
ORM: Object Relational Mapper
	-> Manipulate objects using C# -- Dev
		-> Get { Fetch, Join }
		-> Update
		-> Delete
		-> Create
	-> Convert the manipulations to SQL queries -- ORM
		-> SELECT
		-> Update
		-> delete
		-> insert

Ef Core: Entity Framework Core
	-> DDL { New database, new table, schema changes }
	-> SQL { Fetch data }
	-> DML { Manipulation }
	========================
	-> Class
	-> Properties
	-> Attributes
	-> LINQ
	-> DbContext
	-> Migration
	-> Change Tracker

ProductCategory
---------------------
Id | Name { varchar, default: "" } | IsActive { bool, default: true }
	
Product
------------------
Id | Name | Code | CategoryId

Unit
-----------------------
Id | Name | Code

ProductUnit
------------------------
Id | ProductId | UnitId | Position
	
## Installation
	-> Nuget package: Ef Core, NpgSql.EntityFrameworkCore (Postgres)
	-> Create a new DbContext
		-> Gateway to database
		-> Usually placed under Data/{}DbContext
		-> Register Db context with our application
			builder.Services.AddDbContext<FirstRunDbContext>();
	-> Add new model / Entity
		- Is a C# class
		- Represents a database table
		-> Properties -> Database table columns
	-> Add it to db context
	-> Create new migration
		-> A C# file that specifies what DDL to write
		dotnet ef migrations add "Initial"
		
		-> Snapshot: Whole state of database
			{ tables: {
				product: {
					columns: [
						{ id, type: int },
						{ name, type: string }
					],
					constraints: [
						
					]
				}
			} }
			{ tables: {
				product: {
					columns: [
						{ id, type: int },
						{ name, type: string },
						{ created_at, type: date }
					],
					constraints: [
						
					]
				}
			} }
						
	// Project directory
	-> dotnet ef migrations add "name"
	-> dotnet ef database update
		


## Adding Services



Controller
	-> Mediator
		-> Gets request from View
		-> Does some basic validation
		-> Forwards the request to a handler service

Handler / Service
	-> Performs the actual task
	
## Conceptual logic

1. Create a service class
2. Move logic to service class
----------------
## Actual Implementation
1. Create an interface for our service (For DI and testing) ✅
2. Create the service class that implements the above interface ✅
3. Create request object / DTO (Data transfer object) ✅
4. Move the logic from controller to Service ✅
	- Identify MVC logic vs business logic
		-> MVC logic resided in controller
		-> Business logic, goes to services
5. Call the service: If necessary, perform Vm to Dto mapping ✅
	-> Service Registration | IOC Registration
	-> Service Injection
	-> Method call | Message Passing	

Dto Vs ViewModel (VM)
--------------------------
- Intent: DTO is for data transfer between Controller and Service
		  VM is for data transfer between Controller and View

- Data: DTO contains references to Entities
		VM contains just Ids
		
## Service Lifetime

// Within a scope, multiple get will return same intance
// In different scope, we get different instance
builder.Services.AddScoped

// Inside a single scope
{
		var item = Services.Get(IProductService);
		var item1= Services.Get(IProductService);
		var item2 = Services.Get(IProductService);
		var item3 = Services.Get(IProductService);
		
		// All are same
}

In asp.net core: A scope is an http request
-> User sends a request
	-> Create a new scope
	-> Everything happens within this scope
	-> Scope is disposed

// Everytime you ask, you get different instance
builder.Services.AddTransient

// Everytime single instance
builder.Services.AddSingleton



## March  17 2025


API : Application Programming Interface
Way to interact with a system

Web:
Pages - For Humans
URL with standard format data: For internal/external applications
	-- JSON
NON-REST
	- /api/product/create
	- /api/product/update
	- /api/product/list

REST: Use HTTP verbs
	- Create: HTTP Post /api/product -- /resource
	- Update: HTTP PUT PATCH /api/product/{id}
		- PUT = For entire data update
		- PATCH = For partial data update
	- List: HTTP GET /api/product
	- Single Item: HTTP GET /api/product/{id}
	- Delete: HTTP DELETE /api/product/{id}
	
	- GET: /api/product-category/{id}/product
		-- ❌ Update / Create / Delete
		-- Gets the data
			- Gets a list of products under the product category with Id = {id}

Task:
- Implement Rest API CRUD for product category and product

- Add a API reference client
-- Add Swagger
-- Add Scalar