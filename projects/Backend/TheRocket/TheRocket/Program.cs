
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using T.Repositories;
using TheRocket.Entities.Users;
using TheRocket.RepoInterfaces;
using TheRocket.RepoInterfaces.UsersRepoInterfaces;
using TheRocket.Repositories;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Repositories.UserRepos;
using TheRocket.TheRocketDbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IAppUserRepo,AppUserRepo>();
builder.Services.AddScoped<IAddressRepo, AddressRepo>();
builder.Services.AddScoped<IPhoneRepo, PhoneRepo>();
builder.Services.AddScoped<ILocationRepo, LocationRepo>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<ISubCategory, SubCategoryRepo>();
builder.Services.AddScoped<IReserveCart, ReserveCartRepo>();
builder.Services.AddScoped<IFeedbackRepo, FeedbackRepo>();
builder.Services.AddScoped<IColorRepo, ColourRepo>();
builder.Services.AddScoped<ISizeRepo, SizeRepo>();
builder.Services.AddScoped<IProdcutRepo, ProductRepo>();
builder.Services.AddScoped<IProductColorRepo, ProductColorRepo>();
builder.Services.AddScoped<IProductSizeRepo, ProductSizeRepo>();
builder.Services.AddScoped<IProductImgUrlRepo, ProductImgUrlRepo>();

builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<ISubscripRepo, SubscripRepo>();
builder.Services.AddScoped<IImageRepo, ImageRepo>();

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<TheRocketDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<TheRocketDbContext>();

// builder.Services.Configure<IdentityOptions>(options =>
// {
//     // Default Lockout settings.
//     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//     options.Lockout.MaxFailedAccessAttempts = 5;
//     options.Lockout.AllowedForNewUsers = true;
// });

builder.Services.Configure<IdentityOptions>(opts =>
{
    // opts.Password.RequireNonAlphanumeric = false;
    // opts.Password.RequireLowercase = false;
    // opts.Password.RequireUppercase = false;
    // opts.Password.RequiredLength = 6;
    opts.User.RequireUniqueEmail = true;
});

// // JWT validator
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
// {

//     options.TokenValidationParameters = new TokenValidationParameters
//     {

//         ValidateLifetime = true,
//         ClockSkew=TimeSpan.Zero,
//         ValidateAudience = false,
//         ValidateIssuer = false,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_123456"))
//     };
// });


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
       // Adding Jwt Bearer
       .AddJwtBearer(options =>
       {
           options.SaveToken = true;
           options.RequireHttpsMetadata = false;
           options.TokenValidationParameters = new TokenValidationParameters()
           {
               RequireExpirationTime = false,
               ClockSkew = TimeSpan.Zero,
               ValidateLifetime = false,
               ValidateIssuer = false,
               ValidateAudience = false,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_123456"))
           };
       });

string cors = "";
builder.Services.AddCors(options =>
{
    options.AddPolicy(cors,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

builder.Services.Configure<FormOptions>(o=>{
     o.ValueLengthLimit=int.MaxValue;
     o.MultipartBodyLengthLimit=int.MaxValue;
     o.MemoryBufferThreshold=int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors);
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions{
    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"Resources")),
    RequestPath=new PathString("/Resources")
});

app.UseAuthentication();//identity and jwt
app.UseAuthorization();
app.MapControllers();

app.Run();

