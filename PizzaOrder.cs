// The program allows customers to order pizza with whatever ingredients they like.

class Program
{
    static void Main()
    {
        string command = string.Empty;
        Console.Write("Pizza name: ");
        string name = Console.ReadLine();

        // Use method we can recall until we get valid data.
        Dough dough = CreateNewDough();

        Dictionary<string, Topping> toppings = new Dictionary<string, Topping>();

        Console.Write("> Topping(Name, Weight): ");
        // Repeat until given end command.
        while ((command = Console.ReadLine()).ToLower() != "end")
        {
            try
            {
                string[] toppingData = command.Split(' ');
                Topping newTopping = new Topping(toppingData[0], Byte.Parse(toppingData[1]));

                // Making sure this type of topping is not already added.
                if (!toppings.ContainsKey(toppingData[0]))
                {
                    toppings.Add(toppingData[0], newTopping);
                }
                else
                {
                    throw new ArgumentException($"Topping of type {toppingData[0]} already exists.");
                }
                Console.Write("> Topping: ");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message + "Please try again!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> Topping: ");
            }
        }

        Pizza myPizza = new Pizza(name, dough, toppings);
        Console.WriteLine($"{myPizza.Name} has {myPizza.GetCalories()} kcal.");
    }

    static Dough CreateNewDough()
    {
        Dough dough = null;
        try
        {
            Console.Write("Dough (Type, Baking Technique, Weight): ");
            string[] doughData = Console.ReadLine().Split(' ');
            dough = new Dough(doughData[0], doughData[1], Byte.Parse(doughData[2]));
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message + "Please try again!");
            Console.ForegroundColor = ConsoleColor.White;
            // Recall the method until we get valid data.
            dough = CreateNewDough(); // Assign, otherwise it shall return null at the end of the recursion.
        }
        return dough;
    }

}

class Dough
{
    private string doughType;
    private string bakingTechnique;
    private byte weight;
    private string DoughType
    {
        get { return doughType; }
        set
        {
            if (value != "Wholegrain" && value != "White")
                throw new ArgumentException("Invalid type of dough.");

            doughType = value;
        }
    }
    private string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (value != "Homemade" && value != "Crispy" && value != "Chewy")
                throw new ArgumentException("Invalid type of dough.");

            bakingTechnique = value;
        }
    }
    private byte Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
                throw new ArgumentException("Dough weight should be in the range [1..200].");

            weight = value;
        }
    }
    public float Calories
    {
        get { return CalculateCalories(); }
    }

    private float CalculateCalories()
    {
        float calories = Weight * 2.0f;

        // We don't need to multiply by one (for Wholegrain and Homemade), won't change value.
        if (DoughType == "White") calories *= 1.5f;

        if (BakingTechnique == "Crispy") calories *= 0.9f;
        else if (BakingTechnique == "Chewy") calories *= 1.1f;

        return calories;
    }

    public Dough (string doughType, string bakingTechnique, byte weight)
    {
        DoughType = doughType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }
}

public class Topping
{
    private string toppingName;
    private byte toppingWeight;

    private string ToppingName
    {
        get
        {
            return this.toppingName;
        }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
            }
            this.toppingName = value;
        }
    }
    private byte ToppingWeight
    {
        get
        {
            return this.toppingWeight;
        }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", this.toppingName));
            }
            this.toppingWeight = value;
        }
    }

    public float Calories
    {
        get { return CalculateCalories(); }
    }

    private float CalculateCalories()
    {

        float calories = 2 * toppingWeight;

        switch (toppingName.ToLower())
        {
            case "meat":
                calories *= 1.2f;
                break;
            case "veggies":
                calories *= 0.8f;
                break;
            case "cheese":
                calories *= 1.1f;
                break;
            case "sauce":
                calories *= 0.9f;
                break;
        }

        return calories;
    }

    public Topping(string toppingName, byte toppingWeight)
    {
        this.ToppingName = toppingName;
        this.ToppingWeight = toppingWeight;
    }
}

class Pizza
{
    public string Name;
    private Dough dough;

    // Should not be able to have multiple toppings of the same type.
    private Dictionary<string, Topping> toppings;

    public Pizza (string name, Dough dough, Dictionary<string, Topping> toppings)
    {
        Name = name;
        this.dough = dough;
        this.toppings = toppings;
    }

    public float GetCalories()
    {
        float calories = dough.Calories;
        foreach (KeyValuePair<string, Topping> item in toppings)
        {
            calories += item.Value.Calories;
        }
        return calories;
    }
}
