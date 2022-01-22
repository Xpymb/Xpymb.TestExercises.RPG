using AutoMapper;
using Microsoft.OpenApi.Models;
using Xpymb.TestExercises.RPG.ASP.Configuration.AutoMapper;
using Xpymb.TestExercises.RPG.ASP.Data;
using Xpymb.TestExercises.RPG.ASP.Infrastructure;

namespace Xpymb.TestExercises.RPG.ASP;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Xpymb.TestExercises.RPG.ASP", Version = "v1" });
        });

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UnitProfile());
        });
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddSingleton<MongoDbContext>();
        services.AddScoped<IDbRepository, MongoDbRepository>();
        services.AddTransient<IUnitService, UnitService>();
        services.AddTransient<IEngineService, EngineService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
        
        if (env.IsDevelopment() || env.EnvironmentName == "DockerDevelopment")
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xpymb.TestExercises.RPG.ASP v1"));
        }

        //app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}
