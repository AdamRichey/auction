using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Auctions : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Bid{get; set;}
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Person Person{get; set;}
        public List<Bids> Bids {get; set;}
        public Auctions()
        {
            Bids = new List<Bids>();
        }
    }
}