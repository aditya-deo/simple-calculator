namespace Calculator
{
    public partial class Form1 : Form
    {
        private string CurrentSelectedOperation { get; set; }
        private string Operand1 { get; set; }
        private string Operand2 { get; set; }
        public Form1()
        {
            InitializeComponent();
            CurrentSelectedOperation = String.Empty;
            Operand1 = String.Empty;
            Operand2 = String.Empty;
        }
        public void WriteNumber(Button button)
        {
            textBox1.Text = textBox1.Text + button.Text;
            if (String.IsNullOrEmpty(CurrentSelectedOperation))
            {
                Operand1 = textBox1.Text;
            }
            else
            {
                Operand2 = textBox1.Text;
            }
        }
        public void ClearInput(Object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        public void OperationButtonClick(Object sender, EventArgs e)
        {
            ClearInput(sender, e);
            string operation = ((Button)sender).Text;
            switch (operation)
            {
                case "+":
                    CurrentSelectedOperation = "Add";
                    break;
                case "-":
                    CurrentSelectedOperation = "Subtract";
                    break;
                case "X":
                    CurrentSelectedOperation = "Multiply";
                    break;
                case "/":
                    CurrentSelectedOperation = "Divide";
                    break;
                case "%":
                    CurrentSelectedOperation = "Percentage";
                    break;
            }
            if (!String.IsNullOrEmpty(Operand2))
            {
                Operate();
            }
        }
        public void NumButtonClick(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            WriteNumber(button);
        }

        private void Operate()
        {
            switch (CurrentSelectedOperation)
            {
                case "Add":
                    Operand1 = Convert.ToString(Convert.ToDecimal(Operand1) + Convert.ToDecimal(Operand2));
                    break;
                case "Subtract":
                    Operand1 = Convert.ToString(Convert.ToDecimal(Operand1) - Convert.ToDecimal(Operand2));
                    break;
                case "Multiply":
                    Operand1 = Convert.ToString(Convert.ToDecimal(Operand1) * Convert.ToDecimal(Operand2));
                    break;
                case "Divide":
                    Operand1 = Convert.ToString(Convert.ToDecimal(Operand1) / Convert.ToDecimal(Operand2));
                    break;
                case "Percentage":
                    Operand1 = Convert.ToString(Convert.ToDecimal(Operand1) / Convert.ToDecimal(100));
                    break;
            }
        }

        public void PrintResult(Object sender, EventArgs e)
        {
            Operate();
            textBox1.Text = Operand1;
        }
    }
}
