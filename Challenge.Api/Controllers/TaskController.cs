using Challenge.CommandsAndQueries.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskQuery _taskQuery;

        public TaskController(ILogger<TaskController> logger, ITaskQuery taskQuery)
        {
            _logger = logger;
            _taskQuery = taskQuery;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _taskQuery.GetAll();
                return Ok(result);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
