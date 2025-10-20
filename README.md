# Vehicle Management System

## Overview
This C# console application manages different types of vehicles using an in-memory database. It demonstrates object-oriented programming principles. The system provides core operations for adding, updating, viewing, searching, and removing vehicles, as well as calculating rental prices for each vehicle type.

## Features
- Manage multiple vehicle types  
- Add new vehicles  
- Edit existing vehicles
- View all stored vehicles  
- Search by brand or type  
- Remove vehicles by ID  
- Calculate rental prices with different formulas per vehicle type  
- Easily extendable with new vehicle categories  

## Object-Oriented Design  
- **Extensibility:** New vehicle types can be added by inheriting from the Vehicle class and defining their specific attributes and rental price logic  

## Data Management
All data is stored in memory during runtime using Entity Framework Core 9 (EF Core 9). The application does not use external files or databases. All data is cleared when the program terminates.

## Usage
1. Open the project in Visual Studio or Visual Studio Code.  
2. Build and run the application using the .NET CLI or IDE tools.  
3. Use the console interface to perform vehicle management operations.

## Tools
- Language: C#  
- Framework: .NET  
- ORM: Entity Framework Core 9  

## Code Quality
The project maintains clean, organized, and readable code with a modular structure, following standard C# design and naming conventions.
