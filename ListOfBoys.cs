// Create a forms application that reads the names of all boys in a database and prints them on a text label.

using MySql.Data.MySqlClient;

namespace ConnectingToSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection("server=localhost;database=datastore;uid=root;pwd=\"\";"))
            {
                using (var command = connection.CreateCommand())
                {
                    // Select all boys
                    command.CommandText = @"SELECT name FROM studentdata WHERE gender = 'M';";
                    // Open connection.
                    connection.Open();
                    
                    using (var reader = command.ExecuteReader())
                    {
                        // Print all boys
                        var indexOfColumn1 = reader.GetOrdinal("name");
                        string text = "The boys:\n";
                        while (reader.Read())
                        {
                            text += (string)reader.GetValue(indexOfColumn1) + " ";
                        }
                        label1.Text = text;
                    }

                    connection.Close();

                }
            }
        }
    }
}
