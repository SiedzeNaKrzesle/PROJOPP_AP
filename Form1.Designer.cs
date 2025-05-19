namespace PROJOP_AP
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox ekran;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.ListBox historia;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ekran = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.historia = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ekran
            // 
            this.ekran.Dock = System.Windows.Forms.DockStyle.Top;
            this.ekran.Font = new System.Drawing.Font("Consolas", 28F);
            this.ekran.Location = new System.Drawing.Point(0, 0);
            this.ekran.Name = "ekran";
            this.ekran.ReadOnly = true;
            this.ekran.Size = new System.Drawing.Size(700, 62);
            this.ekran.TabIndex = 0;
            this.ekran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel
            // 
            this.panel.ColumnCount = 4;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panel.Location = new System.Drawing.Point(10, 65);
            this.panel.Name = "panel";
            this.panel.RowCount = 6;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.panel.Size = new System.Drawing.Size(380, 540);
            this.panel.TabIndex = 1;
            // 
            // historia
            // 
            this.historia.FormattingEnabled = true;
            this.historia.ItemHeight = 28;
            this.historia.Location = new System.Drawing.Point(410, 65);
            this.historia.Name = "historia";
            this.historia.Size = new System.Drawing.Size(270, 540);
            this.historia.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(700, 620);
            this.Controls.Add(this.historia);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ekran);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Kalkulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
