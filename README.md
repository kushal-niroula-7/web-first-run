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
		