// How to instantly run code for radio buttons from group boxes.
namespace InstantChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Create a new event that runs a function
            radioButton1.CheckedChanged += new EventHandler(ChangeColorButtons);
            radioButton2.CheckedChanged += new EventHandler(ChangeColorButtons);
        }

        // a function with switch.
        private void ChangeColorButtons(object sender, EventArgs e)
        {
            // Get the button object
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Name)
            {
                case "radioButton1":
                    textBox1.BackColor = Color.Red;
                    break;
                case "radioButton2":
                    textBox1.BackColor = Color.Blue;
                    break;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            radioButton3.CheckedChanged += new EventHandler(ChangeTextColor);
            radioButton4.CheckedChanged += new EventHandler(ChangeTextColor);
        }
        
        // Function with if.
        private void ChangeTextColor(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox1.ForeColor = Color.White;
            }
            if (radioButton4.Checked)
            {
                textBox1.ForeColor = Color.Black;
            }
        }
    }
}
