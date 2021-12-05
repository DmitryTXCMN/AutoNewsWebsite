using System;
using System.Linq;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.BLL
{
    public static class UserLogic
    {
        public static bool IsExist(UserDTO userDto)
        {
            using var db = new DbRepository();
            var query = from p in db.Users
                where p.Login == userDto.Login
                select p;
            return query.Any();
        }

        public static bool IsCorrectInfo(UserDTO userDto)
        {
            using var db = new DbRepository();
            var query = from p in db.Users
                where p.Login == userDto.Login &&
                      p.Password == userDto.Password
                select p;
            return query.Any();
        }
        
        public static void Create(UserDTO userDto)
        {
            using var db = new DbRepository();
            db.Insert(userDto);
        }

        public static UserDTO Get(Guid id)
        {
            using var db = new DbRepository();
            var query = from p in db.Users
                where p.Id == id
                select p;
            return query.First();
        }

        public static void Update(UserDTO user)
        {
            using var db = new DbRepository();
            db.Users
                .Where(u => u.Id == user.Id)
                .Set(u => u.Password, user.Password)
                .Update();
        }
    }
}