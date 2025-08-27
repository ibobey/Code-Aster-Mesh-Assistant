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
            Console.WriteLine($"FILE_PATH: {filePath}");
            MeshReader reader = new MeshReader(filePath);
            Console.WriteLine("Test");
        }
    }
}