using HugeDrawingTool;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HugeDrawingToolWinForm
{
    public partial class frmDrawingTool : Form
    {
        public frmDrawingTool()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            string[] commands = txtCommands.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            DrawingTool dt = new DrawingTool();
            txtOutput.Text = dt.Draw(commands);
        }

        private void btnTestFromFile_Click(object sender, EventArgs e)
        {
            lblFileResult.Text = string.Empty;

            OpenFileDialog _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            string imputFile = string.Empty;
            if (_openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                imputFile = _openFileDialog.InitialDirectory + _openFileDialog.FileName;
            }

            SaveFileDialog _saveFileDialog = new SaveFileDialog();

            _saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            string outputFile = string.Empty;
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFile = _saveFileDialog.InitialDirectory + _saveFileDialog.FileName;
            }

            DrawingToolFileHelper dt = new DrawingToolFileHelper();
            lblFileResult.Text = dt.DrawingToolFile(imputFile, outputFile);
        }
    }
}
