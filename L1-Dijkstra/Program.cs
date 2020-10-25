using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var Map = new Graph<string, int>();
            Map.EdgeValue = v => v;

            var Lviv = Map.AddVertex("Lviv");
            var Drohobych = Map.AddVertex("Drohobych");
            var Boryslav = Map.AddVertex("Boryslav");
            var Truskavec = Map.AddVertex("Truskavec");
            var Stebnyk = Map.AddVertex("Stebnyk");
            var Stryi = Map.AddVertex("Stryi");
            var Sambir = Map.AddVertex("Sambir");
            var NovyiRozdil = Map.AddVertex("Novyi Rozdil");

            Map.AddEdge(26, false, Stryi, Drohobych);
            Map.AddEdge(66, false, Lviv, Drohobych);
            Map.AddEdge(71, false, Stryi, Lviv);
            Map.AddEdge(75, false, Sambir, Lviv);
            Map.AddEdge(33, false, Sambir, Drohobych);
            Map.AddEdge(14, false, Boryslav, Drohobych);
            Map.AddEdge(8, false, Stebnyk, Drohobych);
            Map.AddEdge(12, false, Drohobych, Truskavec);
            Map.AddEdge(6, false, Stebnyk, Truskavec);
            Map.AddEdge(10, false, Boryslav, Truskavec);
            Map.AddEdge(46, false, Stryi, NovyiRozdil);
            Map.AddEdge(57, false, NovyiRozdil, Lviv);

            Console.WriteLine("Graph:");
            foreach (var item in Map)
            {
                Console.WriteLine(item);
                foreach (var edge in item.OutputEdges)
                    Console.WriteLine(" " + edge);
            }

            Console.WriteLine();
            Console.WriteLine("Shortest way:");

            var l = Map.ShortWayDijkstra(Lviv, Stryi);

            foreach (var item in l)
            {
                Console.Write(item + " ");
            }
        }
    }
}
