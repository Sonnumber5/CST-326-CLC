namespace ApplicationUI
{
    partial class AddCategoryForm
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
            btn_addCategory = new Button();
            label1 = new Label();
            tb_categoryName = new TextBox();
            SuspendLayout();
            // 
            // btn_addCategory
            // 
            btn_addCategory.BackColor = Color.DeepSkyBlue;
            btn_addCategory.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_addCategory.ForeColor = Color.White;
            btn_addCategory.Location = new Point(304, 408);
            btn_addCategory.Name = "btn_addCategory";
            btn_addCategory.Size = new Size(268, 85);
            btn_addCategory.TabIndex = 0;
            btn_addCategory.Text = "Add Category";
            btn_addCategory.UseVisualStyleBackColor = false;
            btn_addCategory.Click += btn_addCategory_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Console", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(320, 222);
            label1.Name = "label1";
            label1.Size = new Size(236, 27);
            label1.TabIndex = 1;
            label1.Text = "Add A Category";
            // 
            // tb_categoryName
            // 
            tb_categoryName.BackColor = SystemColors.InactiveBorder;
            tb_categoryName.Location = new Point(255, 308);
            tb_categoryName.Name = "tb_categoryName";
            tb_categoryName.Size = new Size(367, 39);
            tb_categoryName.TabIndex = 2;
            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 729);
            Controls.Add(tb_categoryName);
            Controls.Add(label1);
            Controls.Add(btn_addCategory);
            Name = "AddCategoryForm";
            Text = "AddCategoryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_addCategory;
        private Label label1;
        private TextBox tb_categoryName;
    }
}