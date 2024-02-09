using System.ComponentModel.DataAnnotations;

namespace DapperProject.Models
{
    public class BookDetails
    {
        [Key]
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string BookType { get; set; }

        public DateTime Publisheddate { get; set; }

        public DateTime Releaseddate { get; set;}

        public int Price { get; set; }

        public int Stock {  get; set; }

        public int Sold { get; set; }
    }
}
