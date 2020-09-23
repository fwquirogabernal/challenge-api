using Challenge.Api.Dtos;
using Challenge.CommandsAndQueries.Commands;
using Challenge.CommandsAndQueries.Queries;
using Challenge.DataBase.Entities;
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
        private readonly ITaskCommand<Task> _taskCommand;

        public TaskController(ILogger<TaskController> logger,
            ITaskQuery taskQuery,
            ITaskCommand<Task> taskCommand)
        {
            _logger = logger;
            _taskQuery = taskQuery;
            _taskCommand = taskCommand;
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

        [HttpPost("newtask")]
        public IActionResult NewTask([FromBody] TaskDto task)
        {
            try
            {
                _taskCommand.Add(task.ToEntity());
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("updatetask")]
        public IActionResult UpdateTask([FromBody] TaskDto task)
        {
            try
            {
                _taskCommand.Update(task.ToEntity(true));
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("deletetask")]
        public IActionResult DeleteTask([FromBody] TaskDto task)
        {
            try
            {
                _taskCommand.Update(task.ToEntity(true), true);
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
