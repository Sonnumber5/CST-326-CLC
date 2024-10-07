namespace ApplicationUI
{
    partial class AddExpenseForm
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
            gb_name = new GroupBox();
            tb_name = new TextBox();
            btn_name = new Button();
            label1 = new Label();
            gb_price = new GroupBox();
            tb_price = new TextBox();
            btn_price = new Button();
            label2 = new Label();
            gb_category = new GroupBox();
            cb_categories = new ComboBox();
            btn_category = new Button();
            label3 = new Label();
            gb_date = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            btn_date = new Button();
            label4 = new Label();
            gb_description = new GroupBox();
            tb_description = new TextBox();
            btn_addItem = new Button();
            label5 = new Label();
            gb_name.SuspendLayout();
            gb_price.SuspendLayout();
            gb_category.SuspendLayout();
            gb_date.SuspendLayout();
            gb_description.SuspendLayout();
            SuspendLayout();
            // 
            // gb_name
            // 
            gb_name.BackColor = Color.White;
            gb_name.Controls.Add(tb_name);
            gb_name.Controls.Add(btn_name);
            gb_name.Controls.Add(label1);
            gb_name.Location = new Point(12, 12);
            gb_name.Name = "gb_name";
            gb_name.Size = new Size(706, 560);
            gb_name.TabIndex = 0;
            gb_name.TabStop = false;
            // 
            // tb_name
            // 
            tb_name.BackColor = SystemColors.InactiveBorder;
            tb_name.Location = new Point(171, 215);
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(367, 39);
            tb_name.TabIndex = 5;
            // 
            // btn_name
            // 
            btn_name.BackColor = Color.DeepSkyBlue;
            btn_name.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_name.ForeColor = Color.White;
            btn_name.Location = new Point(220, 315);
            btn_name.Name = "btn_name";
            btn_name.Size = new Size(268, 85);
            btn_name.TabIndex = 3;
            btn_name.Text = "Next";
            btn_name.UseVisualStyleBackColor = false;
            btn_name.Click += btn_name_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Console", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(180, 130);
            label1.Name = "label1";
            label1.Size = new Size(348, 27);
            label1.TabIndex = 4;
            label1.Text = "Enter An Expense Name";
            // 
            // gb_price
            // 
            gb_price.BackColor = Color.White;
            gb_price.Controls.Add(tb_price);
            gb_price.Controls.Add(btn_price);
            gb_price.Controls.Add(label2);
            gb_price.Location = new Point(12, 12);
            gb_price.Name = "gb_price";
            gb_price.Size = new Size(706, 560);
            gb_price.TabIndex = 6;
            gb_price.TabStop = false;
            // 
            // tb_price
            // 
            tb_price.BackColor = SystemColors.InactiveBorder;
            tb_price.Location = new Point(171, 215);
            tb_price.Name = "tb_price";
            tb_price.Size = new Size(367, 39);
            tb_price.TabIndex = 5;
            // 
            // btn_price
            // 
            btn_price.BackColor = Color.DeepSkyBlue;
            btn_price.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_price.ForeColor = Color.White;
            btn_price.Location = new Point(220, 315);
            btn_price.Name = "btn_price";
            btn_price.Size = new Size(268, 85);
            btn_price.TabIndex = 3;
            btn_price.Text = "Next";
            btn_price.UseVisualStyleBackColor = false;
            btn_price.Click += btn_price_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Console", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(228, 130);
            label2.Name = "label2";
            label2.Size = new Size(252, 27);
            label2.TabIndex = 4;
            label2.Text = "Enter The Price";
            // 
            // gb_category
            // 
            gb_category.BackColor = Color.White;
            gb_category.Controls.Add(cb_categories);
            gb_category.Controls.Add(btn_category);
            gb_category.Controls.Add(label3);
            gb_category.Location = new Point(12, 12);
            gb_category.Name = "gb_category";
            gb_category.Size = new Size(706, 560);
            gb_category.TabIndex = 7;
            gb_category.TabStop = false;
            // 
            // cb_categories
            // 
            cb_categories.FormattingEnabled = true;
            cb_categories.Location = new Point(233, 214);
            cb_categories.Name = "cb_categories";
            cb_categories.Size = new Size(242, 40);
            cb_categories.TabIndex = 5;
            // 
            // btn_category
            // 
            btn_category.BackColor = Color.DeepSkyBlue;
            btn_category.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_category.ForeColor = Color.White;
            btn_category.Location = new Point(220, 315);
            btn_category.Name = "btn_category";
            btn_category.Size = new Size(268, 85);
            btn_category.TabIndex = 3;
            btn_category.Text = "Next";
            btn_category.UseVisualStyleBackColor = false;
            btn_category.Click += btn_category_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(196, 130);
            label3.Name = "label3";
            label3.Size = new Size(316, 27);
            label3.TabIndex = 4;
            label3.Text = "Select The Category";
            // 
            // gb_date
            // 
            gb_date.BackColor = Color.White;
            gb_date.Controls.Add(dateTimePicker1);
            gb_date.Controls.Add(btn_date);
            gb_date.Controls.Add(label4);
            gb_date.Location = new Point(12, 12);
            gb_date.Name = "gb_date";
            gb_date.Size = new Size(706, 560);
            gb_date.TabIndex = 8;
            gb_date.TabStop = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(154, 215);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 39);
            dateTimePicker1.TabIndex = 6;
            // 
            // btn_date
            // 
            btn_date.BackColor = Color.DeepSkyBlue;
            btn_date.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_date.ForeColor = Color.White;
            btn_date.Location = new Point(220, 315);
            btn_date.Name = "btn_date";
            btn_date.Size = new Size(268, 85);
            btn_date.TabIndex = 3;
            btn_date.Text = "Next";
            btn_date.UseVisualStyleBackColor = false;
            btn_date.Click += btn_date_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(228, 130);
            label4.Name = "label4";
            label4.Size = new Size(252, 27);
            label4.TabIndex = 4;
            label4.Text = "Select The Date";
            // 
            // gb_description
            // 
            gb_description.BackColor = Color.White;
            gb_description.Controls.Add(tb_description);
            gb_description.Controls.Add(btn_addItem);
            gb_description.Controls.Add(label5);
            gb_description.Location = new Point(12, 12);
            gb_description.Name = "gb_description";
            gb_description.Size = new Size(706, 560);
            gb_description.TabIndex = 7;
            gb_description.TabStop = false;
            // 
            // tb_description
            // 
            tb_description.BackColor = SystemColors.InactiveBorder;
            tb_description.Location = new Point(171, 215);
            tb_description.Name = "tb_description";
            tb_description.Size = new Size(367, 39);
            tb_description.TabIndex = 5;
            // 
            // btn_addItem
            // 
            btn_addItem.BackColor = Color.DeepSkyBlue;
            btn_addItem.Font = new Font("Lucida Console", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_addItem.ForeColor = Color.White;
            btn_addItem.Location = new Point(220, 315);
            btn_addItem.Name = "btn_addItem";
            btn_addItem.Size = new Size(268, 85);
            btn_addItem.TabIndex = 3;
            btn_addItem.Text = "Add";
            btn_addItem.UseVisualStyleBackColor = false;
            btn_addItem.Click += btn_addItem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(180, 130);
            label5.Name = "label5";
            label5.Size = new Size(348, 27);
            label5.TabIndex = 4;
            label5.Text = "Enter The Description";
            // 
            // AddExpenseForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 582);
            Controls.Add(gb_name);
            Controls.Add(gb_price);
            Controls.Add(gb_category);
            Controls.Add(gb_date);
            Controls.Add(gb_description);
            Name = "AddExpenseForm";
            Text = "AddExpenseForm";
            gb_name.ResumeLayout(false);
            gb_name.PerformLayout();
            gb_price.ResumeLayout(false);
            gb_price.PerformLayout();
            gb_category.ResumeLayout(false);
            gb_category.PerformLayout();
            gb_date.ResumeLayout(false);
            gb_date.PerformLayout();
            gb_description.ResumeLayout(false);
            gb_description.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_name;
        private TextBox tb_name;
        private Button btn_name;
        private Label label1;
        private GroupBox gb_price;
        private TextBox tb_price;
        private Button btn_price;
        private Label label2;
        private GroupBox gb_category;
        private Button btn_category;
        private Label label3;
        public ComboBox cb_categories;
        private GroupBox gb_date;
        private Button btn_date;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private GroupBox gb_description;
        private TextBox tb_description;
        private Button btn_addItem;
        private Label label5;
    }
}