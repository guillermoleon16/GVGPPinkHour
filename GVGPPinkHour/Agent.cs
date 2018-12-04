using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SharpGVGP;
//using SharpGVGP.Proposed;
using SharpGVGP.Utils;
using Accord.Statistics.Models.Regression.Linear;
using System.Diagnostics;
using MiscConsoleMAC;

namespace GVGPPinkHour
{
    public class Agent
    {
        #region Operational Objects

        #region Utilities
        private int TIMEOUT;
        public Stopwatch TimeWatch;
        public Player KeyPresser;
        public VisionManager Visor;
        private Thread Interaction;
        public bool HasSetVision;
        public bool IsFirstMove;
        public bool IsPaused { get; private set; }
        public Games ActiveGame;
        public int CaseBaseLimit;
        public bool RandomPlayer;
        private Random RNG;

        #endregion

        #region Blocks

        public CBRLimitedAgent Decisor;
        public Identifier ID;
        #endregion

        #endregion

        #region Block Output Data

        public bool[] PressedKeys { get; private set; }
        public int[] IdentifierLabels { get; private set; }
        private double[] IdentifierValues;
        public int SelectedNetwork { get; private set; }
        public int AvailableNetworks { get; private set; }
        public double CurrentAptitude { get; private set; }

        #endregion

        #region Figure Data

        public FileHandler FileHandler;

        public int CurrentTimestep { get; private set; }
        public int CurrentIteration { get; private set; }
        public double CurrentValid { get; private set; }
        public int CurrentProgress { get; private set; }
        public int CurrentValidMoves { get; private set; }
        public int CurrentTotalMoves { get; private set; }
        public SimpleLinearRegression TimeRegression { get; private set; }
        public SimpleLinearRegression ProgressRegression { get; private set; }
        public SimpleLinearRegression ValidRegression { get; private set; }

        public List<int> ProgressList { get; private set; }
        public List<int> TimeList { get; private set; }
        public List<double> ValidList { get; private set; }
        public List<int> IterationList { get; private set; }

        public List<int> CurrentTimeList { get; private set; }
        public List<int> CurrentProgressList { get; private set; }
        public List<double> CurrentValidList { get; private set; }
        public int WinCounter;
        public bool SaveFile;

        #endregion

        #region Class Methods

        public void SetSaveFile(bool state)
        {
            SaveFile = state;
        }

        public Agent()
        {
            RNG = new Random();
            TimeRegression = new SimpleLinearRegression();
            ProgressRegression = new SimpleLinearRegression();
            ValidRegression = new SimpleLinearRegression();
            TimeWatch = new Stopwatch();
            Visor = new VisionManager();
            HasSetVision = false;
            IsFirstMove = true;
            SaveFile = false;
            RandomPlayer = false;
            CaseBaseLimit = 100;
            SetGame(Games._2048);            
        }

        #region Interaction Methods
        public void StartProcess()
        {
            if(Interaction == null)
            {
                Interaction = new Thread(Play);
                Decisor.CBSizeLimit = CaseBaseLimit;
            }
            if(!Interaction.IsAlive)
            {
                Decisor.CBSizeLimit = CaseBaseLimit;
                Interaction = new Thread(Play);
                Interaction.Start();
                TimeWatch.Start();
                IsPaused = false;
            }
            else
            {
                if (IsPaused)
                {
                    IsPaused = false;
                    TimeWatch.Start();
                }
            }
        }

        public void PauseProcess()
        {
            if (Interaction != null)
            {
                if (Interaction.IsAlive)
                {
                    if(!IsPaused)
                    {
                        IsPaused = true;
                        TimeWatch.Stop();
                        KeyPresser.ReleaseAll();
                    }
                }
            }
        }

        public void StopProcess()
        {
            if(Interaction!=null)
            {
                if(Interaction.IsAlive)
                {
                    Interaction.Abort();
                }
            }
        }

        public void ResetAll()
        {
            WinCounter = 0;
            IsPaused = false;
            IsFirstMove = true;
            CurrentTimestep = 0;
            CurrentIteration = 0;
            CurrentValid = 0;
            CurrentProgress = 0;
            CurrentValidMoves = 0;
            CurrentTotalMoves = 0;
            SelectedNetwork = 0;
            AvailableNetworks = 1;
            CurrentAptitude = 1;
            ProgressList = new List<int>();
            TimeList = new List<int>();
            ValidList = new List<double>();
            CurrentTimeList = new List<int>();
            CurrentProgressList = new List<int>();
            CurrentValidList = new List<double>();
            IterationList = new List<int>();
            StopProcess();
            TimeWatch.Reset();            
        }

        public void SetGame(Games game)
        {
            PauseProcess();
            ActiveGame = game;
            ID = new Identifier(ActiveGame);
            ResetAll();
            switch(ActiveGame)
            {
                case Games._2048:
                    {
                        KeyPresser = new Player(4, "wsad");
                        Decisor = new CBRLimitedAgent(CaseBaseLimit, 4)
                        {
                            HighCB = new List<PlannerCase>
                            {
                                new PlannerCase(0, new int[] { 0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(1, new int[] { 0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(2, new int[] { 0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(3, new int[] { 0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(4, new int[] { 0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(5, new int[] { 0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(6, new int[] { 0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(7, new int[] { 0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(8, new int[] { 0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(9, new int[] { 0,0,0,10,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                                new PlannerCase(10, new int[] { 0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0}, new bool[] { false,false,false, true }),
                            }
                        };
                        PressedKeys = new bool[4];
                        TIMEOUT = 1000;
                        break;
                    }
                case Games.JELLY_ESCAPE:
                    {
                        KeyPresser = new Player(4, "wsad");
                        Decisor = new CBRLimitedAgent(CaseBaseLimit, 9)
                        {
                            HighCB = new List<PlannerCase>
                            {
                                new PlannerCase(0,new int[ID.VisionColumns*ID.VisionRows],
                                new bool[ID.VisionColumns*ID.VisionRows])
                            }
                        };
                        Decisor.HighCB[0].Completion[1139] = true;
                        Decisor.HighCB[0].Labels[1139] = 1;
                        PressedKeys = new bool[4];
                        TIMEOUT = 800;
                        break;
                    }
                case Games.PINK_HOUR:
                    {
                        KeyPresser = new Player(5, "wsadz");
                        Decisor = new CBRLimitedAgent(CaseBaseLimit, 18)
                        {
                            HighCB = new List<PlannerCase>
                            {
                                new PlannerCase(0,new int[ID.VisionColumns*ID.VisionRows],
                                new bool[ID.VisionColumns*ID.VisionRows])
                            }
                        };
                        Decisor.HighCB[0].Completion[ID.VisionColumns - 1] = true;
                        Decisor.HighCB[0].Labels[ID.VisionColumns - 1] = 1;                        
                        PressedKeys = new bool[5];
                        TIMEOUT = 1500;
                        break;
                    }
            }
            Decisor.LastHighC = Decisor.HighCB[0];
            IdentifierLabels = new int[ID.VisionColumns * ID.VisionRows];
            IdentifierValues = new double[ID.VisionColumns * ID.VisionRows];
        }

        public bool SetVision()
        {
            bool toReturn = false;
            try
            {
                SnippetTool st = new SnippetTool();
                st.ShowDialog();
                Visor.SetVisionRectangle(st.GetVisionBoundaries());
                toReturn = true;
            }
            finally
            {
                HasSetVision = toReturn;
            }
            
            return toReturn;
        }
        #endregion

        #region Operational Methods
        public void Play()
        {
            FileHandler = new FileHandler(ActiveGame + "_" + DateTime.Now.ToString(@"MM\-dd\-yyyy h\-mm tt") + "_");
            bool valid = true;
            TimeWatch.Start();
            while (true)
            {
                if(!IsPaused)
                {
                    
                    IdentifierStep();
                    CheckEndGame();
                    IdentifierStep();
                    Stopwatch tempwatch = new Stopwatch();
                    tempwatch.Restart();
                    int move = 0;
                    if(IsFirstMove)
                    {
                        move = Decisor.Retrieve(IdentifierLabels);
                        IsFirstMove = false;
                    }
                    else
                    {
                        valid = Decisor.Feedback(1, IdentifierLabels);
                        move = Decisor.Retrieve(IdentifierLabels);
                    }
                    if(RandomPlayer)
                    {
                        move = RNG.Next(Decisor.NMoves);
                    }
                    PressedKeys = OutputsToKeys(move);
                    KeyPresser.PressKeys(PressedKeys);
                    while (tempwatch.ElapsedMilliseconds < TIMEOUT)
                    {
                        Thread.Sleep(100);
                    }
                    SaveStats(valid);
                    KeyPresser.ReleaseAll();
                    //Console.WriteLine("Decision time = " + tempwatch.ElapsedMilliseconds);
                }                
            }
        }

        public void FullStep()
        {
            if(IsPaused)
            {
                Stopwatch tempwatch = new Stopwatch();
                tempwatch.Start();
                TimeWatch.Start();

                IdentifierStep();
                int move = 0;
                if (IsFirstMove)
                {
                    move = Decisor.Retrieve(IdentifierLabels);
                    IsFirstMove = false;
                }
                else
                {
                    Decisor.Feedback(1, IdentifierLabels);
                    move = Decisor.Retrieve(IdentifierLabels);
                }
                PressedKeys = OutputsToKeys(move);

                KeyPresser.PressKeys(PressedKeys);
                while (tempwatch.ElapsedMilliseconds < TIMEOUT)
                {
                    Thread.Sleep(100);
                }
                KeyPresser.ReleaseAll();
                tempwatch.Stop();
                TimeWatch.Stop();
                CheckEndGame();
            }        
        }

        public void CheckEndGame()
        {
            switch (ActiveGame)
            {
                case Games._2048:
                    {
                        int[,] board = new int[4, 4];
                        int k = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                board[i, j] = IdentifierLabels[k];
                                k++;
                            }
                        }
                        double r = GetReward2048(board);
                        if(r < 0)
                        {
                            Decisor.Feedback(-100, IdentifierLabels);
                            SaveIterationStats(false);

                            IsFirstMove = true;
                            Thread.Sleep(4000);
                            Supervisornew.RestartGame(Visor.Xi, Visor.Yi);
                            KeyPresser.ReleaseAll();
                            CurrentIteration++;
                            Thread.Sleep(1000);
                        }
                        else if(r > 0)
                        {
                            Decisor.Feedback(100, IdentifierLabels);
                            SaveIterationStats(true);                            
                            IsFirstMove = true;
                            Thread.Sleep(4000);
                            Supervisornew.RestartGame(Visor.Xi, Visor.Yi);
                            KeyPresser.ReleaseAll();
                            CurrentIteration++;
                            Thread.Sleep(1000);
                        }
                        break;
                    }
                case Games.JELLY_ESCAPE:
                    {
                        bool flag = false;
                        foreach (int i in IdentifierLabels)
                        {
                            if(i == 10)
                            {
                                Decisor.Feedback(100, IdentifierLabels);                                
                                KeyPresser.ReleaseAll();
                                SaveIterationStats(true);
                                IsFirstMove = true;
                                flag = true;
                                break;
                            }
                        }
                        if(flag)
                        {
                            Thread.Sleep(3000);
                            Player resetter = new Player(1, "r");
                            resetter.PressKeys(new bool[] { true });
                            Thread.Sleep(200);
                            resetter.ReleaseAll();
                            Thread.Sleep(200);
                            KeyPresser.ReleaseAll();
                            CurrentIteration++;
                            //Supervisornew.RestartGame(Visor.Xi + 340, Visor.Yi + 40);
                            Thread.Sleep(3000);
                        }
                        break;
                    }
                case Games.PINK_HOUR:
                    {
                        if (IdentifierLabels[19] == 10)
                        {
                            Player resetter = new Player(1, "m");
                            Decisor.Feedback(-100, IdentifierLabels);
                            SaveIterationStats(false);
                            IsFirstMove = true;
                            KeyPresser.ReleaseAll();
                            Thread.Sleep(3000);
                            KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                            Thread.Sleep(3000);
                            KeyPresser.ReleaseAll();
                            Thread.Sleep(1000);
                            KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                            Thread.Sleep(3000);
                            KeyPresser.PressKeys(new bool[] { false, false, true, false, false });
                            Thread.Sleep(5000);
                            KeyPresser.ReleaseAll();
                            resetter.PressKeys(new bool[] { true });
                            Thread.Sleep(500);
                            resetter.ReleaseAll();
                            Thread.Sleep(500);
                            KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                            Thread.Sleep(1000);
                            KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                            Thread.Sleep(1000);
                            KeyPresser.ReleaseAll();
                            Thread.Sleep(1000);
                            KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                            Thread.Sleep(5000);
                            KeyPresser.ReleaseAll();
                            CurrentIteration++;
                        }
                        else
                        {
                            bool flag = false;
                            foreach(int i in IdentifierLabels)
                            {
                                if(i == 8)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if(flag)
                            {
                                Player resetter = new Player(1, "m");
                                Decisor.Feedback(100, IdentifierLabels);
                                SaveIterationStats(false);
                                IsFirstMove = true;
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(1000);
                                resetter.PressKeys(new bool[] { true });
                                Thread.Sleep(1000);
                                resetter.ReleaseAll();

                                KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { true, false, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(500);
                                
                                KeyPresser.PressKeys(new bool[] { false, false, true, false, false });
                                Thread.Sleep(5000);
                                KeyPresser.ReleaseAll();
                                resetter.PressKeys(new bool[] { true });
                                Thread.Sleep(500);
                                resetter.ReleaseAll();
                                Thread.Sleep(500);
                                KeyPresser.PressKeys(new bool[] { false, true, false, false, false });
                                Thread.Sleep(1000);
                                KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                                Thread.Sleep(1000);
                                KeyPresser.ReleaseAll();
                                Thread.Sleep(1000);
                                KeyPresser.PressKeys(new bool[] { false, false, false, false, true });
                                Thread.Sleep(5000);
                                KeyPresser.ReleaseAll();
                                CurrentIteration++;
                            }
                        }
                        break;
                    }
            }
        }

        public void IdentifierStep()
        {
            IdentifierValues = ID.GetInput(Visor.GetViewDownsampled(ID.VisionColumns, ID.VisionRows));
            Array.Copy(ID.LabelArray, IdentifierLabels, IdentifierValues.Length);
        }

        public void ExecuterStep()
        {
            int move = Decisor.Retrieve(IdentifierLabels);
            PressedKeys = OutputsToKeys(move);
        }

        public void PlannerStep()
        {
            //Decisor.NearestNeighborHigh(IdentifierLabels);            
        }

        private void SaveStats(bool validflag)
        {
            CurrentProgress = Decisor.LowCB.Count;
            CurrentTotalMoves++;
            CurrentTimestep = (int)TimeWatch.ElapsedMilliseconds / 1000;
            if (validflag)
            {
                CurrentValidMoves++;
            }
            CurrentValid = (double)CurrentValidMoves * 100.0 / (double)CurrentTotalMoves;
            this.CurrentProgressList.Add(CurrentProgress);
            this.CurrentTimeList.Add(CurrentTimestep);
            this.CurrentValidList.Add(CurrentValid);
            if(SaveFile)
            {
                FileHandler.SaveOnlinePerformance(CurrentIteration, CurrentTimestep, CurrentValid, CurrentProgress);
            }
        }

        private void SaveIterationStats(bool win)
        {
            this.ProgressList.Add(CurrentProgress);
            this.TimeList.Add(CurrentTimestep);
            this.ValidList.Add(CurrentValid);
            this.IterationList.Add(CurrentIteration);
            if(win)
            {
                WinCounter++;
            }
            TimeWatch.Restart();
            if (SaveFile)
            {
                FileHandler.SaveOfflinePerformance(CurrentIteration, CurrentTimestep, CurrentProgress, CurrentValid);
            }
            CurrentTotalMoves = 0;
            CurrentValidMoves = 0;
            CurrentValidList.Clear();
            CurrentProgressList.Clear();
            CurrentTimeList.Clear();

        }

        private bool[] OutputsToKeys(int executerOutput)
        {
            bool[] toReturn = new bool[PressedKeys.Length];            
            if (executerOutput <= 3)
            {
                toReturn[executerOutput] = true;
            }
            else
            {
                if( executerOutput > 4)
                {
                    if(executerOutput > 9)
                    {
                        toReturn[4] = true;
                    }
                    if ((executerOutput == 5) || (executerOutput == 6) || (executerOutput == 10) || (executerOutput == 14) || (executerOutput == 15))
                    {
                        toReturn[0] = true;
                    }
                    if ((executerOutput == 7) || (executerOutput == 8) || (executerOutput == 11) || (executerOutput == 16) || (executerOutput == 17))
                    {
                        toReturn[1] = true;
                    }
                    if ((executerOutput == 5) || (executerOutput == 7) || (executerOutput == 12) || (executerOutput == 14) || (executerOutput == 16))
                    {
                        toReturn[2] = true;
                    }
                    if ((executerOutput == 6) || (executerOutput == 8) || (executerOutput == 13) || (executerOutput == 15) || (executerOutput == 17))
                    {
                        toReturn[3] = true;
                    }
                }
            }
            return toReturn;
        }
        #endregion

        public double GetReward2048(int[,] input)
        {
            int i, j;
            i = 0;
            bool stopflag = false;
            double ToReturn = -1;
            while ((!stopflag) && (i < 4))
            {
                j = 0;
                while ((!stopflag) && (j < 4))
                {
                    if (input[i, j] == 11)
                    {
                        stopflag = true;
                        ToReturn = 1;
                    }
                    else
                    {
                        //Check sorroundings of the tile
                        if (i > 0)
                        {
                            //The tile is empty
                            if ((input[i - 1, j] == 0) ||
                                //The tile is the same as the current one
                                (input[i - 1, j] == input[i, j]))
                            {
                                ToReturn = 0;
                            }
                        }
                        if (j > 0)
                        {
                            //The tile is empty
                            if ((input[i, j - 1] == 0) ||
                                //The tile is the same as the current one
                                (input[i, j - 1] == input[i, j]))
                            {
                                ToReturn = 0;
                            }
                        }
                        if (i < 3)
                        {
                            //The tile is empty
                            if ((input[i + 1, j] == 0) ||
                                //The tile is the same as the current one
                                (input[i + 1, j] == input[i, j]))
                            {
                                ToReturn = 0;
                            }
                        }
                        if (j < 3)
                        {
                            //The tile is empty
                            if ((input[i, j + 1] == 0) ||
                                //The tile is the same as the current one
                                (input[i, j + 1] == input[i, j]))
                            {
                                ToReturn = 0;
                            }
                        }
                    }
                    j++;
                }
                i++;
            }
            return ToReturn;
        }

        #endregion
    }
}
