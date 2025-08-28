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

        public bool CalculateElementQualities()
        {
            foreach (Quad4 quad in this._Quad4s)
            {
                float data = CalculateElementQuality(quad);
                this._ElementQualities.Add(data);
            }
            return true;
        }
        private static float CalculateElementQuality(Quad4 quad4_)
        {
            Vector3 A = new Vector3(quad4_.N1.X, quad4_.N1.Y, quad4_.N1.Z);
            Vector3 B = new Vector3(quad4_.N2.X, quad4_.N2.Y, quad4_.N2.Z);
            Vector3 C = new Vector3(quad4_.N3.X, quad4_.N3.Y, quad4_.N3.Z);
            Vector3 D = new Vector3(quad4_.N4.X, quad4_.N4.Y, quad4_.N4.Z);


            // Kenar vektörleri (float)
            Vector3 AB = B - A;
            Vector3 BC = C - B;
            Vector3 CD = D - C;
            Vector3 DA = A - D;

            // Kenar uzunluklarının karelerinin toplamı
            float sumLen2 = Vector3.Dot(AB, AB) + Vector3.Dot(BC, BC)
                          + Vector3.Dot(CD, CD) + Vector3.Dot(DA, DA);
            if (sumLen2 <= 0f) return 0f;

            // Alan için iki üçgen bölümü: (A,B,C)+(A,C,D) ve (B,C,D)+(B,D,A)
            float area1 = TriangleArea(A, B, C) + TriangleArea(A, C, D);
            float area2 = TriangleArea(B, C, D) + TriangleArea(B, D, A);

            // Daha büyük olan alanı seç
            float area = Math.Max(area1, area2);

            // ANSYS'teki formül: Element Quality ≈ 4*A / sum(l_i^2)  (square için 1)
            float q = (4f * area) / sumLen2;

            // [0,1] aralığına sıkıştır
            if (q < 0f) q = 0f;
            else if (q > 1f) q = 1f;

            return q;
        }
        private static float TriangleArea(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ab = b - a;
            Vector3 ac = c - a;
            Vector3 cross = Vector3.Cross(ab, ac);
            return 0.5f * cross.Length();
        }

        #endregion

        #region Angle Quality
        private static float CalculateAngleQuality(Quad4 quad4_)
        {
            Vector3 A = new Vector3(quad4_.N1.X, quad4_.N1.Y, quad4_.N1.Z);
            Vector3 B = new Vector3(quad4_.N2.X, quad4_.N2.Y, quad4_.N2.Z);
            Vector3 C = new Vector3(quad4_.N3.X, quad4_.N3.Y, quad4_.N3.Z);
            Vector3 D = new Vector3(quad4_.N4.X, quad4_.N4.Y, quad4_.N4.Z);

            static float CornerAngleDeg(Vector3 prev, Vector3 vtx, Vector3 next)
            {
                Vector3 u = Vector3.Normalize(prev - vtx);
                Vector3 v = Vector3.Normalize(next - vtx);
                float cos = (float)Math.Clamp(Vector3.Dot(u, v), -1.0, 1.0);
                return MathF.Acos(cos) * (180.0f / MathF.PI);
            }

            float angA = CornerAngleDeg(D, A, B);
            float angB = CornerAngleDeg(A, B, C);
            float angC = CornerAngleDeg(B, C, D);
            float angD = CornerAngleDeg(C, D, A);

            float minAng = new[] { angA, angB, angC, angD }.Min();
            float maxAng = new[] { angA, angB, angC, angD }.Max();

            const float thetaIdeal = 90.0f;                 // dörtgen için ideal
            float skew = MathF.Max(
                (maxAng - thetaIdeal) / (180.0f - thetaIdeal),
                (thetaIdeal - minAng) / thetaIdeal
            );

            return (float)Math.Clamp(1.0 - skew, 0.0, 1.0);
        }

        public bool CalculateAngleQualities()
        {
            foreach (Quad4 quad in this._Quad4s)
            {
                float data = CalculateAngleQuality(quad);
                this._AngleQualities.Add(data);
            }
            return true;
        }
        #endregion
    }
}
