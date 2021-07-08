using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KruskalsAlgorithm
{
    public class Edge:IComparable<Edge>
    {
        public int node1;
        public int node2;
        public int weight;
        public bool isIncluded;

        public int CompareTo(Edge other)
        {
            if (weight != other.weight)
                return weight.CompareTo(other.weight);
            else
                return Math.Min(node1, node2).CompareTo(Math.Min(other.node1, other.node2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Edge[] edges;
            List<Edge> result=new List<Edge>();
            int[] marks;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                var nums = sr.ReadLine().Split(' ');
                n = int.Parse(nums[0]);
                m = int.Parse(nums[1]);
                edges = new Edge[m];
                marks = new int[n];
                for(int i=0;i<m;i++)
                {
                    nums = sr.ReadLine().Split(' ');
                    edges[i] = new Edge();
                    edges[i].node1 = int.Parse(nums[0]);
                    edges[i].node2 = int.Parse(nums[1]);
                    edges[i].weight = int.Parse(nums[2]);
                }
            }
            Array.Sort(edges);
            result.Add(edges[0]);
            marks[edges[0].node1] = marks[edges[0].node2] = Math.Min(edges[0].node1+1, edges[0].node2+1);

            int oldValue = 0;
            int newValue = 0;
            for(int i=1;i<n-1;i++)
            {
                if (marks[edges[i].node1] != marks[edges[i].node2] || marks[edges[i].node1] == 0)
                {
                    if (marks[edges[i].node1] == 0 && marks[edges[i].node2] == 0)
                    {
                        marks[edges[i].node1] = marks[edges[i].node2] = Math.Min(edges[i].node1, edges[i].node2) + 1;
                        oldValue = -1;
                    }
                    else if (marks[edges[i].node1] == 0 || marks[edges[i].node2] == 0)
                    {
                        marks[edges[i].node1] = marks[edges[i].node2] = Math.Max(marks[edges[i].node1], marks[edges[i].node2]);
                        oldValue = -1;
                    }
                    else
                    {
                        oldValue = Math.Max(marks[edges[i].node1], marks[edges[i].node2]);
                        newValue = Math.Min(marks[edges[i].node1], marks[edges[i].node2]);
                        //marks[edges[i].node1] = marks[edges[i].node2] = newValue;
                    }

                    for (int j = 0; j < marks.Length; j++)
                    {
                        if (marks[j] == oldValue)
                            marks[j] = newValue;
                    }
                    result.Add(edges[i]);
                }
                else
                    n++;
            }


            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (Edge edge in result)
                    sw.WriteLine("{0} {1}", Math.Min(edge.node1, edge.node2), Math.Max(edge.node1, edge.node2));
            }

            Console.ReadLine();
        }
    }
}
