using System;
using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "Users")]
    public class Comment
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column, NotNull]
        public Guid UserId { get; set; }
        [Column, NotNull]
        public string Content { get; set; }
        [Column]
        public int LikeCount { get; set; }
        [Column]
        public int DislikeCount { get; set; }
        [Column, NotNull]
        public DateTime Date { get; set; }
    }
}