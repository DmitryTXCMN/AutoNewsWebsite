using System.ComponentModel.DataAnnotations;

namespace AutoNews.DB;

public class News
{
    [Required] public int Id { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Text { get; set; }
    [Required] public string LogoUrl { get; set; }
    [Required] public int Likes { get; set; }
    [Required] public DateTime Date { get; set; }
    [Required] public int CreatorId { get; set; }
}
