using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Repositories;

namespace Todo.Application.Services
{
	public class TodoService : ITodoService
	{
		private readonly ITodoRepository _repository;
		public TodoService(ITodoRepository repository)
		{
			_repository = repository;
		}

		public async Task AddTodo(Infrastructure.Todo todo)
		{
			await _repository.AddAsync(todo);
			await _repository.SaveChangesAsyns();
		}
		public async Task DeleteTodo(int id)
		{
			var item = await _repository.GetByIdAsync(id);
			if(item != null)
			{
				_repository.Delete(item);
				await _repository.SaveChangesAsyns();
			}
		}
		public async Task<List<Infrastructure.Todo>> GetAll()
		{
			var todos = await _repository.GetAllAsync();
			return todos.ToList();
		}
		public async Task<Infrastructure.Todo> GetById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}
		public async Task UpdateTodo(Infrastructure.Todo todo)
		{
			var item = await _repository.GetByIdAsync(todo.Id);
			if(item != null)
			{
				item.Title = todo.Title;
				item.IsCompleted = todo.IsCompleted;
				_repository.Update(item);
				await _repository.SaveChangesAsyns();
			}
		}
	}
}
