using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.api.Data;

namespace WebApplication1.api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; } //one-to-many relationship; formed by convention (entity framework, .net core)

        //navigation property
        public Stock? Stock { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

