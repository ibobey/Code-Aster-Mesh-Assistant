using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity.Node
{
    public interface INode
    {
        public int Id { get; }
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public (float X, float Y, float Z) Coor_3D { get; }
    }
}
