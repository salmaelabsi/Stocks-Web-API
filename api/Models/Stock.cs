﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.api.Models
{
    [Table("Stocks")]  //for aesthetic purposes only
    public class Stock
    {
        public int Id { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")] //monetary value with 18digits and 2 decimal places

        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>(); //one to many rs
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
