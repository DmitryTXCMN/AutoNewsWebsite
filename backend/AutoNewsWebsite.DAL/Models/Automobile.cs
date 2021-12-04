using System;
using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "Users")]
    public class Automobile
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column (Name = "Model Name")]
        public string ModelName { get; set; }
        [Column (Name = "Model Variant")]
        public string ModelVariant { get; set; }
        [Column]
        public string Engine { get; set; }
        [Column, NotNull]
        public string Year { get; set; }
    }
}