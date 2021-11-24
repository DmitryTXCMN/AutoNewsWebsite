using AutoNewsWebsite.DAL.Models;
using LinqToDB;

namespace AutoNewsWebsite.DAL
{
    public class DbANW : LinqToDB.Data.DataConnection
    {
        public DbANW() : base("AutoNewsWebsite") {}

        public ITable<UserDTO> Users => GetTable<UserDTO>();
    }
}