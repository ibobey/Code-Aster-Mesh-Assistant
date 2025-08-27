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
            Console.WriteLine(reader.Nodes.Count);
            Console.WriteLine(reader.Quad4s.Count);
            Console.WriteLine(reader.Tria3s.Count);


        }
    }
}