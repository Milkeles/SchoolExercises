/*
 * A person has multiple bank accounts. He needs help calculating his total balance from all of the accounts.
 * Create a program that calculates the total balance for him using classes "BankAccount" and "Person".
 * The person class must have two constructors and a method that returns the total balance.
*/

class Program
{
    static void Main()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Age: ");
        byte age = Byte.Parse(Console.ReadLine());
        Console.Write("Accounts count:");
        byte n = Byte.Parse(Console.ReadLine());

        List<BankAccount> accounts = new List<BankAccount>();

        // Add accounts to the list.
        for (byte i = 0; i < n; i++)
        {
            BankAccount account = new BankAccount();
            Console.Write("> Balance: ");
            account.Balance = Single.Parse(Console.ReadLine());
            accounts.Add(account);
        }

        Person p = new Person(name, age, accounts);
        Console.WriteLine($"{p.Name} ({p.Age} years old) has: {p.GetBalance()}$");
    }
}

class BankAccount
{
    public float Balance;
}
class Person
{
    public string Name;
    public byte Age;
    List<BankAccount> Accounts = new List<BankAccount>();

    public float GetBalance()
    {
        float balance = 0.0f;
        Accounts.ForEach(x => balance += x.Balance);
        return balance;
    }
    public Person(string name, byte age)
    {
        Name = name;
        Age = age;
    }

    public Person(string name, byte age, List<BankAccount> accounts) : this(name, age)
    {
        Accounts = accounts;
    }
}

