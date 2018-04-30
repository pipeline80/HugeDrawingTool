using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HugeDrawingTool;

namespace HugeDrawingToolTest
{
    [TestClass]
    public class DrawingToolTest
    {
        [TestMethod]
        public void ValidData()
        {
            DrawingTool cnv = new DrawingTool(20, 4);
            string result = string.Empty;

            cnv.DrawCanvas();
            cnv.DrawLine(new string[] { "1", "2", "6", "2" });
            cnv.DrawLine(new string[] { "6", "3", "6", "4" });
            cnv.DrawRectangle(new string[] { "16", "1", "20", "3" });
            cnv.FillCanvas(10, 3, "o");

            Console.WriteLine(cnv.DrawArray(cnv.Canvas));
        }

        [TestMethod]
        public void WrongData()
        {
            DrawingTool cnv = new DrawingTool(20, 4);
            string result = string.Empty;

            while (true)
            {
                if (!cnv.DrawCanvas())
                    break;
                if (!cnv.DrawLine(new string[] { "1", "2", "6", "2" }))
                    break;
                if (!cnv.DrawLine(new string[] { "6", "3", "25", "4" }))
                    break;
                if (!cnv.DrawRectangle(new string[] { "16", "1", "20", "50" }))
                    break;
                if (!cnv.FillCanvas(10, 3, "o"))
                    break;
            }

            Console.WriteLine(cnv.dtObj.Result);
        }

        [TestMethod]
        public void DrawingValidData()
        {
            DrawingTool cnv = new DrawingTool();

            string result = string.Empty;

            string[] commands = new string[5];
            commands[0] = "C 20 4";
            commands[1] = "L 1 2 6 2";
            commands[2] = "L 6 3 6 4";
            commands[3] = "R 16 1 20 3";
            commands[4] = "B 10 3 o";

            Console.WriteLine(cnv.Draw(commands));
        }

        [TestMethod]
        public void DrawingWrongData()
        {
            DrawingTool cnv = new DrawingTool();

            string result = string.Empty;

            string[] commands = new string[5];
            commands[0] = "C 20 30";
            commands[1] = "L 1 2 6 2";
            commands[2] = "L 6 3 25 4";
            commands[3] = "R 16 1 20 50";
            commands[4] = "B 1 1";

            Console.WriteLine(cnv.Draw(commands));
        }

        [TestMethod]
        public void DrawingFile()
        {
            DrawingToolFileHelper dt = new DrawingToolFileHelper();

            string result = string.Empty;

            Console.WriteLine(dt.DrawingToolFile());
        }
    }
}
