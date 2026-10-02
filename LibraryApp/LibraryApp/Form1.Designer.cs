namespace LibraryApp
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
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtYear = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvBooks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 285);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(157, 27);
            txtTitle.TabIndex = 0;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(331, 285);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(157, 27);
            txtAuthor.TabIndex = 1;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(635, 285);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(153, 27);
            txtYear.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Desktop;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = SystemColors.Window;
            btnAdd.Location = new Point(12, 354);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 46);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.Desktop;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnUpdate.ForeColor = SystemColors.Window;
            btnUpdate.Location = new Point(331, 354);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(125, 46);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Оновити";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.Desktop;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = SystemColors.Window;
            btnDelete.Location = new Point(663, 354);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(125, 46);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = SystemColors.Control;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(60, 12);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(669, 188);
            dgvBooks.TabIndex = 6;
            dgvBooks.CellClick += dgvBooks_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvBooks);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtYear);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvBooks;
    }
}
