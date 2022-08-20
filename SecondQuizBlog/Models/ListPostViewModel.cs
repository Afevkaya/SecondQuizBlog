using System.Collections;
using SecondQuizBlog.Entities;

namespace SecondQuizBlog.Models
{
    public class ListPostViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        
    }
}
