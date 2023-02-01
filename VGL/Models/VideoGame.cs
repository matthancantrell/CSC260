namespace VGL.Models
{
    public class VideoGame
    {
		private static int nextID = 0;
		public int? Id { get; set; } = nextID++;

		//[Required]

		public string? Title { get; set; } = "[NO TITLE]";
		public string? Platform { get; set; } = string.Empty;
		public string? Genre { get; set; } = string.Empty;
		public string? ESRB_Rating { get; set; } = "RP";
		public int Year { get; set; } = 1958;
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

        public VideoGame(string title, string platform, string genre, string rating, int year, string image, string LoanedTo, DateTime loanDate)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.ESRB_Rating = rating;
            this.Year = year;
            this.Image = image;
            this.LoanDate = loanDate;
            this.LoanedTo= LoanedTo;
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

		public override string ToString()
        {
            return $"{Title} - {Year} - {ESRB_Rating}";
        }
    }
}
