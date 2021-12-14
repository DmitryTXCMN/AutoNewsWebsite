using System;
using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "News")]
    public class News
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column, NotNull]
        public string Head { get; set; }
        [Column, NotNull]
        public string Content { get; set; }
        [Column, NotNull]
        public DateTime DateOfCreate { get; set; }
    }
}