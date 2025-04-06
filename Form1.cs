using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJOP_AP
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        string operation = "";
        bool operationPending = false;
        double result = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            ekran.BackColor = Color.Black;
            ekran.ForeColor = Color.Lime;
            ekran.Font = new Font("Consolas", 24);
            ekran.Text = "0";

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(50, 50, 50);
                    btn.ForeColor = Color.DeepSkyBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 22, FontStyle.Bold);
                    btn.Margin = new Padding(5);
                }
            }
        }

        private void Cyfra_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            ekran.Text = currentInput;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string op = button.Text;

            if (op == "C")
            {
                currentInput = "";
                result = 0;
                operation = "";
                operationPending = false;
                ekran.Text = "0";
                return;
            }

            if (op == "=")
            {
                Evaluate();
                return;
            }

            if (!string.IsNullOrEmpty(currentInput))
            {
                result = double.Parse(currentInput);
                currentInput = "";
                operation = op;
                operationPending = true;
                ekran.Text = "";
            }
        }

        private void Evaluate()
        {
            if (operationPending && !string.IsNullOrEmpty(currentInput))
            {
                double secondNum = double.Parse(currentInput);

                switch (operation)
                {
                    case "+": result += secondNum; break;
                    case "-": result -= secondNum; break;
                    case "*": result *= secondNum; break;
                    case "/":
                        if (secondNum != 0)
                        {
                            result /= secondNum;
                        }
                        else
                        {
                            ekran.Text = "Błąd";
                            return;
                        }
                        break;
                }

                ekran.Text = result.ToString();
                currentInput = "";
                operationPending = false;
            }
        }
    }
}