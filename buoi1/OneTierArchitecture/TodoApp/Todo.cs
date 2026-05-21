using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsSuccess { get; set; }
        public override string ToString()
        {
            return $"[{(IsSuccess ? "x" : "")}] {Id}: {Title}";
        }
        public string ToFileString()
        {
            return $"{Id}|{IsSuccess}|{Title}";
        }
        public static Todo FromFileString(string Line)
        {
            var parts = Line.Split("|");
            return new Todo
            {
                Id = int.Parse(parts[0]),
                IsSuccess = bool.Parse(parts[1]),
                Title = parts[2]
            };
        }
    }
}
