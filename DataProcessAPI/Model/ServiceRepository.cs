using DataProcessAPI.Process;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DataProcessAPI.Model
{
    public class ServiceRepository : IServiceRepository
    {
        string jsonPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.json");
        Task t1 = null;
        public int StartProcess(int x, int y)
        {
            NumberProcess prc = new NumberProcess(x, y);
            t1 = Task.Factory.StartNew(() =>
            {
                prc.DoWork(t1.Id, jsonPath);
            });

            return t1.Id;
        }

        public List<BatchViewModel> GetProcessStatus(int Id)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<BatchViewModel>();
            }
            var list = JsonConvert.DeserializeObject<List<BatchViewModel>>(File.ReadAllText(jsonPath));

            if (list == null) return new List<BatchViewModel>();

            var data = list.Where(item => item.BatchId == Id);
            return data.ToList();
        }

        public List<BatchModel> GetProcessStatusByEach(int Id, int batchID)
        {
            if (!File.Exists(jsonPath))
            {
                return new List<BatchModel>();
            }
            var list = JsonConvert.DeserializeObject<List<BatchViewModel>>(File.ReadAllText(jsonPath));

            if (list == null) return new List<BatchModel>();

            var data = list.Where(item => item.BatchId == Id).FirstOrDefault()
                .Batches.Where(item => item.CurrentBatch == batchID);

                 

            return data.ToList();

        }
    }
}
