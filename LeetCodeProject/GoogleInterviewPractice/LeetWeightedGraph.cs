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
            private List<LeetWeightedGraphEdge> _edges;

            public LeetWeightedGraphNode(string value)
            {
                _value = value;
                _edges = new List<LeetWeightedGraphEdge>();
            }

            public override string ToString()
            {
                return _value;
            }

            public void AddEdge(LeetWeightedGraphNode to, int weight)
            {
                _edges.Add(new LeetWeightedGraphEdge(this, to, weight));
            }

            public List<LeetWeightedGraphEdge> Edges => _edges;
        }

        private class LeetWeight
        {
            public LeetWeightedGraphNode? Location { get; set; }
            public int Distance { get; set; }

            public LeetWeight(LeetWeightedGraphNode? location, int distance)
            {
                Location = location;
                Distance = distance;
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

            public override string ToString()
            {
                return _from + " -> " + _weight + " -> " + _to;
            }
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
            _adjacentStore.TryAdd(_store[value], new HashSet<LeetWeightedGraphEdge>());
        }

        public void AddNode2(string value)
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

        public void AddEdge2(string from, string to, int weight)
        {
            _store.TryGetValue(from, out var vertice);
            if (vertice == null)
                return;

            _store.TryGetValue(to, out var edge);
            if (edge == null)
                return;

            vertice.AddEdge(edge, weight);
            edge.AddEdge(vertice, weight);
        }

        public int GetShortestDistance(string from, string to)
        {
            _store.TryGetValue(from, out var startingPoint);
            if (startingPoint == null)
                return -1;

            _store.TryGetValue(to, out var destination);
            if (destination == null)
                return -1;

            //return GetShortestDistance(startingPoint, startingPoint, destination, int.MaxValue);
            return GetShortestDistance(startingPoint, destination);
        }

        public void Print()
        {
            foreach (var vertice in _store.Values)
                foreach (var edge in _adjacentStore[vertice])
                    Console.WriteLine(edge);
        }

        public void Print2()
        {
            foreach (var vertice in _store.Values)
                foreach (var edge in vertice.Edges)
                    Console.WriteLine(edge);
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

        private int GetShortestDistance(LeetWeightedGraphNode location, LeetWeightedGraphNode destination)
        {
            Dictionary<LeetWeightedGraphNode, LeetWeight> tracker = new();
            foreach (var vertice in _store.Values)
                tracker.Add(vertice, new LeetWeight(null, int.MaxValue));
            tracker[location].Distance = 0;
            GetShortestDistance(location, tracker, 0, new HashSet<LeetWeightedGraphNode>(), new PriorityQueue<LeetWeightedGraphNode, int>());
            return tracker[destination].Distance;
        }

        private void GetShortestDistance(LeetWeightedGraphNode currentLocation, Dictionary<LeetWeightedGraphNode, LeetWeight> tracker, int distance, HashSet<LeetWeightedGraphNode> visitedLocations, PriorityQueue<LeetWeightedGraphNode, int> destinations)
        {
            if (!visitedLocations.Contains(currentLocation))
            {
                visitedLocations.Add(currentLocation);
                foreach (var destination in _adjacentStore[currentLocation])
                {
                    if (!visitedLocations.Contains(destination.Destination))
                    {
                        var newDistance = distance + destination.Distance;
                        if (newDistance < tracker[destination.Destination].Distance)
                        {
                            tracker[destination.Destination].Distance = newDistance;
                            tracker[destination.Destination].Location = currentLocation;
                        }
                        destinations.Enqueue(destination.Destination, destination.Distance);
                    }
                }
            }
            if (destinations.Count == 0)
                return;

            var nextLocation = destinations.Dequeue();
            GetShortestDistance(nextLocation, tracker, tracker[nextLocation].Distance, visitedLocations, destinations);
        }
    }
}
