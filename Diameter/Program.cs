using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            Vertex d = new Vertex();
            Vertex e = new Vertex();

            var vertices = new List<Vertex>() { a,b,c,d,e };

            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ae = new Edge(a, e);
            Edge bd = new Edge(b, d);
            Edge de = new Edge(d, e);

            var edges = new List<Edge>() { ab, bc, ae, bd, de };

            Graph g = new Graph(vertices, edges);

            Console.WriteLine($"Diameter: {g.Diameter}");

            Console.ReadKey();
        }
    }
}
