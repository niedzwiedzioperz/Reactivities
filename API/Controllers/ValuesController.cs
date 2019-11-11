using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly DataContext _dataContext;

        public ValuesController(
            ILogger<ValuesController> logger,
            DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IAsyncEnumerable<Value>> Get()
            => Ok(_dataContext.Values);

        [HttpGet("{id}")]
        public ActionResult<Value> Get(int id)
            => Ok(_dataContext.Values.FirstOrDefaultAsync(v => v.Id == id));
    }
}
