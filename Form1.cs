using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PROJOP_AP
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        string lastNegatedInner = null;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(30, 30, 30);

            ekran.BackColor = Color.Black;
            ekran.ForeColor = Color.Lime;
            ekran.Font = new Font("Consolas", 28);
            ekran.Text = "0";
            ekran.Width = 360;

            historia.BackColor = Color.FromArgb(20, 20, 20);
            historia.ForeColor = Color.LightGray;
            historia.Font = new Font("Consolas", 14);
            historia.BorderStyle = BorderStyle.None;

            foreach (Control c in panel.Controls)
                if (c is Button btn)
                {
                    btn.BackColor = Color.FromArgb(50, 50, 50);
                    btn.ForeColor = Color.DeepSkyBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 22, FontStyle.Bold);
                    btn.Margin = new Padding(5);
                }
        }

        private void InitializeButtons()
        {
            // cyfry 1-9
            Button[] cyfry = new Button[10];
            int num = 1;
            for (int r = 2; r >= 0; r--)
                for (int c = 0; c < 3; c++)
                {
                    cyfry[num] = new Button { Text = num.ToString(), Dock = DockStyle.Fill };
                    cyfry[num].Click += Cyfra_Click;
                    panel.Controls.Add(cyfry[num], c, r);
                    num++;
                }

            // cyfra 0
            cyfry[0] = new Button { Text = "0", Dock = DockStyle.Fill };
            cyfry[0].Click += Cyfra_Click;
            panel.Controls.Add(cyfry[0], 1, 3);

            // przecinek
            var przecinek = new Button { Text = ".", Dock = DockStyle.Fill };
            przecinek.Click += Cyfra_Click;
            panel.Controls.Add(przecinek, 2, 3);

            // negacja
            var negacja = new Button { Text = "±", Dock = DockStyle.Fill };
            negacja.Click += Negacja_Click;
            panel.Controls.Add(negacja, 0, 3);

            // nawiasy obok siebie
            var o = new Button { Text = "(", Dock = DockStyle.Fill };
            o.Click += Cyfra_Click;
            panel.Controls.Add(o, 0, 5);

            var z = new Button { Text = ")", Dock = DockStyle.Fill };
            z.Click += Cyfra_Click;
            panel.Controls.Add(z, 1, 5);

            // quiz (zajmuje dwie kolumny)
            var quiz = new Button { Text = "Quiz", Dock = DockStyle.Fill };
            quiz.Click += Quiz_Click;
            panel.Controls.Add(quiz, 2, 5);
            panel.SetColumnSpan(quiz, 2);

            // operatory
            var ops = new[]
            {
                new {B=new Button(),Col=3,Row=0,T="+"},
                new {B=new Button(),Col=3,Row=1,T="-"},
                new {B=new Button(),Col=3,Row=2,T="*"},
                new {B=new Button(),Col=3,Row=3,T="/"},
                new {B=new Button(),Col=0,Row=4,T="C"},
                new {B=new Button(),Col=1,Row=4,T="√"},
                new {B=new Button(),Col=2,Row=4,T="="}
            };
            foreach (var op in ops)
            {
                op.B.Text = op.T;
                op.B.Dock = DockStyle.Fill;
                op.B.Click += Operator_Click;
                panel.Controls.Add(op.B, op.Col, op.Row);
                if (op.T == "=") panel.SetColumnSpan(op.B, 2);
            }
        }

        private void Cyfra_Click(object s, EventArgs e)
        {
            var t = (s as Button).Text;
            if (t == "." && currentInput.Contains(".")) return;
            currentInput += t;
            ekran.Text = currentInput;
        }

        private void Negacja_Click(object s, EventArgs e)
        {
            if (lastNegatedInner != null && currentInput == $"-({lastNegatedInner})")
            {
                currentInput = lastNegatedInner;
                lastNegatedInner = null;
            }
            else
            {
                lastNegatedInner = currentInput;
                currentInput = $"-({lastNegatedInner})";
            }
            ekran.Text = currentInput;
        }

        private void Operator_Click(object s, EventArgs e)
        {
            var t = (s as Button).Text;
            if (t == "C")
            {
                currentInput = "";
                ekran.Text = "0";
                lastNegatedInner = null;
                return;
            }
            if (t == "√")
            {
                Compute($"Sqrt({currentInput})");
                return;
            }
            if (t == "=")
            {
                Compute(currentInput);
                return;
            }
            currentInput += $" {t} ";
            ekran.Text = currentInput;
        }

        private void Quiz_Click(object s, EventArgs e)
        {
            var rnd = new Random();
            int a = rnd.Next(0, 101), b = rnd.Next(0, 101);
            string[] opArr = { "+", "-", "*", "/", "√" };
            string op = opArr[rnd.Next(opArr.Length)];
            string question;
            double answer;

            if (op == "√")
            {
                question = $"√{a}";
                answer = Math.Sqrt(a);
            }
            else
            {
                question = $"{a}{op}{b}";
                answer = op switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => b != 0 ? (double)a / b : double.NaN,
                    _ => 0
                };
            }

            string resp = Interaction.InputBox($"Quiz: {question}", "Quiz", "");
            if (double.TryParse(resp, NumberStyles.Float, CultureInfo.InvariantCulture, out double user))
            {
                string resText = Math.Abs(user - answer) < 1e-6 ? "Correct" : $"Wrong (ans={answer:F2})";
                MessageBox.Show(resText, "Quiz result");
                historia.Items.Insert(0, $"Quiz: {question} = {resp} → {resText}");
            }
        }

        private void Compute(string expr)
        {
            try
            {
                var dt = new DataTable { Locale = CultureInfo.InvariantCulture };
                var val = dt.Compute(expr, "");
                var s = Convert.ToString(val, CultureInfo.InvariantCulture);
                historia.Items.Insert(0, $"{expr} = {s}");
                currentInput = s;
                ekran.Text = s;
                lastNegatedInner = null;
            }
            catch
            {
                ekran.Text = "Error";
            }
        }
    }
}
