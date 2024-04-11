using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment_2
{
    public partial class Form1 : Form
    {
        private CustomerTree _customerTree = new CustomerTree();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text;
            int customerAge = int.Parse(txtAge.Text);
            string customerAddress = txtAddress.Text;
            float customerAmountOwed = float.Parse(txtAmountOwed.Text);
            
            Customer customer = new Customer(customerName, customerAge, customerAddress, customerAmountOwed);
            _customerTree.InsertCustomer(customer);

            UpdateTraversalList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text;
            Customer customer = _customerTree.SearchCustomer(searchName);

            lstTraversal.Items.Clear();
            lstTraversal.Items.Add(customer.GetInformation());
        }
        
        private void UpdateTraversalList()
        {
            lstTraversal.Items.Clear();
            _customerTree.GetCustomersPreOrder().ToList().ForEach(customer => lstTraversal.Items.Add(customer.GetInformation()));
            UpdateCustomerCount();
        }

        // Event handlers for the traversal buttons
        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            UpdateTraversalListAction("PreOrder");
        }

        private void btnInOrder_Click(object sender, EventArgs e)
        {
            UpdateTraversalListAction("InOrder");
        }

        private void btnPostOrder_Click(object sender, EventArgs e)
        {
            UpdateTraversalListAction("PostOrder");
        }

        // Updated method to handle all three types of traversal
        private void UpdateTraversalListAction(string traversalType)
        {
            lstTraversal.Items.Clear();
            switch (traversalType)
            {
                case "PreOrder":
                    _customerTree.GetCustomersPreOrder().ToList().ForEach(customer => lstTraversal.Items.Add(customer.GetInformation()));
                    break;
                case "InOrder":
                    _customerTree.GetCustomersInOrder().ToList().ForEach(customer => lstTraversal.Items.Add(customer.GetInformation()));
                    break;
                case "PostOrder":
                    _customerTree.GetCustomersPostOrder().ToList().ForEach(customer => lstTraversal.Items.Add(customer.GetInformation()));
                    break;
                default:
                    break;
            }
            UpdateCustomerCount();
        }

        // Event handler for clicking the "Update Count" button
        private void btnUpdateCount_Click(object sender, EventArgs e)
        {
            UpdateCustomerCount();
        }

        // Method to update the customer count display
        private void UpdateCustomerCount()
        {
            // Call the CountCustomers method of _customerTree to get the current count
            int customerCount = _customerTree.CountCustomers();
            // Update the label's text to show the current count
            lblCustomerCount.Text = $"{customerCount}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
