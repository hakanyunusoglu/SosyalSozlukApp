using SosyalSozlukCrooc.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Areas.Crooc.Models.Attributes
{
    public class GetUserInformations
    {
        Context DB = new Context();
        string email = HttpContext.Current.User.Identity.Name.ToString();

        public void UpdateLastLogin(string Email)
        {
            SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.Mail == Email);
            user.LastLogin = DateTime.Now;
            DB.SaveChanges();
        }
        public int GetUserID()
        {
            int ID;
            SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.Mail == email);
            ID = user.ID;
            return ID;
        }

        public string GetUserProfilePhoto()
        {
            string photo;
            photo = DB.Users.FirstOrDefault(x => x.Mail == email).ProfilePicture.ToString();
            return photo;
        }

        public bool IsThatFirstTimeLogin()
        {
            if (HttpContext.Current.User.Identity.Name.ToString() != "")
            {
                bool result;
                result = DB.Users.FirstOrDefault(x => x.Mail == email).FirstTimeLogin;
                if (result == true)
                {
                    SosyalSozlukCrooc.Models.Entity.User user = DB.Users.FirstOrDefault(x => x.Mail == email);
                    user.FirstTimeLogin = false;
                    DB.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}