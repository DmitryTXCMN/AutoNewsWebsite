using System;
using System.Linq;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.BLL
{
    public class UserInfoLogic
    {
        public static UserInfo GetById(Guid id)
        {
            using var db = new DbRepository();
            var query = from p in db.UserInfo
                where p.Id == id
                select p;
            return query.FirstOrDefault();
        }
        public static void Create(UserInfo userInfo)
        {
            using var db = new DbRepository();
            db.Insert(userInfo);
        }
    }
}