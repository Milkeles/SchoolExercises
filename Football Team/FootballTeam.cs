#pragma warning disable CS8600, CS8602, CS8604, CS8618 // Suppress unnecessary warnings.

// Custom exceptions. Not necessary, but I did it to avoid repetition and mistakes.
class InvalidNameException : Exception
{
    public override string Message
    {
        get { return "A name should not be empty."; }
    }
}

class InvalidTeamException : Exception
{
    public InvalidTeamException (string teamName) : base(String.Format($"Team {teamName} does not exist")) { }
}

class Player
{
    private string name;
    private byte endurance, sprint, dribble, shoot, pass; // Private stats.
    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new InvalidNameException();
            this.name = value;
        }
    }

    // Public stats. Should not be changeable.
    public float AverageStats
    {
        get { return CalculateStats(); }
    }

    // Constructor.
    public Player(string name, byte endurance, byte sprint, byte dribble, byte pass, byte shoot)
    {
        Name = name;

        // Validation
        if (endurance < 0 || endurance > 100) throw new ArgumentException("Endurance should be between 0 and 100.");
        if (sprint < 0 || sprint > 100) throw new ArgumentException("Sprint should be between 0 and 100.");
        if (dribble < 0 || dribble > 100) throw new ArgumentException("Dribble should be between 0 and 100.");
        if (pass < 0 || pass > 100) throw new ArgumentException("Pass should be between 0 and 100.");
        if (shoot < 0 || shoot > 100) throw new ArgumentException("Shoot should be between 0 and 100.");

        this.endurance = endurance;
        this.sprint = sprint;
        this.dribble = dribble;
        this.pass = pass;
        this.shoot = shoot;
    }

    private float CalculateStats()
    {
        return (float)Math.Round((endurance + sprint + dribble + shoot + pass) / 5.0f, 2);
    }
}


class Team
{
    public List<Player> Players = new List<Player>();

    // This data should not be changeable, therefore we do not use set.
    public double Rating
    {
        get { return CalculateRating(); }
    }

    public double CalculateRating()
    {
        double rating = 0.0f;
        foreach (Player plr in Players)
        {
            rating += plr.AverageStats;
        }

        // Avoiding NaN output (Division with 0 when the player count is 0).
        if (Double.IsNaN(Math.Round(rating / Players.Count, 2))) rating = 0.0;
        else rating = Math.Round(rating / Players.Count, 2); 

        return rating;
    }

}

class Program
{
    public static void Main()
    {
        // For better time complexity, we'll use dictionary O(1) instead of checking whether a list contains certain team O(n).
        // This will not take up more space either.
        Dictionary<string, Team> teams = new Dictionary<string, Team>();

        string input = string.Empty;

        while ((input = Console.ReadLine()).ToUpper() != "END")
        {
            try
            {
                string[] data = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string teamName = data[1];

                // Checking all possible commands.
                switch (command)
                {
                    case "Team":
                        if (String.IsNullOrEmpty(data[0].Trim())) throw new InvalidNameException();

                        if (!teams.ContainsKey(teamName))
                        {
                            teams.Add(teamName, new Team());
                        }
                        break;

                    case "Add":
                        if (teams.ContainsKey(teamName))
                        {
                            Player newPlayer = new Player(data[2], Byte.Parse(data[3]), Byte.Parse(data[4]), Byte.Parse(data[5]),
                                                         Byte.Parse(data[6]), Byte.Parse(data[7]));
                            teams[teamName].Players.Add(newPlayer);
                        }
                        else throw new InvalidTeamException(teamName);
                        break;

                    case "Remove":
                        if (teams.ContainsKey(teamName))
                        {
                            if (teams[teamName].Players.Any(plr => plr.Name == data[2]))
                            {
                                Player playerToRemove = teams[teamName].Players.FirstOrDefault(plr => plr.Name == data[2]);
                                teams[teamName].Players.Remove(playerToRemove);
                            }
                            else throw new ArgumentException($"Player {data[2]} is not in {teamName} team.");
                        }
                        else throw new InvalidTeamException(teamName);
                        break;

                    case "Rating":
                        if (teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                        }
                        else throw new InvalidTeamException(teamName);
                        break;

                    default:
                        throw new ArgumentException("Invalid Command. Please use: Team, Add, Remove, or Rating!");
                }
            }
            catch(Exception ex)
            {
                // Printing the message in red because it looks better. Not necessary.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}