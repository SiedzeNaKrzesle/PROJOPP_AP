// Form1.Designer.cs
namespace PROJOP_AP
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox ekran;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.Button[] cyfry = new System.Windows.Forms.Button[10];
        private System.Windows.Forms.Button plus, minus, razy, dziel, rowna, clear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ekran = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.TableLayoutPanel();

            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.razy = new System.Windows.Forms.Button();
            this.dziel = new System.Windows.Forms.Button();
            this.rowna = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Name = "Form1";
            this.Text = "Kalkulator";
            this.Load += new System.EventHandler(this.Form1_Load);

            // ekran
            this.ekran.Dock = System.Windows.Forms.DockStyle.Top;
            this.ekran.Font = new System.Drawing.Font("Consolas", 28F);
            this.ekran.ReadOnly = true;
            this.ekran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ekran.Height = 80;
            this.Controls.Add(this.ekran);

            // panel
            this.panel.ColumnCount = 4;
            this.panel.RowCount = 5;
            this.panel.Dock = System.Windows.Forms.DockStyle.None;
            this.panel.Location = new System.Drawing.Point(10, 100); // przesunięcie w dół
            this.panel.Size = new System.Drawing.Size(380, 480);
            this.panel.Padding = new Padding(10);
            this.panel.Margin = new Padding(10);
            for (int i = 0; i < 4; i++)
                this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            for (int i = 0; i < 5; i++)
                this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Controls.Add(this.panel);

            // cyfry 1-9
            int num = 1;
            for (int row = 2; row >= 0; row--)
            {
                for (int col = 0; col < 3; col++)
                {
                    cyfry[num] = new System.Windows.Forms.Button();
                    cyfry[num].Text = num.ToString();
                    cyfry[num].Dock = DockStyle.Fill;
                    cyfry[num].Click += new System.EventHandler(this.Cyfra_Click);
                    this.panel.Controls.Add(cyfry[num], col, row);
                    num++;
                }
            }


            cyfry[0] = new System.Windows.Forms.Button();
            cyfry[0].Text = "0";
            cyfry[0].Dock = DockStyle.Fill;
            cyfry[0].Click += new System.EventHandler(this.Cyfra_Click);
            this.panel.Controls.Add(cyfry[0], 1, 3);


            plus.Text = "+";
            minus.Text = "-";
            razy.Text = "*";
            dziel.Text = "/";
            rowna.Text = "=";
            clear.Text = "C";

            Button[] operatory = { plus, minus, razy, dziel, rowna, clear };
            foreach (Button op in operatory)
            {
                op.Dock = DockStyle.Fill;
                op.Click += new System.EventHandler(this.Operator_Click);
            }

            this.panel.Controls.Add(plus, 3, 0);
            this.panel.Controls.Add(minus, 3, 1);
            this.panel.Controls.Add(razy, 3, 2);
            this.panel.Controls.Add(dziel, 3, 3);
            this.panel.Controls.Add(rowna, 2, 3);
            this.panel.Controls.Add(clear, 0, 3);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}