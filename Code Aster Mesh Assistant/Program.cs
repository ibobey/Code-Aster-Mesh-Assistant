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
            /*
            Env.Load();
            string filePath = Environment.GetEnvironmentVariable("FILE_PATH") ?? "";
            MeshReader reader = new MeshReader(filePath);
            reader.GetAllDataFromFile();
            Console.WriteLine(reader.Nodes.Count);
            */

            Node N1 = new Node(1, 0f, 0f, 1f);
            Node N2 = new Node(2, 1f, 4f, 11f);
            Node N3 = new Node(3, 2f, 6f, 12f);
            Node N4 = new Node(4, 3f, 7f, 13f);
            Quad4 quad = new Quad4(1, N1, N2, N3, N4);
            Console.WriteLine(quad.Id);
            Console.WriteLine(N4.Coor_3D);

        }
    }
}