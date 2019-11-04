using Microsoft.EntityFrameworkCore;
using RaceMeetingManagerWebAPI.Class;
using RaceMeetingManagerWebAPI.Model;

namespace RaceMeetingManagerWebAPI
{
	public class RaceMeetingManagerContext : DbContext
	{
		public DbSet<MeetingCategory> MeetingCategories { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<Venue> Venues { get; set; }
		public DbSet<Meeting> Meetings { get; set; }
		public DbSet<Race> Races { get; set; }

		/// <summary>  
		/// Initializes a new instance of the <see cref="RaceMeetingManagerContext"/> class.  
		/// </summary>  
		/// <param name="options">The options.</param>  
		public RaceMeetingManagerContext(DbContextOptions<RaceMeetingManagerContext> options) : base(options)
		{
			// Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
			//this.Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var dbInitialiser = new DBInitialiser(modelBuilder);
			dbInitialiser.SeedDatabase();
		}
	}
}
