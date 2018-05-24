using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Bids : BaseEntity
    {
        public Person Person{get; set;}
        public Auctions Auction {get; set;}
        public int Value {get; set;}
    }
}