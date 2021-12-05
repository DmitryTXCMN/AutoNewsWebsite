using System;
using System.Data.Linq;
using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "UserInfo")]
    public class UserInfo
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column, NotNull]
        public string Nickname { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Image { get; set; }
        [Column]
        public string Status { get; set; }
        [Column, NotNull]
        public Guid AuthID { get; set; }
    }
}