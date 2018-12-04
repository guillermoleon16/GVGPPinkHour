using System;
namespace MiscConsoleMAC
{
    public class SadGame
    {
        public int X;


        public SadGame()
        {
            Reset();
        }

        public void Reset()
        {
            X = 0;
        }

        public int Move(int move)
        {
            if(X<4)
            {
                switch (move)
                {
                    case -1:
                        {
                            if(X>0)
                            {
                                X--;
                            }
                            break;
                        }
                    case 0:
                        {
                            X++;
                            break;
                        }
                    case 1:
                        {
                            Reset();
                            return -1;
                        }
                }
            }
            else if(X < 7)
            {
                switch (move)
                {
                    case -1:
                        {
                            X++;
                            break;
                        }
                    case 0:
                        {
                            Reset();
                            return -1;
                        }
                    case 1:
                        {
                            X--;
                            break;
                        }
                }
            }
            else if(X < 9)
            {
                switch (move)
                {
                    case -1:
                        {
                            Reset();
                            return -1;
                        }
                    case 0:
                        {
                            X++;
                            break;
                        }
                    case 1:
                        {
                            X--;
                            break;
                        }
                }
            }
            else
            {
                switch (move)
                {
                    case -1:
                        {
                            X--;
                            break;
                        }
                    case 0:
                        {
                            Reset();
                            return -1;
                        }
                    case 1:
                        {
                            X++;
                            break;
                        }
                }
            }
            if(X>=15)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
