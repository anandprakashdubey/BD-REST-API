using DataProcessAPI.Model;
using DataProcessAPI.Process;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DataProcessAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class BatchProcessController : ControllerBase
    {
        private readonly IServiceRepository ServiceRepository;

        public BatchProcessController(IServiceRepository _serviceRepository)
        {
            ServiceRepository = _serviceRepository;
        }

        [HttpPost]
        public IActionResult StartProcess([FromBody] BatchViewModel data)
        {
            var r = this.ServiceRepository.StartProcess(data.X, data.Y);
            return Ok(r);
        }


        [HttpGet]
        public IActionResult CheckStatus(int id)
        {
            var data = this.ServiceRepository.GetProcessStatus(id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult ViewDetail(int id, int batchID)
        {
            var data = this.ServiceRepository.GetProcessStatusByEach(id, batchID);
            return Ok(data);
        }

    }
}
