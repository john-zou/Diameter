using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diameter;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class DiameterTest
    {
        [TestMethod]
        public void TwoVertices()
        {
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            var vertices = new List<Vertex>() { a, b, };
            Edge ab = new Edge(a, b);
            var edges = new List<Edge>() { ab };
            Assert.AreEqual(1, new Graph(vertices, edges).Diameter);
        }

        [TestMethod]
        public void ThreeVertices_2Edges()
        {
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();

            var vertices = new List<Vertex>() { a, b, c };
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            var edges = new List<Edge>() { ab, bc };
            Assert.AreEqual(2, new Graph(vertices, edges).Diameter);
        }

        [TestMethod]
        public void ThreeVertices_3Edges()
        {
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();

            var vertices = new List<Vertex>() { a, b, c };
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge ac = new Edge(a, c);

            var edges = new List<Edge>() { ab, bc, ac };
            Assert.AreEqual(1, new Graph(vertices, edges).Diameter);
        }

        [TestMethod]
        public void FourVertices_Diameter_3()
        {
            // Minimally connected, so diameter is max possible for 4 vertices

            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            Vertex d = new Vertex();


            var vertices = new List<Vertex>() { a, b, c, d };
            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);

            var edges = new List<Edge>() { ab, bc, cd };

            Assert.AreEqual(3, new Graph(vertices, edges).Diameter);
        }

        [TestMethod]
        public void FourVertices_Diameter_1()
        {
            // Maximally connected, so distance between any two nodes is 1

            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            Vertex d = new Vertex();


            var vertices = new List<Vertex>() { a, b, c, d };

            Edge ab = new Edge(a, b);
            Edge bc = new Edge(b, c);
            Edge cd = new Edge(c, d);
            Edge ac = new Edge(a, c);
            Edge ad = new Edge(a, d);
            Edge bd = new Edge(b, d);


            var edges = new List<Edge>() { ab, bc, cd, ac, ad, bd };

            Assert.AreEqual(1, new Graph(vertices, edges).Diameter);
        }

        [TestMethod]
        public void InClassExample1()
        {
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            Vertex d = new Vertex();
            Vertex e = new Vertex();
            Vertex f = new Vertex();
            Vertex g = new Vertex();
            Vertex h = new Vertex();

            var vertices = new List<Vertex>() { a, b, c, d, e, f, g, h };

            var edges = new List<Edge>(){ new Edge(a, b),
                                          new Edge(a, c),
                                          new Edge(b, c),
                                          new Edge(b, d),
                                          new Edge(d, g),
                                          new Edge(b, f),
                                          new Edge(b, e),
                                          new Edge(f, h),
                                          new Edge(e, h)};

            Assert.AreEqual(4, new Graph(vertices, edges).Diameter);

        }

        [TestMethod]
        public void InClassExample2()
        {
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            Vertex d = new Vertex();
            Vertex e = new Vertex();
            Vertex f = new Vertex();

            var vertices = new List<Vertex>() { a, b, c, d, e, f };

            var edges = new List<Edge>(){ new Edge(a, b),
                                          new Edge(b, c),
                                          new Edge(c, d),
                                          new Edge(b, d),
                                          new Edge(d, e),
                                          new Edge(e, f),
                                          new Edge(a, f)};

            Assert.AreEqual(3, new Graph(vertices, edges).Diameter);
        }
    }
}
