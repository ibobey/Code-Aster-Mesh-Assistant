using Code_Aster_Mesh_Assistant.Calculator;
using Code_Aster_Mesh_Assistant.Calculator.Elements;
using Code_Aster_Mesh_Assistant.Entity.Elements;
using Code_Aster_Mesh_Assistant.Entity.Node;
using Code_Aster_Mesh_Assistant.Mesh;
using DotNetEnv;
using System.Diagnostics;

namespace Code_Aster_Mesh_Assistant
{
    class Code_Aster_Mesh_Assistant
    {
        public static void Main(string[] args)
        {

            Env.Load();
            string filePath = Environment.GetEnvironmentVariable("FILE_PATH") ?? "";

            Stopwatch sw = Stopwatch.StartNew();
            MeshReader reader = new MeshReader(filePath);

            MetricCalculator calculator = new MetricCalculator(meshReader_: reader);
            calculator.CalculateAll();
            sw.Stop();


            foreach (var key in calculator.MetricData) Console.WriteLine($"{key.Key} : {Math.Round(key.Value, 4)}");

            Console.WriteLine($"Süre: {sw.Elapsed.TotalSeconds} s");
            Console.WriteLine($"Hassas ölçüm: {sw.Elapsed.TotalMilliseconds} ms");
        }

        public static void CalculateAll()
        {
            /*
            Env.Load();
            string filePath = Environment.GetEnvironmentVariable("FILE_PATH") ?? "";
            MeshReader reader = new MeshReader(filePath);
            reader.GetAllDataFromFile();

            Console.WriteLine("<--- * General Data * --->\n");

            Console.WriteLine($"Nodes: {reader.Nodes.Count}");
            Console.WriteLine($"Quad4s: {reader.Quad4s.Count}");
            Console.WriteLine($"Tria3s: {reader.Tria3s.Count}");
            Console.WriteLine($"Seg2s: {reader.Seg2s.Count}");
            Console.WriteLine($"Total: {reader.Seg2s.Count + reader.Tria3s.Count + reader.Quad4s.Count}");
            Console.WriteLine("");

            Console.WriteLine("<--- * Triangle Data * --->\n");

            TriangleCalculator tria3Calculator = new TriangleCalculator(tria3s_: reader.Tria3s);
            tria3Calculator.CalculateTriangleAreas();
            Console.WriteLine($"Tria3 Area Min: {tria3Calculator.Areas.Min()}");
            Console.WriteLine($"Tria3 Area Max: {tria3Calculator.Areas.Max()}");
            Console.WriteLine($"Tria3 Area Avg: {tria3Calculator.Areas.Average()}");
            Console.WriteLine($"Tria3 Area Sum: {tria3Calculator.Areas.Sum()}");

            tria3Calculator.CalculateElementQualities();
            Console.WriteLine($"Tria3 EQ Min: {tria3Calculator.ElementQualities.Min()}");
            Console.WriteLine($"Tria3 EQ Max: {tria3Calculator.ElementQualities.Max()}");
            Console.WriteLine($"Tria3 EQ Avg: {tria3Calculator.ElementQualities.Average()}");

            tria3Calculator.CalculateAngleQualities();
            Console.WriteLine($"Tria3 AQ Min: {tria3Calculator.AngleQualities.Min()}");
            Console.WriteLine($"Tria3 AQ Max: {tria3Calculator.AngleQualities.Max()}");
            Console.WriteLine($"Tria3 AQ Avg: {tria3Calculator.AngleQualities.Average()}");
            Console.WriteLine("");
            
            Console.WriteLine("<--- * Quad Data * --->\n");
            
            QuadCalculator quadCalculator = new QuadCalculator(reader.Quad4s);
            quadCalculator.CalculateQuadAreas();
            Console.WriteLine($"Quad4 Area Min: {quadCalculator.Areas.Min()}");
            Console.WriteLine($"Quad4 Area Max: {quadCalculator.Areas.Max()}");
            Console.WriteLine($"Quad4 Area Avg: {quadCalculator.Areas.Average()}");
            Console.WriteLine($"Quad4 Area Sum: {quadCalculator.Areas.Sum()}");

            quadCalculator.CalculateElementQualities();
            Console.WriteLine($"Quad4 EQ Min: {quadCalculator.ElementQualities.Min()}");
            Console.WriteLine($"Quad4 EQ Max: {quadCalculator.ElementQualities.Max()}");
            Console.WriteLine($"Quad4 EQ Avg: {quadCalculator.ElementQualities.Average()}");

            quadCalculator.CalculateAngleQualities();
            Console.WriteLine($"Quad4 AQ Min: {quadCalculator.AngleQualities.Min()}");
            Console.WriteLine($"Quad4 AQ Max: {quadCalculator.AngleQualities.Max()}");
            Console.WriteLine($"Quad4 AQ Avg: {quadCalculator.AngleQualities.Average()}");

            Console.WriteLine("<--- * All * --->\n");
            */



        }
    }
}