// using InFrastructure.DataContext;
// using InFrastructure.Entities;
// using InFrastructure.Services;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<IBookService, BookService>();
// builder.Services.AddControllers();
// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.MapControllers();
// app.Run();
// ---------------------------------------------------------------------
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddDbContext<PersonDbContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddControllers();
// builder.Services.AddSwaggerGen();
// builder.Services.AddTransient<IPersonRepository, PersonRepository>();
// // builder.Services.AddDbContext<PersonDbContext>();


// var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();
// app.MapControllers();

// app.Run();

// ---------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PersonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), 
b=>b.MigrationsAssembly("MainApp")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Использование Swagger для документации API
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();