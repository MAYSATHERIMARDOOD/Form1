using System;
using System.Windows.Forms;

namespace OkulKantinApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbUsers;
        private ComboBox cmbProducts;
        private Button btnSale;
        private ListBox lstTransactions;

        private void InitializeComponent()
        {
            this.cmbUsers = new ComboBox();
            this.cmbProducts = new ComboBox();
            this.btnSale = new Button();
            this.lstTransactions = new ListBox();
            this.SuspendLayout();

            // cmbUsers
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(50, 50);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(300, 30);

            // cmbProducts
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(50, 100);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(300, 30);

            // btnSale
            this.btnSale.Location = new System.Drawing.Point(50, 150);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(150, 40);
            this.btnSale.Text = "Satış Yap";
            this.btnSale.Click += new EventHandler(this.btnSale_Click);

            // lstTransactions
            this.lstTransactions.Location = new System.Drawing.Point(50, 200);
            this.lstTransactions.Name = "lstTransactions";
            this.lstTransactions.Size = new System.Drawing.Size(400, 150);

            // Form1
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.lstTransactions);
            this.Name = "Form1";
            this.Text = "Okul Kantini";
            this.Load += new EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
    }
}
