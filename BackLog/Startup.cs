using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using UnitOfWork;

namespace BackLog
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration">Default configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method called by the runtime. Method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="env">Hosting environment.</param>
        /// <param name="loggerFactory">Logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger
            // JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Method called by the runtime. Method to add services to the container.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // use in memory for testing.
            services
                //.AddDbContext<BloggingContext>(opt => opt.UseMySql("Server=localhost;database=uow;uid=root;pwd=root1234;"))
                .AddDbContext<BacklogContext>(opt => opt.UseInMemoryDatabase("UnitOfWork"))
                .AddUnitOfWork<BacklogContext>();
            //.AddCustomRepository<Blog, CustomBlogRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "API Backlog",
                    Version = "v1",
                    Contact = new Contact() { Email = "florian.reiss@supinfo.com", Name = "Florian REISS", Url = "https://github.com/floflo67/BackLog" },
                    Description = "Première version de l'API",
                    License = new License() { },
                    TermsOfService = "Aucun",
                });

                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();

                c.EnableAnnotations();
            });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}