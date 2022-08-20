using SecondQuizBlog.Context;
using SecondQuizBlog.Entities;

namespace SecondQuizBlog.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogContext _context;

        public CategoryRepository(BlogContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
