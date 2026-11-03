using System;
using System.Collections.Generic;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // TODO: count this node, then count every child subtree.

            int count = 1;
            
            foreach (var child in root.Children)
                count  += CountNodes(child);
            
            return count;
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // TODO: compare the current node, then search child subtrees.
            
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            
            if (EqualityComparer<T>.Default.Equals(target, root.Value))
            {
                return true;
            }

            foreach (var child in root.Children)
            {
                if (Contains<T>(child, target))
                    return true;
            }
            
            return false;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // TODO: return values in pre-order:
            // current node first, then each child subtree from left to right.
            
            List<T> result = new List<T>();
            
            result.Add(root.Value);
            
            foreach (var child in root.Children)
                result.AddRange(DepthFirstPreOrder(child));

            return result;
        }

        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // Depth is measured in edges from the root.
            // A single-node tree therefore has max depth 0.
            
            int depth = 0;

            foreach (var child in root.Children)
            {
                int childDepth = MaxDepth(child);
                
                depth = Math.Max(depth, childDepth + 1);
            }

            return depth;
        }
    }
}
