using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    internal class CustomerTree
    {

        private BinarySearchTree<Customer> customerTree;
        public CustomerTree()
        {
            customerTree = new BinarySearchTree<Customer>();
        }

        public void InsertCustomer(Customer customer)
        {
            customerTree.Insert(customer);
        }

        public List<Customer> GetCustomerInorder()
        {
            return customerTree.TraverseInOrder();
        }

        public List<Customer> GetCustomerPreorder()
        {
            return customerTree.TraversePreOrder();
        }

        public List<Customer> GetCustomerPostorder()
        {
            return customerTree.TraversePostOrder();
        }

        public Customer SearchCustomer(int id)
        {
            return customerTree.Search(id);
        }

        public int CountCustomers()
        {
            return customerTree.Count();
        }
    }
}
