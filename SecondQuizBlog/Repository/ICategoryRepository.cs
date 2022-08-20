using SecondQuizBlog.Entities;

namespace SecondQuizBlog.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
