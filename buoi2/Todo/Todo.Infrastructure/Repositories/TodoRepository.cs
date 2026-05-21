using System.Threading.Tasks;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Data;
using Todo.Domain.Repositories;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly Repository<Todo> _repo;

        public TodoRepository(TodoDbContext context)
        {
            _repo = new Repository<Todo>(context);
        }

        public async Task AddAsync(Todo entity) => await _repo.AddAsync(entity);

        public void Delete(Todo entity) => _repo.Delete(entity);

        public async Task<IEnumerable<Todo>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Todo?> GetAsync(int id) => await _repo.GetAsync(id);

        public async Task<Todo?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task SaveChangeAsyns() => await _repo.SaveChangeAsyns();

        public void Update(Todo entity) => _repo.Update(entity);

        public async Task<IEnumerable<Todo>> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return list;
        }

        Task<IEnumerable<Domain.Entities.Todo>> ITodoRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Domain.Entities.Todo?> IRepository<Domain.Entities.Todo>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Domain.Entities.Todo>> IRepository<Domain.Entities.Todo>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Domain.Entities.Todo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Todo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Entities.Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}
