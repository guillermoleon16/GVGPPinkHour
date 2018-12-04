using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiscConsoleMAC;

namespace GVGPPinkHour
{
    public partial class StateDisplayer : Form
    {
        public int Rows;
        public int Columns;
        public int CurrentDisplay;
        List<MiscConsoleMAC.State> GameTree;


        public StateDisplayer(int columns, int rows, List<MiscConsoleMAC.State> tree)
        {
            InitializeComponent();
            Rows = rows;
            Columns = columns;
            GameTree = tree;
            CurrentDisplay = 0;
            UpdateButtons();
        }

        public void UpdateButtons()
        {
            PreviousButton.Enabled = !(CurrentDisplay == 0);
            NextButton.Enabled = !(CurrentDisplay == GameTree.Count - 1);
            ActionLabel.Text = "" + GameTree[CurrentDisplay].Move;
            DisplayState(GameTree[CurrentDisplay].Labels);
        }

        public void DisplayState(int[] labels)
        {
            Bitmap toDraw = State.ToBitmap(Columns, Rows, labels);
            Bitmap newimage = new Bitmap(StateImage.Width, StateImage.Height);
            Graphics g = Graphics.FromImage(newimage);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(toDraw, 0, 0, newimage.Width, newimage.Height);
            if (StateImage.InvokeRequired)
            {
                StateImage.Invoke((MethodInvoker)delegate ()
                {
                    StateImage.Image = newimage;
                });
            }
            else
            {
                StateImage.Image = newimage;
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            CurrentDisplay--;
            UpdateButtons();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            CurrentDisplay++;
            UpdateButtons();
        }
    }
}
