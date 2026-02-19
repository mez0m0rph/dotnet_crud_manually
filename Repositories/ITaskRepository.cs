using Microsoft.EntityFrameworkCore;

namespace project
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(int id); // "?" - может быть null

        Task AddAsync(TaskItem taskItem);

        Task UpdateAsync(TaskItem taskItem);

        Task DeleteAsync(int id);
    }
}