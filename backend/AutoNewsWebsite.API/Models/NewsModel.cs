using System;

namespace AutoNewsWebsite.API.Models
{
    public class NewsModel
    {
        public string Head { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}