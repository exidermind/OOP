using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab3.oop
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PaintBox = new Panel();
            SuspendLayout();
            // 
            // PaintBox
            // 
            PaintBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PaintBox.BackColor = SystemColors.Control;
            PaintBox.Location = new Point(-1, -1);
            PaintBox.Margin = new Padding(2, 1, 2, 1);
            PaintBox.Name = "PaintBox";
            PaintBox.Size = new Size(1358, 744);
            PaintBox.TabIndex = 0;
            PaintBox.Paint += PaintBox_Paint;
            PaintBox.MouseClick += PaintBox_MouseClick;
            PaintBox.Resize += PaintBox_Resize;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1359, 497);
            Controls.Add(PaintBox);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Panel PaintBox;
    }
}
