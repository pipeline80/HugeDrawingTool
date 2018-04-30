namespace HugeDrawingTool
{
    public abstract class Validations
    {
        /// <summary>
        /// Validate Canvas sise
        /// </summary>
        /// <param name="result">output error message</param>
        /// <returns>false if the Canvas size is so big</returns>
        public static bool ValidateCanvasSize(CanvasObject obj)
        {
            if (obj.CanvasSizeX > 51 || obj.CanvasSizeY > 51)
            {
                obj.Result = "The max value for Canvas in x: 50, y: 50";
                return false;
            }
            obj.Result = string.Empty;
            return true;
        }

        /// <summary>
        /// Determines if a position is drawn on the canvas
        /// </summary>
        /// <param name="x">psition on x</param>
        /// <param name="y">position on y</param>
        /// <returns>True if the position is already drawn</returns>
        public static bool isPositionDrawn(int x, int y, string[,] canvas)
        {
            if (!string.IsNullOrWhiteSpace(canvas[x, y]))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determines if a given position is out of the canvas
        /// </summary>
        /// <param name="x">position in x</param>
        /// <param name="y">position in y</param>
        /// <returns>true if the position is out</returns>
        public static bool isOutOfCanvas(int x, int y, int canvasSizeX, int canvasSizeY)
        {
            if (x < 1 || x > canvasSizeX || y < 1 || y > canvasSizeY)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get sequence between two numbers
        /// </summary>
        /// <param name="x">start number</param>
        /// <param name="y">end number</param>
        /// <returns>return an array with the sequence</returns>
        public static int[] GetSequence(int x, int y)
        {
            int[] result = new int[(y - x) + 1];

            for (int i = 0; i < (y - x) + 1; i++)
            {
                result[i] = x + i;
            }
            return result;
        }
    }
}