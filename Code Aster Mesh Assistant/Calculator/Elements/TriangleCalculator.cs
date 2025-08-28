using Code_Aster_Mesh_Assistant.Entity.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Calculator.Elements
{
    internal class TriangleCalculator
    {
        #region Fields
        private List<Tria3> _Tria3s = new();
        private List<float> _Areas = new();
        private List<float> _ElementQualities = new();
        private List<float> _AngleQualities = new();
        #endregion

        #region Properties
        public List<Tria3> Tria3s { get => _Tria3s; }
        public List<float> Areas { get => _Areas; }
        public List<float> ElementQualities { get => _ElementQualities; }
        public List<float> AngleQualities { get => _AngleQualities; }
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

        private bool CalculateTriangleAreas()
        {
            foreach (Tria3 tria3 in _Tria3s)
            {
                float area_ = CalculateTriangleArea(tria3);
                _Areas.Add(area_);
            }
            return true;
        }

        #endregion

        #region Element Quality

        private static float CalculateElementQuality(Tria3 tria3)
        {
            Vector3 A = new Vector3(tria3.N1.X, tria3.N1.Y, tria3.N1.Z);
            Vector3 B = new Vector3(tria3.N2.X, tria3.N2.Y, tria3.N2.Z);
            Vector3 C = new Vector3(tria3.N3.X, tria3.N3.Y, tria3.N3.Z);

            float a = Vector3.Distance(B, C);
            float b = Vector3.Distance(A, C);
            float c = Vector3.Distance(A, B);

            Vector3 AB = B - A;
            Vector3 AC = C - A;
            float area = 0.5f * Vector3.Cross(AB, AC).Length();

            float Q = 4.0f * MathF.Sqrt(3.0f) * area / (a * a + b * b + c * c);
            return Q;
        }
        private bool CalculateElementQualities()
        {
            foreach (Tria3 tria3 in _Tria3s)
            {
                float eq_ = CalculateElementQuality(tria3);
                _ElementQualities.Add(eq_);
            }

            return true;
        }

        #endregion

        #region Angle Quality
        private static float CalculateAngleQuality(Tria3 tria3)
        {
            Vector3 A = new Vector3(tria3.N1.X, tria3.N1.Y, tria3.N1.Z);
            Vector3 B = new Vector3(tria3.N2.X, tria3.N2.Y, tria3.N2.Z);
            Vector3 C = new Vector3(tria3.N3.X, tria3.N3.Y, tria3.N3.Z);

            float a = Vector3.Distance(B, C);
            float b = Vector3.Distance(A, C);
            float c = Vector3.Distance(A, B);

            float angleA = MathF.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180.0f / MathF.PI);
            float angleB = MathF.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180.0f / MathF.PI);
            float angleC = MathF.Acos((a * a + b * b - c * c) / (2 * a * b)) * (180.0f / MathF.PI);

            float minAngle = new[] { angleA, angleB, angleC }.Min();
            float maxAngle = new[] { angleA, angleB, angleC }.Max();

            float skewness = MathF.Max(
                (maxAngle - 60.0f) / (180.0f - 60.0f),
                (60.0f - minAngle) / 60.0f
            );

            return 1.0f - skewness;
        }
        
        private bool CalculateAngleQualities()
        {
            foreach (Tria3 tria3 in _Tria3s)
            {
                float aq_ = CalculateAngleQuality(tria3);
                _AngleQualities.Add(aq_);
            }
            return true;
        }
        #endregion

        #region Calculate All
        public bool CalculateAll()
        {
            CalculateTriangleAreas();
            CalculateElementQualities();
            CalculateAngleQualities();
            return true;
        }
        #endregion
    }
}
