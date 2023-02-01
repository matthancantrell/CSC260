using VGL.Models;

namespace VGL.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<VideoGame> GetGames();
		void AddGame(VideoGame game);
		void RemoveGame(int? id);
		VideoGame GetGame(int? id);
		int GetGame(VideoGame game);
		void Edit(VideoGame game);
		void Loan(int? id, string LoanOut);
	}
}
