using System;
using System.Collections.Generic;
using System.Text;

namespace HugeDrawingTool
{
    public interface IDrawingToolFileHelper
    {
        string DrawingToolFile();
        string DrawingToolFile(string imputFile, string outputFile);
    }
}
