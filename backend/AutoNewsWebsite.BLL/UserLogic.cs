﻿using System;
using AutoNewsWebsite.BLL.Models;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;

namespace AutoNewsWebsite.BLL
{
    public static class UserLogic
    {
        public static bool IsExist(User user)
        {
            var temp = Engine.Select($"SELECT * FROM Users WHERE Login = {user.Login}");
            return temp.ColumnsCount != 0;
        }

        public static bool IsCorrectInfo(User user)
        {
            var temp = Engine.Select($"SELECT * FROM Users WHERE Login = {user.Login} and Password = {user.Password}");
            return temp.ColumnsCount != 0;
        }
        
        public static void Create(User user)
        {
            var dtoUser = new Users() {Id = new Guid(user.Login), Login = user.Login, Password = user.Password};
            dtoUser.Insert();
        }
    }
}