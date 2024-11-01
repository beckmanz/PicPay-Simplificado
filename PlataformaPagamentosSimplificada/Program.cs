using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using PlataformaPagamentosSimplificada.Data;
using PlataformaPagamentosSimplificada.Services.Authorizer;
using PlataformaPagamentosSimplificada.Services.Notify;
using PlataformaPagamentosSimplificada.Services.Transaction;
using PlataformaPagamentosSimplificada.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserInterface, UserServices>();
builder.Services.AddScoped<ITransactionInterface, TransactionServices>();
builder.Services.AddScoped<INotifyInterface, NotifyService>();
builder.Services.AddHttpClient<IAuthorizerInterface, AuthorizerServices>();

builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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