using Code_Aster_Mesh_Assistant.Calculator;
using Code_Aster_Mesh_Assistant.Entity.Elements;
using Code_Aster_Mesh_Assistant.Entity.Node;
using Code_Aster_Mesh_Assistant.Mesh;
using DotNetEnv;

namespace Code_Aster_Mesh_Assistant
{
    class Code_Aster_Mesh_Assistant
    {
        public static void Main(string[] args)
        {
            Env.Load();
            string filePath = Environment.GetEnvironmentVariable("FILE_PATH") ?? "";
            MeshReader reader = new MeshReader(filePath);
            reader.GetAllDataFromFile();
            
            /*
            Console.WriteLine(reader.Nodes.Count);
            Console.WriteLine(reader.Quad4s.Count);
            Console.WriteLine(reader.Tria3s.Count);
            Console.WriteLine(reader.Seg2s.Count);
            */

            /*
            TriangleCalculator tria3Calculator = new TriangleCalculator(tria3s_: reader.Tria3s);
            tria3Calculator.CalculateTriangleAreas();
            Console.WriteLine(tria3Calculator.Areas.Average());

            tria3Calculator.CalculateElementQualities();
            Console.WriteLine(tria3Calculator.ElementQualities.Average());

            tria3Calculator.CalculateAngleQualities();
            Console.WriteLine(tria3Calculator.AngleQualities.Average());
            */

            QuadCalculator quadCalculator = new QuadCalculator(reader.Quad4s);
            quadCalculator.CalculateQuadAreas();
            Console.WriteLine(quadCalculator.Areas.Count);
            Console.WriteLine(quadCalculator.Areas.Average());
            Console.WriteLine(quadCalculator.Areas.Max());
            Console.WriteLine(quadCalculator.Areas.Min());
        }
    }
}