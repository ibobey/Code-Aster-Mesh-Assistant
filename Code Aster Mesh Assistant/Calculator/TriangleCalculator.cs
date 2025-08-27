using Code_Aster_Mesh_Assistant.Entity.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Calculator
{
    public class TriangleCalculator
    {
        #region Fields
        private List<Tria3> _Tria3s = new();
        private List<float> _Areas = new();
        #endregion

        #region Properties
        public List<Tria3> Tria3s { get => this._Tria3s; }
        public List<float> Areas { get => this._Areas; }
        #endregion

        #region Constructors
        public TriangleCalculator(List<Tria3> tria3s_)
        {
            this._Tria3s = tria3s_;
        }
        #endregion

        #region Calculate Area
        private static float CalculateTriangleArea(Tria3 tria3)
        {
            Vector3 A = new Vector3(tria3.N1.X, tria3.N1.Y, tria3.N1.Z);
            Vector3 B = new Vector3(tria3.N2.X, tria3.N2.Y, tria3.N2.Z);
            Vector3 C = new Vector3(tria3.N3.X, tria3.N3.Y, tria3.N3.Z);

            Vector3 AB = B - A;
            Vector3 AC = C - A;

            Vector3 cross = Vector3.Cross(AB, AC);
            float area = 0.5f * cross.Length();

            return area;
        }

        public bool CalculateTriangleAreas()
        {
            foreach (Tria3 tria3 in _Tria3s)
            {
                float area_ = CalculateTriangleArea(tria3);
                this._Areas.Add(area_);
            }
            return true;
        }

        #endregion
    }
}
