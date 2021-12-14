using System;
using LinqToDB.Mapping;

namespace AutoNewsWebsite.DAL.Models
{
    [Table(Name = "Automobile")]
    public class Automobile
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column]
        public string ModelName { get; set; }
        [Column]
        public string ModelVariant { get; set; }
        [Column]
        public string Engine { get; set; }
        [Column, NotNull]
        public DateTime Year { get; set; }
    }
}