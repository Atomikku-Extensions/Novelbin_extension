﻿using Novelbin.Core.Domain.Interfaces;
using Novelbin.Core.Handlers;
using Novelbin.Core.Providers;
using Novelbin.Core.Services;

namespace Novelbin.API
{
    public class Startup(IConfiguration configuration) : IStartup
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            ConfigureInjections(services);
        }

        private static void ConfigureInjections(IServiceCollection services)
        {
            services.AddScoped<IMainProvider, MainProvider>();
            services.AddScoped<IDirectoryProvider, DirectoryProvider>();
            services.AddScoped<IWebPageHandler, WebPageHandler>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<ITranslatePageService, TranslatePageService>();
            services.AddScoped<IPageExtractorService, PageExtractorService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }

        void Configure(WebApplication app, IWebHostEnvironment env);

        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            if (Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) is not IStartup startup)
                throw new InvalidOperationException($"Could not create instance of {typeof(IStartup)}");

            startup.ConfigureServices(webAppBuilder.Services);

            var app = webAppBuilder.Build();
            startup.Configure(app, webAppBuilder.Environment);

            app.Run();

            return webAppBuilder;
        }
    }
}