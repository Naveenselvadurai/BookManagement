namespace BookManagement.API.Models.Services
{
    public class BooksResponse
    {
        public string Publisher { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;
        public string AuthorFirstName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string MLACitation
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. *{Title}*. {Publisher}";
            }
        }
        public string ChicagoCitation
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. *{Title}*. {Publisher}";
            }
        }
    }
}
