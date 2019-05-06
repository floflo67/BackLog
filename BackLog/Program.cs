using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BackLog
{
    /// <summary>
    /// Default launch.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Create WebHost builder.
        /// </summary>
        /// <param name="args">Parameters.</param>
        /// <returns>WebHost builder built.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        /// <summary>
        /// Launch method.
        /// </summary>
        /// <param name="args">Parameters.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}