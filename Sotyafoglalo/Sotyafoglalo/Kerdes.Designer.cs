namespace Sotyafoglalo
{
    partial class Kerdes
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kerdesLabel = new System.Windows.Forms.Label();
            this.aValasz = new System.Windows.Forms.Label();
            this.bValasz = new System.Windows.Forms.Label();
            this.cValasz = new System.Windows.Forms.Label();
            this.dValasz = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dValasz, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cValasz, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.bValasz, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kerdesLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.aValasz, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 719);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kerdesLabel
            // 
            this.kerdesLabel.AutoSize = true;
            this.kerdesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kerdesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.kerdesLabel.Location = new System.Drawing.Point(3, 0);
            this.kerdesLabel.Name = "kerdesLabel";
            this.kerdesLabel.Size = new System.Drawing.Size(976, 230);
            this.kerdesLabel.TabIndex = 0;
            this.kerdesLabel.Text = "Kérdés";
            this.kerdesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aValasz
            // 
            this.aValasz.AutoSize = true;
            this.aValasz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aValasz.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.aValasz.Location = new System.Drawing.Point(3, 230);
            this.aValasz.Name = "aValasz";
            this.aValasz.Size = new System.Drawing.Size(976, 122);
            this.aValasz.TabIndex = 1;
            this.aValasz.Text = "A Válasz";
            this.aValasz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bValasz
            // 
            this.bValasz.AutoSize = true;
            this.bValasz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bValasz.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.bValasz.Location = new System.Drawing.Point(3, 352);
            this.bValasz.Name = "bValasz";
            this.bValasz.Size = new System.Drawing.Size(976, 122);
            this.bValasz.TabIndex = 2;
            this.bValasz.Text = "B Válasz";
            this.bValasz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cValasz
            // 
            this.cValasz.AutoSize = true;
            this.cValasz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cValasz.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.cValasz.Location = new System.Drawing.Point(3, 474);
            this.cValasz.Name = "cValasz";
            this.cValasz.Size = new System.Drawing.Size(976, 122);
            this.cValasz.TabIndex = 3;
            this.cValasz.Text = "C Válasz";
            this.cValasz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dValasz
            // 
            this.dValasz.AutoSize = true;
            this.dValasz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dValasz.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.dValasz.Location = new System.Drawing.Point(3, 596);
            this.dValasz.Name = "dValasz";
            this.dValasz.Size = new System.Drawing.Size(976, 123);
            this.dValasz.TabIndex = 4;
            this.dValasz.Text = "D Válasz";
            this.dValasz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Kerdes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 719);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Kerdes";
            this.Text = "Kérdés";
            this.Load += new System.EventHandler(this.Kerdes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label dValasz;
        private System.Windows.Forms.Label cValasz;
        private System.Windows.Forms.Label bValasz;
        private System.Windows.Forms.Label kerdesLabel;
        private System.Windows.Forms.Label aValasz;
    }
}