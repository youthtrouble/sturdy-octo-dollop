using System;
using System.Collections.Generic;

namespace Assessment_2

{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int count;
        
        public BinarySearchTree()
        {
            Root = null;
            count = 0;
        }

        /// <summary>
        /// Inserts a value into the binary search tree.
        /// Time Complexity: Average O(log n), Worst O(n) for unbalanced tree.
        /// </summary>
        public void Insert(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Root = InsertRec(Root, value);
            count++;
        }
        
        /// <summary>
        /// Recursively counts the number of nodes in the tree.
        /// Time Complexity: O(n), as it needs to visit every node.
        /// </summary>
        private int CountRec(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                // Count the node itself (+1), then count all nodes in the left subtree and the right subtree
                return 1 + CountRec(node.Left) + CountRec(node.Right);
            }
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

        /// <summary>
        /// Traverses the tree in pre-order and returns a list of values.
        /// Time Complexity: O(n), as it traverses every node.
        /// </summary>
        public List<T> TraversePreOrder()
        {
            List<T> values = new List<T>();
            TraversePreOrderRec(Root, values);
            return values;
        }

        // Helper method for pre-order traversal, not directly exposed.
        private void TraversePreOrderRec(Node<T> node, List<T> values)
        {
            if (node != null)
            {
                values.Add(node.Value);
                TraversePreOrderRec(node.Left, values);
                TraversePreOrderRec(node.Right, values);
            }
        }

        /// <summary>
        /// Lazily traverses the tree in order and yields each value.
        /// Time Complexity: O(n), as it traverses every node once.
        /// </summary>
        public IEnumerable<T> TraverseInOrder()
        {
            foreach (var value in TraverseInOrderRec(Root))
                yield return value;
        }

        // Helper recursive method for in-order traversal.
        private IEnumerable<T> TraverseInOrderRec(Node<T> node)
        {
            if (node != null)
            {
                foreach (var value in TraverseInOrderRec(node.Left))
                    yield return value;

                yield return node.Value;

                foreach (var value in TraverseInOrderRec(node.Right))
                    yield return value;
            }
        }


        /// <summary>
        /// Traverses the tree in post-order and returns a list of values.
        /// Time Complexity: O(n), as it traverses every node.
        /// </summary>
        public List<T> TraversePostOrder()
        {
            List<T> values = new List<T>();
            TraversePostOrderRec(Root, values);
            return values;
        }

        // Helper method for post-order traversal, not directly exposed.
        private void TraversePostOrderRec(Node<T> node, List<T> values)
        {
            if (node != null)
            {
                TraversePostOrderRec(node.Left, values);
                TraversePostOrderRec(node.Right, values);
                values.Add(node.Value);
            }
        }

        /// <summary>
        /// Searches for a value in the tree by a specific attribute.
        /// Time Complexity: Average O(log n), Worst O(n) for unbalanced trees.
        /// </summary>
        public T FindByAttribute(Func<T, string> attributeSelector, string valueToFind)
        {
            return FindByAttributeRec(Root, attributeSelector, valueToFind);
        }

        // Helper method for attribute-based search, not directly exposed.
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
        
        /// <summary>
        /// Returns the number of nodes in the tree, as tracked by insert operations.
        /// This method provides direct access to the count of nodes that have been inserted into the tree.
        /// Time Complexity: O(1), as it simply returns the value of an already maintained count variable.
        /// </summary>
        public int CountByInsert()
        {
            return count;
        }

        /// <summary>
        /// Returns the count of nodes in the tree. Utilizes a recursive helper method to count nodes.
        /// Time Complexity: O(n), as it potentially needs to traverse the entire tree.
        /// </summary>
        public int Count()
        {
            return CountRec(Root);
        }
    }
}
