using CodeBase.Core.Interfaces.Services.Department;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
                                                 {
                                                     jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                                                 });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CodeBase.Core.Interfaces.Services.Department.IDepartmentService, IDepartmentService>();

builder.Services.AddScoped(typeof(CodeBase.Core.Repositories.Interfaces.IBaseRepository<>),
                           typeof(CodeBase.Infrastructure.Repositories.BaseRepository<>));
builder.Services.AddScoped(typeof(CodeBase.Core.Interfaces.Services.IBaseService<>),
                           typeof(CodeBase.Core.Services.BaseService<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// CORS
app.UseCors(o => o.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.MapControllers();

app.Run();