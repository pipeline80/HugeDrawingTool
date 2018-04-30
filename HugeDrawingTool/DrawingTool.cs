using System;
using System.Linq;
using System.Text;

namespace HugeDrawingTool
{
    public class DrawingTool : IDrawingTool
    {
        /// <summary>
        /// Array Canvas grid 
        /// </summary>
        public string[,] _canvas;
        public string[,] Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }

        public CanvasObject dtObj { get; set; }

        /// <summary>
        /// Drawing tool class
        /// </summary>
        public DrawingTool()
        {
            Canvas = new string[,] { };
            dtObj = new CanvasObject();
        }

        /// <summary>
        /// Drawing tool class
        /// </summary>
        public DrawingTool(int CanvasSizeX, int CanvasSizeY)
        {
            Canvas = new string[,] { };
            dtObj = new CanvasObject()
            {
                CanvasSizeX = CanvasSizeX,
                CanvasSizeY = CanvasSizeY
            };

            this.Canvas = new string[dtObj.CanvasSizeX + 2, dtObj.CanvasSizeY + 2];
        }

        /// <summary>
        /// Draw Canvas from comands
        /// </summary>
        /// <param name="commands">
        /// Create Canvas:    C w h 
        /// Create Line:      L x1 y1 x2 y2 
        /// Create Rectangle: R x1 y1 x2 y2 
        /// Bucket Fill:      B x y c 
        /// </param>
        /// <returns>Srtring with the data to draw</returns>
        public string Draw(string[] commands)
        {
            try
            {
                foreach (string item in commands)
                {
                    switch (item.ToLower().First())
                    {
                        case 'c':
                            dtObj.CanvasSizeX = int.Parse(item.Split(' ')[1]) + 1;
                            dtObj.CanvasSizeY = int.Parse(item.Split(' ')[2]) + 1;

                            this.Canvas = new string[dtObj.CanvasSizeX + 2, dtObj.CanvasSizeY + 2];
                            DrawCanvas();
                            break;
                        case 'l':
                            DrawLine(item.Split(' ').Skip(1).ToArray());
                            break;
                        case 'r':
                            DrawRectangle(item.Split(' ').Skip(1).ToArray());
                            break;
                        case 'b':
                            FillCanvas(int.Parse(item.Split(' ')[1]), int.Parse(item.Split(' ')[2]), item.Split(' ')[3]);
                            break;
                    }
                }

                if (string.IsNullOrEmpty(dtObj.Result))
                    dtObj.Result = DrawArray(Canvas);
            }
            catch (Exception ex)
            {
                dtObj.Result = "Please check the entered data. Error: " + ex.Message;
            }

            return dtObj.Result;
        }

        /// <summary>
        /// Draw Canvas area
        /// </summary>
        /// <returns>true if the Canvas can be draw</returns>
        public bool DrawCanvas()
        {
            try
            {
                if (!Validations.ValidateCanvasSize(dtObj))
                {
                    dtObj.Result = dtObj.Result;
                    return false;
                }

                for (int y = 0; y <= dtObj.CanvasSizeY; y++)
                {
                    for (int x = 0; x <= dtObj.CanvasSizeX; x++)
                    {
                        if (y == 0 || y == dtObj.CanvasSizeY)
                            this.Canvas[x, y] = Constants.CanvasTopChar;
                        else if (x == 0 || x == dtObj.CanvasSizeX)
                            this.Canvas[x, y] = Constants.CanvasSideChar;
                        else if (Validations.isPositionDrawn(x, y, this.Canvas))
                            this.Canvas[x, y] = this.Canvas[x, y];
                        else
                            this.Canvas[x, y] = Constants.CanvasSpaceChar;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                dtObj.Result = "Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Draws a line (horizontally or vertically) on the Canvas
        /// </summary>
        /// <param name="args">array [x1, y1, x2, y2]</param>
        /// <returns>true if the line can be draw</returns>
        public bool DrawLine(string[] args)
        {
            try
            {
                if (!Validations.ValidateCanvasSize(dtObj))
                {
                    dtObj.Result = dtObj.Result;
                    return false;
                }

                if (Validations.isOutOfCanvas(int.Parse(args[0]), int.Parse(args[1]), dtObj.CanvasSizeX, dtObj.CanvasSizeY)
                    || Validations.isOutOfCanvas(int.Parse(args[2]), int.Parse(args[3]), dtObj.CanvasSizeX, dtObj.CanvasSizeY))
                {
                    dtObj.Result = "The line size is larger than the Canvas size";
                    return false;
                }

                //draws an horizontal line
                if (args[1] == args[3])
                {
                    var singleLine = Validations.GetSequence(int.Parse(args[0]), int.Parse(args[2]));
                    foreach (int posX in singleLine)
                    {
                        this.Canvas[posX, int.Parse(args[1])] = Constants.LineChar;
                    }
                }
                //draws an vartical line
                else if (args[0] == args[2])
                {
                    var singleLine = Validations.GetSequence(int.Parse(args[1]), int.Parse(args[3]));
                    foreach (int posY in singleLine)
                    {
                        this.Canvas[int.Parse(args[0]), posY] = Constants.LineChar;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                dtObj.Result = "Please check the entered data. Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Draws a rectangle on the Canvas
        /// </summary>
        /// <param name="args"></param>
        /// <returns>true if the rectangle can be draw</returns>
        public bool DrawRectangle(string[] args)
        {
            dtObj.Result = string.Empty;
            try
            {
                if (!Validations.ValidateCanvasSize(dtObj))
                {
                    dtObj.Result = dtObj.Result;
                    return false;
                }

                if (args[1] == args[3] || args[0] == args[2]
                    || Validations.isOutOfCanvas(int.Parse(args[0]), int.Parse(args[1]), dtObj.CanvasSizeX, dtObj.CanvasSizeY)
                    || Validations.isOutOfCanvas(int.Parse(args[2]), int.Parse(args[3]), dtObj.CanvasSizeX, dtObj.CanvasSizeY))
                {
                    dtObj.Result = "The rectangle size is larger than the Canvas size";
                    return false;
                }
                //Rectangle Top 
                this.DrawLine(new string[] { args[0], args[1], args[2], args[1] });
                //Rectangle Left
                this.DrawLine(new string[] { args[0], args[1], args[0], args[3] });
                //Rectangle Right
                this.DrawLine(new string[] { args[2], args[1], args[2], args[3] });
                //Rectangle Bottom
                this.DrawLine(new string[] { args[0], args[3], args[2], args[3] });
                return true;
            }
            catch (Exception ex)
            {
                dtObj.Result = "Please check the entered data. Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        ///  Fill Canvas area
        ///  Source: http://gamedev.stackexchange.com/questions/31909/best-algorithm-for-recursive-adjacent-tiles
        /// </summary>
        /// <param name="x">Start Point</param>
        /// <param name="y">End point</param>
        /// <param name="fill">Filled chart to</param>
        /// <returns>true if the Canvas can be fill</returns>
        public bool FillCanvas(int x, int y, string fill)
        {
            dtObj.Result = string.Empty;
            try
            {
                if (!Validations.ValidateCanvasSize(dtObj))
                {
                    dtObj.Result = dtObj.Result;
                    return false;
                }

                if (Validations.isOutOfCanvas(x, y, dtObj.CanvasSizeX, dtObj.CanvasSizeY) || Validations.isPositionDrawn(x, y, Canvas))
                {
                    return false;
                }
                this.Canvas[x, y] = fill;
                /* Recursive calls */
                this.FillCanvas(x + 1, y, fill);
                this.FillCanvas(x - 1, y, fill);
                this.FillCanvas(x, y + 1, fill);
                this.FillCanvas(x, y - 1, fill);
                return true;
            }
            catch (Exception ex)
            {
                dtObj.Result = "Please check the entered data. Error: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Retunr a string with the array content
        /// </summary>
        /// <param name="array">data to be drawing</param>
        /// <returns>string with the array content</returns>
        public string DrawArray(string[,] array)
        {
            StringBuilder sb = new StringBuilder();

            int colLength = array.GetLength(1);
            int rowLength = array.GetLength(0);

            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    sb.Append(string.Format("{0}", array[j, i]));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
