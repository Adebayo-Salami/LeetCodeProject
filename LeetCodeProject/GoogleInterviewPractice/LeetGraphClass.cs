using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetGraphClass
    {
        private class LeetGraphNode
        {
            private string _label;

            public LeetGraphNode(string label)
            {
                _label = label;
            }

            public string Value => _label;
        }

        private Dictionary<string, LeetGraphNode> _store;
        private Dictionary<LeetGraphNode, HashSet<LeetGraphNode>> _adjacentStore;

        public LeetGraphClass()
        {
            _store = new Dictionary<string, LeetGraphNode>();
            _adjacentStore = new Dictionary<LeetGraphNode, HashSet<LeetGraphNode>>();
        }

        public void AddNode(string label)
        {
            if (!_store.ContainsKey(label))
            {
                _store.Add(label, new LeetGraphNode(label));
                _adjacentStore.Add(_store[label], new HashSet<LeetGraphNode>());
            }
        }

        public void RemoveNode(string label)
        {
            _store.TryGetValue(label, out LeetGraphNode? vertice);
            if (vertice == null)
                return;

            foreach (var edges in _adjacentStore.Values)
                if (edges.Contains(vertice))
                    edges.Remove(vertice);

            _adjacentStore.Remove(vertice);
            _store.Remove(label);
        }

        public void AddEdge(string from, string to)
        {
            _store.TryGetValue(from, out var vertice);
            if (vertice == null)
                return;

            _store.TryGetValue(to, out var edge);
            if (edge == null)
                return;

            _adjacentStore[vertice].Add(edge);
        }

        public void RemoveEdge(string from, string to)
        {
            _store.TryGetValue(from, out var vertice);
            if (vertice == null)
                return;

            _store.TryGetValue(to, out var edge);
            if (edge == null)
                return;

            _adjacentStore[vertice].Remove(edge);
        }

        private bool VerticeExists(string label) => _store.ContainsKey(label);

        public void Print()
        {
            foreach (var vertice in _store.Values)
            {
                List<string> edges = new();
                foreach (var edge in _adjacentStore[vertice])
                    edges.Add(edge.Value);

                Console.WriteLine(vertice.Value + " is connected with " + String.Join(',', edges));
            }
        }

        public string[] TraversePrint_BreadthFirst(string startingCharacter)
        {
            _store.TryGetValue(startingCharacter, out var vertice);
            if (vertice == null)
                return [];

            return TraversePrint_BreadthFirst(vertice, new Queue<LeetGraphNode>(), new HashSet<string>()).ToArray();
        }

        private HashSet<string> TraversePrint_BreadthFirst(LeetGraphNode node, Queue<LeetGraphNode> queue, HashSet<string> values)
        {
            if (node == null)
                return values;

            foreach (var edge in _adjacentStore[node].OrderBy(x => x.Value))
                queue.Enqueue(edge);

            values.Add(node.Value);
            return queue.Count == 0 ? values : TraversePrint_BreadthFirst(queue.Dequeue(), queue, values);
        }

        public string[] TraversePrint_DepthFirst(string startingCharacter)
        {
            _store.TryGetValue(startingCharacter, out var vertice);
            if (vertice == null)
                return [];

            return TraversePrint_DepthFirst(vertice, new HashSet<string>()).ToArray();
        }

        private HashSet<string> TraversePrint_DepthFirst(LeetGraphNode node, HashSet<string> values)
        {
            if (node == null)
                return values;

            values.Add(node.Value);

            foreach (var edge in _adjacentStore[node].OrderBy(x => x.Value))
                TraversePrint_DepthFirst(edge, values);

            return values;
        }
    }
}
