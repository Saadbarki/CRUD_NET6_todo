using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Entities;

namespace Todo.Repositories
{
    public class TodoService : ITodoService
    {
        private readonly DbContextClass _dbcontext;
        public TodoService(DbContextClass dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<ImTodo>> GetTodoListAsync()
        {
            return await _dbcontext.TodoTab.FromSqlRaw<ImTodo>("GetTodoList").ToListAsync();
        }
        public async Task<IEnumerable<ImTodo>> GetTodoListByIdAsync(int todoId)
        {
            var param = new SqlParameter("TodoId", todoId);
            var TodoDetails = await Task.Run(() => _dbcontext.TodoTab.FromSqlRaw<ImTodo>(@"exec GetTodoListById @TodoId", param)
            .ToListAsync());
            return TodoDetails;
        }
        public async Task<int> AddTodoAsync(ImTodo todo)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", todo.Name));
            parameters.Add(new SqlParameter("@Description", todo.Description));
            var result = await Task.Run(() => _dbcontext.Database.ExecuteSqlRawAsync(@"exec AddNewTodo @Name,@Description", parameters.ToArray()));
            return result;
        }
        public async Task<int> UpdateTodoAsync(ImTodo todo)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TodoId", todo.ID));
            parameters.Add(new SqlParameter("@Name", todo.Name));
            parameters.Add(new SqlParameter("@Description", todo.Description));
            var result = await Task.Run(() => _dbcontext.Database.ExecuteSqlRawAsync(@"exec UpdateTodo @TodoId,@Name,@Description", parameters.ToArray()));
            return result;
        }
        public async Task<int> DeleteTodoAsync(int todoId)
        {
            return await Task.Run(() => _dbcontext.Database.ExecuteSqlInterpolatedAsync($"DeleteTodoById {todoId}"));
        }
    }
}
