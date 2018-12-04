using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GVGPPinkHour
{
    public class FileHandler
    {
        public String FileName { get; private set; }
        private String OnlineMetrics;
        private String OfflineMetrics;
        private ulong OnModifier;
        private ulong OffModifier;
        private ulong OffLines;
        private ulong OnLines;
        private ulong LINE_LIMIT = 2000;

        public FileHandler(String Name)
        {
            this.FileName = Name;
            this.OnlineMetrics = FileName + ".onmetrics.txt";
            this.OfflineMetrics = FileName + ".offmetrics.txt";
            this.OnModifier = 0;
            this.OffLines = 0;
            this.OffModifier = 0;
            this.OnLines = 0;
        }

        public void SaveOnlinePerformance(int IterationID, int TimeStamp,
            double ValidPercentage,int CBSize)
        {
            /*
            StreamWriter writer = File.AppendText(OnlineMetrics);
            writer.WriteLine(IterationID + ";" +
                                        TimeStamp + ";" +
                                        ValidPercentage+";"+CBSize);
            OnLines++;
            if (OnLines > LINE_LIMIT)
            {
                OnModifier++;
                OnlineMetrics = FileName + OnModifier + ".onmetrics.txt";
                OnLines = 0;
            }
            writer.Close();
            */
        }

        public void SaveOfflinePerformance(int IterationID, int TimeStamp,
            int CBSize, double ValidPercentage)
        {
            StreamWriter writer = File.AppendText(OfflineMetrics);
            writer.WriteLine(IterationID + ";" +
                             TimeStamp + ";" +
                             CBSize + ";" +
                             ValidPercentage
                );
            OffLines++;
            if (OffLines > LINE_LIMIT)
            {
                OffModifier++;
                OfflineMetrics = FileName + OffModifier + ".offmetrics.txt";
                OffLines = 0;
            }
            writer.Close();
        }
    }
}