using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SharpGVGP;
using System.Drawing;

namespace GVGPPinkHour
{
    public class Identifier
    {
        List<ObjectData> Identifiables;
        public int[] LabelArray { get; private set; }
        public double[] StateArray { get; private set; }
        public int VisionRows { get; private set; }
        public int VisionColumns { get; private set; }

        public Identifier(Games game)
        {
            switch (game)
            {
                case Games._2048:
                    {
                        Identifiables = Load2048();
                        VisionRows = 4;
                        VisionColumns = 4;
                        break;
                    }
                case Games.JELLY_ESCAPE:
                    {
                        Identifiables = LoadJellyEscape();
                        VisionRows = 30;
                        VisionColumns = 50;
                        break;
                    }
                case Games.PINK_HOUR:
                    {
                        Identifiables = LoadPinkHour();
                        VisionRows = 15;
                        VisionColumns = 25;
                        break;
                    }
            }
            LabelArray = new int[VisionColumns*VisionRows];
            StateArray = new double[LabelArray.Length];
        }

        private List<ObjectData> Load2048()
        {
            List<ObjectData> toReturn = new List<ObjectData>
            {
                new ObjectData
                {
                    Name = "0",
                    Label = 0,
                    Color = Color.FromArgb(205, 193, 179)
                },
                new ObjectData
                {
                    Name = "2",
                    Label = 1,
                    Color = Color.FromArgb(223, 213, 202)
                },
                new ObjectData
                {
                    Name = "4",
                    Label = 2,
                    Color = Color.FromArgb(230, 218, 195)
                },
                new ObjectData
                {
                    Name = "8",
                    Label = 3,
                    Color = Color.FromArgb(241, 181, 129)
                },
                new ObjectData
                {
                    Name = "16",
                    Label = 4,
                    Color = Color.FromArgb(244, 158, 113)
                },
                new ObjectData
                {
                    Name = "32",
                    Label = 5,
                    Color = Color.FromArgb(244, 137, 111)
                },
                new ObjectData
                {
                    Name = "64",
                    Label = 6,
                    Color = Color.FromArgb(245, 111, 81)
                },
                new ObjectData
                {
                    Name = "128",
                    Label = 7,
                    Color = Color.FromArgb(238, 210, 126)
                },
                new ObjectData
                {
                    Name = "256",
                    Label = 8,
                    Color = Color.FromArgb(238, 209, 115)
                },
                new ObjectData
                {
                    Name = "512",
                    Label = 9,
                    Color = Color.FromArgb(237, 205, 97)
                },
                new ObjectData
                {
                    Name = "1024",
                    Label = 10,
                    Color = Color.FromArgb(232, 198, 90)
                },
                new ObjectData
                {
                    Name = "2048",
                    Label = 11,
                    Color = Color.FromArgb(238, 194, 46)
                }
            };
            return toReturn;
        }

        private List<ObjectData> LoadJellyEscape()
        {
            List<ObjectData> toReturn = new List<ObjectData>
            {
                new ObjectData
                {
                    Name = "Avatar",
                    Label = 1,
                    Unique = true,
                    Color = Color.FromArgb(78, 105, 44)
                },
                new ObjectData
                {
                    Label = 2,
                    Name = "Fire",
                    Unique = false,
                    Color = Color.FromArgb(117, 100, 49)
                },
                new ObjectData
                {
                    Label = 0,
                    Name = "Background",
                    Unique = false,
                    Color = Color.FromArgb(37, 37, 37)
                },
                new ObjectData
                {
                    Label = 3,
                    Name = "Platform",
                    Unique = false,
                    Color = Color.FromArgb(64, 96, 136)
                },
                new ObjectData
                {
                    Label = 4,
                    Name = "Goal",
                    Unique = true,
                    Color = Color.FromArgb(66, 72, 75)
                },
                new ObjectData
                {
                    Label = 3,
                    Name = "Goo",
                    Unique = false,
                    Color = Color.FromArgb(56, 128, 104)
                },
                new ObjectData
                {
                    Label = 10,
                    Name = "End flag",
                    Unique = false,
                    Color = Color.FromArgb(240, 240, 1)
                },
                new ObjectData
                {
                    Label = 0,
                    Name = "Checkpoint",
                    Unique = false,
                    Color = Color.FromArgb(81, 102, 72)
                }
            };
            return toReturn;
        }

        private List<ObjectData> LoadPinkHour()
        {
            List<ObjectData> toReturn = new List<ObjectData>
            {
                new ObjectData
                {
                    Name = "Avatar",
                    Label = 1,
                    Unique = true,
                    Color = Color.FromArgb(186, 98, 130)
                },
                new ObjectData
                {
                    Label = 2,
                    Name = "Enemy",
                    Unique = false,
                    Color = Color.FromArgb(42, 27, 16)
                },
                new ObjectData
                {
                    Label = 0,
                    Name = "Background",
                    Unique = false,
                    Color = Color.FromArgb(0, 0, 0)
                },
                new ObjectData
                {
                    Label = 3,
                    Name = "Platform",
                    Unique = false,
                    Color = Color.FromArgb(64, 85, 56)
                },
                new ObjectData
                {
                    Label = 3,
                    Name = "Hanging Platform",
                    Unique = false,
                    Color = Color.FromArgb(1, 26, 1)
                },
                new ObjectData
                {
                    Label = 0,
                    Name = "Innocent Bush",
                    Unique = false,
                    Color = Color.FromArgb(11, 12, 1)
                },
                new ObjectData
                {
                    Label = 2,
                    Name = "Flying Enemy",
                    Unique = false,
                    Color = Color.FromArgb(28, 55, 19)
                },
                new ObjectData
                {
                    Label = 10,
                    Name = "Death Flag",
                    Unique = false,
                    Color = Color.FromArgb(36, 15, 46)
                },
                new ObjectData
                {
                    Label = 8,
                    Name = "Water",
                    Unique = false,
                    Color = Color.FromArgb(0, 23, 85)
                }
            };
            return toReturn;
        }

        public class ObjectData
        {
            public bool Unique;
            public Color Color;
            public int Label;
            public String Name;

            public ObjectData()
            {
                Name = "";
                Unique = false;
                Color = Color.FromArgb(0);
                Label = 0;
            }
        }

        public int ColorDifference(Color C1, Color C2)
        {
            return
                (C1.R - C2.R) * (C1.R - C2.R) +
                (C1.G - C2.G) * (C1.G - C2.G) +
                (C1.B - C2.B) * (C1.B - C2.B)
                ;
        }

        public double[] GetInput(Bitmap screenshot)
        {
            List<ObjectData> UniqueLabels = new List<ObjectData>();
            List<ObjectData> NonUniqueLabels = new List<ObjectData>();
            double maxLabel = 0;

            foreach (ObjectData od in Identifiables)
            {
                if (od.Unique)
                {
                    UniqueLabels.Add(od);
                }
                else
                {
                    NonUniqueLabels.Add(od);
                }
                if (maxLabel < od.Label)
                {
                    maxLabel = od.Label;
                }
            }
            if (NonUniqueLabels.Count > 0)
            {
                int k = 0;
                for (int i = 0; i < screenshot.Height; i++)
                {
                    for (int j = 0; j < screenshot.Width; j++)
                    {
                        int minD = 255 * 255 * 3;
                        int minl = 0;
                        foreach (ObjectData od in NonUniqueLabels)
                        {
                            int dist = ColorDifference(screenshot.GetPixel(j, i), od.Color);
                            if (dist <= minD)
                            {
                                minD = dist;
                                minl = od.Label;
                            }
                        }
                        LabelArray[k] = minl;
                        k++;
                    }
                }
            }

            if (UniqueLabels.Count > 0)
            {                
                foreach (ObjectData od in UniqueLabels)
                {
                    int minD = (255 * 255) * 3;
                    int mink = 0;
                    int k = 0;
                    for (int i = 0; i < screenshot.Height; i++)
                    {
                        for (int j = 0; j < screenshot.Width; j++)
                        {
                            int dist = ColorDifference(od.Color, screenshot.GetPixel(j, i));
                            if (dist <= minD)
                            {
                                mink = k;
                                minD = dist;
                            }
                            k++;
                        }
                    }
                    if(UniqueLabels.Find(x => x.Label == LabelArray[mink]) != null)
                    {
                        if(LabelArray[mink] != 1)
                        {
                            LabelArray[mink] = od.Label;
                        }
                    }
                    else
                    {
                        LabelArray[mink] = od.Label;
                    }
                }
            }

            for (int i = 0; i < LabelArray.Length; i++)
            {
                StateArray[i] = (double)(2.0 * (double)LabelArray[i] / (double)maxLabel) - 1.0;
            }

            return StateArray;
        }
    }
}
