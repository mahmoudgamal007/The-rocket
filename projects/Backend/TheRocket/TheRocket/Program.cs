using Microsoft.AspNetCore.Identity;
using TheRocket.Repositories.RepoInterfaces;
<<<<<<< HEAD
using TheRocket.Repositories;
using Microsoft.EntityFrameworkCore;
using TheRocket.Entities.Users;
using TheRocket.TheRocketDbContexts;


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

=======
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
>>>>>>> 331488e644bc869d3c220af373275910bd96c616
