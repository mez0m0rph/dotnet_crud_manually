using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace project
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDto>> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Create(TaskCreateDto createDto)
        {
            var result = await _taskService.CreateTaskAsync(createDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskUpdateDto updateDto)
        {
            await _taskService.UpdateTaskAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult> Delete(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

    }
}