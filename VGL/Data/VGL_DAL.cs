using VGL.Interfaces;
using VGL.Models;

namespace VGL.Data
{
	public class VGL_DAL : IDataAccessLayer
	{
		private AppDbContext db;

		public VGL_DAL(){}
		public VGL_DAL(AppDbContext iDB)
		{
			db = iDB;
		}

		public void AddGame(VideoGame game)
		{
			db.VGL.Add(game);
			db.SaveChanges();
		}

		public void RemoveGame(int? id)
		{
			db.VGL.Remove(GetGame(id));
			db.SaveChanges();
		}

		public void Edit(VideoGame game)
		{
			db.VGL.Update(game);
			db.SaveChanges();
		}

		public VideoGame GetGame(int? id)
		{
			return db.VGL.Where(m => m.Id == id).FirstOrDefault();
		}

		public IEnumerable<VideoGame> GetGames()
		{
			return db.VGL.OrderBy(g => g.Title).ToList();
		}

		public void Loan(int? id, string LoanOut)
		{
			GetGame(id).Loan(LoanOut);
			db.SaveChanges();
		}
		public IEnumerable<VideoGame> Search(string key)
		{
			return GetGames().Where(k => k.Title.ToLower().Contains(key.ToLower()));
		}

		/*		private static List<VideoGame> GameList = new List<VideoGame>
				{
					new VideoGame("Pikmin", "GameCube", "Real- Time Strategy, Puzzle", "E", 2001, "https://upload.wikimedia.org/wikipedia/en/1/13/Pikmin_cover_art.jpg"),
					new VideoGame("Pikmin 2", "GameCube", "Real- Time Strategy, Puzzle", "E", 2004, "https://upload.wikimedia.org/wikipedia/en/3/38/Pikmin_2_Case.jpg"),
					new VideoGame("Pikmin 3", "Wii U", "Real- Time Strategy, Puzzle", "E", 2013, "https://upload.wikimedia.org/wikipedia/en/5/53/Pikmin_3_box_artwork.png"),
					new VideoGame("Pikmin 4", "Nintendo Switch", "Real- Time Strategy, Puzzle", "E", 2023, "https://upload.wikimedia.org/wikipedia/en/d/d0/Pikmin_4_Logo.png"),
					new VideoGame("Pikmin Bloom", "Mobile", "Real- Time Strategy, Puzzle", "E", 2021, "https://upload.wikimedia.org/wikipedia/en/f/f2/Pikmin_Bloom_App_icon.png")
				};*/
	}
}
