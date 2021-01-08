using System;
using System.Collections.Generic;
using System.Linq;
using Methods_of_artificial_intelligence_systemsML.Model;

namespace NeuroNetworkImages
{
    class Program
    {
        public static readonly Dictionary<int, string> Shapes = new Dictionary<int, string>
        {
            { 0, "Circle" },
            { 1, "Diamond" },
            { 2, "Square" }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Chose your image: ");

            var path = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Loading...\n");

            ModelInput image = new ModelInput()
            {
                ImageSource = path,
            };

            var result = ConsumeModel.Predict(image);

            Console.Clear();

            Console.WriteLine($"Choosen image - {result.Prediction} ({Math.Round(result.Score.Max() * 10000) / 100}%)\n");

            for (int i = 0; i < result.Score.Length; i++)
            {
                Console.WriteLine($"{Shapes[i]} - {Math.Round(result.Score[i] * 10000) / 100}%");
            }
        }
    }
}
