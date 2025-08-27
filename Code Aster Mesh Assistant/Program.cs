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
            var data = MeshReader.GetNode("N1 -2.94243156 -4.24992688 4.24992688");
            Console.WriteLine(data);
        }
    }
}