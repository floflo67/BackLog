using Microsoft.EntityFrameworkCore;
using UnitOfWork.Entities;

namespace UnitOfWork
{
    /// <summary>
    /// Base context for the application.
    /// </summary>
    public class BacklogContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">Options for the context.</param>
        public BacklogContext(DbContextOptions<BacklogContext> options) : base(options)
        {
        }

        /// <summary>
        /// Ideas.
        /// </summary>
        public DbSet<Idea> Ideas { get; set; }

        /// <summary>
        /// Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Votes.
        /// </summary>
        public DbSet<Vote> Votes { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in Microsoft.EntityFrameworkCore.DbSet`1 properties on your
        /// derived context. The resulting model may be cached and re-used for subsequent instances
        /// of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        /// The builder being used to construct the model for this context. Databases (and other
        /// extensions) typically define extension methods on this object that allow you to configure
        /// aspects of the model that are specific to a given database.
        /// </param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via
        /// Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel))
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}