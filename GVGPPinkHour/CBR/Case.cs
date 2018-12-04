using System;

namespace MiscConsoleMAC
{
    public class Case
    {
        public int[] Labels;

        public Case()
        {
            
        }

        public Case(int[] labels)
        {
            Labels = new int[labels.Length];
            Array.Copy(labels, Labels, Labels.Length);
        }

        public bool Equals(Case target)
        {
            return DistanceTo(target) == 0;
        }

        public bool Equals(int[] target)
        {
            return DistanceTo(target) == 0;
        }

        public int DistanceTo(Case target)
        {
            int toReturn = 0;
            for (int i = 0; i < Labels.Length; i++)
            {
                toReturn += Math.Abs(Labels[i] - target.Labels[i]);
            }
            return toReturn;
        }

        public int DistanceTo(int[] target)
        {
            int toReturn = 0;
            for (int i = 0; i < Labels.Length; i++)
            {
                toReturn += Math.Abs(Labels[i] - target[i]);
            }
            return toReturn;
        }

        public static int[] MatrixToVector(int[,] matrix)
        {
            int[] toReturn = new int[matrix.Length];
            int k = 0;
            foreach(int i in matrix)
            {
                toReturn[k] = i;
                k++;
            }
            return toReturn;
        }
    } 
}
