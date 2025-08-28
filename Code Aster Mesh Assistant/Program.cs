using Code_Aster_Mesh_Assistant.Calculator;
using Code_Aster_Mesh_Assistant.Calculator.Elements;
using Code_Aster_Mesh_Assistant.Entity;
using Code_Aster_Mesh_Assistant.Entity.Elements;
using Code_Aster_Mesh_Assistant.Entity.Node;
using Code_Aster_Mesh_Assistant.Mesh;
using ConsoleTables;
using DotNetEnv;
using System.Diagnostics;

namespace Code_Aster_Mesh_Assistant
{
    class Code_Aster_Mesh_Assistant
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Env.Load();
            string filePath = Environment.GetEnvironmentVariable("FILE_PATH") ?? "";

            Stopwatch sw = Stopwatch.StartNew();
            MeshReader reader = new MeshReader(filePath);

            MetricCalculator calculator = new MetricCalculator(meshReader_: reader);
            calculator.CalculateAll();
            sw.Stop();

            Console.WriteLine("<------- ~~* General Mesh Data *~~ ------->");

            var table = new ConsoleTable("Data", "Count");
            table.AddRow(nameof(calculator.MeshData.Node), calculator.MeshData.Node.ToString("#,##"))
                 .AddRow(nameof(calculator.MeshData.Quad4), calculator.MeshData.Quad4.ToString("#,##"))
                 .AddRow(nameof(calculator.MeshData.Tria3), calculator.MeshData.Tria3.ToString("#,##"))
                 .AddRow(nameof(calculator.MeshData.Seg2), calculator.MeshData.Seg2.ToString("#,##"))
                 .AddRow(nameof(calculator.MeshData.Total), calculator.MeshData.Total.ToString("#,##"))
                 .Configure(o => o.NumberAlignment = Alignment.Right)
                 .Write(Format.Alternative);

            Console.WriteLine("<------- ~~* General Metric Data *~~ ------->");


            var table2 = new ConsoleTable(KeyWords.TOTAL, "Min", "Max", "Avg", "Sum");
            table2.AddRow(
                    $"Area",
                        calculator.MetricData[KeyWords.TOTAL].Area.Min.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Area.Max.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Area.Avg.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Area.Sum.ToString("F4"))
                .AddRow(
                    $"EQ",
                        calculator.MetricData[KeyWords.TOTAL].Eq.Min.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Eq.Max.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Eq.Avg.ToString("F4"),
                        "-")
                .AddRow(
                    $"AQ",
                        calculator.MetricData[KeyWords.TOTAL].Aq.Min.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Aq.Max.ToString("F4"),
                        calculator.MetricData[KeyWords.TOTAL].Aq.Avg.ToString("F4"),
                        "-")
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);
            
            Console.WriteLine("<------- ~~* QUAD4 Metric Data *~~ ------->");

            var table3 = new ConsoleTable(KeyWords.QUAD4, "Min", "Max", "Avg", "Sum");
            table3.AddRow(
                $"Area",
                    calculator.MetricData[KeyWords.QUAD4].Area.Min.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Area.Max.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Area.Avg.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Area.Sum.ToString("F4"))
            .AddRow(
                $"EQ",
                    calculator.MetricData[KeyWords.QUAD4].Eq.Min.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Eq.Max.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Eq.Avg.ToString("F4"),
                    "-")
            .AddRow(
                $"AQ",
                    calculator.MetricData[KeyWords.QUAD4].Aq.Min.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Aq.Max.ToString("F4"),
                    calculator.MetricData[KeyWords.QUAD4].Aq.Avg.ToString("F4"),
                    "-")
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(Format.Alternative);

            Console.WriteLine("<------- ~~* TRIA3 Metric Data *~~ ------->");

            var table4 = new ConsoleTable(KeyWords.TRIA3, "Min", "Max", "Avg", "Sum");
            table4.AddRow(
                $"Area",
                    calculator.MetricData[KeyWords.TRIA3].Area.Min.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Area.Max.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Area.Avg.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Area.Sum.ToString("F4"))
            .AddRow(
                $"EQ",
                    calculator.MetricData[KeyWords.TRIA3].Eq.Min.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Eq.Max.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Eq.Avg.ToString("F4"),
                    "-")
            .AddRow(
                $"AQ",
                    calculator.MetricData[KeyWords.TRIA3].Aq.Min.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Aq.Max.ToString("F4"),
                    calculator.MetricData[KeyWords.TRIA3].Aq.Avg.ToString("F4"),
                    "-")
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(Format.Alternative);

            Console.WriteLine($"Calculation Time: {sw.Elapsed.TotalSeconds} s");
            Console.ResetColor();

        }
    }
}