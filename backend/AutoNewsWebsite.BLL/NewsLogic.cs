using System;
using System.Linq;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.BLL
{
    public static class NewsLogic
    {
        public static News GetById(Guid id)
        {
            using var db = new DbRepository();
            var query = from p in db.News
                where p.Id == id
                select p;
            return query.FirstOrDefault();
        }
        public static void Create(News news)
        {
            using var db = new DbRepository();
            db.Insert(news);
        }
    }
}