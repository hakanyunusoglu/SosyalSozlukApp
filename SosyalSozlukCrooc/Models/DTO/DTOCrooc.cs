using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.DTO
{
    public class DTOCrooc
    {
        public SosyalSozlukCrooc.Models.Context.Context DB = new SosyalSozlukCrooc.Models.Context.Context();

        public List<SosyalSozlukCrooc.Models.Entity.Crooc> GetCroocByID(int ID)
        {
            List<SosyalSozlukCrooc.Models.Entity.Crooc> croocs = DB.Croocs.Where(x => x.IsDelete == false && x.ID==ID).ToList();
            return croocs;
        }

        public List<SosyalSozlukCrooc.Models.Entity.Crooc> GetAllCroocIcerik()
        {
            List<SosyalSozlukCrooc.Models.Entity.Crooc> croocs = DB.Croocs.Where(x => x.IsDelete == false && x.ContentType==1).ToList();
            return croocs;
        }

        public List<SosyalSozlukCrooc.Models.Entity.Crooc> GetAllCroocSoru()
        {
            List<SosyalSozlukCrooc.Models.Entity.Crooc> croocs = DB.Croocs.Where(x => x.IsDelete == false && x.ContentType == 2).ToList();
            return croocs;
        }

        public List<SosyalSozlukCrooc.Models.Entity.Crooc> GetAllCroocVideo()
        {
            List<SosyalSozlukCrooc.Models.Entity.Crooc> croocs = DB.Croocs.Where(x => x.IsDelete == false && x.ContentType == 3).ToList();
            return croocs;
        }

        public List<SosyalSozlukCrooc.Models.Entity.Crooc> GetAllCroocAnket()
        {
            List<SosyalSozlukCrooc.Models.Entity.Crooc> croocs = DB.Croocs.Where(x => x.IsDelete == false && x.ContentType == 4).ToList();
            return croocs;
        }

        public int GetCommentCount(int ID)
        {
            int count = 0;

             count = DB.comments.Count(x => x.CroocID == ID);
            return count;
        }

        public List<SosyalSozlukCrooc.Models.Entity.Comment> GetCommentByID(int ID)
        {
            List<SosyalSozlukCrooc.Models.Entity.Comment> comments = DB.comments.Where(x=>x.CroocID==ID && x.IsDelete==false).ToList();
            return comments;


        }



    }
}