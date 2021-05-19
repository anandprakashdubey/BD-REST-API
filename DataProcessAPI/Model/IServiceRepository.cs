using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessAPI.Model
{
    public interface IServiceRepository
    {
        public int StartProcess(int x, int y);
        public List<BatchViewModel> GetProcessStatus(int Id);

        public List<BatchModel> GetProcessStatusByEach(int Id, int batchID);
    }
}
