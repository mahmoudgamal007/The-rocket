using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRocket.Entities.Users;
using TheRocket.Repositories;
using TheRocket.TheRocketDbContexts;
using TheRocket.Repositories.RepoInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddDbContext<TheRocketDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<TheRocketDbContext>();

builder.Services.AddScoped<ISubCategory, SubCategoryRepo>();




var app = builder.Build();

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

