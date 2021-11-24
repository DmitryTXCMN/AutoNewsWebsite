using System;
using System.Linq;
using AutoNewsWebsite.BLL.Entities;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;
using User = AutoNewsWebsite.DAL.Models.User;

namespace AutoNewsWebsite.BLL
{
    public static class UserLogic
    {
        public static bool IsExist(User user)
        {
            using var db = new DbANW();
            var query = from p in db.Users
                where p.Login == user.Login
                select p;
            return query.Any();
        }

        public static bool IsCorrectInfo(User user)
        {
            using var db = new DbANW();
            var query = from p in db.Users
                where p.Login == user.Login &&
                      p.Password == user.Password
                select p;
            return query.Any();
        }
        
        public static void Create(User user)
        {
            using var db = new DbANW();
            db.Insert(user);
        }
    }
}