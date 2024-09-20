using AutoMapper;
using Entities;
using LibraryProjectRepository;
using LibraryProjectRepository.Models;
using LibraryProjectService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IOpeningHourRepository, OpeningHourRepository>();
builder.Services.AddScoped<IOpeningHourService, OpeningHourService>();
builder.Services.AddScoped<ITitleRepository, TitleRepository>();
builder.Services.AddScoped<ITitleService, TitleService>();
builder.Services.AddScoped<IBooksArchiveRepository, BooksArchiveRepository>();
builder.Services.AddScoped<IBooksArchiveService, BooksArchiveService>();builder.Services.AddScoped<IBooksArchiveRepository, BooksArchiveRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryToTitleRepository, CategoryToTitleRepository>();
builder.Services.AddScoped<ICategoryToTitleService, CategoryToTitleService>();
builder.Services.AddScoped<ICheckedBookRepository, CheckedBookRepository>();
builder.Services.AddScoped<ICheckedBookService, CheckedBookService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddDbContext<LibraryContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors(options => options.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

