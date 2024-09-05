using DefenseSyber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenseSyber
{
    internal static class Reccorsion
    {
        public static TreeNode? SearchReccorsive(TreeNode node, int value)
        {
            // כשמצאתי ITEM
            // not found
            if (node == null)
            {
                return null;
            }
            if (SeverityService.FindRange(node.Value, value))
            {
                return node;
            }
            //reccoresive
            if (SeverityService.Bigger(node.Value, value))
            {
                return SearchReccorsive(node.Right, value);
            }
            return SearchReccorsive(node.Left, value);
        }
        public static TreeNode SearchPreOrderReccorsive(TreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }
            if (SeverityService.FindRange(node.Value, value))
            {
                return node;
            }
            TreeNode leftResult = SearchPreOrderReccorsive(node.Left, value);
            if (leftResult != null)
            {
                return leftResult;
            }
            return SearchPreOrderReccorsive(node.Right, value);
        }

        public static TreeNode InsertReccorsive(TreeNode node, Defense value, int count)
        {
            if (node is null)
            {
                return new TreeNode(value, count);
            }
            if (SeverityService.Bigger(node.Value, value.MaxSeverity))
            {
                node.Right = InsertReccorsive(node.Right, value, count + 1);
            }
            if (SeverityService.Smaller(node.Value, value.MinSeverity))
            {
                node.Left = InsertReccorsive(node.Left, value, count + 1);
            }
            return node;
        }
        public static List<TreeNode> PreOrderReccorsive(TreeNode node)
        {
            {
                if (node == null) { return []; }
                var listNode = new List<TreeNode> { node };
                var ListNodeLeft = PreOrderReccorsive(node.Left);
                var ListNodeRight = PreOrderReccorsive(node.Right);
                return [.. listNode, .. ListNodeLeft, .. ListNodeRight];
            }
        }
        public static void PreOrderReccorsivePrint(TreeNode node, string mode)
        {
            {
                if (node == null) { return; }
                var listNode = new List<TreeNode> { node };
                Console.WriteLine($"{"-".Repeat(node.Height)} {mode}: MinSeverity:{node.Value.MinSeverity} | MaxSeverity:{node.Value.MaxSeverity} | Defenses:{string.Join(",", node.Value.Defenses)}");
                PreOrderReccorsivePrint(node.Left, "LEFT");
                PreOrderReccorsivePrint(node.Right, "RIGHT");
                return;
            }
        }
        public static List<TreeNode> InOrderReccorsive(TreeNode node)
        {
            if (node == null) { return []; }
            var ListNodeLeft = PreOrderReccorsive(node.Left);
            var listNode = new List<TreeNode> { node };
            var ListNodeRight = PreOrderReccorsive(node.Right);
            return [.. listNode, .. ListNodeLeft, .. ListNodeRight];
        }

        public static TreeNode FindMinReccorsive(TreeNode node)
        {
            if (node.Left is null)
            {
                return node;
            }
            return FindMinReccorsive(node.Left);
        }
        public static TreeNode? RemoveRecursive(TreeNode? node, int value)
        {
            if (node == null)
            {
                return null;
            }
            if (SeverityService.Smaller(node.Value, value))
            {
                node.Left = RemoveRecursive(node.Left, value);
            }
            else if (SeverityService.Bigger(node.Value, value))
            {
                node.Right = RemoveRecursive(node.Right, value);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                else
                {
                    TreeNode node1 = FindMinReccorsive(node.Right);
                    Defense minValue = node1.Value;
                    node.Value = minValue;
                    node.Right = RemoveRecursive(node.Right, minValue.MinSeverity);
                }
            }

            return node;
        }
        public static TreeNode BuildBalancedTreeRecursive(List<TreeNode> sortedList, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;
            TreeNode root = sortedList[middle];

            root.Left = BuildBalancedTreeRecursive(sortedList, start, middle - 1);
            root.Right = BuildBalancedTreeRecursive(sortedList, middle + 1, end);

            return root;
        }
        public static void CalculateHeights(TreeNode node, int count = 0)
        {
            if (node == null)
            {
                return;
            }

            node.Height = count;

            CalculateHeights(node.Left, count + 1);
            CalculateHeights(node.Right, count + 1);
        }



    }
}
