using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
	public class TodoUI
	{
		private readonly TodoService _service = new();
		public void ShowTodos()
		{
			var todos = _service.GetTodos();
			Console.WriteLine("=====DANH SACH CONG VIEC=====");
			foreach (var item in todos)
			{
				Console.WriteLine(item.ToString());
			}
			if (todos.Count <= 0)
				Console.WriteLine("Chua co cong viec nao");
			Console.WriteLine("==============================");
		}
		public void ShowMenu()
		{
			Console.WriteLine("=====MENU=====");
			Console.WriteLine("1. Them cong viec");
			Console.WriteLine("2. Xoa cong viec");
			Console.WriteLine("3. Danh dau hoan thanh");
			Console.WriteLine("4. Sua cong viec");
			Console.WriteLine("5. Thoat");
		}
		public void AddTodo()
		{
			Console.WriteLine("Nhap noi dung cong viec: ");
			string contnet = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(contnet))
				_service.CreateTodo(contnet);
		}
		public void RemoveTodo()
		{
            Console.WriteLine("Nhap ID cong viec can xoa: ");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteTodo(id);
        }
		public void ToggleTodo()
		{
			Console.WriteLine("Nhap ID cong viec can danh dau hoan thanh: ");
			int id = int.Parse(Console.ReadLine());
			_service.ToggleTodo(id);
        }
        public void EditTodo()
		{
			Console.WriteLine("Nhap ID cong viec can sua: ");
				int id = int.Parse(Console.ReadLine());
			Console.Write("Nhap noi dung moi: ");
			string content = Console.ReadLine();
			_service.UpdateTodo(id, content);
        }
		public void Run()
		{
			while (true)
			{
				Console.Clear();
				ShowTodos();
				ShowMenu();
				Console.Write("_Chon: ");
				string choice = Console.ReadLine();
				switch (choice)
				{
					case "1":
						AddTodo();  break;
					case "2":
						RemoveTodo(); break;
					case"3":
						ToggleTodo(); break;
					case"4":
						EditTodo(); break;
					case "0":
						return;
                    default:
						Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
						break;
				}
				Console.WriteLine("Nhan Enter de tiep tuc...");
				Console.ReadLine();
            }
		}
	}
}

