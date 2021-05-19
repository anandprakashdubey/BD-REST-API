using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataNumberAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataNumberController : ControllerBase
    {
        Random _randomDelay = new Random();
        Random _randomGenNumber = new Random();
        Random _randomMulNumber = new Random();

        [HttpGet("{givenNumber}")]
        public IActionResult GetGeneratedNumber(int givenNumber)
        {
            Thread.Sleep(_randomDelay.Next(5, 10) * 1000);

            List<int> _numbers = new List<int>();
            for (int i = 0; i < givenNumber; i++)
                _numbers.Add(_randomGenNumber.Next(1, 100));
            
            return Ok(_numbers);        
        }

        [HttpGet("{mulNumber}")]
        public IActionResult GetMultipliedNumber(string mulNumber)
        {
            var _givennumbers = mulNumber.Split(',').Select(int.Parse).ToList();
            Thread.Sleep(_randomDelay.Next(5, 10) * 1000);

            List<int> _numbers = new List<int>();
            for (int i = 0; i < _givennumbers.Count() ; i++)
                _numbers.Add(_randomMulNumber.Next(2, 4) * _givennumbers[i]);

            return Ok(_numbers);
        }
    }
}
