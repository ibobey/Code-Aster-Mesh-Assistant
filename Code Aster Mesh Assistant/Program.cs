using Code_Aster_Mesh_Assistant.Entity;

namespace Code_Aster_Mesh_Assistant
{
    class Code_Aster_Mesh_Assistant
    {
        public static void Main(string[] args)
        {
            Node node = new Node(Id: 1, X: 1.1f, Y: 1.2f, Z: 1.3f);
            Console.WriteLine(node.Coor_3D);
            
        }
    }
}