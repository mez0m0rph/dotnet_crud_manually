using Microsoft.EntityFrameworkCore;

namespace project
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _db;
        public TaskRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _db.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            var taskItem = await _db.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            return taskItem;
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _db.TaskItems.AddAsync(taskItem);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            _db.TaskItems.Update(taskItem);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _db.TaskItems.FindAsync(id);
            if (task != null)
            {
                _db.TaskItems.Remove(task);
                await _db.SaveChangesAsync();
            }
        }
    }
}