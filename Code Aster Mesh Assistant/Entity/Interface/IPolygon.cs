using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity.Interface
{
    internal interface IPolygon
    {
        public int Id { get; }
        public string Element { get; }
        public List<INode> Nodes { get; }
        public float Area { get; set; }
        public float ElementQuality { get; set; }
        public float AngleQuality { get; set; }

    }
}
