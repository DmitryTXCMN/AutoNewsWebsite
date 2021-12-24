using System.ComponentModel.DataAnnotations;

namespace AutoNews.DB;

public class Comment
{
    [Required] public int Id { get; set; }
    [Required] public int WriterId { get; set; }
    [Required] public int NewsId { get; set; }
    [Required] public string Text { get; set; }
}
