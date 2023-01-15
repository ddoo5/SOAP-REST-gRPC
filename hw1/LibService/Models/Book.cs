using System;
namespace LibService
{
	public class Book
	{
		public string? Id { get; set; }

		public string? Title { get; set; }

		public string? Category { get; set; }

        public string? Language { get; set; }

        public string? Pages { get; set; }

        public string? AgeLimit { get; set; }

        public string? PublicationDate { get; set; }

        public Author[] Authors { get; set; }
    }
}

