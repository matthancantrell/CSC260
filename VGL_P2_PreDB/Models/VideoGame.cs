using System.ComponentModel.DataAnnotations;

namespace VGL.Models
{
    public class VideoGame
    {
		private static int nextID = 0;
		public int? Id { get; set; } = nextID++;

        [Required(ErrorMessage = "Your game must have a title.")]
        public string? Title { get; set; } = "[NO TITLE]";

        [Required(ErrorMessage = "Your game must have a platform.")]
        public string? Platform { get; set; } = string.Empty;

        [Required(ErrorMessage = "Your game must have a genere.")]
        public string? Genre { get; set; } = string.Empty;

		public string? ESRB_Rating { get; set; } = "E";

        [Required(ErrorMessage = "Release Year is required.")]
        [Range(1958, 2023, ErrorMessage = "Invalid Year.")]
        public int Year { get; set; } = 1958;

        [Required(ErrorMessage = "Your game must have an image link.")]
        public string? Image { get; set; } = string.Empty;
		public string? LoanedTo { get; set; } = null;
		public DateTime? LoanDate { get; set; } = null;

        public VideoGame() { }

		public VideoGame(string title, string platform, string genre, string rating, int year, string image)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.ESRB_Rating = rating;
            this.Year = year;
            this.Image = image;
        }

		public void Loan(string? name = null)
		{
			if (name != null)
			{
				LoanedTo = name;
				LoanDate = DateTime.Now;
			}
			else if (LoanedTo != null)
			{
				LoanedTo = null;
				LoanDate = null;
			}
		}
    }
}
