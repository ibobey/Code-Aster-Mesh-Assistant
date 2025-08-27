using Code_Aster_Mesh_Assistant.Entity.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Calculator
{
    public class QuadCalculator
    {
        #region Fields
        private List<Quad4> _Quad4s = new();
        private List<float> _Areas = new();
        private List<float> _ElementQualities = new();
        private List<float> _AngleQualities = new();
        #endregion

        #region Properties
        public List<Quad4> Tria3s { get => this._Quad4s; }
        public List<float> Areas { get => this._Areas; }
        public List<float> ElementQualities { get => this._ElementQualities; }
        public List<float> AngleQualities { get => this._AngleQualities; }
        #endregion

        #region Constructors
        public QuadCalculator(List<Quad4> quad4s_)
        {
            this._Quad4s = quad4s_;
        }
        #endregion

        #region Calculate Area
        private static float CalculateQuadArea(Quad4 quad4_)
        {
            Vector3 A = new Vector3(quad4_.N1.X, quad4_.N1.Y, quad4_.N1.Z);
            Vector3 B = new Vector3(quad4_.N2.X, quad4_.N2.Y, quad4_.N2.Z);
            Vector3 C = new Vector3(quad4_.N3.X, quad4_.N3.Y, quad4_.N3.Z);
            Vector3 D = new Vector3(quad4_.N4.X, quad4_.N4.Y, quad4_.N4.Z);

            static float TriArea(Vector3 P0, Vector3 P1, Vector3 P2)
                                 => 0.5f * Vector3.Cross(P1 - P0, P2 - P0).Length();
            float area_AC = TriArea(A, B, C) + TriArea(A, C, D); // AC köşegeni
            float area_BD = TriArea(B, C, D) + TriArea(B, D, A); // BD köşegeni

            return 0.5f * (area_AC + area_BD);
        }

        public bool CalculateQuadAreas()
        {
            foreach (Quad4 quad in this._Quad4s)
            {
                float area_ = CalculateQuadArea(quad);
                this._Areas.Add(area_);
            }
            return true;
        }

        #endregion

        #region Element Quality

        private static float CalculateElementQuality(Quad4 quad4_)
        {
            return 0f;
        }
        public bool CalculateElementQualities()
        {

            return true;
        }

        #endregion

        #region Angle Quality
        private static float CalculateAngleQuality()
        {
            return 0f;
        }

        public bool CalculateAngleQualities(Quad4 quad4_)
        {

            return true;
        }
        #endregion
    }
}
