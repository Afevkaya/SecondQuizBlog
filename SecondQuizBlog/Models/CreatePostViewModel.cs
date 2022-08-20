namespace SecondQuizBlog.Models
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string ContentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

    }
}
