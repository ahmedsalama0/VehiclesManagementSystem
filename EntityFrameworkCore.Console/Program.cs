using EntityframeworkCore.Data;
using EntityFrameworkCore.Console.Controllers;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


using VehicleDbContext context = new VehicleDbContext();
context.Database.EnsureCreated();

Console.WriteLine("Welcome to our Vehicle Management System:");

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
  

bool IsFinished = true;
int userInput;
while(IsFinished)
{
    DisplayOptions();
    userInput = int.Parse(Console.ReadLine());
    if (userInput == 0)
    {
        IsFinished = false;
        Console.WriteLine("Thank you to use our system, come back again.");
    }
    else if (userInput > 3 || userInput < 1)
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
            HandleAddition(carController);
            break;

        case 3:
            string searchTerm = ReturnSearchKeyword();
            if(searchTerm == null)
            {
                Console.WriteLine("Invalid Input! - Empty Search Term!");
            }
            else
            {
                List<Car> returnedLst = carController.GetByModelorBrand(searchTerm);
                if (returnedLst.Count == 0)
                    Console.WriteLine("No matched items found!");
                else
                    DisplayListData(returnedLst);
            }
                break;
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

void HandleAddition(CarController c)
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


    Car newCar = new Car()
    {
        Id = id,
        Model = model ?? "N/A",
        Brand = brand ?? "N/A",
        Year = year,
        MaxSpeed = maxSpeed,
        //Type = (CarType)int.Parse((Console.ReadLine()))
    };

    c.Add(newCar);

}

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
    Console.WriteLine("1)Retrieve All Data.");
    Console.WriteLine("2)Add New Items.");
    Console.WriteLine("3) search a specific brand or type within this section.");
    Console.WriteLine("4)Remove Vehicle by Id.");
    int userInput = int.Parse(Console.ReadLine());
    if (userInput > 4 || userInput < 1)
    {
        Console.WriteLine("Wrong Input - Back to the main menu!");
        return 0;
    }
    return userInput;


}
void DisplayOptions()
{
    Console.WriteLine("Choose a section:");
    Console.WriteLine("1) Cars");
    Console.WriteLine("2) Motorcycles");
    Console.WriteLine("3) Trucks");
    Console.WriteLine("0) Exit");
}

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