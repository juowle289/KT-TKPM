using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities; // Nạp thư mục chứa file Todo.cs của tầng Domain

namespace Todo.Domain.Repositories
{
    // 1. Trỏ IRepository về đúng Entity của Domain
    public interface ITodoRepository : IRepository<Todo.Domain.Entities.Todo>
    {
        // 2. Đổi kiểu trả về thành danh sách thực thể Todo
        Task<IEnumerable<Todo.Domain.Entities.Todo>> GetAll();
    }
}