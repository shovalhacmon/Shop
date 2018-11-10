using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //TODO: remove: Seed orders and products
            //    List<OrderProduct> total = _context.OrderProducts.ToList();
            //    List<Order> orders = _context.Order.ToList();
            //    List<Product> products = _context.Product.ToList();
            //    Random rnd = new Random();
            //    List<OrderProduct> ordersProducts = new List<OrderProduct>();
            //    for (int i = 0; i < 40; i++)
            //    {
            //        Product randomProduct = products[rnd.Next(products.Count)];
            //        Order randomOrder = orders[rnd.Next(orders.Count)];
            //        Predicate<OrderProduct> findQuery = op =>
            //           op.OrderId == randomOrder.OrderId &&
            //           op.ProductId == randomProduct.ProductId;
            //        if (total.FindIndex(findQuery) == -1 && ordersProducts.FindIndex(findQuery) == -1)
            //            ordersProducts.Add(
            //                new OrderProduct
            //                {
            //                    OrderId = randomOrder.OrderId,
            //                    ProductId = randomProduct.ProductId,
            //                    ProductAmount = rnd.Next(1, 10)
            //                });
            //    }
            //    ordersProducts.ForEach(op =>
            //    {
            //        _context.Add(op);
            //    });
            //    _context.SaveChangesAsync().Wait();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
