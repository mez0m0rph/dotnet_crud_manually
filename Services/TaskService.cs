using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace project
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();

            return tasks.Select(t => new TaskResponseDto {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt
            });
        }

        public async Task<TaskResponseDto?> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null) return null;

            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt
            };
        }

        public async Task<TaskResponseDto> CreateTaskAsync(TaskCreateDto createTaskDto)
        {
            var taskEntity = new TaskItem
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _taskRepository.AddAsync(taskEntity);

            return new TaskResponseDto
            {
                Id = taskEntity.Id,
                Title = taskEntity.Title,
                Description = taskEntity.Description,
                IsCompleted = taskEntity.IsCompleted,
                CreatedAt = taskEntity.CreatedAt
            };
        }

        public async Task UpdateTaskAsync(int id, TaskUpdateDto updateDto)
        {
            var existingTask = await _taskRepository.GetByIdAsync(id);
            if (existingTask == null) return;

            existingTask.Title = updateDto.Title;
            existingTask.Description = updateDto.Description;
            existingTask.IsCompleted = updateDto.IsCompleted;

            await _taskRepository.UpdateAsync(existingTask);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

    }
}