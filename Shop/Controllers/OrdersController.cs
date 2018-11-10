using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //<month, orders amount in this month>
            Dictionary<int, int> ordersAmountByMonth = GetOrdersAmountByMonth();
            ViewBag.Orders = JsonConvert.SerializeObject(ordersAmountByMonth);

            //<orderId,orderPrice>
            Dictionary<int, float> ordersPrices = GetOrdersPrices();
            ViewData["OrdersPrices"] = ordersPrices;

            var applicationDbContext = _context.Order.Include(o => o.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        //returns map of <order id, orders price>
        private Dictionary<int, float> GetOrdersPrices()
        {
            var joinedOrders =
                from orderProduct in _context.OrderProducts
                join order in _context.Order on orderProduct.OrderId equals order.OrderId
                join product in _context.Product on orderProduct.ProductId equals product.ProductId
                select new { order.OrderId, Price = product.Price * orderProduct.ProductAmount };
            var ordersGroupBy =
                from orderProduct in joinedOrders
                group orderProduct by orderProduct.OrderId into ordersGroup
                select new
                {
                    OrderId = ordersGroup.Key,
                    Price = ordersGroup.Sum(elem => elem.Price)
                };
            Dictionary<int, float> ordersPrices = new Dictionary<int, float>();
            ordersGroupBy.ForEachAsync(order => ordersPrices.Add(order.OrderId, order.Price)).Wait();
            return ordersPrices;
        }

        //returns map of <month(in the last year),orders amount>
        private Dictionary<int, int> GetOrdersAmountByMonth()
        {
            DateTime currentYearStart = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            var ordersByMonth =
                from order in _context.Order
                where order.Date.CompareTo(currentYearStart) >= 0
                group order by order.Date.Month into ordersGroup
                select new { Month = ordersGroup.Key, Amount = ordersGroup.Count() };

            Dictionary<int, int> orderAmountByMonth = new Dictionary<int, int>();
            ordersByMonth.ForEachAsync(ordersGroup =>
            {
                orderAmountByMonth.Add(ordersGroup.Month, ordersGroup.Amount);
            }).Wait();
            return orderAmountByMonth;
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewBag.Products = _context.Product.ToList()
                .Select<Product, Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>
                (p => new SelectListItem(p.ProductName, p.ProductId.ToString()));
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,IsSent,IsMoneyTaken,Products")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Date = DateTime.Now;
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,IsSent,IsMoneyTaken")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
