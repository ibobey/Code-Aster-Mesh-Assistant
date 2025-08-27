using Code_Aster_Mesh_Assistant.Entity.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity.Elements
{
    public class Quad4 : IPolygon
    {
        #region Fields
        private int _Id;
        private float _Area;
        private float _ElementQuality;
        private float _AngleQuality;
        private List<INode> _Nodes = new();

        private INode _N1;
        private INode _N2;
        private INode _N3;
        private INode _N4;
        #endregion

        #region Properties
        public int Id => this._Id;
        public string Element => KeyWords.QUAD4;
        public float Area { get => this._Area; set => this._Area = value; }
        public float ElementQuality { get => this._ElementQuality; set => this._ElementQuality = value; }
        public float AngleQuality { get => this._AngleQuality; set => this._AngleQuality = value; }
        List<INode> IPolygon.Nodes => this._Nodes;

        public INode N1 { get => this._N1; }
        public INode N2 { get => this._N2; }
        public INode N3 { get => this._N3; }
        public INode N4 { get => this._N4; }

        #endregion

        #region Constructors
        public Quad4(int Id_, INode N1_, INode N2_, INode N3_, INode N4_ )
        {
            this._Id = Id_;
            this._N1 = N1_;
            this._N2 = N2_;
            this._N3 = N3_;
            this._N4 = N4_;
        }
        #endregion
    }
}
