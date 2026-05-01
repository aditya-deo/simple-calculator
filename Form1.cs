namespace Calculator
{
    public partial class Form1 : Form
    {
        private string SelectedOperator { get; set; }
        private decimal Operand1 { get; set; }
        private decimal Operand2 { get; set; }
        private int state { get; set; } 
        public Form1()
        {
            InitializeComponent();
            SelectedOperator = String.Empty;
            Operand1 = default(int);
            Operand2 = default(int);
            state = 1;
        }
        public void WriteNumber(Button button)
        {
            textBox1.Text = textBox1.Text + button.Text;
            switch (state)
            {
                case 0:
                    state = 1;
                    Operand1 = Convert.ToDecimal(textBox1.Text);
                    break;
                case 1:
                    state = 2;
                    Operand1 = Convert.ToDecimal(textBox1.Text);
                    break;
                case 2:
                    state = 2;
                    Operand1 = Convert.ToDecimal(textBox1.Text);
                    break;
                case 3:
                    state = 4;
                    Operand2 = Convert.ToDecimal(textBox1.Text);
                    break;
                case 4:
                    state = 4;
                    Operand2 = Convert.ToDecimal(textBox1.Text);
                    break;
                case 5:
                    state = 2;
                    Operand2 = default(int);
                    Operand1 = Convert.ToDecimal(textBox1.Text);
                    break;
            }
        }
        public void ClearInput(Object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        public void OperationButtonClick(Object sender, EventArgs e)
        {
            ClearInput(sender, e);
            SelectedOperator = ((Button)sender).Text;
            switch (state)
            {
                case 0:
                    state = 0;
                    break;
                case 1:
                    state = 0;
                    break;
                case 2:
                    state = 3;
                    break;
                case 3:
                    state = 0;
                    break;
                case 4:
                    state = 3;
                    Operand1 = Operate(SelectedOperator);
                    Operand2 = default(int);
                    break;
                case 5:
                    state = 3;
                    Operand2 = default(int);
                    break;
            }
        }
        public void NumButtonClick(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            WriteNumber(button);
        }

        public void EqualsToClick(Object sender, EventArgs e)
        {
            Operand1 = Operate(SelectedOperator);
            textBox1.Text = Convert.ToString(Operand1);
        }

        private decimal Operate(string operation)
        {
            switch (operation)
            {
                case "+":
                    return Operand1 + Operand2;
                case "-":
                    return Operand1 - Operand2;
                case "X":
                    return Operand1 * Operand2;
                case "/":
                    return Operand1 / Operand2;
                case "%":
                    return Operand1 / 100;
            }
            return 0;
        }
    }
}
