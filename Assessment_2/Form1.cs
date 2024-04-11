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
            
            txtInsert.Clear();
            UpdateTraversalList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text;
            Customer customer = _customerTree.SearchCustomer(searchName);
        }
        
        private void UpdateTraversalList()
        {
            lstTraversal.Items.Clear();
            _customerTree.GetCustomersPreOrder().ToList().ForEach(customer => lstTraversal.Items.Add(customer.GetInformation());
        }
    }
}
