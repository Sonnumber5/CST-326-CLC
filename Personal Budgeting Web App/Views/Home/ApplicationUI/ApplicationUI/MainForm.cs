namespace ApplicationUI
{
    public partial class MainForm : Form
    {

        List<string> categoriesList = new List<string>();
        public MainForm()
        {
            InitializeComponent();
        }

        //Adds a category name defined by the user to the tree view
        private void AddCategory(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                string nameToLower = categoryName.ToLower();

                // Check if the category already exists
                // iterates through the tree view nodes 
                foreach (TreeNode node in treeView_categories.Nodes)
                {
                    // if the category already exists, do nothing
                    if (node.Text.ToLower() == nameToLower)
                    {
                        MessageBox.Show($"\"{categoryName}\" already exists as a category.");
                        return;
                    }
                }
            }
            categoriesList.Add(categoryName);

            // Turn the categoryName into a node
            TreeNode categoryNode = new TreeNode(categoryName);

            // put the newly created node into the treeview
            treeView_categories.Nodes.Add(categoryNode);
        }



        //Adds objects of type ExpenseModel as child nodes to the tree view
        private void AddExpense(ExpenseModel expense) //takes an expense item and adds to the treeview
        {

            //declare the category node
            TreeNode categoryNode = null;

            //finds the category node to which the expense node will fall into
            foreach (TreeNode node in treeView_categories.Nodes)
            {
                // finds a category node that matches the expense's category 
                if (node.Text == expense.Category)
                {
                    categoryNode = node;
                    break;
                }
            }

            // creates a new category if one does not exist yet
            if (categoryNode == null)
            {
                categoryNode = new TreeNode(expense.Category);
                treeView_categories.Nodes.Add(categoryNode);
            }


            TreeNode expenseNode = new TreeNode(expense.ToString());
            expenseNode.Tag = expense;
            categoryNode.Nodes.Add(expenseNode);
            categoryNode.Expand();
        }

        private void btn_addCategory_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm();
            addCategoryForm.ShowDialog();

            string categoryName = addCategoryForm.categoryName;

            if (!string.IsNullOrEmpty(categoryName))
            {
                AddCategory(categoryName);

                foreach (TreeNode node in treeView_categories.Nodes)
                {
                    if (node.Text == categoryName)
                    {
                        return;
                    }
                }
            }

            //string newcategory = "groceries"; // this would come from user input
            //addcategory(newcategory);         // add the new category node
        }

        private void btn_addExpense_Click(object sender, EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm(categoriesList);
            addExpenseForm.ShowDialog();

            // Check if an item was created
            if (addExpenseForm.ExpenseItem != null)
            {
                // Add the item to the main form (e.g., add to a list or TreeView)
                AddExpense(addExpenseForm.ExpenseItem);
            }

            //// Simulate user input for a new expense
            //ExpenseModel newExpense = new ExpenseModel("Walmart", 114.56, "Groceries", DateTime.Now, "Weekly groceries");

            //// Add the expense under the correct category
            //AddExpense(newExpense);
        }

        private void treeView_categories_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Adjust node bounds to increase spacing
            e.Node.Bounds.Offset(0, 10);  // Increase the vertical spacing by 10 pixels

            // If the node is a child (Level > 0), change its text color
            if (e.Node.Level > 0)
            {
                // Child nodes get a different color
                e.Graphics.DrawString(e.Node.Text, treeView_categories.Font, Brushes.DarkGray, e.Bounds.Left, e.Bounds.Top);
            }
            else
            {
                // Parent nodes (Level == 0) keep the default color
                e.Graphics.DrawString(e.Node.Text, treeView_categories.Font, Brushes.DarkSlateGray, e.Bounds.Left, e.Bounds.Top);
            }

            // Ensure the node is selected if needed
            if ((e.State & TreeNodeStates.Selected) != 0 && e.Node.Level > 0)
            {
                e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds);
                e.Graphics.DrawString(e.Node.Text, treeView_categories.Font, Brushes.White, e.Node.Bounds.Left, e.Node.Bounds.Top);
            }

            // Draw a border around the node's text area
            Pen borderPen = new Pen(Color.Gray, 1);
            e.Graphics.DrawRectangle(borderPen, e.Bounds);

            e.DrawDefault = false;  // Prevent default drawing
        }

    }
}
