using Code_Aster_Mesh_Assistant.Calculator.Elements;
using Code_Aster_Mesh_Assistant.Entity;
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
        Dictionary<string, MetricData> _metricData = new();
        MeshData _meshData = new();
        #endregion

        #region Properties
        public List<Quad4> Quad4s { get => this._meshReader.Quad4s; }
        public List<Tria3> Tria3s { get => this._meshReader.Tria3s; }
        public List<Seg2> Seg2s { get => this._meshReader.Seg2s; }
        public Dictionary<string, MetricData> MetricData { get => this._metricData; }
        public MeshData MeshData { get => this._meshData; }
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

            this._meshData = new MeshData
            {
                Node = this._meshReader.Nodes.Count,
                Seg2 = this._meshReader.Seg2s.Count,
                Tria3 = this._meshReader.Tria3s.Count,
                Quad4 = this._meshReader.Quad4s.Count

            };
            return true;
        }
        #endregion

        #region Calculate All
        public bool CalculateAll()
        {
            this._tria3Calculator.CalculateAll();
            this._quad4Calculator.CalculateAll();

            MetricData tria3MetricData = new MetricData
            {
                ElementName = KeyWords.TRIA3,
                TotalElementCount = this._meshReader.Tria3s.Count,

                Area = (Min: this._tria3Calculator.Areas.Min(),
                        Max: this._tria3Calculator.Areas.Max(),
                        Avg: this._tria3Calculator.Areas.Average(),
                        Sum: this._tria3Calculator.Areas.Sum()),

                Eq = (Min: this._tria3Calculator.ElementQualities.Min(),
                      Max: this._tria3Calculator.ElementQualities.Max(),
                      Avg: this._tria3Calculator.ElementQualities.Average()),

                Aq = (Min: this._tria3Calculator.AngleQualities.Min(),
                      Max: this._tria3Calculator.AngleQualities.Max(),
                      Avg: this._tria3Calculator.AngleQualities.Average())
            };

            this._metricData[KeyWords.TRIA3] = tria3MetricData;

            MetricData quad4MetricData = new MetricData
            {
                ElementName = KeyWords.QUAD4,
                TotalElementCount = this._meshReader.Quad4s.Count,

                Area = (Min: this._quad4Calculator.Areas.Min(),
                        Max: this._quad4Calculator.Areas.Max(),
                        Avg: this._quad4Calculator.Areas.Average(),
                        Sum: this._quad4Calculator.Areas.Sum()),

                Eq = (Min: this._quad4Calculator.ElementQualities.Min(),
                      Max: this._quad4Calculator.ElementQualities.Max(),
                      Avg: this._quad4Calculator.ElementQualities.Average()),

                Aq = (Min: this._quad4Calculator.AngleQualities.Min(),
                      Max: this._quad4Calculator.AngleQualities.Max(),
                      Avg: this._quad4Calculator.AngleQualities.Average())
            };
            this._metricData[KeyWords.QUAD4] = quad4MetricData;

            MetricData totalMetricData = new MetricData
            {
                ElementName = KeyWords.TOTAL,
                TotalElementCount = this._meshReader.Quad4s.Count,

                Area = (Min: Math.Min(quad4MetricData.Area.Min, tria3MetricData.Area.Min),
                        Max: Math.Max(quad4MetricData.Area.Max, tria3MetricData.Area.Max),
                        Avg: CalculateMean(quad4MetricData.Area.Avg, this.Quad4s.Count, tria3MetricData.Area.Avg, this.Tria3s.Count),
                        Sum: quad4MetricData.Area.Sum + tria3MetricData.Area.Sum),

                Eq = (Min: Math.Min(quad4MetricData.Eq.Min, tria3MetricData.Eq.Min),
                      Max: Math.Max(quad4MetricData.Eq.Max, tria3MetricData.Eq.Max),
                      Avg: CalculateMean(quad4MetricData.Eq.Avg, this.Quad4s.Count, tria3MetricData.Eq.Avg, this.Tria3s.Count)),

                Aq = (Min: Math.Min(quad4MetricData.Aq.Min, tria3MetricData.Aq.Min),
                      Max: Math.Max(quad4MetricData.Aq.Max, tria3MetricData.Aq.Max),
                      Avg: CalculateMean(quad4MetricData.Aq.Avg, this.Quad4s.Count, tria3MetricData.Aq.Avg, this.Tria3s.Count))
            };
            this._metricData[KeyWords.TOTAL] = totalMetricData;

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
