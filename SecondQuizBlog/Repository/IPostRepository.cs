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
        List<Post> PostsWithCategory(int page, int pageSize);
    }
}
