using Code_Aster_Mesh_Assistant.Entity;
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
        private List<Node> _Nodes = new();
        #endregion

        #region Properties
        public string FilePath { get => this._FilePath; }
        public List<Node> Nodes { get => this._Nodes; }
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

        private static (int Id, float X, float Y, float Z) GetNode(string node_)
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
                throw new System.FormatException($"Invalid Format: '{node_}'");
            }
        }

        #endregion

        #region Mesh Reader
        private IEnumerable<(string Block, string Data)> ReadDataFromFile()
        {
            using var reader = new StreamReader(this._FilePath, encoding: Encoding.ASCII);
            bool capture = false;
            string? line;
            string currentBlock = "";

            while ((line = reader.ReadLine()).Trim() != KeyWords.FIN)
            {
                line = line.Trim();

                if (line.Length == 0) continue;

                if (KeyWords.Keywords.Contains(line))
                {
                    capture = true;
                    currentBlock = line;
                }

                if (line == KeyWords.FINSF) capture = false;

                if (capture)
                {
                    if (currentBlock != line) yield return (Block: currentBlock, Data: line);
                }
            }
        }

        public bool GetAllDataFromFile()
        {
            foreach (var data in ReadDataFromFile())
            {
                if (data.Block == KeyWords.COOR_3D)
                {
                    try
                    {
                        (int Id, float X, float Y, float Z) nodeData = GetNode(data.Data);
                        this._Nodes.Add(new Node(nodeData.Id, nodeData.X, nodeData.Y, nodeData.Z));
                    }
                    catch (System.FormatException) { continue; }
                    catch { throw new Exception("Unknown Format Exception Occured!"); }
                }
            }

            return true;
        }
        #endregion

    }
}
