using Code_Aster_Mesh_Assistant.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity
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
        public int Id { get => this._Id; }
        public float X { get => this._X; }
        public float Y { get => this._Y; }
        public float Z { get => this._Z; }
        public (float X, float Y, float Z) Coor_3D { get => (X: this._X, Y: this._Y, Z: this._Z); }
        #endregion

        #region Constructors
        public Node(int Id, float X, float Y, float Z)
        {
            this._Id = Id;
            this._X = X;
            this._Y = Y;
            this._Z = Z;
        }
        #endregion
    }
}
