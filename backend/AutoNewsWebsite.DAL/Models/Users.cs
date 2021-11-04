using System;

namespace AutoNewsWebsite.DAL.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}