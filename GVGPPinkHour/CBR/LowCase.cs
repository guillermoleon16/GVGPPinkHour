using System;
using System.Collections.Generic;

namespace MiscConsoleMAC
{
	public class LowCase: Case
    {
		public List<ActionScore> Actions;
        public List<BehaviorScore> Behaviors;
		public int ActiveAction;

        public class ActionScore
		{
			public int Action;
			public int Score;
		}

        public class BehaviorScore
        {
            public int Uses;
            public int Useful;
        }

		public LowCase(int nMoves, int nBehaviors):base()
        {
			Random RNG = new Random();
            Actions = new List<ActionScore>();
            for (int i = 0; i < nMoves; i++)
            {
				int toAdd = RNG.Next(nMoves);
				while(Actions.Find(x => x.Action == toAdd) != null)
				{
					toAdd = RNG.Next(nMoves);
				}
                Actions.Add(new ActionScore
                {
                    Action = toAdd,
                    Score = 0
                });
            }
            Behaviors = new List<BehaviorScore>();
            for (int i = 0; i < nBehaviors; i++)
            {
                Behaviors.Add(new BehaviorScore
                {
                    Useful = 0,
                    Uses = 0
                });
            }
        }

		public LowCase(int[] labels, int nMoves, int nBehaviors) : base(labels)
		{
			Random RNG = new Random();
            Actions = new List<ActionScore>();
            for (int i = 0; i < nMoves; i++)
            {
                int toAdd = RNG.Next(nMoves);
                while (Actions.Find(x => x.Action == toAdd) != null)
                {
                    toAdd = RNG.Next(nMoves);
                }
                Actions.Add(new ActionScore
                {
                    Action = toAdd,
                    Score = 0
                });
            }
            Behaviors = new List<BehaviorScore>();
            for (int i = 0; i < nBehaviors; i++)
            {
                Behaviors.Add(new BehaviorScore
                {
                    Useful = 0,
                    Uses = 0
                });
            }
        }

        public LowCase(int[] labels, List<ActionScore> actions, int nBehaviors): base (labels)
        {
            Actions = new List<ActionScore>();
            foreach(ActionScore asc in actions)
            {
                Actions.Add(new ActionScore
                {
                    Action = asc.Action,
                    Score = 0
                });
            }
            Behaviors = new List<BehaviorScore>();
            for (int i = 0; i < nBehaviors; i++)
            {
                Behaviors.Add(new BehaviorScore
                {
                    Useful = 0,
                    Uses = 0
                });
            }
        }

        public double BehaviorAffinity(int behavior)
        {
            if(behavior > Behaviors.Count - 1)
            {
                return 0;
            }
            else
            {
                if(Behaviors[behavior].Uses == 0)
                {
                    return 0;
                }
                else
                {
                    return (double) Behaviors[behavior].Useful / (double) Behaviors[behavior].Uses;
                }
            }
        }

        public void AssignScore(int targetAction, int score)
		{
			Actions.Find(x => x.Action == targetAction).Score = score;
			SortActions();
		}

		public void IncrementScore(int targetAction)
		{
            Actions.Find(x => x.Action == targetAction).Score++;
            SortActions();
		}

		public void DecrementScore(int targetAction)
        {
            Actions.Find(x => x.Action == targetAction).Score--;
            SortActions();
        }

        public void Banish(int targetAction)
        {
            Actions.Find(x => x.Action == targetAction).Score = Actions[Actions.Count - 1].Score - 1;            
            SortActions();
        }

        public void Praise(int targetAction)
        {
            Actions.Find(x => x.Action == targetAction).Score = Actions[0].Score + 1;
            SortActions();
        }

        public void RateUsefulness(int targetBehavior, bool wasUseful)
        {
            if (targetBehavior <=  Behaviors.Count - 1)
            {
                Behaviors[targetBehavior].Uses++;
                if(wasUseful)
                {
                    Behaviors[targetBehavior].Useful++;
                }
            }
        }

        public void NormalizeScores()
		{
            int sumsq = 0;
            int sum = 0;
            foreach (ActionScore asc in Actions)
            {
                sumsq += asc.Score * asc.Score;
                sum += asc.Score;
            }
            int meanScore = 0;
            if(sum != 0)
            {
                meanScore = sumsq / (sum * 2);
            }
			foreach (ActionScore asc in Actions)
            {
				asc.Score -= meanScore;
            }
		}

        public void BonusUsefulness(int targetBehavior)
		{
			if (targetBehavior <= Behaviors.Count - 1)
            {
				if(Behaviors[targetBehavior].Uses > Behaviors[targetBehavior].Useful)
				{
					Behaviors[targetBehavior].Useful += 
						(int)Math.Floor((Behaviors[targetBehavior].Uses - Behaviors[targetBehavior].Useful)/ 2.0);
				}
            }
		}

        public void SortActions()
		{
			Actions.Sort((ActionScore x, ActionScore y) => y.Score.CompareTo(x.Score));
		}

        public int RetrieveAction(bool retry)
		{
			int toReturn = -1;
			if(!retry)
			{
				ActiveAction = 0;
			}
			toReturn = Actions[ActiveAction].Action;
			if(ActiveAction < Actions.Count - 1)
			{
				ActiveAction++;
			}
			else
			{
				ActiveAction = 0;
			}
			return toReturn;
		}
        
        public void Reset(int nMoves)
		{
			Random RNG = new Random();
            Actions = new List<ActionScore>();
            for (int i = 0; i < nMoves; i++)
            {
                int toAdd = RNG.Next(nMoves);
                while (Actions.Find(x => x.Action == toAdd) != null)
                {
                    toAdd = RNG.Next(nMoves);
                }
                Actions.Add(new ActionScore
                {
                    Action = toAdd,
                    Score = 0
                });
            }
			foreach(BehaviorScore bs in Behaviors)
			{
				bs.Useful = 0;
				bs.Uses = 0;
			}
			foreach(ActionScore asc in Actions)
			{
				asc.Score = 0;
			}
			ActiveAction = 0;
		}

    }
}
