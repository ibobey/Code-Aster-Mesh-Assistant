using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Mesh
{
    public class MeshReader
    {
        #region Fields
        private string _FilePath;
        #endregion

        #region Properties
        public string FilePath { get => this._FilePath; }
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

        #region Reader

        #endregion

    }
}
