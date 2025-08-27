using Code_Aster_Mesh_Assistant.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity.Node
{
    public class Node : INode
    {
        #region Fields
        private int _Id;
        private float _X;
        private float _Y;
        private float _Z;
        private (float X, float Y, float Z) _Coor_3D;
        #endregion

        #region Properties
        public int Id { get => _Id; }
        public float X { get => _X; }
        public float Y { get => _Y; }
        public float Z { get => _Z; }
        public (float X, float Y, float Z) Coor_3D { get => (X: _X, Y: _Y, Z: _Z); }
        #endregion

        #region Constructors
        public Node(int Id, float X, float Y, float Z)
        {
            _Id = Id;
            _X = X;
            _Y = Y;
            _Z = Z;
        }
        #endregion
    }
}
