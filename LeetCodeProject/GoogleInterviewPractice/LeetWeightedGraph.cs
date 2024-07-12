using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetWeightedGraph
    {
        private class LeetWeightedGraphNode
        {
            private string _value;

            public LeetWeightedGraphNode(string value)
            {
                _value = value;
            }
        }

        private class LeetWeightedGraphEdge
        {
            private LeetWeightedGraphNode _from;
            private LeetWeightedGraphNode _to;
            private int _weight;

            public LeetWeightedGraphEdge(LeetWeightedGraphNode from, LeetWeightedGraphNode to, int weight)
            {
                _from = from;
                _to = to;
                _weight = weight;
            }

            public int Distance => _weight;

            public LeetWeightedGraphNode Destination => _to;
        }

        private Dictionary<string, LeetWeightedGraphNode> _store;
        private Dictionary<LeetWeightedGraphNode, HashSet<LeetWeightedGraphEdge>> _adjacentStore;

        public LeetWeightedGraph()
        {
            _store = new Dictionary<string, LeetWeightedGraphNode>();
            _adjacentStore = new Dictionary<LeetWeightedGraphNode, HashSet<LeetWeightedGraphEdge>>();
        }

        public void AddNode(string value)
        {
            _store.TryAdd(value, new LeetWeightedGraphNode(value));
        }

        public void AddEdge(string from, string to, int weight)
        {
            _store.TryGetValue(from, out var vertice);
            if (vertice == null)
                return;

            _store.TryGetValue(to, out var edge);
            if (edge == null)
                return;

            _adjacentStore[vertice].Add(new LeetWeightedGraphEdge(vertice, edge, weight));
            _adjacentStore[edge].Add(new LeetWeightedGraphEdge(edge, vertice, weight));
        }

        public int GetShortestDistance(string from, string to)
        {
            _store.TryGetValue(from, out var startingPoint);
            if (startingPoint == null)
                return -1;

            _store.TryGetValue(to, out var destination);
            if (destination == null)
                return -1;

            return GetShortestDistance(startingPoint, startingPoint, destination, int.MaxValue);
        }

        private int GetShortestDistance(LeetWeightedGraphNode startingPoint, LeetWeightedGraphNode current, LeetWeightedGraphNode destination, int distance)
        {
            if (current == destination)
                return distance;

            foreach (var location in _adjacentStore[current])
            {
                if (location.Destination == current || location.Destination == startingPoint)
                    continue;

                var travelDistance = GetShortestDistance(startingPoint, location.Destination, destination, (distance + location.Distance));
                if (travelDistance < distance)
                    distance = travelDistance;
            }

            return distance;
        }
    }
}
