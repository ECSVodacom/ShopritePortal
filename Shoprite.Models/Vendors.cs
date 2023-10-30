using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoprite.Models
{
   public class Vendors
    {

        public int Id { get; set; }
        public string vendorName { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public int enableOrders { get; set; }
        public int enableClaims { get; set; }
        public DateTime lastActionDate { get; set; }

    }
}
