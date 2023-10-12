using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Repository.Domain;
using ToDoList.Repository.Interfaces;
using ToDoList.Repository.Repositories;
using ToDoList.Services.Interfaces;
using ToDoList.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MappingService, MappingService>();

builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ToDoListContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("LapTopCon"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DesktopCon"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
