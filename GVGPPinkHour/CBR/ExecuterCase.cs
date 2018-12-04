using System;
using System.Collections.Generic;

namespace MiscConsoleMAC
{
    public class ExecuterCase: Case
    {
        public List<List<int>> Actions;
        public List<int> Forbidden;

        public ExecuterCase(int[] labels)
        {
            Labels = new int[labels.Length];
            Array.Copy(labels, Labels, labels.Length);
            Actions =  new List<List<int>>();
            Forbidden = new List<int>();
        }

        public void Unforbid(int target)
        {
            Forbidden.Remove(target);
            foreach(List<int> behavior in Actions)
            {
                behavior.Add(target);
            }
        }

        public void Forbid(int target)
        {
            if(Forbidden.FindAll(x => x == target).Count == 0)
            {
                Forbidden.Add(target);
            }
            Forbid();
        }

        public void Forbid()
        {
            foreach (List<int> plan in Actions)
            {
                foreach (int objective in Forbidden)
                {
                    plan.RemoveAll(x => x == objective);
                }
            }
        }

        public void AddBehavior(List<int> actions)
        {
            Actions.Add(actions);
            Forbid();
        }

        public bool ShiftBehavior(int behavior)
        {
            if(behavior >= Actions.Count)
            {
                return false;
            }
            if(Actions[behavior].Count < 2)
            {
                return false;
            }
            int temp = Actions[behavior][0];
            for (int i = 0; i < Actions[behavior].Count-1; i++)
            {
                Actions[behavior][i] = Actions[behavior][i + 1];
            }
            Actions[behavior][Actions[behavior].Count - 1] = temp;
            return true;
        }
    }
}
