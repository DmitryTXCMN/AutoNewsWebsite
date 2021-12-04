using System;
using System.Linq;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.BLL
{
    public class CommentLogic
    {
        public static Comment GetById(Guid id)
        {
            using var db = new DbRepository();
            var query = from p in db.Comment
                where p.Id == id
                select p;
            return query.FirstOrDefault();
        }
        public static void Create(Comment comment)
        {
            using var db = new DbRepository();
            db.Insert(comment);
        }
    }
}