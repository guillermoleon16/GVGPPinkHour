using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVGPPinkHour
{
    /// <summary>
    /// Output of the Executer block
    /// </summary>
    class EOutput
    {
        public bool[] KeysToPress;

        public EOutput(bool[] keys)
        {
            this.KeysToPress = keys;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual
        /// </summary>
        /// <returns>Cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            String ToReturn = "[";
            for (int i = 0; i < 4; i++)
            {
                ToReturn += "" + KeysToPress[i];
            }
            ToReturn += "]";
            return ToReturn;
        }
    }
}
