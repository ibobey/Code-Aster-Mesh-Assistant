using Code_Aster_Mesh_Assistant.Entity.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static float CalculateTriangleArea(Quad4 quad4_)
        {
            

            return 0f;
        }

        public bool CalculateQuadAreas()
        {
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
