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
    public partial class CBDisplay : Form
    {
        public int Rows;
        public int Columns;
        public int CurrentDisplay;
        public List<CBRLimitedAgent.CaseScore> CB;

        public CBDisplay(List<CBRLimitedAgent.CaseScore> cb, int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            InitializeComponent();
            CB = new List<CBRLimitedAgent.CaseScore>(cb);
            CaseList.Items.Clear();
            for (int i = 0; i < CB.Count; i++)
            {
                CaseList.Items.Add("Case " + i);
            }
            CurrentDisplay = 0;
            UpdateData();
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

        public void DisplayStateData()
        {
            ActionList.Items.Clear();
            foreach(LowCase.ActionScore asc in CB[CurrentDisplay].Case.Actions)
            {
                ActionList.Items.Add("Action " + asc.Action + " Score = " + asc.Score);
            }
        }

        private void CaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentDisplay = CaseList.SelectedIndex;
            UpdateData();
        }

        public void UpdateData()
        {
            DisplayState(CB[CurrentDisplay].Case.Labels);
            DisplayStateData();
        }
    }
}
