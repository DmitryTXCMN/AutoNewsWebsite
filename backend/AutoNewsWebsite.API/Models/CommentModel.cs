using System;

namespace AutoNewsWebsite.API.Models
{
    public class CommentModel
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public DateTime Date { get; set; }
        public Guid NewsId { get; set; }
    }
}