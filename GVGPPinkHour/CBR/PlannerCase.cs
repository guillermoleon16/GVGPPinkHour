using System;
namespace MiscConsoleMAC
{
    public class PlannerCase: Case
    {
        public int ID;
        public bool[] Completion;
        public Case CompletedCase;
        public bool Completed;
        public bool Learned;
        public int Score;

        public PlannerCase(int id, int[] labels, bool[] completion)
        {
            ID = id;
            Completed = false;
            Labels = new int[labels.Length];
            Array.Copy(labels, Labels, labels.Length);

            Completion = new bool[completion.Length];
            Array.Copy(completion, Completion, completion.Length);
            Score = 0;
            Learned = false;
        }

        public bool CheckCompletion(int[] labels)
        {
            bool toReturn = true;
            for (int i = 0; i < Completion.Length; i++)
            {
                if(Completion[i])
                {
                    toReturn &= Labels[i] == labels[i];
                }
            }
            if(!Completed)
            {
                if (toReturn)
                {
                    CompletedCase = new Case(labels);
                }
                Completed = toReturn;
            }
            return toReturn;
        }
    }
}
