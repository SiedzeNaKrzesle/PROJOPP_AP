// Form1.Designer.cs
namespace PROJOP_AP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ekran = new TextBox();
            panel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // ekran
            // 
            ekran.Dock = DockStyle.Top;
            ekran.Font = new Font("Consolas", 28F);
            ekran.Location = new Point(0, 0);
            ekran.Margin = new Padding(3, 4, 3, 4);
            ekran.Name = "ekran";
            ekran.ReadOnly = true;
            ekran.Size = new Size(400, 62);
            ekran.TabIndex = 0;
            ekran.TextAlign = HorizontalAlignment.Right;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.None;
            panel.ColumnCount = 4;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel.Location = new Point(10, 65);
            panel.Margin = new Padding(10, 12, 10, 12);
            panel.Name = "panel";
            panel.Padding = new Padding(10, 12, 10, 12);
            panel.RowCount = 5;
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.Size = new Size(380, 494);
            panel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 559);
            Controls.Add(ekran);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Kalkulator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox ekran;
        private System.Windows.Forms.TableLayoutPanel panel;
    }
}

// Note: All dynamic button creation and configuration should be done in Form1.cs (outside InitializeComponent).
