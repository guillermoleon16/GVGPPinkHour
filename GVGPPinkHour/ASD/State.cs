using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVGPPinkHour
{
    public class State
    {
        public long id;
        public int[] Labels;
        public double[] Board;
        public State[] Links;

        public State(State s)
        {
            id = 0;
            Board = new double[s.Board.Length];
            Array.Copy(s.Board, Board, s.Board.Length);
            Links = new State[s.Links.Length];
        }

        public State(double[] board,int nMoves)
        {
            Board = new double[board.Length];
            Array.Copy(board, Board, board.Length);
            Links = new State[nMoves];
        }

        public State(double[,] board, int nMoves)
        {
            Board = MatrixToVector(board);
            Links = new State[nMoves];
        }

        public bool Equals(State s)
        {
            bool toReturn = true;
            int i = 0;
            while (toReturn && i < Board.Length)
            {
                if (Board[i] != s.Board[i])
                {
                    toReturn = false;
                }
                i++;
            }
            return toReturn;
        } 

        public static double[] MatrixToVector(double[,] board)
        {
            double[] toReturn = new double[board.Length];
            int i = 0;
            foreach(double v in board)
            {
                toReturn[i] = v;
                i++;
            }
            return toReturn;
        }

        public Bitmap ToBitmap(int width, int height)
        {
            Bitmap toReturn = new Bitmap(width, height);
            if(Labels != null)
            {
                int k = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Color toColor = new Color();
                        switch(Labels[k])
                        {
                            case 0:
                                {
                                    toColor = Color.Black;
                                    break;
                                }
                            case 1:
                                {
                                    toColor = Color.White;
                                    break;
                                }
                            case 2:
                                {
                                    toColor = Color.Violet;
                                    break;
                                }
                            case 3:
                                {
                                    toColor = Color.Yellow;
                                    break;
                                }
                            case 4:
                                {
                                    toColor = Color.Red;
                                    break;
                                }
                            case 5:
                                {
                                    toColor = Color.Blue;
                                    break;
                                }
                            case 6:
                                {
                                    toColor = Color.Orange;
                                    break;
                                }
                            case 7:
                                {
                                    toColor = Color.Green;
                                    break;
                                }
                            case 8:
                                {
                                    toColor = Color.LightBlue;
                                    break;
                                }
                            case 9:
                                {
                                    toColor = Color.LightGreen;
                                    break;
                                }
                            case 10:
                                {
                                    toColor = Color.SandyBrown;
                                    break;
                                }
                            case 11:
                                {
                                    toColor = Color.Silver;
                                    break;
                                }
                        }
                        toReturn.SetPixel(j, i, toColor);
                        k++;
                    }
                }
            }
            return toReturn;
        }

        public static Bitmap ToBitmap(int width, int height, int[] Labels)
        {
            Bitmap toReturn = new Bitmap(width, height);
            if (Labels != null)
            {
                int k = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Color toColor = new Color();
                        switch (Labels[k])
                        {
                            case 0:
                                {
                                    toColor = Color.Black;
                                    break;
                                }
                            case 1:
                                {
                                    toColor = Color.Red;
                                    break;
                                }
                            case 2:
                                {
                                    toColor = Color.Violet;
                                    break;
                                }
                            case 3:
                                {
                                    toColor = Color.Yellow;
                                    break;
                                }
                            case 4:
                                {
                                    toColor = Color.White;
                                    break;
                                }
                            case 5:
                                {
                                    toColor = Color.Blue;
                                    break;
                                }
                            case 6:
                                {
                                    toColor = Color.Orange;
                                    break;
                                }
                            case 7:
                                {
                                    toColor = Color.Green;
                                    break;
                                }
                            case 8:
                                {
                                    toColor = Color.LightBlue;
                                    break;
                                }
                            case 9:
                                {
                                    toColor = Color.LightGreen;
                                    break;
                                }
                            case 10:
                                {
                                    toColor = Color.SandyBrown;
                                    break;
                                }
                            case 11:
                                {
                                    toColor = Color.Silver;
                                    break;
                                }
                        }
                        toReturn.SetPixel(j, i, toColor);
                        k++;
                    }
                }
            }
            return toReturn;
        }
    }
}
