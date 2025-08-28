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
            
            Console.WriteLine(calculator.MeshData.Total);
            foreach (var data in calculator.MetricData) Console.WriteLine($"{data.Key}{data.Value}");
        }
    }
}