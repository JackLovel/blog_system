﻿using BlogSystem.BLL;
using BlogSystem.MVCSite.Filter;
using BlogSystem.MVCSite.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.MVCSite.Controllers
{
    public class HomeController : Controller
    {
        [BlogSystemAuth]
        public ActionResult Index()
        {
            return View();
        }

        [BlogSystemAuth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [BlogSystemAuth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Models.UserViewModels.RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                IBLL.IUserManager userManager = new UserManager();
                await userManager.Login(model.Email, model.Password);

                return Content("注册成功");
            }

            return View(model);
        }

        //[AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUserManager userManager = new UserManager();
                if (await userManager.Login(model.Email, model.LoginPwd))
                {
                    // 跳转
                    // 判断是用 session还是用cookie 
                    if (model.RememberMe)
                    {
                        Response.Cookies.Add(new HttpCookie("loginName")
                        {
                            Value = model.Email,
                            Expires = DateTime.Now.AddDays(7)
                        });
                    }
                    else
                    {
                        Session["loginName"] = model.Email;
                    }

                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    ModelState.AddModelError("", "您的账号密码有误.");   
                }
            }

            return View(model);
        }
    }
}