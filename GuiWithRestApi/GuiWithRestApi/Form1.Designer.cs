namespace GuiWithRestApi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnLoad = new System.Windows.Forms.Button();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblSelectedId = new System.Windows.Forms.Label();
            this.lblSelectedTitle = new System.Windows.Forms.Label();
            this.txtSelectedBody = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(160, 35);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Завантажити публікації";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.Location = new System.Drawing.Point(12, 60);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(320, 368);
            this.listBoxPosts.TabIndex = 1;
            this.listBoxPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxPosts_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(350, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Статус: ";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(350, 60);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(117, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Отримано публікацій: 0";
            // 
            // lblSelectedId
            // 
            this.lblSelectedId.AutoSize = true;
            this.lblSelectedId.Location = new System.Drawing.Point(350, 95);
            this.lblSelectedId.Name = "lblSelectedId";
            this.lblSelectedId.Size = new System.Drawing.Size(21, 13);
            this.lblSelectedId.TabIndex = 4;
            this.lblSelectedId.Text = "ID:";
            // 
            // lblSelectedTitle
            // 
            this.lblSelectedTitle.AutoSize = true;
            this.lblSelectedTitle.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblSelectedTitle.Name = "lblSelectedTitle";
            this.lblSelectedTitle.Size = new System.Drawing.Size(65, 13);
            this.lblSelectedTitle.TabIndex = 5;
            this.lblSelectedTitle.Text = "Заголовок:";
            // 
            // txtSelectedBody
            // 
            this.txtSelectedBody.Location = new System.Drawing.Point(350, 150);
            this.txtSelectedBody.Multiline = true;
            this.txtSelectedBody.Name = "txtSelectedBody";
            this.txtSelectedBody.ReadOnly = true;
            this.txtSelectedBody.Size = new System.Drawing.Size(420, 278);
            this.txtSelectedBody.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSelectedBody);
            this.Controls.Add(this.lblSelectedTitle);
            this.Controls.Add(this.lblSelectedId);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBoxPosts);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Перегляд публікацій";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblSelectedId;
        private System.Windows.Forms.Label lblSelectedTitle;
        private System.Windows.Forms.TextBox txtSelectedBody;
    }
}