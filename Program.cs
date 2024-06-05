using System.Reflection;
using MailerSend.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Extensions;
using PruebaDesemp.Services.MailerSend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicio de controladores 
builder.Services.AddControllers();

//conexion a la base de datos 
builder.Services.AddDbContext<DataContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2-Mysql")
    );
});

//mapeo de interfaces y repositorios
builder.Services.AddRepositories(Assembly.GetExecutingAssembly());


//Envio de correos 
builder.Services.AddScoped<IEmailService, EmailService>();

//Servicios del mailerSend
builder.Services.AddHttpClient<IEmailService, EmailService>();
builder.Services.Configure<MailerSendOptions>(builder.Configuration.GetSection("MailerSend"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

