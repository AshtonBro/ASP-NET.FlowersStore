﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersStore.Data;
using FlowersStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowersStore.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var model = new BasketViewModel();
            using (StoreDBContext db = new StoreDBContext())
            {
                model.UserName = db.Users.FirstOrDefault(f => f.Name == "User1").Name;

                var user = db.Users.FirstOrDefault(f => f.Name == "User1");
                var basket = db.Baskets.FirstOrDefault(f => f.UserId == user.UserId);
                model.ShopingCarts = db.ShopingCarts.Where(f => f.Basket.BasketId == basket.BasketId);
            }

            return View("~/Views/Basket/Index.cshtml", model);
        }
    }
}
