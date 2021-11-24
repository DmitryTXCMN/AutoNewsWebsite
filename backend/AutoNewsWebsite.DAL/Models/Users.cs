using System;
using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "Users")]
    public class User
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column, NotNull]
        public string Login { get; set; }
        [Column, NotNull]
        public string Password { get; set; }
    }
}