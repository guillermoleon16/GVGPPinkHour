using System;
using System.Collections.Generic;

namespace MiscConsoleMAC
{
	public class CBRLimitedAgent : IAgent
    {
		public int CBSizeLimit;
		public List<CaseScore> LowCB;
		public List<LowCase> UsedInBehavior;
		public List<PlannerCase> HighCB;
		public Supervisor SV;
		public Random RNG;
		public int NMoves;
		public bool Retry;
		public int LastAction;
		public Case LastState;
		public LowCase LastLowC;
		public int LastLowCIndex;
		public PlannerCase LastHighC;
		public int CompletionSteps;

        public class CaseScore
		{
			public LowCase Case;
			public int Score;
		}

        public CBRLimitedAgent(int limit, int nMoves)
        {
			CBSizeLimit = limit;
			LowCB = new List<CaseScore>();
			HighCB = new List<PlannerCase>();
			UsedInBehavior = new List<LowCase>();
			RNG = new Random();
			SV = new Supervisor();
			NMoves = nMoves;
			LastState = null;
			LastAction = 0;
			LastLowCIndex = 0;
			LastLowC = null;
			LastHighC = null;
			Retry = false;
			CompletionSteps = 0;
		}

		public bool Feedback(int reward, int[] nextState)
		{
            int retro = SV.GameTree.Count;
			bool loop = !SV.AddState(nextState, LastAction, reward);
            retro -= SV.GameTree.Count;
            Retry = (LastState.Equals(nextState)) && loop;
			if(Math.Abs(reward) < 100)
			{
				//Still playing
                if(loop)
				{
                    //Loop in the tree
                    if(retro > 0)
                    {
                        for (int i = 0; i < retro; i++)
                        {
                            LastLowC.DecrementScore(LastAction);
                        }
                    }
                    else
                    {
                        LastLowC.DecrementScore(LastAction);
                    }
					LastLowC.RateUsefulness(LastHighC.ID, false);
				}
				else
				{
					LastLowC.IncrementScore(LastAction);
					LastLowC.RateUsefulness(LastHighC.ID, true);
				}
				LastState = new Case(nextState);
			}
			else
			{
                // End game
                if (reward < 0)
                {
					// Lost
					LastLowC.Banish(LastAction);
					LastLowC.RateUsefulness(LastHighC.ID, false);
                }
                else
                {
                    // Won
					LastLowC.Praise(LastAction);
					LastLowC.RateUsefulness(LastHighC.ID, true);
                }
				foreach(CaseScore lc in LowCB)
				{
					lc.Case.NormalizeScores();
				}
                UpdateCaseBase();
                foreach (PlannerCase pc in HighCB)
                {
                    pc.Completed = false;
                }
				SV.Reset();
			}
			return !loop;
		}

        public void UpdateCaseBase()
        {
            NormalizeStates();
            double meanStateScore = SV.MeanScore();
            List<State> CandidateStates = 
                SV.GameTree.FindAll(x => x.GetScore() <= meanStateScore);
            if(CandidateStates.Count > 0)
            {
                CandidateStates.Sort((State x, State y) => x.GetScore().CompareTo(y.GetScore()));
                while((LowCB.Count < CBSizeLimit)&&(CandidateStates.Count > 0))
                {
					CaseScore temp = LowCB.Find(x => x.Equals(CandidateStates[0].Labels));
                    if(temp != null)
					{
						temp.Case.Reset(NMoves);
					}
					else
					{
                        NewLowCase(CandidateStates[0].Labels);
					}
                    CandidateStates.RemoveAt(0);
                }
                if(CandidateStates.Count > 0)
                {
                    List<CaseScore> AvailableCases = LowCB.FindAll(x => x.Score < 0);
					AvailableCases.Sort((CaseScore x, CaseScore y) => x.Score.CompareTo(y.Score));
					while ((AvailableCases.Count > 0) && (CandidateStates.Count > 0))
					{
						if(NewLowCase(CandidateStates[0].Labels))
						{
                            LowCB.Remove(AvailableCases[0]);
						}
						else
						{
							AvailableCases[0].Case.Reset(NMoves);
						}
						CandidateStates.RemoveAt(0);
						AvailableCases.RemoveAt(0);
					}
                }
            }
        }

        public void NormalizeStates()
        {
            int sumsq = 0;
            int sum = 0;
            foreach (CaseScore asc in LowCB)
            {
                sumsq += asc.Score * asc.Score;
                sum += asc.Score;
            }
            int meanScore = 0;
            if (sum != 0)
            {
                meanScore = sumsq / (sum * 2);
            }
            foreach (CaseScore cs in LowCB)
            {
                cs.Score -= meanScore;
            }
        }

        public PlannerCase NearestNeighborHigh()
        {
            bool flag = true;
			PlannerCase temp = HighCB[0];
            foreach (PlannerCase ec in HighCB)
            {
                if ((!ec.Completed) && (flag))
                {
                    temp = ec;
                    flag = false;
                }
                else
                {
                    flag |= ec.Completed;
                }
            }
			if(temp.Equals(LastHighC))
			{
				CompletionSteps++;
				if(LastLowC != null)
				{
					if (UsedInBehavior.Find(x => x.Equals(LastLowC.Labels)) == null)
					{
						UsedInBehavior.Add(LastLowC);
					}
				}
			}
			else
			{
				foreach (LowCase lc in UsedInBehavior)
                {
                    lc.BonusUsefulness(LastHighC.ID);
                }
				if ((LastHighC.Score == 0) || (CompletionSteps < LastHighC.Score))
				{
					LastHighC.Score = CompletionSteps;
					foreach (LowCase lc in UsedInBehavior)
                    {
                        lc.BonusUsefulness(LastHighC.ID);
                    }
					UsedInBehavior.Clear();
				}
				CompletionSteps = 0;	
			}
			LastHighC = temp;
            return LastHighC;
        }
        
        public int NearestNeighborLow(int[] labels)
        {
			double minDist = ((double)LowCB[0].Case.DistanceTo(labels))
				* (1.0 - 0.1*LowCB[0].Case.BehaviorAffinity(LastHighC.ID));
			int index = 0;
			LastLowC = LowCB[0].Case;
			for (int i = 1; i < LowCB.Count; i++)
			{
				LowCase ec = LowCB[i].Case;
				double dist = ((double)ec.DistanceTo(labels))
					/ (1.0 + ec.BehaviorAffinity(LastHighC.ID));
				if ((minDist > dist))
                {
					index = i;
                    minDist = dist;
                    LastLowC = ec;
                }
			}
            return index;
        }

        public int Retrieve(int[] labels)
		{
            foreach (PlannerCase pc in HighCB)
            {
                pc.CheckCompletion(labels);
            }
            NearestNeighborHigh();
            if (SV.GameTree.Count <= 0)
            {
				SV.AddState(labels, 0, 1);
                LastState = SV.GameTree[0];
            }
            if (LowCB.Count <= 0)
            {
                NewLowCase(labels);
            }
			LastLowCIndex = NearestNeighborLow(labels);
            if(Retry)
			{
				LowCB[LastLowCIndex].Score--;
			}
			else
			{
				LowCB[LastLowCIndex].Score += NMoves;
			}
            LastAction = LastLowC.RetrieveAction(Retry);
			return LastAction;
        }

        public bool NewLowCase(int[] labels)
        {
            CaseScore executerCase = LowCB.Find(x => x.Case.Equals(labels));
            if (executerCase != null)
            {
                return false;
            }
            else
            {
                if (LowCB.Count > 0)
                {
                    CaseScore NN = LowCB[0];
                    foreach (CaseScore cs in LowCB)
                    {
                        if (NN.Case.DistanceTo(labels) > cs.Case.DistanceTo(labels))
                        {
                            NN = cs;
                        }
                    }
                    LowCB.Add(new CaseScore()
                    {
                        Case = new LowCase(labels, NN.Case.Actions, HighCB.Count),
                        Score = 0
                    });
                    return true;
                }
                else
                {
                    LowCB.Add(new CaseScore()
                    {
                        Case = new LowCase(labels, NMoves, HighCB.Count),
                        Score = 0
                    });
                    return true;
                }                
            }
        }
    }
}
