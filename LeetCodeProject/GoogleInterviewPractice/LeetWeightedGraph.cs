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
        }

        public void AddNode(string value)
        {

        }

        public void AddEdge(string from, string to, int weight)
        {

        }
    }
}
