using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Todo.Entities;
using Todo.Repositories;

namespace Todo.Controllers
{
    [Route("api/TodoController")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;
        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }
        [HttpGet("GetTodoList")]
        public async Task<List<ImTodo>> GetTodoListAsync()
        {
            try
            {
                return await todoService.GetTodoListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetTodoByID")]
        public async Task<IEnumerable<ImTodo>> GetTodoByIdAsync(int todoId)
        {
            try
            {
                var response =  await todoService.GetTodoListByIdAsync(todoId);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("AddNewTodo")]
        public async Task<IActionResult> AddNewTodoAsync(ImTodo todoObj)
        {
            if (todoObj == null)
            {
                return BadRequest(); ;
            }
            try
            {

                var response = await todoService.AddTodoAsync(todoObj);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("UpdateTodo")]
        public async Task<IActionResult> UpdateTodoAsync(ImTodo todoObj)
        {
            if (todoObj == null)
            {
                return BadRequest(); ;
            }
            try
            {

                var response = await todoService.UpdateTodoAsync(todoObj);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("DeleteTodo")]
        public async Task<int> DeleteTodoAsync(int Id)
        {
            try
            {

                var response = await todoService.DeleteTodoAsync(Id);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
