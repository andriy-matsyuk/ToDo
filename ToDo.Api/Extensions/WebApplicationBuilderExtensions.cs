using ToDo.Infrastructure;
using ToDo.Application;
using ToDo.Api.ExceptionHandling;

namespace ToDo.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //

        builder.Services.AddAuthentication();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("all",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    }
}
