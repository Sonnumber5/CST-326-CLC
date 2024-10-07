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
    public partial class AddCategoryForm : Form
    {
        public string categoryName { get; set; }
        public AddCategoryForm()
        {
            Reset();
            InitializeComponent();
        }

        private void btn_addCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_categoryName.Text))
            {
                MessageBox.Show("Please enter a category name");
            }
            else
            {
                categoryName = tb_categoryName.Text;
                this.Close();
            }
        }

        private void Reset()
        {
            categoryName = null;
        }
    }
}
