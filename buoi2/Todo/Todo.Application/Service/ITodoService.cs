using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;
// Đặt bí danh: Ép C# hiểu TodoEntity chính là Class Todo của tầng Domain
using TodoEntity = Todo.Domain.Entities.Todo;   

namespace Todo.Application.Service
{
    public interface ITodoService
    {
        Task<List<TodoEntity>> GetAll();
        Task<TodoEntity?> GetById(int id);
        Task AddTodo(TodoEntity todo);
        Task UpdateTodo(TodoEntity todo);
        Task DeleteTodo(int id);
    }
}