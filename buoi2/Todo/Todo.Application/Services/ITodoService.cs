using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Infrastructure;

namespace Todo.Application.Services
{
	public interface ITodoService
	{
		Task<List<Todo.Infrastructure.Todo>> GetAll();
		Task<Todo.Infrastructure.Todo> GetById(int id);
		Task AddTodo(Todo.Infrastructure.Todo todo);
		Task UpdateTodo(Todo.Infrastructure.Todo todo);
		Task DeleteTodo(int id);
	}
}
