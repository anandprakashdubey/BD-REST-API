using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessAPI.Model
{
    public class BatchViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        private List<BatchModel> _batches = new List<BatchModel>();
        public int BatchId { get; set; }
        public List<BatchModel> Batches
        {
            get { return this._batches; }
            set { _batches = value; }
        }
    }
}
