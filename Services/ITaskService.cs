using Microsoft.EntityFrameworkCore;

namespace project
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync();
        Task<TaskResponseDto?> GetTaskByIdAsync(int id);
        Task<TaskResponseDto> CreateTaskAsync(TaskCreateDto createTaskDto);
        Task UpdateTaskAsync(int id, TaskUpdateDto updateDto);
        Task DeleteTaskAsync(int id);


    }
}