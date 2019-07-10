using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    public class Graph
    {
        public List<Edge> Edges { get; }
        public List<Vertex> Vertices { get; }

        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }


        public List<Vertex> Neighbors(Vertex v)
        {
            return (from e in Edges
                    where e.Contains(v)
                    select e.Neighbor(v)).ToList();
        }


        public int Height(Vertex v)
        {
            return new Tree(v, this).Height;
        }

        public int Diameter
        {
            get
            {
                return (from v in Vertices
                        select Height(v)).Max();
            }
        }

    }

    public class Tree
    {
        public int Height { get; }

        public Tree(Vertex root, Graph graph)
        {
            var queue = new Queue<Vertex>();
            var parent = new Dictionary<Vertex, Vertex>();
            Vertex current = root;
            queue.Enqueue(current);
            while (queue.Any())
            {
                current = queue.Dequeue();
                foreach (var n in graph.Neighbors(current))
                {
                    if (!parent.ContainsKey(n) && n != root)
                    {
                        parent[n] = current;
                        queue.Enqueue(n);
                    }
                }
            }
            // get the height using the last node dequeued
            int height = 0;
            while (parent.ContainsKey(current))
            {
                height++;
                current = parent[current];
            }
            Height = height;
        }
    }

    public class Edge
    {
        public Vertex V1 { get; }
        public Vertex V2 { get; }

        public Edge(Vertex v1, Vertex v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public bool Contains(Vertex v)
        {
            return V1 == v || V2 == v;
        }

        public Vertex Neighbor(Vertex v)
        {
            if (v == V1)
            {
                return V2;
            }
            else
            {
                return V1;
            }
        }
    }

    public class Vertex
    {
    }

}
