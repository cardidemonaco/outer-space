using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using outer_space.Data.Tables;

namespace outer_space.Data
{
    public class DataModelDbContext : DbContext
    {
        //To update the database (make sure blank "outer-space" database created first)
        //  Open View > Package Manager Console

        //dotnet ef migrations add Migration0**-DESCRIPTION --project outer-space.Data --context DataModelDbContext --startup-project outer-space.Web (updates Project)
        //dotnet ef database update --project outer-space.Data --context DataModelDbContext --startup-project outer-space.Web (updates Database)

        //dotnet ef database update --project outer-space.Data --context DataModelDbContext --startup-project outer-space.Web [MigrationName]
        //dotnet ef migrations remove --project outer-space.Data --context DataModelDbContext --startup-project outer-space.Web (removes latest migration)

        public IConfiguration Configuration { get; }

        public DataModelDbContext()
        {

        }
        public DataModelDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DataModelDbContext(DbContextOptions<DataModelDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Do not need connection string here, except when migrating database?...
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            //======//
            // keys //
            //======//
            mb.Entity<MissionAstronaut>()
                .HasKey(k => new { k.MissionID, k.AstronautID });



            //=======================//
            // navigation Properties //
            //=======================//
            //mb.Entity<Mission>()
            //    .HasMany(e => e.Astronauts)
            //    .WithMany(e => e.Missions)
            //.UsingEntity("MissionAstronauts");

            //mb.Entity<Astronaut>()
            //    .HasMany(e => e.Missions)
            //    .WithMany(e => e.Astronauts)
            //    .UsingEntity("MissionAstronauts");

     
             

      
            //===========//
            // seed data //
            //===========//
            //...
        }

        //========//
        // tables //
        //========//

        //This is what creates the context connection in the code
        //  if a table is down below as a DbSet, _context.Table can be called

        public virtual DbSet<Astronaut> Astronauts { get; set; }
        public virtual DbSet<Galaxy> Galaxies { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }

        //Join tables
        public virtual DbSet<MissionAstronaut> MissionAstronauts { get; set; }
    }
}