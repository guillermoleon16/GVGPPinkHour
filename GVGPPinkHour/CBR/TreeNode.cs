using System;
namespace MiscConsoleMAC
{
    public class TreeNode: Case
    {
        public int ID;
        public TreeNode[] Next;
        public bool Visited;
        public int Distance;

        public TreeNode(int nMoves, int[] labels): base(labels)
        {
           Next = new TreeNode[nMoves];
            Visited = true;
            Distance = -1;
        }

        public TreeNode(TreeNode source): base(source.Labels)
        {
            Next = new TreeNode[source.Next.Length];
            Visited = source.Visited;
        }

        public bool IsLeaf()
        {
            bool toReturn = true;
            foreach(TreeNode tn in Next)
            {
                if(tn != null)
                {
                    toReturn = false;
                    break;
                }
            }
            return toReturn;
        }

        public bool PointsTo(TreeNode objective)
        {
            bool toReturn = false;

            foreach(TreeNode tn in Next)
            {
                if(tn != null)
                {
                    if (tn.DistanceTo(objective) == 0)
                    {
                        toReturn = true;
                        break;
                    }
                }
            }

            return toReturn;
        }
    }
}
