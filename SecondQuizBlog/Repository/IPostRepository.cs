using SecondQuizBlog.Entities;

namespace SecondQuizBlog.Repository
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        (List<Post>,int) GetProductWithPaged(int page, int pageSize);
        List<Post> PostsWithCategory();
        Post GetByIdWithCategory(int id);
    }
}
