using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public enum Estatus
    {
        PendingApproval=0, // מחכה לאישור
        InProgress=1,      // בתהליך
        Completed=2        // הושלמה
    }
    public class Order
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public Estatus Status { get; set; }
    }
}
