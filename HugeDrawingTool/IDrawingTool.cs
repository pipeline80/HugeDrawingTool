namespace HugeDrawingTool
{
    public interface IDrawingTool
    {
        string Draw(string[] commands);
        bool DrawCanvas();
        bool DrawLine(string[] args);
        bool DrawRectangle(string[] args);
        bool FillCanvas(int x, int y, string fill);
        string DrawArray(string[,] array);
    }
}
