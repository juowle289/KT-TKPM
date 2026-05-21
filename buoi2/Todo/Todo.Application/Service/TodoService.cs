using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Repositories;
using Todo.Domain.Entities;
using TodoEntity = Todo.Domain.Entities.Todo;

namespace Todo.Application.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        // 2. Đổi đầu vào thành Todo (không còn chữ Infrastructure.)
        public async Task AddTodo(TodoEntity todo)
        {
            await _repository.AddAsync(todo);
            await _repository.SaveChangeAsyns();
        }

        public Task DeleteTodo(int id)
        {
            throw new NotImplementedException();
        }

        // 3. Đổi kiểu trả về thành List<Todo> chuẩn Domain
        public async Task<List<TodoEntity>> GetAll()
        {
            // Gọi hàm GetAll() chuẩn mà chúng ta đã đồng bộ ở ITodoRepository
            var todos = await _repository.GetAll();
            return todos.ToList();
        }

        // 4. Đổi kiểu trả về thành Todo? chuẩn Domain
        public async Task<TodoEntity?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // 5. Đổi đầu vào thành Todo chuẩn Domain
        public async Task UpdateTodo(TodoEntity todo)
        {
            var item = await _repository.GetByIdAsync(todo.Id);
            if (item != null)
            {
                item.Title = todo.Title;
                item.IsCompleted = todo.IsCompleted;

                _repository.Update(item);
                await _repository.SaveChangeAsyns();
            }
        }
    }
}