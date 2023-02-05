using VGL.Models;

namespace VGL.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<VideoGame> GetGames();
		IEnumerable<VideoGame> Search(string key);

        VideoGame GetGame(int? id);

        void AddGame(VideoGame game);
		void RemoveGame(int? id);
        void Edit(VideoGame game);
        void Loan(int? id, string LoanOut);

		int GetGame(VideoGame game);

	}
}
