// A car-selling company needs software that collects data about their cars (brand, model, engine volume, and year of production) and calculates the annual tax of each car and the total tax of all cars.
// The annual bill is equal to 20% of the car's engine volume plus: 50$ for cars created after 2010, 60$ for cars produced between 2001 and 2010, and 70$ for cars produced before 2001.
// The program must add cars until it receives an "End" command that makes it stop and then print all cars sorted by their brand.

using System.Text.RegularExpressions;

class Car
{
    public string Brand;
    public string Model;
    public short Volume;
    public short ProductionYear;

    public Car(string brand, string model, short volume, short productionYear)
    {
        Brand = brand;
        Model = model;
        Volume = volume;
        ProductionYear = productionYear;
    }
}

class Program
{
    static void Main()
    {
        List <Car> cars = new List <Car> ();

        // Show the user how to input data about his cars.
        Console.WriteLine("> Brand, Model, Engine Volume, Year of Production");

        // Input cars.
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            // Stop adding cars after receiving an "end" command.
            if (input.ToLower() == "end")
            {
                break;
            }
            else
            {
                string[] data = Regex.Split(input, ", ");
                // Using constructor to create a new car object.
                Car newCar = new Car(data[0], data[1], Int16.Parse(data[2]), Int16.Parse(data[3]));
                cars.Add(newCar);
            }
        }
        Console.WriteLine();

        // Sort cars by Brand.
        cars = cars.OrderBy(x => x.Brand).ToList();

        float totalBill = 0.0f;
        float carBill = 0.0f;

        // Calculate and print the car's bill.
        foreach (Car car in cars)
        {
            // Engine volume bill only.
            carBill = (float)((car.Volume * 20.0f) / 100.0f);

            // Adding year of production bill.
            if (car.ProductionYear > 2010) carBill += 50.0f;
            else if (car.ProductionYear < 2001) carBill += 70.0f;
            else carBill += 60.0f;

            Console.WriteLine($"{car.Brand}, {car.Model} | Annual bill: {carBill}$");
            totalBill += carBill;
        }

        // Print the total annual bill of all cars.
        Console.WriteLine("Total: {0}$", totalBill);
    }
}
