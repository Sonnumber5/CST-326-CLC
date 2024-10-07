namespace ApplicationUI
{
    partial class MainForm
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
            btn_addCategory = new Button();
            treeView_categories = new TreeView();
            btn_addExpense = new Button();
            btn_income = new Button();
            SuspendLayout();
            // 
            // btn_addCategory
            // 
            btn_addCategory.BackColor = Color.DeepSkyBlue;
            btn_addCategory.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_addCategory.ForeColor = Color.White;
            btn_addCategory.Location = new Point(669, 25);
            btn_addCategory.Name = "btn_addCategory";
            btn_addCategory.Size = new Size(209, 57);
            btn_addCategory.TabIndex = 2;
            btn_addCategory.Text = "Add Category";
            btn_addCategory.UseVisualStyleBackColor = false;
            btn_addCategory.Click += btn_addCategory_Click;
            // 
            // treeView_categories
            // 
            treeView_categories.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeView_categories.Font = new Font("Lucida Console", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView_categories.ForeColor = Color.Gray;
            treeView_categories.LineColor = Color.DarkGray;
            treeView_categories.Location = new Point(36, 495);
            treeView_categories.Name = "treeView_categories";
            treeView_categories.Size = new Size(905, 500);
            treeView_categories.TabIndex = 3;
            treeView_categories.DrawNode += treeView_categories_DrawNode;
            // 
            // btn_addExpense
            // 
            btn_addExpense.BackColor = Color.DeepSkyBlue;
            btn_addExpense.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_addExpense.ForeColor = Color.White;
            btn_addExpense.Location = new Point(884, 25);
            btn_addExpense.Name = "btn_addExpense";
            btn_addExpense.Size = new Size(57, 57);
            btn_addExpense.TabIndex = 4;
            btn_addExpense.Text = "+";
            btn_addExpense.UseVisualStyleBackColor = false;
            btn_addExpense.Click += btn_addExpense_Click;
            // 
            // btn_income
            // 
            btn_income.BackColor = Color.DeepSkyBlue;
            btn_income.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_income.ForeColor = Color.White;
            btn_income.Location = new Point(457, 23);
            btn_income.Name = "btn_income";
            btn_income.Size = new Size(206, 57);
            btn_income.TabIndex = 5;
            btn_income.Text = "Add Income";
            btn_income.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(979, 1032);
            Controls.Add(btn_income);
            Controls.Add(btn_addExpense);
            Controls.Add(treeView_categories);
            Controls.Add(btn_addCategory);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Button btn_addCategory;
        private TreeView treeView_categories;
        private Button btn_addExpense;
        private Button btn_income;
    }
}
