using Dinner.Application;
using Dinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    //Here we are adding the DI container
    builder.Services.AddControllers();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();

}

var app = builder.Build();
{
    //Here we are adding the middleware
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
