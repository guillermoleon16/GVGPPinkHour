using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Runtime.InteropServices;
using SharpGVGP;
using System.Drawing;
using MiscConsoleMAC;

namespace GVGPPinkHour
{

    public partial class Form1 : Form
    {
        Agent IntelligentAgent;

        Thread UIEditor;
        Thread Tester;

        #region Interface Variables
        
        bool IsPlaying;
        bool VisionSet;
        bool IsPaused;
        int IdentifierRows;
        int IdentifierColumns;


        PictureBox[] ButtonImages;
        #endregion


        
        /// <summary>
        /// Main form of the project.
        /// </summary>
        public Form1()
        {

            IdentifierRows = 1;
            IdentifierColumns = 1;
            InitializeComponent();
            this.IsPlaying = false;
            this.VisionSet = false;
            this.IsPaused = false;
            FigureSelector1.SelectedIndex = 0;
            FigureSelector2.SelectedIndex = 0;
            UpdateButtons();
            ButtonImages = new PictureBox[]
            {
                upArrow,
                downArrow,
                leftArrow,
                rightArrow,
                zButton
            };
        }

        private void AutoTest()
        {
            int[] CBSizes = new int[] { 200, 500, 700, 1000 };
            if (IntelligentAgent.ActiveGame == Games.JELLY_ESCAPE)
            {
                CBSizes = new int[] { 40, 60, 80, 100 };
            }
            IntelligentAgent.RandomPlayer = true;
            for (int i = 0; i < 4; i++)
            {
                IntelligentAgent.CaseBaseLimit = CBSizes[i];
                IntelligentAgent.SetGame(IntelligentAgent.ActiveGame);
                Thread.Sleep(2000);                
                IntelligentAgent.StartProcess();
                this.UIEditor = new Thread(UpdateUI);
                UIEditor.Start();

                while (IntelligentAgent.CurrentIteration <= 100)
                {
                    Thread.Sleep(1000);
                    
                }

                IntelligentAgent.StopProcess();
                UIEditor.Abort();
                this.IsPlaying = false;
            }
            IntelligentAgent.RandomPlayer = false;
            MessageBox.Show("Testing Complete!");
        }

        private void UpdateUI()
        {
            while (true)
            {
                UpdateState();
                UpdateArrows(IntelligentAgent.PressedKeys);
                UpdatePlanner();
                UpdateFigures();
                String wanted = "CB Size "+ IntelligentAgent.Decisor.LowCB.Count;
                if(this.RewardLabel.InvokeRequired)
                {
                    this.RewardLabel.Invoke((MethodInvoker)delegate()
                    {
                        RewardLabel.Text = wanted;
                    });
                }
                else
                {
                    RewardLabel.Text = wanted;
                }
                
                Thread.Sleep(200);
            }
        }

        private void UpdateFigures()
        {
            if(FigureSelector1.InvokeRequired)
            {
                FigureSelector1.Invoke((MethodInvoker)delegate () 
                {
                    switch (this.FigureSelector1.SelectedIndex)
                    {
                        case 0:
                            {
                                //CB Size vs Iteration
                                if (this.Figure1.InvokeRequired)
                                {
                                    Figure1.Invoke((MethodInvoker)delegate
                                    {
                                        Series series;
                                        FormatFigure(ref Figure1, out series, "Iteration", "CB Size");
                                        DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                        Figure1.Invalidate();
                                    });
                                }
                                else
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "CB Size");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                    Figure1.Invalidate();
                                }
                                break;
                            }
                        case 1:
                            {
                                // Completion Time vs. Iteration
                                if (this.Figure1.InvokeRequired)
                                {
                                    Figure1.Invoke((MethodInvoker)delegate
                                    {
                                        Series series;
                                        FormatFigure(ref Figure1, out series, "Iteration", "Session Time (s)");
                                        DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                        Figure1.Invalidate();
                                    });
                                }
                                else
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "Session Time (s)");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                    Figure1.Invalidate();
                                }
                                break;
                            }
                        case 2:
                            {
                                // Valid vs. Iteration
                                if (this.Figure1.InvokeRequired)
                                {
                                    Figure1.Invoke((MethodInvoker)delegate
                                    {
                                        Series series;
                                        FormatFigure(ref Figure1, out series, "Iteration", "Valid Move Percentage");
                                        DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                        Figure1.Invalidate();
                                    });
                                }
                                else
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "Valid Move Percentage");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                    Figure1.Invalidate();
                                }
                                break;
                            }
                        case 3:
                            {
                                //CB Size vs. Time
                                if (this.Figure1.InvokeRequired)
                                {
                                    Figure1.Invoke((MethodInvoker)delegate
                                    {
                                        Series series;
                                        FormatFigure(ref Figure1, out series, "Session Time (s)", "CB Size");
                                        DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                        Figure1.Invalidate();
                                    });
                                }
                                else
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Session Time (s)", "CB Size");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                    Figure1.Invalidate();
                                }
                                break;
                            }
                        default:
                            {
                                // Valid vs. Time
                                if (this.Figure1.InvokeRequired)
                                {
                                    Figure1.Invoke((MethodInvoker)delegate
                                    {
                                        Series series;
                                        FormatFigure(ref Figure1, out series, "Session Time (s)", "Valid Move Percentage");
                                        DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                        Figure1.Invalidate();
                                    });
                                }
                                else
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Session Time (s)", "Valid Move Percentage");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                    Figure1.Invalidate();
                                }
                                break;
                            }
                    }
                });
            }
            else
            {
                switch (this.FigureSelector1.SelectedIndex)
                {
                    case 0:
                        {
                            //CB Size vs Iteration
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "CB Size");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Iteration", "CB Size");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    case 1:
                        {
                            // Completion Time vs. Iteration
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "Session Time (s)");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Iteration", "Session Time (s)");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    case 2:
                        {
                            // Valid vs. Iteration
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "Valid Move Percentage");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Iteration", "Valid Move Percentage");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    case 3:
                        {
                            //CB Size vs. Time
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Session Time (s)", "CB Size");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Session Time (s)", "CB Size");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    default:
                        {
                            // Valid vs. Time
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Session Time (s)", "Valid Move Percentage");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Session Time (s)", "Valid Move Percentage");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                }
            }
            
            if(FigureSelector2.InvokeRequired)
            {
                FigureSelector2.Invoke((MethodInvoker)delegate ()
               {
                   switch (this.FigureSelector2.SelectedIndex)
                   {
                       case 0:
                           {
                               //CB Size vs Iteration
                               if (this.Figure2.InvokeRequired)
                               {
                                   Figure2.Invoke((MethodInvoker)delegate
                                   {
                                       Series series;
                                       FormatFigure(ref Figure2, out series, "Iteration", "CB Size");
                                       DataToFigure(ref Figure2, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                       Figure2.Invalidate();
                                   });
                               }
                               else
                               {
                                   Series series;
                                   FormatFigure(ref Figure2, out series, "Iteration", "CB Size");
                                   DataToFigure(ref Figure2, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                   Figure2.Invalidate();
                               }
                               break;
                           }
                       case 1:
                           {
                               // Completion Time vs. Iteration
                               if (this.Figure2.InvokeRequired)
                               {
                                   Figure2.Invoke((MethodInvoker)delegate
                                   {
                                       Series series;
                                       FormatFigure(ref Figure2, out series, "Iteration", "Session Time (s)");
                                       DataToFigure(ref Figure2, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                       Figure2.Invalidate();
                                   });
                               }
                               else
                               {
                                   Series series;
                                   FormatFigure(ref Figure2, out series, "Iteration", "Session Time (s)");
                                   DataToFigure(ref Figure2, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                   Figure2.Invalidate();
                               }
                               break;
                           }
                       case 2:
                           {
                               // Valid vs. Iteration
                               if (this.Figure2.InvokeRequired)
                               {
                                   Figure2.Invoke((MethodInvoker)delegate
                                   {
                                       Series series;
                                       FormatFigure(ref Figure2, out series, "Iteration", "Valid Move Percentage");
                                       DataToFigure(ref Figure2, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                       Figure2.Invalidate();
                                   });
                               }
                               else
                               {
                                   Series series;
                                   FormatFigure(ref Figure2, out series, "Iteration", "Valid Move Percentage");
                                   DataToFigure(ref Figure2, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                   Figure2.Invalidate();
                               }
                               break;
                           }
                       case 3:
                           {
                               //CB Size vs. Time
                               if (this.Figure2.InvokeRequired)
                               {
                                   Figure1.Invoke((MethodInvoker)delegate
                                   {
                                       Series series;
                                       FormatFigure(ref Figure2, out series, "Session Time (s)", "CB Size");
                                       DataToFigure(ref Figure2, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                       Figure2.Invalidate();
                                   });
                               }
                               else
                               {
                                   Series series;
                                   FormatFigure(ref Figure2, out series, "Session Time (s)", "CB Size");
                                   DataToFigure(ref Figure2, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                   Figure2.Invalidate();
                               }
                               break;
                           }
                       default:
                           {
                               // Valid vs. Time
                               if (this.Figure2.InvokeRequired)
                               {
                                   Figure1.Invoke((MethodInvoker)delegate
                                   {
                                       Series series;
                                       FormatFigure(ref Figure2, out series, "Session Time (s)", "Valid Move Percentage");
                                       DataToFigure(ref Figure2, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                       Figure2.Invalidate();
                                   });
                               }
                               else
                               {
                                   Series series;
                                   FormatFigure(ref Figure2, out series, "Session Time (s)", "Valid Move Percentage");
                                   DataToFigure(ref Figure2, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                   Figure2.Invalidate();
                               }
                               break;
                           }
                   }
               });
            }
            else
            {
                switch (this.FigureSelector1.SelectedIndex)
                {
                    case 0:
                        {
                            //CB Size vs Iteration
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "CB Size");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Iteration", "CB Size");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ProgressList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    case 1:
                        {
                            // Completion Time vs. Iteration
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "Session Time (s)");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Iteration", "Session Time (s)");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.TimeList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    case 2:
                        {
                            // Valid vs. Iteration
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Iteration", "Valid Move Percentage");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Iteration", "Valid Move Percentage");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.IterationList, IntelligentAgent.ValidList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    case 3:
                        {
                            //CB Size vs. Time
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Session Time (s)", "CB Size");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Session Time (s)", "CB Size");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentProgressList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                    default:
                        {
                            // Valid vs. Time
                            if (this.Figure1.InvokeRequired)
                            {
                                Figure1.Invoke((MethodInvoker)delegate
                                {
                                    Series series;
                                    FormatFigure(ref Figure1, out series, "Session Time (s)", "Valid Move Percentage");
                                    DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                    Figure1.Invalidate();
                                });
                            }
                            else
                            {
                                Series series;
                                FormatFigure(ref Figure1, out series, "Session Time (s)", "Valid Move Percentage");
                                DataToFigure(ref Figure1, ref series, IntelligentAgent.CurrentTimeList, IntelligentAgent.CurrentValidList);
                                Figure1.Invalidate();
                            }
                            break;
                        }
                }
            }
            
        }

        private void FormatFigure(ref Chart chart, out Series series,String xlabel, String ylabel)
        {
            chart.ChartAreas.Clear();
            ChartArea a = new ChartArea("Learning");
            a.AxisX.Title = xlabel;
            a.AxisY.Title = ylabel;
            chart.ChartAreas.Add(a);
            chart.Series.Clear();
            series = new Series
            {
                Name = "Series",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                ChartArea = "Learning"
            };
        }

        private void DataToFigure(ref Chart chart, ref Series series, List<int> x, List<double> y)
        {
            chart.Series.Add(series);
            for (int i = 0; i < Math.Min(x.Count,y.Count); i++)
            {
                series.Points.AddXY(x[i], y[i]);
            }
        }

        private void DataToFigure(ref Chart chart, ref Series series, List<int> x, List<int> y)
        {
            chart.Series.Add(series);
            for (int i = 0; i < Math.Min(x.Count, y.Count); i++)
            {
                series.Points.AddXY(x[i], y[i]);
            }
        }

        private void UpdateButtons()
        {
            this.SaveFileCheckBox.Enabled = !IsPlaying;
            this.StartPlayingButton.Enabled = ((VisionSet) && (!IsPlaying))||((IsPaused)&&(VisionSet));
            this.StopPlayingButton.Enabled = (VisionSet) && (IsPlaying);
            this.StepButton.Enabled = (VisionSet) && (IsPlaying) && (IsPaused);
            this.IDStep.Enabled = this.StepButton.Enabled;
            //this.PStep.Enabled = this.StepButton.Enabled;
            this.PStep.Enabled = (!IsPlaying) && (!IsPaused);
            this.EStep.Enabled = this.StepButton.Enabled;
            this.SetVisionButton.Enabled = (!IsPlaying);
            this.PauseButton.Enabled = ((IsPlaying) && (!IsPaused));
            this.GameSelector.Enabled = !((IsPlaying)||(IsPaused));
            this.SeeTree.Enabled = (!IsPlaying);
            this.CBLimitTrackBar.Enabled = !IsPlaying;
            
        }

        private void UpdateArrows(bool[] pressedKeys)
        {
            if(IntelligentAgent.Decisor.LastLowC != null)
            {
                Bitmap toDraw = State.ToBitmap(IdentifierColumns, IdentifierRows,
                IntelligentAgent.Decisor.LastLowC.Labels);
                Bitmap newimage = new Bitmap(EXState.Width, EXState.Height);
                Graphics g = Graphics.FromImage(newimage);
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(toDraw, 0, 0, newimage.Width, newimage.Height);
                if (EXState.InvokeRequired)
                {
                    EXState.Invoke((MethodInvoker)delegate ()
                    {
                        EXState.Image = newimage;
                    });
                }
                else
                {
                    EXState.Image = newimage;
                }
            }            

            for (int i = 0; i < pressedKeys.Length; i++)
            {
                Image toAssing = Properties.Resources.upArrow;
                switch(i)
                {
                    case 0:
                        {
                            if(pressedKeys[i])
                            {
                                toAssing = Properties.Resources.upArrowP;
                            }
                            else
                            {
                                toAssing = Properties.Resources.upArrow;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (pressedKeys[i])
                            {
                                toAssing = Properties.Resources.downArrowP;
                            }
                            else
                            {
                                toAssing = Properties.Resources.downArrow;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (pressedKeys[i])
                            {
                                toAssing = Properties.Resources.leftArrowP;
                            }
                            else
                            {
                                toAssing = Properties.Resources.leftArrow;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (pressedKeys[i])
                            {
                                toAssing = Properties.Resources.rightArrowP;
                            }
                            else
                            {
                                toAssing = Properties.Resources.rightArrow;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (pressedKeys[i])
                            {
                                toAssing = Properties.Resources.zP;
                            }
                            else
                            {
                                toAssing = Properties.Resources.z;
                            }
                            break;
                        }
                }
                if(ButtonImages[i].InvokeRequired)
                {
                    ButtonImages[i].Invoke((MethodInvoker)delegate ()
                    {
                        ButtonImages[i].Image = toAssing;
                    });
                }
                else
                {
                    ButtonImages[i].Image = toAssing;
                }
            }
        }

        private void UpdateState()
        {
            Bitmap toDraw = State.ToBitmap(IdentifierColumns, IdentifierRows,
                IntelligentAgent.IdentifierLabels);
            Bitmap newimage = new Bitmap(IDState.Width, IDState.Height);
            Graphics g = Graphics.FromImage(newimage);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(toDraw, 0, 0, newimage.Width, newimage.Height);
            if (IDState.InvokeRequired)
            {
                IDState.Invoke((MethodInvoker)delegate ()
               {
                   IDState.Image = newimage;
               });
            }
            else
            {
                IDState.Image = newimage;
            }
        }

        private void UpdatePlanner()
        {
            Bitmap toDraw = State.ToBitmap(IdentifierColumns, IdentifierRows,
                IntelligentAgent.Decisor.LastHighC.Labels);
            Bitmap newimage = new Bitmap(PLState.Width, PLState.Height);
            Graphics g = Graphics.FromImage(newimage);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(toDraw, 0, 0, newimage.Width, newimage.Height);
            if (PLState.InvokeRequired)
            {
                PLState.Invoke((MethodInvoker)delegate ()
                {
                    PLState.Image = newimage;
                });
            }
            else
            {
                PLState.Image = newimage;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.IntelligentAgent = new Agent();
            this.GameSelector.SelectedIndex = 0;
        }

        private void SetVisionButton_Click(object sender, EventArgs e)
        {
            this.VisionSet = IntelligentAgent.SetVision();
            UpdateButtons();
        }

        private void TestVisionButton_Click(object sender, EventArgs e)
        {/*
            Console.WriteLine("First status: " + IntelligentAgent.PauseStatus(out bool f));
            Console.WriteLine("Second status: " + IntelligentAgent.TogglePause());
            Console.WriteLine("Third status: " + IntelligentAgent.PauseStatus(out f));*/
        }

        private void StartPlayingButton_Click(object sender, EventArgs e)
        {
            if (!IsPlaying)
            {
                Thread.Sleep(2000);
                IntelligentAgent.CaseBaseLimit = CBLimitTrackBar.Value;
                IntelligentAgent.StartProcess();
                this.UIEditor = new Thread(UpdateUI);
                UIEditor.Start();
                this.IsPlaying = true;                
            }
            else
            {
                if (IsPaused)
                {
                    Thread.Sleep(2000);
                    IntelligentAgent.StartProcess();
                    this.IsPaused = false;
                }
            }
            UpdateButtons();
        }

        private void StopPlayingButton_Click(object sender, EventArgs e)
        {
            IntelligentAgent.StopProcess();
            UIEditor.Abort();
            this.IsPlaying = false;
            UpdateButtons();
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IntelligentAgent.StopProcess();
            if (UIEditor != null)
            {
                if (UIEditor.IsAlive)
                {
                    UIEditor.Abort();
                }
            }
            if(Tester != null)
            {
                if(Tester.IsAlive)
                {
                    Tester.Abort();
                }
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            IntelligentAgent.PauseProcess();
            this.IsPaused = true;
            UpdateButtons();
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            IntelligentAgent.FullStep();
        }

        private void EStep_Click(object sender, EventArgs e)
        {
            IntelligentAgent.ExecuterStep();
        }

        private void IDStep_Click(object sender, EventArgs e)
        {
            IntelligentAgent.IdentifierStep();
        }

        private void PStep_Click(object sender, EventArgs e)
        {
            Tester = new Thread(AutoTest);
            Tester.Start();
            IsPlaying = true;
            UpdateButtons();
        }

        private void GameSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

            IntelligentAgent.SetGame((Games)this.GameSelector.SelectedIndex);
            IdentifierRows = IntelligentAgent.ID.VisionRows;
            IdentifierColumns = IntelligentAgent.ID.VisionColumns;
        }

        private void SaveFileCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            IntelligentAgent.SetSaveFile(SaveFileCheckBox.Checked);
        }

        private void SeeTree_Click(object sender, EventArgs e)
        {
            StateDisplayer SD = new StateDisplayer(IntelligentAgent.ID.VisionColumns,
                IntelligentAgent.ID.VisionRows, IntelligentAgent.Decisor.SV.GameTree);
            SD.ShowDialog();
        }

        private void CBLimitTrackBar_Scroll(object sender, EventArgs e)
        {
            IntelligentAgent.CaseBaseLimit = CBLimitTrackBar.Value;
            CBLimitLabel.Text = "Case Base Size Limit: " + CBLimitTrackBar.Value;
        }

        private void SeeCB_Click(object sender, EventArgs e)
        {
            CBDisplay CBD = new CBDisplay(IntelligentAgent.Decisor.LowCB,
                IntelligentAgent.ID.VisionRows, IntelligentAgent.ID.VisionColumns);
            CBD.ShowDialog();
        }
    }
}