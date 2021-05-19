using DataProcessAPI.Model;
using Newtonsoft.Json;
using Observer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DataProcessAPI.Process
{
    public class NumberProcess
    {
        public int NumberOfBatches { get; set; }
        public int NumberPerBatches { get; set; }
        public NumberProcess(int x, int y)
        {
            NumberOfBatches = x;
            NumberPerBatches = y;
        }

        public async void DoWork(int BatchId, string jsonPath)
        {
            Subject sub = new Subject();
            DataProcessNumbers dpn = new DataProcessNumbers();
            sub.Attach(dpn);

            for (int _currBatch = 0; _currBatch < NumberOfBatches; _currBatch++)
            {
                sub.GeneratedNumberList = await WebClientCall("GetGeneratedNumber", NumberPerBatches.ToString(), null);
                sub.GeneratedNumbers(NumberOfBatches, NumberPerBatches, _currBatch);
                sub.MultipliedNumberList = await WebClientCall("GetMultipliedNumber", null, dpn.GeneratedNumberList);
                sub.MultipliedNumbers(NumberOfBatches, NumberPerBatches, _currBatch);                
                WriteToOutputFile(dpn, BatchId, jsonPath);
            }
        }
        public async Task<List<int>> WebClientCall(string endpoint, string data, List<int> numbers)
        {
            if (numbers != null && numbers.GetType().IsGenericType)
            {
                data = String.Join(",", numbers.Select(i => i.ToString()).ToArray());
            }

            List<int> list = new List<int>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:51666/api/DataNumber/{endpoint}/{data}");
                string responsContent = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<int>>(responsContent);
            }

            return list;
        }

        public void WriteToOutputFile(DataProcessNumbers dpn, int BatchId, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                var fileStream = File.Create(jsonPath);
                fileStream.Close();

                ProcessFile(dpn, BatchId, jsonPath);
            }
            else
            {
                ProcessFile(dpn, BatchId, jsonPath);
            }
        }

        private static List<BatchViewModel> ProcessFile(DataProcessNumbers dpn, int BatchId, string jsonPath)
        {
            BatchModel btc = new BatchModel();
            BatchViewModel bvm = new BatchViewModel();
            List<BatchViewModel> bvmList = new List<BatchViewModel>();

            var list = JsonConvert.DeserializeObject<List<BatchViewModel>>(File.ReadAllText(jsonPath));

            bvmList = list ?? bvmList;

            var _batchVM = bvmList.FirstOrDefault(item => item.BatchId == BatchId);

            if (_batchVM != null)
            {
                _batchVM.Batches.Add(btc.ConvertToBatch(dpn));               
            }
            else {
                bvm.BatchId = BatchId;
                bvm.Batches.Add(btc.ConvertToBatch(dpn));
                bvmList.Add(bvm);
            }
           

            System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(bvmList));
            return bvmList;
        }
    }
}
