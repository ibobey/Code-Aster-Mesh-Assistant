using Code_Aster_Mesh_Assistant.Calculator.Elements;
using Code_Aster_Mesh_Assistant.Entity.Elements;
using Code_Aster_Mesh_Assistant.Mesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Calculator
{
    public class MetricCalculator
    {
        #region Fields
        MeshReader _meshReader;
        TriangleCalculator? _tria3Calculator;
        QuadCalculator? _quad4Calculator;
        Dictionary<string, double> _metricData = new();
        #endregion

        #region Properties
        public List<Quad4> Quad4s { get => this._meshReader.Quad4s; }
        public List<Tria3> Tria3s { get => this._meshReader.Tria3s; }
        public List<Seg2> Seg2s { get => this._meshReader.Seg2s; }
        public Dictionary<string, double> MetricData { get => this._metricData; }
        #endregion

        #region Constructors
        public MetricCalculator(MeshReader meshReader_)
        {
            this._meshReader = meshReader_;
            Setup();
        }
        #endregion

        #region Setup
        private bool Setup()
        {
            if (!this._meshReader.GetAllDataFromFile()) throw new InvalidOperationException("ERROR 201");
            this._tria3Calculator = new TriangleCalculator(tria3s_: this._meshReader.Tria3s);
            this._quad4Calculator = new QuadCalculator(quad4s_: this._meshReader.Quad4s);

            this._metricData["Node"] = this._meshReader.Nodes.Count;
            this._metricData["Quad4"] = this._meshReader.Quad4s.Count;
            this._metricData["Tria3"] = this._meshReader.Tria3s.Count;
            this._metricData["Seg2"] = this._meshReader.Seg2s.Count;
            this._metricData["Total"] = this._meshReader.Seg2s.Count + this._meshReader.Quad4s.Count + this._meshReader.Tria3s.Count;

            return true;
        }
        #endregion

        #region Calculate All
        public bool CalculateAll()
        {
            /* TRIA3*/
            this._tria3Calculator.CalculateAll();
            this._metricData["Tria3_Area_Min"] = this._tria3Calculator.Areas.Min();
            this._metricData["Tria3_Area_Max"] = this._tria3Calculator.Areas.Max();
            this._metricData["Tria3_Area_Avg"] = this._tria3Calculator.Areas.Average();
            this._metricData["Tria3_Area_Sum"] = this._tria3Calculator.Areas.Sum();

            this._metricData["Tria3_EQ_Min"] = this._tria3Calculator.ElementQualities.Min();
            this._metricData["Tria3_EQ_Max"] = this._tria3Calculator.ElementQualities.Max();
            this._metricData["Tria3_EQ_Avg"] = this._tria3Calculator.ElementQualities.Average();

            this._metricData["Tria3_AQ_Min"] = this._tria3Calculator.AngleQualities.Min();
            this._metricData["Tria3_AQ_Max"] = this._tria3Calculator.AngleQualities.Max();
            this._metricData["Tria3_AQ_Avg"] = this._tria3Calculator.AngleQualities.Average();

            /* QUAD4 */
            this._quad4Calculator.CalculateAll();
            this._metricData["Quad4_Area_Min"] = this._quad4Calculator.Areas.Min();
            this._metricData["Quad4_Area_Max"] = this._quad4Calculator.Areas.Max();
            this._metricData["Quad4_Area_Avg"] = this._quad4Calculator.Areas.Average();
            this._metricData["Quad4_Area_Sum"] = this._quad4Calculator.Areas.Sum();

            this._metricData["Quad4_EQ_Min"] = this._quad4Calculator.ElementQualities.Min();
            this._metricData["Quad4_EQ_Max"] = this._quad4Calculator.ElementQualities.Max();
            this._metricData["Quad4_EQ_Avg"] = this._quad4Calculator.ElementQualities.Average();

            this._metricData["Quad4_AQ_Min"] = this._quad4Calculator.AngleQualities.Min();
            this._metricData["Quad4_AQ_Max"] = this._quad4Calculator.AngleQualities.Max();
            this._metricData["Quad4_AQ_Avg"] = this._quad4Calculator.AngleQualities.Average();

            /* Total */

            this._metricData["T_Area_Min"] = Math.Max(this._metricData["Quad4_Area_Min"], this._metricData["Tria3_Area_Min"]);
            this._metricData["T_Area_Max"] = Math.Max(this._metricData["Quad4_Area_Max"], this._metricData["Tria3_Area_Max"]);
            this._metricData["T_Area_Avg"] = CalculateMean(
                this._metricData["Quad4_Area_Avg"], this.Quad4s.Count,
                this._metricData["Tria3_Area_Avg"], this.Tria3s.Count);
            this._metricData["T_Area_Total"] = this._metricData["Quad4_Area_Sum"] + this._metricData["Tria3_Area_Sum"];


            this._metricData["T_EQ_Min"] = Math.Max(this._metricData["Quad4_EQ_Min"], this._metricData["Tria3_EQ_Min"]);
            this._metricData["T_EQ_Max"] = Math.Max(this._metricData["Quad4_EQ_Max"], this._metricData["Tria3_EQ_Max"]);
            this._metricData["T_EQ_Avg"] = CalculateMean(
                this._metricData["Quad4_EQ_Avg"], this.Quad4s.Count,
                this._metricData["Tria3_EQ_Avg"], this.Tria3s.Count);


            this._metricData["T_AQ_Min"] = Math.Max(this._metricData["Quad4_AQ_Min"], this._metricData["Tria3_AQ_Min"]);
            this._metricData["T_AQ_Max"] = Math.Max(this._metricData["Quad4_AQ_Max"], this._metricData["Tria3_AQ_Max"]);
            this._metricData["T_AQ_Avg"] = CalculateMean(
                this._metricData["Quad4_AQ_Avg"], this.Quad4s.Count,
                this._metricData["Tria3_AQ_Avg"], this.Tria3s.Count);

            return true;
        }
        #endregion

        #region Helper Methods
        private static double CalculateMean(double M1, int N1, double M2, int N2)
        {
            return (M1 * N1 + M2 * N2) / (N1 + N2);
        }
        #endregion
    }
}
