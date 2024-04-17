using Todo.Entities;

namespace Todo.Repositories
{
    public interface ITodoService
    {
        public Task<List<ImTodo>> GetTodoListAsync();
        public Task<IEnumerable<ImTodo>> GetTodoListByIdAsync(int id);
        public Task<int> AddTodoAsync(ImTodo todo);
        public Task<int> UpdateTodoAsync(ImTodo todo);
        public Task<int> DeleteTodoAsync(int id);
    }
}
