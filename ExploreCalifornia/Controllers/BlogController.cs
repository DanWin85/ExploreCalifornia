﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        // GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            var posts = new[]
            {
                new Post
                {
                    Title = "My blog Post",
                    Posted = DateTime.Now,
                    Author = "Daniel Wingate",
                    Body = "This is a great blog post, don't you think?",
                },
                new Post
                {
                    Title = "My second blog Post",
                    Posted = DateTime.Now,
                    Author = "Daniel Wingate",
                    Body = "This is a great blog post, don't you think?",
                }
            };
            return View();
        }
        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Title = "My blog Post",
                Posted = DateTime.Now,
                Author = "Daniel Wingate",
                Body = "This is a great blog post, don't you think?",
            };
          
            return View(post);
        }

        [HttpGet,Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if(ModelState.IsValid)
                return View(post);

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            return View();
        }

        
    }
}