using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVGPPinkHour
{
    class EInput
    {
        public int[,] PlannedBoard;

        public EInput(int[,] matrix)
        {
            this.PlannedBoard = new int[4, 4];
            Array.Copy(matrix, this.PlannedBoard, 16);
        }
    }
}
