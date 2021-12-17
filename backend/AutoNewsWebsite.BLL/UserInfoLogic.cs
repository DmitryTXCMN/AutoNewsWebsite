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

        public static void Edit(UserInfo userInfo)
        {
            using var db = new DbRepository();
            db.UserInfo
                .Where(p => p.Id == userInfo.Id)
                .Set(p => p.Email, userInfo.Email)
                .Set(p => p.Image, userInfo.Image)
                .Set(p => p.Nickname, userInfo.Nickname)
                .Set(p => p.Status, userInfo.Status)
                .Set(p => p.AuthID, userInfo.AuthID)
                .Update();
        }
    }
}