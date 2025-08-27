using Code_Aster_Mesh_Assistant.Entity.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity.Elements
{
    public interface ILine
    {
        public int Id { get; }
        public string Element { get; }
        public List<INode> Nodes { get; }

    }
}
