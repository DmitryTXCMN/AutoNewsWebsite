using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "File")]
    public class FileModel
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column, NotNull]
        public string Name { get; set; }
        [Column, NotNull]
        public string Path { get; set; }
    }
}