// You are a vet. Write a program that stores the name, age, owner's name, and breed (for dogs only) of the pets you take care of. 
// Your program should save the data about the pets and based on the input it must decide whether the pet is a dog or a cat.
// Then it should print all pets ordered by their type and age.

using System.Text.RegularExpressions;

class Pet
{
    public string Name;
    public byte Age;
    public string Owner;
    public string PetType = "Cat"; // Is cat by default unless given breed.
    public string? Breed = null;

    // Constructor for cats.
    public Pet (string name, byte age, string owner)
    {
        Name = name;
        Age = age;
        Owner = owner;
    }

    // Constructor for dogs.
    public Pet(string name, byte age, string owner, string breed)
    {
        Name = name;
        Age = age;
        Owner = owner;
        Breed = breed;
        PetType = "Dog";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Pets count: ");
        byte n = Byte.Parse(Console.ReadLine());

        List<Pet> pets = new List<Pet>();

        // Show the user how to input new pets.
        Console.WriteLine("Pet: Name, age, owner's name, breed (for dogs only!)");

        for (byte i = 0; i < n; i ++)
        {
            Console.Write($"Pet[{i + 1}]: ");
            string[] input = Regex.Split(Console.ReadLine(), ", ");

            // Create different kind of pets based on the input.
            if (input.Length > 3)
            {
                Pet newDog = new Pet(input[0], Byte.Parse(input[1]), input[2], input[3]);
                pets.Add(newDog);
            }
            else
            {
                Pet newCat = new Pet(input[0], Byte.Parse(input[1]), input[2]);
                pets.Add(newCat);
            }
        }

        // Sorting the pets by their type and then by their age.
        pets = pets.OrderBy(x => x.PetType).ThenByDescending(y => y.Age).ToList();

        // Printing data about all pets.
        foreach (var pet in pets)
        {
            Console.Write($"{pet.Name}({pet.PetType}), {pet.Age} owned by {pet.Owner}");
  
            if (pet.Breed != null) Console.WriteLine($"is a {pet.Breed}.");
            else Console.WriteLine(".");
        }
    }
}
