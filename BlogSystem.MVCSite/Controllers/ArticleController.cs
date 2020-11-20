using BlogSystem.BLL;
using BlogSystem.Dto;
using BlogSystem.IBLL;
using BlogSystem.MVCSite.Filter;
using BlogSystem.MVCSite.Models.ArticleViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace BlogSystem.MVCSite.Controllers
{
    [BlogSystemAuth]
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                IArticleManager articleManager = new ArticleManager();
                articleManager.CreateCategory(model.CategoryName, Guid.Parse(Session["userid"].ToString()));

                return RedirectToAction("CategoryList");
            }

            ModelState.AddModelError("", "您录入的信息的有误！");
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> CategoryList()
        {
            var userid = Guid.Parse(Session["userid"].ToString());
            return View(await new ArticleManager().GetAllCategories(userid));
        }

        [HttpGet]
        public async Task<ActionResult> CreateArticle()
        {

            var userid = Guid.Parse(Session["userid"].ToString());
            ViewBag.CategoryIds = await new ArticleManager().GetAllCategories(userid);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateArticle(CreateArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = Guid.Parse(Session["userid"].ToString());
                await new ArticleManager().CreateArticle(model.Title, model.Content, model.CategoryIds, userid);
                return RedirectToAction("ArticleList");
            }

            ModelState.AddModelError("", "添加失败");
            return View();
        }

        //[HttpGet]
        //public async Task<ActionResult> ArticleList(int pageIndex = 0, int pageSize = 1)
        //{
        //    // 需要给页面前端总页码数，当前页码，可显示的总页码数量
        //    var manager = new ArticleManager();
        //    var userid = Guid.Parse(Session["userid"].ToString());
        //    var articles = await manager.GetAllArticlesByUserId(userid,pageIndex,pageSize);
        //    var dataCount = await manager.GetDataCount(userid);
        //    ViewBag.PageCount = dataCount % pageSize == 0? dataCount/pageSize: dataCount / pageSize + 1;
        //    ViewBag.PageIndex = pageIndex; 
        //    return View(articles);
        //}

        [HttpGet]
        public async Task<ActionResult> ArticleList(int pageIndex = 1, int pageSize = 3)
        {
            // 需要给页面前端总页码数，当前页码，可显示的总页码数量
            var manager = new ArticleManager();
            var userid = Guid.Parse(Session["userid"].ToString());
            // 当前用户第n页数据
            var articles = await manager.GetAllArticlesByUserId(userid, pageIndex-1, pageSize);
            // 获取当前用户文章总数
            var dataCount = await manager.GetDataCount(userid);

            //ViewBag.PageCount = dataCount % pageSize == 0 ? dataCount / pageSize : dataCount / pageSize + 1;
            //ViewBag.PageIndex = pageIndex;
            return View(new PagedList<ArticleDto>(articles,pageIndex,pageSize,dataCount));
        }

        public async Task<ActionResult> ArticleDetails(Guid? id) 
        {
            var articleManager = new ArticleManager();
            if (id == null || !await articleManager.ExistsArticle(id.Value)) 
            {
                return RedirectToAction(nameof(ArticleList));
            }

            return View(await articleManager.GetOneArticleById(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> EditArticle(Guid id)
        {
            IBLL.IArticleManager manager = new ArticleManager();
            var data = await manager.GetOneArticleById(id);
            return View(new EditArticleViewModel() 
            {
                Title = data.Title, 
                Content = data.Content,
                CategoryIds = data.CategoryIds,
                Id = data.Id
            });
        }
    }
}