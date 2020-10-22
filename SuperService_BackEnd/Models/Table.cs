﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperService_BackEnd.Models
{
    public class Table
    {
        [Key]
        public int ID { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string DisplayTableNumber => $"Table: {TableNumber}";
    }
}
