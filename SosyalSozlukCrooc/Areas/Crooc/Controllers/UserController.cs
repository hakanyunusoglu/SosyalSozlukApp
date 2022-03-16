using SosyalSozlukCrooc.Areas.Crooc.Models.Attributes;
using SosyalSozlukCrooc.Models.Entity;
using SosyalSozlukCrooc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SosyalSozlukCrooc.Areas.Crooc.Controllers
{

    public class UserController : BaseController
    {
        // GET: Crooc/User

        GetUserInformations userClass = new GetUserInformations();
        [_SessionLoginControl]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(User model, string returnUrl)
        {
            SosyalSozlukCrooc.Models.Entity.User user = new SosyalSozlukCrooc.Models.Entity.User();
            user.Mail = model.Mail;
            user.Nickname = model.Nickname;
            user.Password = model.Password;
            DB.Users.Add(user);
            DB.SaveChanges();

            FormsAuthentication.SetAuthCookie(model.Mail.ToString(), true);
            string loggedUser = model.Nickname.ToString();
            HttpCookie cookieUser = new HttpCookie("User", loggedUser);
            HttpContext.Response.Cookies.Add(cookieUser);

            userClass.UpdateLastLogin(model.Mail.ToString());

            return Redirect(returnUrl);
        }
        [_SessionLoginControl]
        public ActionResult AddCrooc()
        {
            return View();
        }

        public void CroocAdd(SosyalSozlukCrooc.Models.Entity.Crooc crooc)
        {
            GetUserInformations user = new GetUserInformations();
            int UserID = user.GetUserID();
            SosyalSozlukCrooc.Models.Entity.Crooc entity = new SosyalSozlukCrooc.Models.Entity.Crooc();
            entity.Title = crooc.Title;
            entity.ContentType = crooc.ContentType;
            entity.Content = crooc.Content;
            entity.UserID = UserID;
            DB.Croocs.Add(entity);
            DB.SaveChanges();
            Session["CroocID"] = entity.ID;

        }

        public void CroocPollItems()
        {

            string[] pollitems = Request["PollItem"].Split(',');
            Poll poll = new Poll();

            for (int i = 0; i < pollitems.Length; i++)
            {
                poll.Name = pollitems[i];
                poll.CroocID = Convert.ToInt32(Session["CroocID"]);
                DB.Polls.Add(poll);
                DB.SaveChanges();
            }

        }


        public ActionResult Login(User model, string returnUrl)
        {
            if (DB.Users.Any(x => x.Mail == model.Mail && x.Password == model.Password && x.IsDelete == false))
            {
                FormsAuthentication.SetAuthCookie(model.Mail.ToString(), true);
                SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.Mail == model.Mail);
                string loggedUser = user.Nickname.ToString();
                HttpCookie cookieUser = new HttpCookie("User", loggedUser);
                HttpContext.Response.Cookies.Add(cookieUser);

                userClass.UpdateLastLogin(model.Mail.ToString());
                return Redirect(returnUrl);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult SignOut()
        {
            var c = new HttpCookie("User");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [_SessionLoginControl]
        public ActionResult EditProfile()
        {
            if (HttpContext.Request.Cookies["User"] != null)
            {
                int ID = userClass.GetUserID();
                SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.ID == ID);
                SosyalSozlukCrooc.Models.Entity.User model = new SosyalSozlukCrooc.Models.Entity.User();
                model.Name = user.Name;
                model.Surname = user.Surname;
                model.AddDate = user.AddDate;
                model.UpdateDate = user.UpdateDate;
                model.Mail = user.Mail;
                model.Twitter = user.Twitter;
                model.Instagram = user.Instagram;
                model.Biography = user.Biography;
                model.Linkedin = user.Linkedin;
                model.ProfilePicture = user.ProfilePicture;
                model.Nickname = user.Nickname;
                model.Facebook = user.Facebook;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Login = "False" });
            }
        }
        [_SessionLoginControl]
        [HttpPost]
        public ActionResult EditProfile(EditProfileVM model)
        {
            ViewData["ProcessType"] = "";
            string fname = ""; string condition = ""; string extension = "";
            int ID = userClass.GetUserID();
            SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.ID == ID);
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];
            if (Request.Files.Count > 0 && string.IsNullOrEmpty(file.FileName) != true)
            { 
                
                extension = System.IO.Path.GetExtension(file.FileName.ToLower());
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    fname = file.FileName.Replace(' ', '-');
                    file.SaveAs(Server.MapPath("~/Areas/Crooc/Content/images/Users/" + ID + "/ProfilePicture/" + fname));
                    condition = "True";
                }
                else
                {
                    ViewData["ProcessType"] = "ImageFail";
                    condition = "False";
                }

            }

            try
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Linkedin = model.Linkedin;
                user.Facebook = model.Facebook;
                user.Twitter = model.Twitter;
                user.Instagram = model.Instagram;
                user.Biography = model.Biography;
                user.UpdateDate = DateTime.Now;

                if (condition == "True")
                {
                    string strPhysicalFolder = Server.MapPath(user.ProfilePicture);

                    if (System.IO.File.Exists(strPhysicalFolder))
                        System.IO.File.Delete(strPhysicalFolder);

                    user.ProfilePicture = "/Areas/Crooc/Content/images/Users/" + ID + "/ProfilePicture/" + fname;
                }

                DB.SaveChanges();
                ViewData["Process"] = "Show";
                ViewData["AlertType"] = "success";
                ViewData["ProcessIcon"] = "fa fa-check";
                ViewData["ProcessTitle"] = "Tebrikler!";
                ViewData["ProcessMessage"] = "Profil bilgilerinizi başarıyla güncelleştirdik.";
                return View(user);

            }
            catch (Exception ex)
            {
                string mesj = ex.Message.ToString();

                ViewData["Process"] = "Show";
                ViewData["AlertType"] = "error";
                ViewData["ProcessIcon"] = "fa fa-times";
                ViewData["ProcessTitle"] = "Hata!";
                ViewData["ProcessMessage"] = "Profil bilgilerinizi güncellenirken bir hata ile karşılaştık. Lütfen daha sonra tekrar deneyin.";
                return View(user);
            }

        }
    }
}