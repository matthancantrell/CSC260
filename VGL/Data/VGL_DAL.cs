using VGL.Interfaces;
using VGL.Models;

namespace VGL.Data
{
	public class VGL_DAL : IDataAccessLayer
	{
		private static List<VideoGame> GameList = new List<VideoGame>
		{
			new VideoGame("Pikmin", "GameCube", "Real- Time Strategy, Puzzle", "E", 2001, "pik1.jpg"),
			new VideoGame("Pikmin 2", "GameCube", "Real- Time Strategy, Puzzle", "E", 2004, "pik2.jpg"),
			new VideoGame("Pikmin 3", "Wii U", "Real- Time Strategy, Puzzle", "E", 2013, "pik3.png"),
			new VideoGame("Pikmin 4", "Nintendo Switch", "Real- Time Strategy, Puzzle", "E", 2023, "pik4.jpg"),
			new VideoGame("Pikmin Bloom", "Mobile", "Real- Time Strategy, Puzzle", "E", 2021, "pik5.png")
		};

		public void AddGame(VideoGame game)
		{
			GameList.Add(game);
		}

		public void Edit(VideoGame game)
		{
			GameList[GetGame(game)] = game;
		}

		public VideoGame GetGame(int? id)
		{
			return GameList.Where(m => m.Id == id).FirstOrDefault();
		}

		public int GetGame(VideoGame game)
		{
			return GameList.FindIndex(x => x.Id == game.Id);
		}

		public IEnumerable<VideoGame> GetGames()
		{
			return GameList;
		}

		public void RemoveGame(int? id)
		{
			GameList.Remove(GetGame(id));
		}

		public void Loan(int? id, string LoanOut)
		{
			GetGame(id).Loan(LoanOut);
		}
	}
}
