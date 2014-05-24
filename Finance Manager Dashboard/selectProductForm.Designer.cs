namespace Trexis.Finance.Manager
{
    partial class selectProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectProductForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.labelVat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.labelExist = new System.Windows.Forms.Label();
            this.labelSubTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelGrandTotal);
            this.groupBox2.Controls.Add(this.labelVat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxProducts);
            this.groupBox2.Controls.Add(this.labelExist);
            this.groupBox2.Controls.Add(this.labelSubTotal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxQuantity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxPrice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 179);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.AutoSize = true;
            this.labelGrandTotal.Location = new System.Drawing.Point(89, 154);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(28, 13);
            this.labelGrandTotal.TabIndex = 20;
            this.labelGrandTotal.Text = "0.00";
            // 
            // labelVat
            // 
            this.labelVat.AutoSize = true;
            this.labelVat.Location = new System.Drawing.Point(89, 130);
            this.labelVat.Name = "labelVat";
            this.labelVat.Size = new System.Drawing.Size(28, 13);
            this.labelVat.TabIndex = 19;
            this.labelVat.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Vat:";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(89, 15);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(234, 21);
            this.comboBoxProducts.Sorted = true;
            this.comboBoxProducts.TabIndex = 2;
            this.comboBoxProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            this.comboBoxProducts.TextChanged += new System.EventHandler(this.comboBoxProducts_TextChanged);
            // 
            // labelExist
            // 
            this.labelExist.AutoSize = true;
            this.labelExist.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelExist.Location = new System.Drawing.Point(329, 15);
            this.labelExist.Name = "labelExist";
            this.labelExist.Size = new System.Drawing.Size(21, 18);
            this.labelExist.TabIndex = 16;
            this.labelExist.Text = "a";
            this.labelExist.Visible = false;
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(89, 104);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(28, 13);
            this.labelSubTotal.TabIndex = 5;
            this.labelSubTotal.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sub Total:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(89, 74);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(166, 20);
            this.textBoxQuantity.TabIndex = 4;
            this.textBoxQuantity.Text = "1";
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Quantity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Price:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(89, 43);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(166, 20);
            this.textBoxPrice.TabIndex = 3;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxPrice_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(288, 198);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(207, 198);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Ok";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // selectProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 230);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "selectProductForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Product [*productname*]";
            this.Load += new System.EventHandler(this.selectproduct_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelSubTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelExist;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label labelGrandTotal;
        private System.Windows.Forms.Label labelVat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}