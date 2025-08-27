using Code_Aster_Mesh_Assistant.Entity.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity.Elements
{
    public class Seg2
    {
        #region Fields
        private int _Id;
        private List<INode> _Nodes = new();

        private INode _N1;
        private INode _N2;

        #endregion

        #region Properties
        public int Id => this._Id;
        public string Element => KeyWords.SEG2;
        List<INode> Nodes => this._Nodes;

        public INode N1 { get => this._N1; }
        public INode N2 { get => this._N2; }

        #endregion

        #region Constructors
        public Seg2(int Id_, INode N1_, INode N2_)
        {
            this._Id = Id_;
            this._N1 = N1_;
            this._N2 = N2_;
        }
        #endregion
    }
}
