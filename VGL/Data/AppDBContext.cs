using Microsoft.EntityFrameworkCore;
using VGL.Models;

namespace VGL.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		//will create a movies table mapped to movie model
		public DbSet<VideoGame> VideoGames { get; set; }
	}
}