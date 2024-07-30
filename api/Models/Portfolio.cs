using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.api.Models
{
    //this is our joint table
    [Table("Portfolios")]
    public class Portfolio
    {
        //foreign keys setup
        public string AppUserId { get; set; }
        public int StockId { get; set; }
        public AppUser AppUser { get; set; }  //this is for me, the dev [nav prop]
        public Stock Stock { get; set; }  //this is for me, the dev [nav prop]
    }
}
