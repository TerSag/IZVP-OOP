namespace DataBindingPractice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnDiscount = new Button();
            btnShowData = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 250);
            txtName.Name = "txtName";
            txtName.Size = new Size(155, 27);
            txtName.TabIndex = 0;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(324, 250);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(158, 27);
            txtPrice.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(628, 250);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(160, 27);
            txtQuantity.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(49, 219);
            label1.Name = "label1";
            label1.Size = new Size(66, 28);
            label1.TabIndex = 3;
            label1.Text = "Назва";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(379, 219);
            label2.Name = "label2";
            label2.Size = new Size(54, 28);
            label2.TabIndex = 4;
            label2.Text = "Ціна";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(666, 219);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 5;
            label3.Text = "Кількість";
            // 
            // btnDiscount
            // 
            btnDiscount.BackColor = SystemColors.ActiveCaption;
            btnDiscount.Location = new Point(49, 341);
            btnDiscount.Name = "btnDiscount";
            btnDiscount.Size = new Size(203, 61);
            btnDiscount.TabIndex = 6;
            btnDiscount.Text = "Зробити знижку 10% (Зміна з коду)";
            btnDiscount.UseVisualStyleBackColor = false;
            btnDiscount.Click += btnDiscount_Click;
            // 
            // btnShowData
            // 
            btnShowData.BackColor = SystemColors.ActiveCaption;
            btnShowData.Location = new Point(553, 341);
            btnShowData.Name = "btnShowData";
            btnShowData.Size = new Size(205, 61);
            btnShowData.TabIndex = 7;
            btnShowData.Text = "Показати стан об'єкта";
            btnShowData.UseVisualStyleBackColor = false;
            btnShowData.Click += btnShowData_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShowData);
            Controls.Add(btnDiscount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnDiscount;
        private Button btnShowData;
    }
}
