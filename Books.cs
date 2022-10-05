// Create a program that allows the user to input a list of n books they would like to pruchase. Each book has the following data: id, title, author, price;
// The program sorts the books based on their price and prints data about them, as well as their total price.
class Book
{
    public byte id;
    public string title;
    public string author;
    public float price;
}

class Program
{
    static void Main()
    {
        // Prompt the user to write the books count.
        Console.Write("Book count: ");
        byte count = Byte.Parse(Console.ReadLine());

        List<Book> books = new List<Book>();

        // Show the user how to add books into his list.
        Console.WriteLine("Book: Title,Author,Price");

        // Create a variable to sum the prices.
        float priceSum = 0.0f;

        for (byte i = 0; i < count; i++)
        {
            // Prompt the user to input a new book for each iteration of the loop and add it to the list.
            Book tempBook = new Book();
            Console.Write($"> Book[{i + 1}]: ");
            var input = Console.ReadLine().Split(',');
            tempBook.id = (byte)(i + 1);
            tempBook.title = input[0];
            tempBook.author = input[1];
            tempBook.price = Single.Parse(input[2]);
            books.Add(tempBook);

            // Add the book's price to the total price.
            priceSum += tempBook.price;
        }

        // Sort the list based on the price field.
        books = books.OrderByDescending(val => val.price).ToList<Book>();

        // Printing the list.
        foreach (Book book in books)
        {
            Console.WriteLine($"{book.id} | {book.title} by {book.author} for {book.price}$");
        }
        Console.WriteLine("Total: {0:#.##}$", priceSum);
    }
}