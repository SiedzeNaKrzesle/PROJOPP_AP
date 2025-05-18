// Form1.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

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
            InitializeButtons(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            ekran.BackColor = Color.Black;
            ekran.ForeColor = Color.Lime;
            ekran.Font = new Font("Consolas", 28);
            ekran.Text = "0";
            ekran.Width = 360;

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

        private void InitializeButtons()
        {
            Button[] cyfry = new Button[10];
            // cyfry 1-9
            int num = 1;
            for (int row = 2; row >= 0; row--)
            {
                for (int col = 0; col < 3; col++)
                {
                    cyfry[num] = new Button();
                    cyfry[num].Text = num.ToString();
                    cyfry[num].Dock = DockStyle.Fill;
                    cyfry[num].Click += Cyfra_Click;
                    panel.Controls.Add(cyfry[num], col, row);
                    num++;
                }
            }
            // cyfra 0
            cyfry[0] = new Button();
            cyfry[0].Text = "0";
            cyfry[0].Dock = DockStyle.Fill;
            cyfry[0].Click += Cyfra_Click;
            panel.Controls.Add(cyfry[0], 1, 3);

            // przecinek
            Button przecinek = new Button();
            przecinek.Text = ".";
            przecinek.Dock = DockStyle.Fill;
            przecinek.Click += Cyfra_Click;
            panel.Controls.Add(przecinek, 2, 3);

            // negacja
            Button negacja = new Button();
            negacja.Text = "±";
            negacja.Dock = DockStyle.Fill;
            negacja.Click += Operator_Click;
            panel.Controls.Add(negacja, 0, 3);

            // operatory
            var ops = new[] {
                new {Btn = new Button(), Pos = (3,0), Text = "+"},
                new {Btn = new Button(), Pos = (3,1), Text = "-"},
                new {Btn = new Button(), Pos = (3,2), Text = "*"},
                new {Btn = new Button(), Pos = (3,3), Text = "/"},
                new {Btn = new Button(), Pos = (2,4), Text = "="},
                new {Btn = new Button(), Pos = (0,4), Text = "C"},
                new {Btn = new Button(), Pos = (1,4), Text = "√"}
            };
            foreach (var op in ops)
            {
                op.Btn.Text = op.Text;
                op.Btn.Dock = DockStyle.Fill;
                op.Btn.Click += Operator_Click;
                panel.Controls.Add(op.Btn, op.Pos.Item1, op.Pos.Item2);
                if (op.Text == "=") panel.SetColumnSpan(op.Btn, 2);
            }
        }

        private void Cyfra_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string input = button.Text;

            if (input == "." && currentInput.Contains(".")) return;
            currentInput += input;
            ekran.Text = currentInput;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
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
            if (op == "±")
            {
                if (!string.IsNullOrEmpty(currentInput) && double.TryParse(currentInput, out double neg))
                {
                    neg = -neg;
                    currentInput = neg.ToString();
                    ekran.Text = currentInput;
                }
                return;
            }
            if (op == "=") { Evaluate(); return; }
            if (op == "√")
            {
                if (double.TryParse(currentInput, out double val))
                {
                    result = Math.Sqrt(val);
                    ekran.Text = result.ToString();
                    currentInput = result.ToString();
                }
                return;
            }
            if (op == "1/x")
            {
                if (double.TryParse(currentInput, out double val) && val != 0)
                {
                    result = 1 / val;
                    ekran.Text = result.ToString();
                    currentInput = result.ToString();
                }
                else ekran.Text = "Błąd";
                return;
            }
            if (!string.IsNullOrEmpty(currentInput))
            {
                result = double.Parse(currentInput, CultureInfo.InvariantCulture);
                currentInput = "";
                operation = op;
                operationPending = true;
                ekran.Text = "";
            }
        }

        private void Evaluate()
        {
            if (!operationPending || string.IsNullOrEmpty(currentInput)) return;
            double secondNum = double.Parse(currentInput, CultureInfo.InvariantCulture);
            switch (operation)
            {
                case "+": result += secondNum; break;
                case "-": result -= secondNum; break;
                case "*": result *= secondNum; break;
                case "/": result = secondNum != 0 ? result / secondNum : double.NaN; break;
            }
            ekran.Text = result.ToString();
            currentInput = "";
            operationPending = false;
        }
    }
}
