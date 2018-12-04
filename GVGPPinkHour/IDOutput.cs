using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVGPPinkHour
{
    /// <summary>
    /// Output of the Identifier block
    /// </summary>
    class IDOutput
    {
        public int[,] BoardState;

        public IDOutput(int[,] board)
        {
            this.BoardState = board;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual
        /// </summary>
        /// <returns>Cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            String ToReturn = "";
            for (int i = 0; i < 4; i++)
            {
                ToReturn += "Fila " + i + ", ";
                for (int j = 0; j < 4; j++)
                {
                    ToReturn += "Columna " + j + ": {";
                    ToReturn += "" + BoardState[i, j];
                    ToReturn += "}, ";
                }
                ToReturn += "\n";
            }
            return ToReturn;
        }
    }    
}
