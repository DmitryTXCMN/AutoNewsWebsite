using System;

namespace AutoNewsWebsite.API.Models
{
    public class AutomobileModel
    {
        public string ModelName { get; set; }
        
        public string ModelVariant { get; set; }
        
        public string Engine { get; set; }
        
        public DateTime Year { get; set; }
    }
}