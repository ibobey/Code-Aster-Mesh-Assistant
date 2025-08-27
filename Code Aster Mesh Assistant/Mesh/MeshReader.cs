using Code_Aster_Mesh_Assistant.Entity.Node;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Mesh
{
    public class MeshReader
    {
        #region Fields
        private string _FilePath;
        private List<Node> _nodes = new();
        #endregion

        #region Properties
        public string FilePath { get => this._FilePath; }
        public List<Node> Nodes { get => this._nodes; }
        #endregion


        #region Constructors
        public MeshReader(string filePath)
        {
            this._FilePath = filePath;
            IsFileExists();
        }
        #endregion

        #region Helper Methods
        public bool IsFileExists()
        {
            if (File.Exists(this._FilePath)) return true;
            throw new FileNotFoundException($"There is no file or file path {this._FilePath}");
        }
        #endregion

        #region Node & Element Reader

        public static (int Id, float X, float Y, float Z) GetNode(string node_)
        {
            try
            {
                node_ = node_.Replace("N", "");
                var values = node_
                    .Split((char[])null!, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => float.Parse(x, CultureInfo.InvariantCulture))
                    .ToList();

                var result = (Id: Convert.ToInt32(values[0]), X: values[1], Y: values[2], Z: values[3]);
                return result;
            }
            catch (System.FormatException)
            {
                throw new System.InvalidOperationException($"Invalid Format: '{node_}'");
            }
        }

        #endregion

        #region Mesh Reader
        
        #endregion

    }
}
