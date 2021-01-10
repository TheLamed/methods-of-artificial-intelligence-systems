using Methods_of_artificial_intelligence_systemsML.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L9
{
    class Program
    {
        public static readonly Dictionary<int, string> Games = new Dictionary<int, string>
        {
            { 0, "football" },
            { 1, "basketball" },
            { 2, "tenis" },
            { 3, "pingpong" },
            { 4, "badminton" },
            { 5, "baseball" },
            { 6, "bowling" },
            { 7, "chess" },
            { 8, "voleyball" },
            { 9, "golf" },
        };

        static void Main(string[] args)
        {
            ModelInput input = new ModelInput();

            Console.WriteLine("Chose item:");
            Console.WriteLine("0 - ball");
            Console.WriteLine("1 - small ball");
            Console.WriteLine("2 - volanchyk");
            Console.WriteLine("3 - figures");
            input.Item = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter count of players: ");
            input.PlayersCount = float.Parse(Console.ReadLine());

            Console.WriteLine("Is it team game (0 - yes, 1 - no)?");
            input.Comand = float.Parse(Console.ReadLine());

            Console.WriteLine("Size of the area:");
            Console.WriteLine("0 - big");
            Console.WriteLine("1 - medium");
            Console.WriteLine("2 - small");
            Console.WriteLine("3 - none");
            Console.WriteLine("4 - table");
            input.AreaSize = float.Parse(Console.ReadLine());

            Console.WriteLine("Is there any net on the area? (0 - yes, 1 - no)");
            input.Net = float.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Loading...\n");

            var result = ConsumeModel.Predict(input);

            Console.Clear();

            Console.WriteLine($"Game is - {result.Prediction} ({Math.Round(result.Score.Max() * 10000) / 100}%)\n");

            for (int i = 0; i < result.Score.Length; i++)
            {
                Console.WriteLine($"{Games[i]} - {Math.Round(result.Score[i] * 10000) / 100}%");
            }
        }
    }
}
