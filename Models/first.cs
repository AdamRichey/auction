using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Person : BaseEntity
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Wallet {get; set;}
        public List<Auctions> Auctions {get;set;}
        public List<Bids> Bids {get;set;}
        public Person()
        {
            Auctions = new List<Auctions>();
            Bids = new List<Bids>();
        }
    }
}