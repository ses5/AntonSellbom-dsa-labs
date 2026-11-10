using System;
using System.Collections.Generic;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// Complete these methods after the adjacency representation is working.
    /// Think in terms of:
    /// frontier + visited + neighbors.
    /// </summary>
    public static class GraphTraversal
    {
        public static IReadOnlyList<string> BreadthFirstOrder(AdjacencyGraph graph, string start)
        {
            List<string> result = new List<string>();
            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string currentNode = queue.Dequeue();
                result.Add(currentNode);

                foreach (string neighbor in graph.GetNeighbors(currentNode))
                {
                    if (visited.Add(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
            
            return result;
        }

        public static IReadOnlyList<string> DepthFirstOrder(AdjacencyGraph graph, string start)
        {
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();
            HashSet<string> visited = new HashSet<string>();
            
            stack.Push(start);
            visited.Add(start);

            while (stack.Count > 0)
            {
                string currentNode = stack.Pop();
                result.Add(currentNode);
                
                IReadOnlyList<string> neighbors = graph.GetNeighbors(currentNode);

                for (int i = neighbors.Count - 1; i >= 0; i--)
                {
                    string neighbor = neighbors[i];
                    
                    if (visited.Add(neighbor))
                        stack.Push(neighbor);
                }
            }

            return result;
        }

        public static bool IsReachableBfs(AdjacencyGraph graph, string start, string target)
        {
            if (!graph.ContainsNode(start) || !graph.ContainsNode(target))
                return false;
            
            if (start == target)
                return true;
            
            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string currentNode = queue.Dequeue();

                foreach (string neighbor in graph.GetNeighbors(currentNode))
                {
                    if (visited.Add(neighbor))
                        queue.Enqueue(neighbor);

                    if (neighbor == target)
                        return true;
                }
            }

            return false;
        }
    }
}
