using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondQuizBlog.Entities;
using SecondQuizBlog.Models;
using SecondQuizBlog.Repository;

namespace SecondQuizBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private  readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PostsController(IPostRepository postRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        // Datayı çekme
        [HttpGet]
        [Route("Posts/PostList")]
        public IActionResult PostList()
        {
            var postList = _postRepository.PostsWithCategory();

            return View(_mapper.Map<List<ListPostViewModel>>(postList));
        }


        [HttpGet]
        [Route("Posts/Create")]
        public IActionResult Create()
        {
            var categories = _categoryRepository.GetAll();
            var categoryList = _mapper.Map<List<CategoryViewModel>>(categories);
            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("Posts/Create")]
        public IActionResult Create(CreatePostViewModel createPostViewModel)
        {
            var post = _mapper.Map<Post>(createPostViewModel);
            _postRepository.Add(post);
            return RedirectToAction(nameof(PostsController.PostList));
        }
    }
}
