using System;
using System.Linq;
using AutoNewsWebsite.BLL.Entities;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.BLL
{
    public static class UserLogic
    {
        public static bool IsExist(UserDTO userDto)
        {
            using var db = new DbANW();
            var query = from p in db.Users
                where p.Login == userDto.Login
                select p;
            return query.Any();
        }

        public static bool IsCorrectInfo(UserDTO userDto)
        {
            using var db = new DbANW();
            var query = from p in db.Users
                where p.Login == userDto.Login &&
                      p.Password == userDto.Password
                select p;
            return query.Any();
        }
        
        public static void Create(UserDTO userDto)
        {
            using var db = new DbANW();
            db.Insert(userDto);
        }
    }
}