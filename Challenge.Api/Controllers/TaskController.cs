using Challenge.Api.Dtos;
using Challenge.CommandsAndQueries.Commands;
using Challenge.CommandsAndQueries.Queries;
using Challenge.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

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
                var result = _taskQuery.GetAll().OrderBy(t => t.Codigo).OrderBy(t => !t.IsCompleted);
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

        [HttpPost("updatetasks")]
        public IActionResult UpdateTasks([FromBody] TaskDto[] tasks)
        {
            try
            {
                _taskCommand.UpdateAll(tasks.Select(t => t.ToEntity(true)).ToArray());
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("deletetasks")]
        public IActionResult DeleteTasks([FromBody] TaskDto[] tasks)
        {
            try
            {
                _taskCommand.UpdateAll(tasks.Select(t => t.ToEntity(true)).ToArray(), remove: true);
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
