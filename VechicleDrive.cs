// Write a program that stores data for a certain amount of vehicles (model, fuel, fuel consumption, travelled distance). Each car should be a different model (models cannot repeat) and start with a 0 km distance.
// After you input the data for each vehicle, until the program receives an "end" command, it should obey commands to drive the vehicle to a certain distance and update the vehicle's data or return an error if there is not enough fuel for the drive.
// After the end command is given, the program will output the updated data for each car.

class Vehicle
{
    public float Fuel;
    public float FuelConsumption;
    public float Distance = 0.0f; // Must always be 0 at the start.

    public Vehicle(float fuel, float fuelConsumption)
    {
        Fuel = fuel;
        FuelConsumption = fuelConsumption;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Car count: ");
        byte n = Byte.Parse(Console.ReadLine());

        // Key = Car Model, Val = Other Data.
        Dictionary<string, Vehicle> cars = new Dictionary<string, Vehicle>();

        // Show the user how to input cars.
        Console.WriteLine("<Model> <Fuel> <Fuel Consumption>");

        // Adding cars to the dictionary.
        for (byte i = 0; i < n; i++)
        {
            Console.Write("> ");
            string[] input = Console.ReadLine().Split(' ');

            if (!cars.ContainsKey(input[0]))
            {
                // Input[0] (the model) should be the dictionary's key!
                Vehicle newVehicle = new Vehicle(Single.Parse(input[1]), Single.Parse(input[2]));
                cars.Add(input[0], newVehicle);
            }
        }
        Console.WriteLine();

        // Start driving cycle.
        while (true)
        {
            Console.Write("Drive: ");
            string input = Console.ReadLine();

            // Stop the loop upon receiving "End" command.
            if (input.ToLower() == "end") break;

            string[] data = input.Split(' ');
            float distance = Single.Parse(data[1]);

            if (cars[data[0]].FuelConsumption * distance <= cars[data[0]].Fuel) // Checking whether the car has enough fuel to travel that far.
            {
                cars[data[0]].Distance += distance;
                cars[data[0]].Fuel -= cars[data[0]].FuelConsumption * distance;
            }
            else // Error if not enough fuel.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient fuel for the drive!");
                Console.ResetColor();
            }
        }
        Console.WriteLine();

        // Output results.
        foreach (KeyValuePair <string, Vehicle> car in cars)
        {
            Console.WriteLine($"{car.Key} has {car.Value.Fuel} fuel after travelling {car.Value.Distance} km.");
        }
    }
}
