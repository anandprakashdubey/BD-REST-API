using Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessAPI.Model
{
    public class BatchModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int CurrentBatch { get; set; }
        public List<int> GeneratedNumberList { get; set; }
        public List<int> MultipliedNumberList { get; set; }
        public int RemainingBatch { get; set; }

        public DateTime LastUpdated { get; set; }

        public int SumOfGeneratedNumbers { get; set; }
        public int SumOfMultipliedNumbers { get; set; }

        public BatchModel ConvertToBatch(DataProcessNumbers dpn) 
        {
            BatchModel btc = new BatchModel();
            btc.X = dpn.X;
            btc.Y = dpn.Y;
            btc.CurrentBatch = dpn.CurrentBatch;
            btc.GeneratedNumberList = dpn.GeneratedNumberList;
            btc.MultipliedNumberList = dpn.MultipliedNumberList;
            btc.RemainingBatch = dpn.RemainingBatch;
            btc.LastUpdated = dpn.LastUpdated;
            btc.SumOfGeneratedNumbers = dpn.GeneratedNumberList.Sum();
            btc.SumOfMultipliedNumbers = dpn.MultipliedNumberList.Sum();

            return btc;
        }
    }
}
