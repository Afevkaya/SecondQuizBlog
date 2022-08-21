using Microsoft.EntityFrameworkCore;
using SecondQuizBlog.Context;
using SecondQuizBlog.Entities;

namespace SecondQuizBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.First(x => x.Id == id);
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Posts.First(x => x.Id == id);
            _context.Posts.Remove(entity);
            _context.SaveChanges();
        }

        /*public List<Post> PostsWithCategory(int page, int pageSize)
        {
            IQueryable<Post> query;
            query = _context.Posts.Include(x => x.Category).OrderByDescending(y => y.CreatedDate);
            int totalCount = query.Count();
            var postList = query.Skip((pageSize * (page - 1))).Take(pageSize).ToList();
            return postList;
        }*/

        public List<Post> PostsWithCategory()
        {
            return _context.Posts.Include(x => x.Category).OrderByDescending(y => y.CreatedDate).ToList();
        }

        public Post GetByIdWithCategory(int id)
        {
            return _context.Posts.Include(x => x.Category).First(x => x.Id == id);
        }
    }
}
