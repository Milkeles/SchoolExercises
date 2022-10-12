// This exercise is old! 

char[,] matrix = new char[3, 3];
bool xTurn = false;

//Vuvejdane i generirane na poleta
Console.WriteLine("Input the board: ");
for (byte i = 0; i < 3; i++)
{
    string line = Console.ReadLine();
    string[] splitLine = line.Split(' ');
    if (splitLine.Length != 3)
    {
        Console.WriteLine("Invalid input!");
        break;
    }
    else
    {
        for (byte j = 0; j < 3; j++)
        {
            matrix[i, j] = Char.Parse(splitLine[j]);
            if (matrix[i, j] == '-' && xTurn == false)
            {
                xTurn = true;
                matrix[i, j] = 'O';
            }
            else if (matrix[i, j] == '-' && xTurn == true)
            {
                xTurn = false;
                matrix[i, j] = 'X';
            }
        }
    }
}

//Presmqtane na pobeditel.
Console.WriteLine();

string Winner = "Nobody";
char hor = '-', ver = '-', d1 = '-', d2 = '-';
bool f1 = false, f2 = false, f3 = false, f4 = false;
for (byte i = 0; i < 3; i++)
{
    for (byte j = 0; j < 3; j++)
    {
        Console.Write(matrix[i, j] + " ");
        if (hor == '-' && ver == '-')
        {
            hor = matrix[i, j];
            ver = matrix[j, i];
            d1 = matrix[i, i];
            d2 = matrix[2 - i, 2 - i];
        }
        if (i != 0 && matrix[j, i] != ver) f1 = true;
        if (j != 0 && matrix[i, j] != hor) f2 = true;
    }
    if (i != 0 && matrix[i, i] != d1) f3 = true;
    if ((byte)(2 - i) != 2 && matrix[2 - i, 2 - i] != d2) f4 = true;
    if (i == 2)
    {
        if (f1 == false) Winner = hor.ToString();
        if (f2 == false) Winner = ver.ToString();
        if (f3 == false) Winner = d1.ToString();
        if (f4 == false) Winner = d2.ToString();
    }
    Console.WriteLine();
}
Console.WriteLine("Winner: " + Winner);
