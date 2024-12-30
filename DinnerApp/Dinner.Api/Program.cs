using Dinner.Api.Filters;
using Dinner.Api.Middlewares;
using Dinner.Application;
using Dinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    //Here we are adding the DI container

    //To handle the exception using filter
    //builder.Services.AddControllers(x=>x.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

}

var app = builder.Build();
{
    //Here we are adding the middleware


    //To handle exception using middleware
    //app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
