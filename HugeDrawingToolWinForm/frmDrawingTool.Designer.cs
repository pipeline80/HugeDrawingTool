namespace HugeDrawingToolWinForm
{
    partial class frmDrawingTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDrawingTool));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommands = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnTestFromFile = new System.Windows.Forms.Button();
            this.lblFileResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 78);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sample commands\r\nC 20 4\r\nL 1 2 6 2\r\nL 6 3 6 4\r\nR 16 1 20 3\r\nB 10 3 o";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 52);
            this.label1.TabIndex = 11;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // txtCommands
            // 
            this.txtCommands.Location = new System.Drawing.Point(12, 163);
            this.txtCommands.Multiline = true;
            this.txtCommands.Name = "txtCommands";
            this.txtCommands.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommands.Size = new System.Drawing.Size(238, 110);
            this.txtCommands.TabIndex = 10;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(12, 279);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(588, 362);
            this.txtOutput.TabIndex = 9;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(256, 163);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(78, 110);
            this.btnDraw.TabIndex = 8;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnTestFromFile
            // 
            this.btnTestFromFile.Location = new System.Drawing.Point(12, 12);
            this.btnTestFromFile.Name = "btnTestFromFile";
            this.btnTestFromFile.Size = new System.Drawing.Size(118, 44);
            this.btnTestFromFile.TabIndex = 13;
            this.btnTestFromFile.Text = "Test From File";
            this.btnTestFromFile.UseVisualStyleBackColor = true;
            this.btnTestFromFile.Click += new System.EventHandler(this.btnTestFromFile_Click);
            // 
            // lblFileResult
            // 
            this.lblFileResult.AutoSize = true;
            this.lblFileResult.Location = new System.Drawing.Point(12, 63);
            this.lblFileResult.Name = "lblFileResult";
            this.lblFileResult.Size = new System.Drawing.Size(0, 13);
            this.lblFileResult.TabIndex = 14;
            // 
            // frmDrawingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 653);
            this.Controls.Add(this.lblFileResult);
            this.Controls.Add(this.btnTestFromFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommands);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDraw);
            this.Name = "frmDrawingTool";
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommands;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnTestFromFile;
        private System.Windows.Forms.Label lblFileResult;
    }
}

