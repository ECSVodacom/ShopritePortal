using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoprite.Models
{
   public class Order
    {
       int OrderId { get; set; }
       public int BatchId { get; set; }
       public string Batch { get; set; }
       public string OrderNumber { get; set; }
       public String Store { get; set; }
       public String VendorName { get; set; }
       public int VendorId { get; set; }
       public String BatchDate { get; set; }
       public String OrderProcessedDate { get; set; }
       public String OrderStatus { get; set; }

    }
}
