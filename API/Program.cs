using Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;
using Application.Core;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

//Setting up the database
using var scope=app.Services.CreateScope(); 
var services= scope.ServiceProvider; 

try{

    var context=services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    //Seed data to populate the database
    await Seed.SeedData(context);

}catch(Exception ex){

    var logger= services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex,"An error occured during migration");

}


app.MapControllers();

 await app.RunAsync();
