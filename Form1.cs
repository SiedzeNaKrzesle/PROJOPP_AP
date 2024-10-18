namespace PROJOP_AP
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        double result = 0;
        string operation = "";
        bool operationPending = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ekran_TextChanged(object sender, EventArgs e)
        {

        }


        private void guzik1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik3_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik4_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik6_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik7_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik8_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik9_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void guzik0_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void Evaluate()
        {
            if (operationPending)
            {
                double secondNum = double.Parse(currentInput);

                switch (operation)
                {
                    case "+": 
                        result += secondNum; 
                        break;

                    case "-":
                        result -= secondNum;
                        break;

                    case "*":
                        result *= secondNum;
                        break;

                    case ":":
                    
                        if (secondNum != 0)
                        {
                            result /= secondNum;
                        }
                        else
                        {
                            ekran.Text = "B³¹d";
                            return;
                        }
                        break;

                    case "/":
                        if (secondNum != 0)
                        {
                            result /= secondNum;
                        }
                        else
                        {
                            ekran.Text = "B³¹d";
                            return;
                        }
                        break;


                }

                ekran.Text = result.ToString();
                currentInput = "";
                operationPending = false;





            }


        }
        private void sigma_plus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }
            
        private void sigma_razy_Click(object sender, EventArgs e) //metoda od mno¿enia
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void sigma_minus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void sigma_dziel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void sigma_rowna_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), ekran.Text);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            double result = double.Parse((string)row["expression"]);

            ekran.Text = result.ToString();
        }

        private void wyczysc_Click(object sender, EventArgs e)
        {
            currentInput = "";
            result = 0;
            operation = "";
            operationPending = false;
            ekran.Text = "";
        }
    }
}
