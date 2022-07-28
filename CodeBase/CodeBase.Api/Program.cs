var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
                                                 {
                                                     jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                                                 });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<CodeBase.Core.Interfaces.Services.IDepartmentService, CodeBase.Core.Services.DepartmentService>();
builder.Services
    .AddScoped<CodeBase.Core.Interfaces.Repositories.IDepartmentRepo,
            CodeBase.Infrastructure.Repositories.DepartmentRepo>();


builder.Services.AddScoped(typeof(CodeBase.Core.Repositories.Interfaces.IBaseRepo<>),
                           typeof(CodeBase.Infrastructure.Repositories.BaseRepo<>));
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