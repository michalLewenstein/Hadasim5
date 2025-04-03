using Grocery.Core.Models;
using Grocery.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
        public void AddOrder(Order order)
        {
            order.Status = Estatus.PendingApproval;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void OrderConfirmation(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                order.Status = Estatus.InProgress;
            }
            _context.SaveChanges();
        }
        public void OrderCompleted(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                order.Status = Estatus.Completed;
            }
            _context.SaveChanges();
        }

    }
}


