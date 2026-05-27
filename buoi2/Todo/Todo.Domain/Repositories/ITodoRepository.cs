using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Infrastructure;

namespace Todo.Domain.Repositories
{
	public interface ITodoRepository : IRepository<Todo.Infrastructure.Todo>
	{
	}
}
