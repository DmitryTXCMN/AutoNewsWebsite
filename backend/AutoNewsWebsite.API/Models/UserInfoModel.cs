using System;
using System.Data.Linq;

namespace AutoNewsWebsite.API.Models
{
    public class UserInfoModel
    {
        
        public string Nickname { get; set; }
        
        public string Email { get; set; }
        
        public string Image { get; set; }
        
        public string Status { get; set; }
        
        public Guid AuthID { get; set; }
    }
}