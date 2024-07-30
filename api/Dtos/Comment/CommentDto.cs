using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WebApplication1.api.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = string.Empty; //for the comment to appear under a stock

        public int? StockId { get; set; } //one-to-many relationship; formed by convention (entity framework, .net core)

    }
}
