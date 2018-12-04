using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsoleMAC
{
    public class Supervisor
    {
        public State LastState;
        public List<State> GameTree;

        public Supervisor()
        {
            GameTree = new List<State>();
            Reset();
        }

        public void Reset()
        {
            LastState = null;
            GameTree.Clear();
        }

        public bool AddState(int[] labels,int move, int reward)
        {
            if(LastState == null)
            {
				LastState = new State(labels)
				{
					Reward = reward
				};
				GameTree.Add(LastState);
                return true;
            }
            else
            {
                State next = GameTree.Find(x => x.Equals(labels));
                if (next == null)
                {
                    LastState.Move = move;
					LastState = new State(labels)
                    {
                        Reward = reward
                    };
                    GameTree.Add(LastState);
                    return true;
                }
                else
                {
                    int i = GameTree.Count - 1;
                    while ((i > 0) && (!GameTree[i].Equals(labels)))
                    {
                        GameTree.RemoveAt(i);
                        i--;
                    }
                    LastState = GameTree[GameTree.Count - 1];
					LastState.Attempts++;
                    return false;
                }
            }
        }

        public double MeanScore()
        {
            double meanScore = 0;
            foreach(State s in GameTree)
            {
                meanScore += s.GetScore();
            }

            return meanScore / GameTree.Count;
        }

        public List<State> GetSubTree(State source, State destination)
        {
            bool start = source == null;
            bool end = false;
            List<State> toReturn = new List<State>();
            foreach(State elem in GameTree)
            {
                if((start)&&(!end))
                {
                    toReturn.Add(elem);
                }
                else
                {
                    if(!start)
                    {
                        start = elem.Equals(source);
                    }
                    if(start)
                    {
                        toReturn.Add(elem);
                    }
                }
                if(destination != null)
                {
                    end = elem.Equals(destination);
                }
            }
            return toReturn;
        }
    }
}
