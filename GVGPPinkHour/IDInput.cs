using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVGPPinkHour
{
    /// <summary>
    /// Input for the identifier block
    /// </summary>
    public class IDInput
    {
        /// <summary>
        /// Matrix of the rgb values on a vision PlannedBoard.
        /// </summary>
        public long[,,] RGBMatrix;

        /// <summary>
        /// Get new instance of IDInput
        /// </summary>
        /// <param name="rgbMatrix">New value of <c>RGBMatrix</c>
        /// to be set</param>
        public IDInput(long[,,] rgbMatrix)
        {
            RGBMatrix = new long[3, 4, 4];
            Array.Copy(rgbMatrix, RGBMatrix, 48);
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
                    ToReturn += "" + RGBMatrix[0, i, j] + "," + RGBMatrix[1, i, j] + "," + RGBMatrix[2, i, j];
                    ToReturn += "}, ";
                }
                ToReturn += "\n";
            }
            return ToReturn;
        }
    }
}
