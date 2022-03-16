using SosyalSozlukCrooc.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SosyalSozlukCrooc.Areas.Crooc.Controllers
{
    public class BaseController : Controller
    {
        public Context DB;
        public BaseController()
        {
            DB = new Context();
        }
        protected override void Dispose(bool disposing)
        {
            DB.Dispose();
        }
    }
}