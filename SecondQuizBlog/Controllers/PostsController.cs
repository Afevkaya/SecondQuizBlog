using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
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
        private readonly IFileProvider _fileProvider;

        public PostsController(IPostRepository postRepository, IMapper mapper, ICategoryRepository categoryRepository, IFileProvider fileProvider)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _fileProvider = fileProvider;
        }

        // Datayı çekme
        [HttpGet]
        [Route("Posts/PostList/{page}/{pageSize}")]
        public IActionResult PostList(int page = 1, int pageSize = 2)
        {
            var postList = _postRepository.PostsWithCategory(page,pageSize);

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
        public async Task<IActionResult> Create(CreatePostViewModel createPostViewModel, IFormFile photo)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryRepository.GetAll();
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categories);
                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
                return View(createPostViewModel);
            }
            if (photo != null && photo.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var pictureDirectory = root.First(x => x.Name == "images");
                var path = Path.Combine(pictureDirectory.PhysicalPath, photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);
                var returnPath = path;
                createPostViewModel.ImageUrl = photo.FileName;
            }
            
            var post = _mapper.Map<Post>(createPostViewModel);
            
            _postRepository.Add(post);
            return RedirectToAction(nameof(PostsController.PostList));
        }

        
    }
}
