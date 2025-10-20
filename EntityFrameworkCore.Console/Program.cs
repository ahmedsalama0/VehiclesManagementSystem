using EntityframeworkCore.Data;
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
                HandleVehicle<Car>();
                break;

            case 2:
                HandleVehicle<Motorcycle>();
                break;

            case 3:
                HandleVehicle<Truck>();
                break;

            case 4:
                DisplayRentFees();
                break;
            default:
                break;
        }
    }
}


///////////////////////////////////////////////
///// - Helpers
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
        
        case 5:
            HandleUpdate<T>(vehicleController);
            break;

        default:
            Console.WriteLine("Invalid Iput!");
            break;

    }
}

async void  HandleUpdate<T>(GenericRepository<T> repo) where T: Vehicle
{
    Console.WriteLine("This is the Update Section.");
    Console.WriteLine("Enter an Id of a Vehicle to update its Data:");
    int id = int.Parse(Console.ReadLine());
    //Check for the Id existance
    T? returnedItem = repo.GetById(id);
    if(returnedItem == null)
    {
        Console.WriteLine("No Item matches the entered Id!");
        Console.WriteLine("Try again with correct data.");
        return;
    }

    Console.WriteLine("Update by type new data for the attribute - otherwise press enter:");
    Console.WriteLine($"Old model name: {returnedItem.Model}");
    Console.WriteLine("New model name:");
    string model = Console.ReadLine();
    Console.WriteLine($"Old brand name: {returnedItem.Brand}");
    Console.WriteLine("New Brand name:");
    string brand = Console.ReadLine();
    Console.WriteLine($"Old production year: {returnedItem.Year}");
    Console.WriteLine("New production year:");
    string? userInputYear = Console.ReadLine();
    int? year;
    if(string.IsNullOrEmpty(userInputYear))
    {
        year = null;
    }
    else
    {
        year = int.Parse(userInputYear);
    }
    Console.WriteLine($"Old Max Speed: {returnedItem.MaxSpeed}");
    Console.WriteLine("New Max Speed:");
    int userInputMaxSpeed;
    int? maxSpeed;
    if(int.TryParse(Console.ReadLine(), out userInputMaxSpeed))
    {
        maxSpeed = userInputMaxSpeed;
    }
    else
    {
        maxSpeed = null;
    }

        returnedItem.Model = model ?? returnedItem.Model;
    returnedItem.Brand = brand ?? returnedItem.Brand;
    returnedItem.Year = year ?? returnedItem.Year;
    returnedItem.MaxSpeed = maxSpeed ?? returnedItem.MaxSpeed;

    var responseMsg = await repo.Update(returnedItem);
    Console.WriteLine(responseMsg);

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

    //Be sure the Id is not already exist.

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



string? ReturnSearchKeyword()
{
    Console.WriteLine("Please enter a brand or a model to search:");
    string searchTerm = Console.ReadLine();
    return searchTerm;
}


int  DisplayMenuOptions()
{
    Console.WriteLine("1) Retrieve All Data.");
    Console.WriteLine("2) Add New Items.");
    Console.WriteLine("3) search a specific brand or type within this section.");
    Console.WriteLine("4) Remove Vehicle by Id.");
    Console.WriteLine("5) Edit Vehicle Data:");
    //Console.WriteLine("4) Display Renting Fees (per week): .");
    int userInput = int.Parse(Console.ReadLine());
    if (userInput > 5 || userInput < 1)
    {
        Console.WriteLine("Wrong Input - Back to the main menu...");
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

