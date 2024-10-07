using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationUI
{
    public partial class AddExpenseForm : Form
    {
        public ExpenseModel ExpenseItem { get; private set; }

        private string name;
        private double price;
        private string category;
        private string date;
        private string description;
        public AddExpenseForm(List<string> categoriesList)
        {
            ResetItem();
            InitializeComponent();
            PopulateComboBox(categoriesList);
        }

        private void PopulateComboBox(List<string> categoriesList)
        {
            foreach (String category in categoriesList)
            {
                cb_categories.Items.Add(category);
            }
        }

        private void btn_name_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_name.Text))
            {
                MessageBox.Show("Please enter a name.");
            }
            else
            {
                name = tb_name.Text;
                gb_name.Visible = false;
            }
        }

        private void btn_price_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tb_price.Text, out price))
            {
                price = Convert.ToDouble(tb_price.Text);
                gb_price.Visible = false;
            }
            else
            {
                MessageBox.Show("Please enter a numeric value for the price.");
            }
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            if(cb_categories.SelectedItem == null)
            {
                MessageBox.Show("Please select a category or make a new one.");
            }
            else
            {
                category = cb_categories.SelectedItem.ToString();
                gb_category.Visible = false;
            }
        }

        private void btn_date_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToShortDateString();
            gb_date.Visible = false;
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_name.Text))
            {
                description = "";
            }
            description = tb_description.Text;

            var expenseItem = new ExpenseModel(name, price, category, date, description);
            ExpenseItem = expenseItem;
            this.Close();
        }

        private void ResetItem()
        {
            ExpenseItem = null;
        }
    }
}
