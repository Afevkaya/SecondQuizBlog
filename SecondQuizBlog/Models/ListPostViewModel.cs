using System.Collections;
using SecondQuizBlog.Entities;

namespace SecondQuizBlog.Models
{
    public class ListPostViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
