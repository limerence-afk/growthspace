using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Services;
using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IModuleRepository, ModuleRepository>();
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAuthenticationProvider, AuthenticationProvider>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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