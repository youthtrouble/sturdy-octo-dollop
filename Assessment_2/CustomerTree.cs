using System;
using System.Collections.Generic;


namespace Assessment_2
{
    internal class CustomerTree
    {

        private BinarySearchTree<Customer> _customerTree;
        public CustomerTree()
        {
            _customerTree = new BinarySearchTree<Customer>();
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Cannot insert a null customer.");

            _customerTree.Insert(customer);
        }

        public IEnumerable<Customer> GetCustomersInOrder()
        {
            return _customerTree.TraverseInOrder();
        }

        public IEnumerable<Customer> GetCustomersPreOrder()
        {
            return _customerTree.TraversePreOrder();
        }

        public IEnumerable<Customer> GetCustomersPostOrder()
        {
            return _customerTree.TraversePostOrder();
        }

        public Customer SearchCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            return _customerTree.FindByAttribute(customer => customer.Name, name);
        }

        public int CountCustomers()
        {
            return _customerTree.CountByInsert();
        }
    }
}
