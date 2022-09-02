using NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewSystem.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            NewsProvider newsprovider = new NewsProvider();
            var news = newsprovider.Select();
            return View(news);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult UploadNews()
        {
            return View();
        }
        public ActionResult EditMember(int ID)
        {
            MemberProvider memberProvider = new MemberProvider();
            var model = memberProvider.Select().FirstOrDefault(t=>t.ID==ID);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("UserManagement");
            }
        }
        public ActionResult EditMemberBackForm()
        {
            string password = Request["password"];
            int ID = Convert.ToInt32(Request["id"]);
            MemberProvider memberProvider = new MemberProvider();
            var model = memberProvider.Select().FirstOrDefault(t=>t.ID==ID);
            if (model != null)
            {
                model.Password = password;
                memberProvider.Update(model);
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");
            }
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult DeleteNews(int ID)
        {
            NewsProvider newsprovider = new NewsProvider();
            var news = newsprovider.Select().FirstOrDefault(t => t.ID == ID);
            newsprovider.Delete(news);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 编辑一条新闻
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult EditNews(int ID)
        {
            NewsProvider newsprovider = new NewsProvider();
            var news = newsprovider.Select().FirstOrDefault(t => t.ID == ID);
            if (news != null)
            {
                return View(news);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <returns></returns>
        public ActionResult EditNewsBackForm()
        {
            string title = Request["title"].ToString().Trim();
            string text = Request["text"].ToString().Trim();
            int id = Convert.ToInt32(Request["id"]);
            NewsProvider newsProvider = new NewsProvider();
            var news = newsProvider.Select().FirstOrDefault(t => t.ID == id);
            if (news != null)
            {
                news.Text = text;
                news.Title = title;
                newsProvider.Update(news);
                return Content("修改成功");
            }
            return Content("修改失败");

        }

        public ActionResult Deletemember(int ID)
        {
            MemberProvider memberProvider = new MemberProvider();
            var member = memberProvider.Select().FirstOrDefault(t=>t.ID==ID);
            if (member != null)
            {
                memberProvider.Delete(member);
                return RedirectToAction("UserManagement");
            }
            else
            {
                return Content("删除失败");
            }
        }

        public ActionResult AddUserForm()
        {
            string membername = Request["username"].Trim();
            string password = Request["password"];
            MemberProvider memberProvider = new MemberProvider();
            var IsRename = memberProvider.Select().FirstOrDefault(t =>t.Name.Trim()==membername);
            if (IsRename == null){
                if (membername != null && password != null)
                {
                    member addmember = new member();
                    addmember.Name = membername;
                    addmember.Password = password;
                    addmember.Creatdate = DateTime.Now;
                    memberProvider.Insert(addmember);
                    return Content("创建成功");
                }
                else
                {
                    return Content("用户名或密码不能为空");
                }
            }
            else
            {
                return Content("用户名重复");
            }
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult DeleteMember(int ID)
        {
            MemberProvider memberProvider = new MemberProvider();
            var member = memberProvider.Select().FirstOrDefault(t => t.ID == ID);
            memberProvider.Delete(member);
            return RedirectToAction("UserManagement");
        }
        public ActionResult UserManagement()
        {
            MemberProvider membersProvider = new MemberProvider();
            var members = membersProvider.Select();
            return View(members);
        }

        public ActionResult UploadNewsForm()
        {
            string title = Request["title"].ToString().Trim();
            string text = Request["text"].ToString().Trim();
            NewsProvider newsProvider = new NewsProvider();
            News news = new News();
            news.MemberName = Session["username"].ToString();
            news.Title = title;
            news.Text = text;
            news.MemberID = Convert.ToInt32(Session["userId"]);
            news.Createtime = DateTime.Now;
            if (news.Title != null && news.Text != null)
            {
                newsProvider.Insert(news);
                return Content("上传成功");
            }
            else
            {
                return Content("上传失败");
            }
        }
        /// <summary>
        /// 用户验证
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckUser()
        {
            string username = Request["user"].ToString().Trim();
            string password = Request["pass"].ToString().Trim();
            MemberProvider memberProvider = new MemberProvider();
            var model = memberProvider.Select().FirstOrDefault(t=>t.Name.Trim() == username&&t.Password.Trim() == password);
            if (model != null)
            {
                Session["username"] = model.Name;
                Session["userId"] = model.ID;
                return Content("登录成功");
            }
            else
            {
                return Content("登录失败");
            }
        }
    }
}