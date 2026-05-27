using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly TodoDbContext _context;
		private readonly DbSet<T> _dbSet;
		public Repository(TodoDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}
		public async Task AddAsync(T entity) => await _context.AddAsync(entity);
		public void Delete(T entity) => _dbSet.Remove(entity);
		public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
		public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
		public async Task SaveChangesAsyns() => await _context.SaveChangesAsync();
		public void Update(T entity) => _dbSet.Update(entity);
	}
}
