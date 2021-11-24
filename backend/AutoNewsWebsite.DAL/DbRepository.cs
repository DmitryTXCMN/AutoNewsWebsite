using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.DAL
{
    public class DbRepository : LinqToDB.Data.DataConnection
    {
        public DbRepository() : base("AutoNewsWebsite") {}

        public ITable<UserDTO> Users => GetTable<UserDTO>();
    }
}