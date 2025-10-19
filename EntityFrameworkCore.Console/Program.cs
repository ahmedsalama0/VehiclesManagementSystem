using EntityframeworkCore.Data;
using EntityFrameworkCore.Console.Controllers;
using EntityFrameworkCore.Console.Repository;
using EntityFrameworkCore.Domain;
using EntityFrameworkCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;


using VehicleDbContext context = new VehicleDbContext();
context.Database.EnsureCreated();

Console.WriteLine("Welcome to our Vehicle Management System:");



bool IsFinished = true;
int userInput;
while(IsFinished)
{
    int userImput = DisplayOptions();
    
    if (userInput == 0)
    {
        IsFinished = false;
        Console.WriteLine("Thank you for using our system, come back again.");
    }
    else if (userInput > 4 || userInput < 1)
    {
        Console.WriteLine("Incorrect Input! - Please Enter a valid optoin.");
        Console.Clear();
    }
    else
    {
       switch(userInput)
        {
            case 1:
                HandleCars();
                break;

            case 2:
                HandleMotorcycles();
                break;

            case 3:
                HandleTrucks();
                break;

            case 4:
                DisplayRentFees();
                break;
            default:
                break;
        }
    }
}

void HandleCars()
{
    bool IsFinished = true;
    int userChoice = DisplayMenuOptions();
    if (userChoice == 0)
        return;
    var carController = new CarController(context);
    switch (userChoice) {
        case 1:
            List<Car> items = carController.GetAll().Result;
            if(items.Count == 0 || items == null)
                Console.WriteLine("No Items To Show!");
            else
              DisplayListData<Car>(items);
            break;
        case 2:
            //HandleAddition(carController);
            break;

        case 3:
            //HandleSearch(carController);
                break;
        case 4:
            //HandleDeletion(carController);
            break;


        default:
            break;

    }
}
// T: Car, U: CarController
void HandleVehicle<T>() where T : Vehicle, EntityFrameworkCore.Domain.Interfaces.IVehicle, new()
{
    bool IsFinished = true;
    int userChoice = DisplayMenuOptions();
    if (userChoice == 0)
        return;
    var vehicleController = new GenericRepository<T>(context);
    switch (userChoice)
    {
        case 1:
            List<T> items = vehicleController.GetAll().Result;
            if (items.Count == 0 || items == null)
                Console.WriteLine("No Items To Show!");
            else
                DisplayListData<T>(items);
            break;
        case 2:
            HandleVehicleAddition<T>(vehicleController);
            break;

        case 3:
            HandleSearch<T>(vehicleController);
            break;
        case 4:
            HandleDeletion<T>(vehicleController);
            break;


        default:
            break;

    }
}


void HandleSearch<T>(GenericRepository<T> v) where T: Vehicle
{
    string searchTerm = ReturnSearchKeyword();
    if (searchTerm == null)
    {
        Console.WriteLine("Invalid Input! - Empty Search Term!");
    }
    else
    {
        List<T> returnedLst = v.GetByModelorBrand(searchTerm);
        if (returnedLst.Count == 0)
            Console.WriteLine("No matched items found!");
        else
            DisplayListData(returnedLst);
    }
}

void DisplayRentFees()
{
    Console.WriteLine("Enter an option to Display the Rent Fees (Per Week):");
    Console.WriteLine("1) Cars");
    Console.WriteLine("2) Motorcycles");
    Console.WriteLine("3) Trucks");
    int userInput = int.Parse(Console.ReadLine());
    if(userInput < 1 || userInput > 3)
        Console.WriteLine("Invalid Input!");
    else
    {
        Vehicle v;
        switch(userInput)
        {
            case 1:
                v = new Car();
                v.CalculateRentalFees();
                break;
            case 2:
                v = new Motorcycle();
                v.CalculateRentalFees();
                break;
            case 3:
                v = new Truck();
                v.CalculateRentalFees();
                break;
            default:
                break;
        }
    }
}


void DisplayListData<T>(List<T> items)
{
    foreach (var item in items)
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine("-----------------------");
}

void HandleDeletion<T>(GenericRepository<T> c) where T: Vehicle
{
    Console.WriteLine("Enter a product Id To Remove:");
    int id = int.Parse(Console.ReadLine());
    Vehicle? item = c.GetById(id);
    if(item == null)
        Console.WriteLine("Not Found!");
    else
    {
        c.Delete(id);
        Console.WriteLine($"Item {id} Delete Successfully!");
    }


}


void HandleVehicleAddition<T>(GenericRepository<T> v) where T : Vehicle, new()
{
    Console.WriteLine("Enter an Id");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter a model name:");
    string model = Console.ReadLine();
    Console.WriteLine("Enter a Brand name:");
    string brand = Console.ReadLine();
    Console.WriteLine("Enter a production year:");
    int year = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter a Max Speed:");
    int maxSpeed = int.Parse(Console.ReadLine());


    T newCar = new T()
    {
        Id = id,
        Model = model ?? "N/A",
        Brand = brand ?? "N/A",
        Year = year,
        MaxSpeed = maxSpeed,
        //Type = (CarType)int.Parse((Console.ReadLine()))
    };

    v.Add(newCar);

}

//void HandleAddition(CarController c)
//{
//    Console.WriteLine("Enter an Id");
//    int id = int.Parse(Console.ReadLine());
//    Console.WriteLine("Enter a model name:");
//    string model = Console.ReadLine();
//    Console.WriteLine("Enter a Brand name:");
//    string brand = Console.ReadLine();
//    Console.WriteLine("Enter a production year:");
//    int year = int.Parse(Console.ReadLine());
//    Console.WriteLine("Enter a Max Speed:");
//    int maxSpeed = int.Parse(Console.ReadLine());


//    Car newCar = new Car()
//    {
//        Id = id,
//        Model = model ?? "N/A",
//        Brand = brand ?? "N/A",
//        Year = year,
//        MaxSpeed = maxSpeed,
//        //Type = (CarType)int.Parse((Console.ReadLine()))
//    };

//    c.Add(newCar);

//}

string? ReturnSearchKeyword()
{
    Console.WriteLine("Please enter a brand or a model to search:");
    string searchTerm = Console.ReadLine();
    return searchTerm;
}


void HandleMotorcycles()
{
    bool IsFinished = true;
    DisplayMenuOptions();
    
}

void HandleTrucks()
{
    bool IsFinished = true;
    DisplayMenuOptions();
}

int  DisplayMenuOptions()
{
    Console.WriteLine("1) Retrieve All Data.");
    Console.WriteLine("2) Add New Items.");
    Console.WriteLine("3) search a specific brand or type within this section.");
    Console.WriteLine("4) Remove Vehicle by Id.");
    //Console.WriteLine("4) Display Renting Fees (per week): .");
    int userInput = int.Parse(Console.ReadLine());
    if (userInput > 4 || userInput < 1)
    {
        Console.WriteLine("Wrong Input - Back to the main menu!");
        return 0;
    }
    return userInput;


}
int DisplayOptions()
{
    Console.WriteLine("Choose a section:");
    Console.WriteLine("1) Cars");
    Console.WriteLine("2) Motorcycles");
    Console.WriteLine("3) Trucks");
    Console.WriteLine("4) Rent Fees");
    Console.WriteLine("0) Exit");

    userInput = int.Parse(Console.ReadLine());
    return userInput;

}

//await context.Cars.AddAsync(new Car()
//{
//    Id = 452441,
//    //Name = "Cotrolla",
//    Brand = "Toyota",
//    MaxSpeed = 240,
//    Model = "Corola",
//    Type = CarType.Sedan,
//    Year = 2020
//});
//await context.SaveChangesAsync();


/*
await context.Cars.AddAsync(new Car()
{
    Id = 452441,
    Name = "Cotrolla",
    Brand = "Toyota",
    MaxSpeed = 240,
    Model = "Corola",
    Type = CarType.Sedan,
    Year = 2020
});
await context.SaveChangesAsync();

var r = await  context.Cars.ToListAsync();
if (r.Count == 0) return;
foreach(var el in r)
    Console.WriteLine(el.Brand);

var foundEntity = await context.Cars.FindAsync(452441);
if(foundEntity != null)
{
    foundEntity.Brand = "Toyota Updated";
    context.Entry(foundEntity).State = EntityState.Modified;
    await context.SaveChangesAsync();
}
    Console.WriteLine(foundEntity.Brand);

Console.WriteLine("Update occurred!");
context.Entry(foundEntity).State = EntityState.Deleted;
await context.SaveChangesAsync();
Console.WriteLine("Delete occured");
var foundEntity2 = await context.Cars.FindAsync(452441);
if(foundEntity2 == null)
    Console.WriteLine("N/A");
else Console.WriteLine("Found!");
*/