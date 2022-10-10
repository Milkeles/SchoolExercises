/*
 * Create a class called Person, which has fields name and age.
 * And a class, Family, that stores a list of people and has methods to add new members and return the oldest member in the family.
 * Use them to input a family with N members and output the oldest member in it.
*/

class Person
{
    public string Name;
    public byte Age;

    public Person(string name, byte age)
    {
        Name = name;
        Age = age;
    }
}

class Family
{
    List<Person> members = new List<Person>();

    // Add new member to the list.
    public void AddMember(Person newMember)
    {
        members.Add(newMember);
    }

    // Return oldest member
    public Person GetOldestMember()
    {
        Person? oldest = null;
        foreach (Person current in members)
        {
            if (oldest == null || oldest.Age < current.Age) oldest = current;
        }
        return oldest;
    }
}

class Program
{
    static void Main()
    {
        // Prompt the user to input the members count.
        Console.Write("Family members count: ");
        byte n = Byte.Parse(Console.ReadLine());

        Family family = new Family();

        // Add the members to the list.
        for (byte i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            Person newPerson = new Person(input[0], Byte.Parse(input[1]));
            family.AddMember(newPerson);
        }

        // Output the oldest member.
        Person oldest = family.GetOldestMember();
        Console.WriteLine($"Oldest member of the family: {oldest.Name}, {oldest.Age}");
    }
}
