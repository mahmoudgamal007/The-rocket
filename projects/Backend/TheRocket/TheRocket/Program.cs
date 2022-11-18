using Microsoft.AspNetCore.Identity;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Entities.Users;
using TheRocket.TheRocketDbContexts;
using Microsoft.EntityFrameworkCore;
using TheRocket.Repositories;

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
builder.Services.AddScoped<IPlanRepository,PlanRepository>();
builder.Services.AddScoped<ISubCategory,SubCategoryRepo>();

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =

Newtonsoft.Json.ReferenceLoopHandling.Ignore);


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
