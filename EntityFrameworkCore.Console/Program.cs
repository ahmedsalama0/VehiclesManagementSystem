using EntityframeworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


using VehicleDbContext context = new VehicleDbContext();
Console.WriteLine("Welcome to our Vehicle Management System:");
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
    Console.WriteLine("");
}
void DisplayMenuOptions()
{
    Console.WriteLine("1)Retrieve All Data.");
    Console.WriteLine("2)Add New Items.");
    Console.WriteLine("3) search a specific brand or type within this section.");
    Console.WriteLine("4)Remove Vehicle by Id.");

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