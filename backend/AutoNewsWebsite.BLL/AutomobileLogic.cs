using System;
using System.Linq;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.BLL
{
    public class AutomobileLogic
    {
        public static Automobile GetById(Guid id)
        {
            using var db = new DbRepository();
            var query = from p in db.Automobile
                where p.Id == id
                select p;
            return query.FirstOrDefault();
        }
        public static void Create(Automobile automobile)
        {
            using var db = new DbRepository();
            db.Insert(automobile);
        }
    }
}