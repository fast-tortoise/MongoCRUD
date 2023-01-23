using CRUDBusiness;
using CRUDModel;
using CRUDRepository;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Api
{
    public class Program
    {
        private IConfigurationRoot _config;

        string connection;
        string databaseClass;
        string databaseSchool;
        public static void Main(string[] args)
        {
            var program = new Program();
            
            program.SetupConfiguration();
            //program.SetupLogging();
            //program.SetupDIContainer();

            program.Run(args);
        }
        public void SetupConfiguration()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connection = _config["connectionString"];
            databaseClass = _config["databaseClass"];
            databaseSchool = _config["databaseSubject"];

        }

        public void Run(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddScoped<ModelClass , ModelClass>();
            builder.Services.AddScoped<ICreate>(x => new CreateRepository(connection));
            builder.Services.AddScoped<IDelete>(x => new DeleteRepository(connection));
            builder.Services.AddScoped<IRead>(x => new ReadRepository(connection));
            builder.Services.AddScoped<IUpdate>(x => new UpdateRepository(connection));

            builder.Services.AddScoped<IServiceClass>(x => new ServiceClass(
                                                      x.GetRequiredService<ICreate>(),
                                                      x.GetRequiredService<IDelete>(),
                                                      x.GetRequiredService<IUpdate>(),
                                                      x.GetRequiredService<IRead>(),
                                                      databaseClass));

            builder.Services.AddScoped<IServiceSubject>(x => new ServiceSubject(
                                                      x.GetRequiredService<ICreate>(),
                                                      x.GetRequiredService<IDelete>(),
                                                      x.GetRequiredService<IUpdate>(),
                                                      x.GetRequiredService<IRead>(),
                                                      databaseSchool));

            //builder.Services.AddApiVersioning(x =>
            //{
            //    x.DefaultApiVersion = new ApiVersion(2, 0);
            //    x.AssumeDefaultVersionWhenUnspecified = true;
            //    x.ReportApiVersions = true;
            //});

            builder.Services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            builder.Services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
                x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });

            builder.Services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            }).AddXmlSerializerFormatters();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        
    }
}


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//var app = builder.Build();

//// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//#region Amit
////builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
////builder.Host.ConfigureContainer<ContainerBuilder>(builder => SetupIoCContainer(builder));
//#endregion
