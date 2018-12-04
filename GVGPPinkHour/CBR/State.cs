using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsoleMAC
{
    public class State: Case
    {
        public int Move;
        public int Reward;
        public int Attempts;

        public State(int[] labels) : base(labels)
        {
            Move = 0;
            Reward = 0;
            Attempts = 1;
        }

        public double GetScore()
        {
            if (Reward > 0)
            {
                return (1.0 / (double)Attempts) * (double)Reward;
            }
            else
            {
                return -(1.0 / (double)Attempts) * (double)Reward;
            }
        }

        public State(State source):base(source.Labels)
        {
            Move = source.Move;
        }
    }
}
