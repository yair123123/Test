using DefenseSyber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DefenseSyber
{
    internal class TreeNode
    {
        public TreeNode(Defense value, int height)
        {
            Value = value;
            this.Height = height;
        }

        public Defense Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Height { get; set; } = 0;
    }
    internal class BsTree
    {
        private TreeNode root;

        public TreeNode Search(int value)
        {
            return Reccorsion.SearchReccorsive(root, value);
        }
        public TreeNode SearchPreOrder(int value)
        {
            return Reccorsion.SearchPreOrderReccorsive(root, value);
        }
        public void Insert(Defense value)
        {
            root = Reccorsion.InsertReccorsive(root, value, 0);
            return;
        }
        //public TreeNode Remove(Defense value) 
        //{ 
        //    return Reccorsion.RemoveReccorsive(root, value);
        //}
        public List<TreeNode> PreOrder()
        {
            return Reccorsion.PreOrderReccorsive(root);
        }
        public List<TreeNode> InOrder()
        {
            return Reccorsion.InOrderReccorsive(root);
        }

        public void PreOrderPrint()
        {
            Reccorsion.PreOrderReccorsivePrint(root, "ROOT");
        }
        public TreeNode FindMim()
        {
            return Reccorsion.FindMinReccorsive(root);
        }

        public void Remuve(int value)
        {
            Reccorsion.RemoveRecursive(root, value);
        }
        public BsTree Balance()
        {
            List<TreeNode> listInOrder = Reccorsion.InOrderReccorsive(root);
            listInOrder.ForEach(node => node.Height = 0);
            BsTree newTree = new();
            newTree.root = Reccorsion.BuildBalancedTreeRecursive(listInOrder, 0, listInOrder.Count - 1);
            Reccorsion.CalculateHeights(newTree.root);

            return newTree;
        }
    }
}
