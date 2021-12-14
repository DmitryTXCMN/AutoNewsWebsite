using System;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.DAL
{
    public class DbRepository : LinqToDB.Data.DataConnection
    {
        public DbRepository() : base("AutoNewsWebsite") {}

        public ITable<UserDTO> Users => GetTable<UserDTO>();
        public ITable<News> News => GetTable<News>();
        public ITable<Comment> Comment => GetTable<Comment>();
        public ITable<UserInfo> UserInfo => GetTable<UserInfo>();
        public ITable<Automobile> Automobile => GetTable<Automobile>();
        
    }
}