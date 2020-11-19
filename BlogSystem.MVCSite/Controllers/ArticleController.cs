using BlogSystem.BLL;
using BlogSystem.IBLL;
using BlogSystem.MVCSite.Filter;
using BlogSystem.MVCSite.Models.ArticleViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        [HttpGet]
        public async Task<ActionResult> ArticleList()
        {
            var userid = Guid.Parse(Session["userid"].ToString());
            var articles = await new ArticleManager().GetAllArticlesByUserId(userid); 
            return View(articles);
        }
    }
}