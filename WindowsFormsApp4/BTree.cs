using System;
using System.Collections.Generic;

namespace Assessment_2

{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public void Insert(T value)
        {
            Root = InsertRec(Root, value);
        }

        private Node<T> InsertRec(Node<T> node, T value)
        {
            if (node == null)
                return new Node<T>(value);

            int comparison = value.CompareTo(node.Value);
            if (comparison < 0)
                node.Left = InsertRec(node.Left, value);
            else if (comparison > 0)
                node.Right = InsertRec(node.Right, value);

            return node;
        }

        public List<T> TraversePreOrder()
        {
            List<T> values = new List<T>();
            TraversePreOrderRec(Root, values);
            return values;
        }

        private void TraversePreOrderRec(Node<T> node, List<T> values)
        {
            if (node != null)
            {
                values.Add(node.Value);
                TraversePreOrderRec(node.Left, values);
                TraversePreOrderRec(node.Right, values);
            }
        }

        public List<T> TraverseInOrder()
        {
            List<T> values = new List<T>();
            TraverseInOrderRec(Root, values);
            return values;
        }

        private void TraverseInOrderRec(Node<T> node, List<T> values)
        {
            if (node != null)
            {
                TraverseInOrderRec(node.Left, values);
                values.Add(node.Value);
                TraverseInOrderRec(node.Right, values);
            }
        }

        public List<T> TraversePostOrder()
        {
            List<T> values = new List<T>();
            TraversePostOrderRec(Root, values);
            return values;
        }

        private void TraversePostOrderRec(Node<T> node, List<T> values)
        {
            if (node != null)
            {
                TraversePostOrderRec(node.Left, values);
                TraversePostOrderRec(node.Right, values);
                values.Add(node.Value);
            }
        }

        public T FindByAttribute(Func<T, string> attributeSelector, string valueToFind)
        {
            return FindByAttributeRec(Root, attributeSelector, valueToFind);
        }

        private T FindByAttributeRec(Node<T> node, Func<T, string> attributeSelector, string valueToFind)
        {
            if (node == null)
                return default(T);

            string currentValue = attributeSelector(node.Value);
            int comparison = valueToFind.CompareTo(currentValue);

            if (comparison == 0)
                return node.Value;
            else if (comparison < 0)
                return FindByAttributeRec(node.Left, attributeSelector, valueToFind);
            else
                return FindByAttributeRec(node.Right, attributeSelector, valueToFind);
        }

        public int Count()
        {
            return root;
        }
    }
}
