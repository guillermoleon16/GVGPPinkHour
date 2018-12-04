using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGVGP;
using SharpGVGP.Utils;

namespace GVGPPinkHour
{
    static class Supervisornew
    {

        public static void RestartGame(int xi, int yi)
        {
            VirtualMouse.MoveTo(xi + 240, yi + 240);
            VirtualMouse.LeftClick();
        }
    }
}
