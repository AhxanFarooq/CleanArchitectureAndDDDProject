using Dinner.Api.Mapping;
using Dinner.Application;
using Dinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    //Here we are adding the DI container
    
    builder.Services
    .AddMapping()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

}

var app = builder.Build();
{
    //Here we are adding the middleware

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
