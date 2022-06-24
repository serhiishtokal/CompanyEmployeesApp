
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CompanyEmployees.Application.Mappers;
using CompanyEmployees.Infrastructure;
using CompanyEmployees.Infrastructure.Settings;
using CompanyEmployeesApplication;
using CompanyEmployeesApplication.StartupTasks;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(/*options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = false*/)
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);

        //opts.SerializerSettings. = new RequiredPropertiesContractResolver();

    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add app options
var options = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringOptions>();
builder.Services.AddSingleton<ConnectionStringOptions>(options);
builder.Services.AddAutoMapper(typeof(AutoMapperApplicationConfig));

// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterMediatR(typeof(Program).Assembly);
    containerBuilder.RegisterModule<AppModule>();
});

InfrastructureModule.RegisterModuleServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


var startupTasks = app.Services.GetServices<IStartupTask>();
foreach (var startupTask in startupTasks)
{
    await startupTask.ExecuteAsync();
}

app.Run();
