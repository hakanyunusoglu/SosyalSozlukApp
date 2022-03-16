using SosyalSozlukCrooc.Areas.Crooc.Models.Gmailer;
using SosyalSozlukCrooc.Models.DTO;
using SosyalSozlukCrooc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SosyalSozlukCrooc.Areas.Crooc.Controllers
{
    public class HomeController : BaseController
    {
        HomeView mymodel = new HomeView();
        DTOCrooc _crooc = new DTOCrooc();
        public ActionResult Index()
        {
            mymodel.Croocs_icerik = _crooc.GetAllCroocIcerik();
            mymodel.Croocs_soru = _crooc.GetAllCroocSoru();
            mymodel.Croocs_video = _crooc.GetAllCroocVideo();
            mymodel.Croocs_anket = _crooc.GetAllCroocAnket();
            return View(mymodel);
        }

        public ActionResult Detail(int ID)
        {
            SosyalSozlukCrooc.Models.Entity.Crooc entity = DB.Croocs.FirstOrDefault(x => x.ID == ID);
            entity.view += 1;
            DB.SaveChanges();
            mymodel.Croocs_icerik = DB.Croocs.Where(x => x.ID == ID).ToList();
            return View(mymodel);
        }

        public ActionResult Contact()
        {
            if (HttpContext.Request.Cookies["User"] != null)
            {
                string email = HttpContext.User.Identity.Name.ToString();
                SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.Mail == email);
                SosyalSozlukCrooc.Models.Entity.User model = new SosyalSozlukCrooc.Models.Entity.User();
                model.Name = user.Name;
                model.Surname = user.Surname;
                model.Mail = user.Mail;
                return View(model);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Contact(string Name, string Surname, string Mail, string Phone, string Message)
        {
            try
            {
                if (Phone.ToString() == "")
                    Phone = "Belirtilmemiş";

                StreamReader reader = new StreamReader(Server.MapPath("~/Areas/Crooc/Models/Gmailer/MailTemplate.html"));
                string readHTML = reader.ReadToEnd();
                string strContent = "";
                strContent = readHTML;
                strContent = strContent.Replace("[Name]", Name);
                strContent = strContent.Replace("[Surname]", Surname);
                strContent = strContent.Replace("[Mail]", Mail);
                strContent = strContent.Replace("[Phone]", Phone);
                strContent = strContent.Replace("[Message]", Message);

                GMailer.GmailUsername = "hakan@gmail.com";
                GMailer.GmailPassword = "12345678";

                GMailer mailer = new GMailer();
                mailer.ToEmail = "hakan@gmail.com";
                mailer.Subject = "Crooc! Yeni Bir Mesaj Var.";
                mailer.Body = strContent.ToString();
                //mailer.Body = "Bu mail sistem üzerinden bir kullanıcı tarafından gönderildi. Detaylar aşağıdadır; <br/> <b>İsim Soyisim: </b>" + Name.ToString() + " " + Surname.ToString() + "<br/><b>Email:</b> " + Mail.ToString() + "<br/><b>Telefon: </b>" + Phone.ToString() + "<br/><b>Mesaj: </b>" + Message.ToString();
                mailer.IsHtml = true;
                mailer.Send();

                ViewData["Process"] = "Show";
                ViewData["AlertType"] = "success";
                ViewData["ProcessIcon"] = "fa fa-check";
                ViewData["ProcessTitle"] = "Teşekkürler!";
                ViewData["ProcessMessage"] = "Mesajınız başarılı bir şekilde iletilmiştir.";
                return View();
            }
            catch
            {
                ViewData["Process"] = "Show";
                ViewData["AlertType"] = "error";
                ViewData["ProcessIcon"] = "fa fa-times";
                ViewData["ProcessTitle"] = "Hata!";
                ViewData["ProcessMessage"] = "Mesaj gönderilirken bir sorun ile karşılaşıldı. Lütfen daha sonra tekrar deneyin.";
                return View();
            }
        }
    }
}