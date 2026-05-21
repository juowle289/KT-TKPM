using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Data;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ── Services ────────────────────────────────────────────────────────────────

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnnStr")));

// DI
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// CORS — cho phép Vue dev server (port 5173) và production build
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVue", policy =>
        policy
            .WithOrigins(
                "http://localhost:5173",   // Vite dev server
                "http://localhost:4173",   // Vite preview
                "http://localhost:3000"    // fallback
            )
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ── Pipeline ────────────────────────────────────────────────────────────────

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowVue");   // phải trước UseAuthorization
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();