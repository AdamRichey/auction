using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Plate.Controllers
{
    public class HomeController : Controller
    {
        private platecontext _context;
    
        public HomeController(platecontext context)
        {
            _context = context;
        }
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.login=TempData["login"];
            ViewBag.errors = "";
            return View("index");
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            string a1 = HttpContext.Session.GetString("user");
            if(a1 == "null")
            {
                return RedirectToAction("index");
            }
            else{
                Person a3 = _context.Users.SingleOrDefault(user => user.Username == a1);
                ViewBag.name=a3.First;
                ViewBag.wallet=a3.Wallet;
                ViewBag.auction = _context.Auctions;
                return View("Welcome");
            }


        }

        [HttpPost]
        [Route("vlogin")]
        public IActionResult vlogin(string username, string password)
        {
                Person ReturnedValue = _context.Users.SingleOrDefault(User => User.Username == username);
                if(ReturnedValue == null)
                {
                    TempData["login"]="Invalid Username";
                    return RedirectToAction("index");
                }
                else if(ReturnedValue.Password != password)
                {
                    TempData["login"]="Invalid Password";
                    return RedirectToAction("index");
                }
                else
                {
                    HttpContext.Session.SetString("user",username);
                    return RedirectToAction("welcome");

                } 
        }
        [Route("new")]
        public IActionResult New()
        {
            return View("New");
        }
        [Route("vnew")]
        public IActionResult VNew(Auctionsvm Model, DateTime end, string name, int bid, string description)
        {
            if(end<DateTime.Now)
            {
                ViewBag.error="Please Enter a Future Date";
                return View("New");
            }
            else if(ModelState.IsValid)
            {
                string a1 = HttpContext.Session.GetString("user");
                Person a2 = _context.Users.SingleOrDefault(User => User.Username == a1);
                Auctions NewAuction = new Auctions
                {
                    Name=name,
                    Description=description,
                    Bid = bid,
                    Start=DateTime.Now,
                    End=end,
                    Person=a2,
                };
                _context.Add(NewAuction);
                _context.SaveChanges();              

                return RedirectToAction("welcome");
            }
            else{
                ViewBag.error=ModelState.Values;
                return View("New");
            }
        }

        [HttpPost]
        [Route("vregister")]
        
        public IActionResult vregister(Personvm Model, string first, string last, string username, string password)
        {
            if(ModelState.IsValid)
            {
                Person NewPerson = new Person
                {
                    First=first,
                    Last=last,
                    Username=username,
                    Password=password,
                    Wallet=1000,
                };
                HttpContext.Session.SetString("user",username);
                _context.Add(NewPerson);
                _context.SaveChanges();
                return RedirectToAction("welcome");
            }
            else{
                ViewBag.errors = ModelState.Values;
                return View("index");
            }         
            
        }
            [Route("logout")]
            public IActionResult logout()
            {
                HttpContext.Session.SetString("user", "null");
                return RedirectToAction("index");

            }
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Auctions a3 = _context.Auctions.SingleOrDefault(auctions => auctions.id == id);
            _context.Remove(a3);
            _context.SaveChanges();   
            return RedirectToAction("welcome");
        }

        [Route("auction/{name}")]
        public IActionResult Detail(string name)
        {
            Auctions a3 = _context.Auctions.SingleOrDefault(auctions => auctions.Name == name);
            ViewBag.Product=a3.Name;
            ViewBag.Time=a3.End;
            ViewBag.Bid=a3.Bids;
            ViewBag.Details=a3.Description;
            ViewBag.Name=a3.Person;
            HttpContext.Session.SetString("auction",name);
            return View("details");
        }
        [HttpPost]
        [Route("bid")]
        public IActionResult Bid(int bid)
        {
            string a1 = HttpContext.Session.GetString("auction");
            Auctions a3 = _context.Auctions.SingleOrDefault(auctions => auctions.Name == a1);
            string a4 = HttpContext.Session.GetString("user");
            Person a5 = _context.Users.SingleOrDefault(User => User.Username == a4);

            Bids NewBid = new Bids
            {
                Person = a5,
                Auction = a3,
                Value = bid

            };
            _context.Add(NewBid);
            _context.SaveChanges(); 
            return RedirectToAction("welcome");
        }
    }
}
