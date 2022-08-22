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

        
        /*int page = 1, int pageSize = 2*/
        [HttpGet]
        /*[Route("Posts/PostList")]*/
        [Route("Posts/PostList/{page}")]
        public IActionResult PostList(int page = 1)
        {
            int pageSize = 2;
            var postList = _postRepository.GetProductWithPaged(page, pageSize).Item1;
            int totalCount = _postRepository.GetProductWithPaged(page, pageSize).Item2;
            int totalPage = (int)(Math.Ceiling((decimal)totalCount / (decimal)pageSize));

            ViewBag.page = page;
            ViewBag.totalPage = totalPage;

            /*var postList = _postRepository.PostsWithCategory();*/

            return View(_mapper.Map<List<ListPostViewModel>>(postList));
        }

        // Create Get
        [HttpGet]
        [Route("Posts/Create")]
        public IActionResult Create()
        {
            var categories = _categoryRepository.GetAll();
            var categoryList = _mapper.Map<List<CategoryViewModel>>(categories);
            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
            return View();
        }

        // Create Post
        [HttpPost]
        [Route("Posts/Create")]
        public async Task<IActionResult> Create(CreatePostViewModel createPostViewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryRepository.GetAll();
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categories);
                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
                return View(createPostViewModel);
            }

            if (createPostViewModel.Image != null && createPostViewModel.Image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var pictureDirectory = root.First(x => x.Name == "images");
                var path = Path.Combine(pictureDirectory.PhysicalPath, createPostViewModel.Image.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await createPostViewModel.Image.CopyToAsync(stream);
            }
            
            var post = _mapper.Map<Post>(createPostViewModel);
            post.ImageUrl = createPostViewModel.Image.FileName;
            _postRepository.Add(post);
            return RedirectToAction(nameof(PostsController.PostList));
        }

        // Detail Get
        public IActionResult PostDetail(int id)
        {
            var post = _postRepository.GetByIdWithCategory(id);
            return View(_mapper.Map<ListPostViewModel>(post));
        }


        public IActionResult Update(int id)
        {
            var categories = _categoryRepository.GetAll();
            var categoryList = _mapper.Map<List<CategoryViewModel>>(categories);
            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

            var post = _postRepository.GetByIdWithCategory(id);
            
            return View(_mapper.Map<UpdatePostViewModel>(post));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePostViewModel updatePostViewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryRepository.GetAll();
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categories);
                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
                return View(updatePostViewModel);
            }

            if (updatePostViewModel.Image != null && updatePostViewModel.Image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var pictureDirectory = root.First(x => x.Name == "images");
                var path = Path.Combine(pictureDirectory.PhysicalPath, updatePostViewModel.Image.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await updatePostViewModel.Image.CopyToAsync(stream);
            }

            var post = _mapper.Map<Post>(updatePostViewModel);
            post.ImageUrl = updatePostViewModel.Image.FileName;
            _postRepository.Update(post);
            return RedirectToAction("PostList", "Posts", new { page = 1 });
        }

        // Delete Get
        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return RedirectToAction("PostList", "Posts", new { page = 1 });
        }
    }
}
