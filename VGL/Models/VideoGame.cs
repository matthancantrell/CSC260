namespace VGL.Models
{
    public class VideoGame
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        public string Title { get; set; } = "[No Title Found]";
        public string Platform { get; set; } = "[No Platform Found]";
        public string Genre { get; set; } = "[No Genre Found]";
        public string ESRB_Rating { get; set; } = "[No Rating Found]";
        public int Year { get; set; }
        public string Image { get; set; } = "[No Image Found]";
        public string? LoanedTo { get; set; } = "[No Loan Found]";
        public string? LoanDate { get; set; }

        public VideoGame(string title, string platform, string genre, string rating, int year, string image)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.ESRB_Rating = rating;
            this.Year = year;
            this.Image = image;
        }

        public VideoGame(string title, string platform, string genre, string rating, int year, string image, string LoanedTo, string loanDate)
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

        public override string ToString()
        {
            return $"{Title} - {Year} - {ESRB_Rating}";
        }
    }
}
