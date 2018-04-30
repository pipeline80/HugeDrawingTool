using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HugeDrawingTool
{
    public class DrawingToolFileHelper : IDrawingToolFileHelper
    {
        /// <summary>
        /// Create output file
        /// </summary>
        /// <returns>Message with the result</returns>
        public string DrawingToolFile()
        {
            return DrawingToolFile(Constants.ImputFilename, Constants.OutputFilename);
        }

        /// <summary>
        /// Create output file
        /// </summary>
        /// <param name="imputFile">imput file path</param>
        /// <param name="outputFile">output file path</param>
        /// <returns>Message with the result</returns>
        public string DrawingToolFile(string imputFile, string outputFile)
        {
            try
            {
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }

                string[] lines = System.IO.File.ReadAllLines(imputFile);

                List<string> canvas = new List<string>();
                int count = 0;
                DrawingTool cnv = new DrawingTool();
                StringBuilder sb = new StringBuilder();

                foreach (string line in lines)
                {
                    canvas.Add(line);

                    for (int i = 0; i <= count; i++)
                    {
                        if (i == count)
                        {
                            sb.Append(cnv.Draw(canvas.ToArray()));
                            sb.AppendLine();
                        }
                    }
                    count++;
                }
                using (StreamWriter sw = File.CreateText(outputFile))
                {
                    sw.WriteLine(sb);
                    return "The file was created in " + outputFile;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}