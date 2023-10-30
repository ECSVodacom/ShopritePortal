using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoprite.Models;


namespace Shoprite.DataLayer
{
    public class ShopriteDataLayer
    {

        private static ShopriteDataLayer _Instance;

        public ShopriteDataLayer() { }

        public static ShopriteDataLayer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShopriteDataLayer();
                }
                return _Instance;
            }
        }

        public List<Vendors> GetVendors()
        {
            using (ShopriteEntities dataContext = new ShopriteEntities())
            {
                List<Vendors> Vendors = (from vendor in dataContext.Vendors
                                         select new Vendors
                                         {
                                             Id = vendor.id,
                                             userName = vendor.VendorUserName,
                                             vendorName = vendor.VendorName,
                                             enableClaims = (int)vendor.EnableClaims,
                                             enableOrders = (int)vendor.Enabled,
                                              Password = vendor.VendorPassWord,
                                              //lastActionDate = DateTime.Parse( vendor.LastActionDate.ToString())
                                         }).ToList();
                return Vendors;
            }
        }

        public bool ChangeOrderState(int vendorId)
        {
            using (ShopriteEntities dataContext = new ShopriteEntities())
            {
                var ven = dataContext.Vendors.Where(v => v.id == vendorId).FirstOrDefault<Vendor>();
                if(ven.Enabled == 1){ven.Enabled = 0;}else { ven.Enabled = 1;}
                dataContext.Entry(ven).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
            }
            return true;
        }

        public bool ChangeClaimState(int vendorId)
        {
            using (ShopriteEntities dataContext = new ShopriteEntities())
            {
                var ven = dataContext.Vendors.Where(v => v.id == vendorId).FirstOrDefault<Vendor>();
                if (ven.EnableClaims == 1) { ven.EnableClaims = 0; } else { ven.EnableClaims = 1; }
                dataContext.Entry(ven).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
            }
            return true;
        }

        public bool AddVendor(Vendors vendor)
        {

            try
            {
                using (ShopriteEntities dataContext = new ShopriteEntities())
                {
                    var ven = new Vendor();
                    ven.VendorName = vendor.vendorName;
                    ven.VendorUserName = vendor.userName;
                    ven.VendorPassWord = vendor.Password;
                    ven.Enabled = vendor.enableOrders;
                    ven.EnableClaims = ven.EnableClaims;
                    dataContext.Entry(ven).State = System.Data.Entity.EntityState.Added;
                    dataContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        public bool DeleteVendor(int vendorId)
        {

            try
            {
                using (ShopriteEntities dataContext = new ShopriteEntities())
                {
                    var ven = dataContext.Vendors.Where(v => v.id == vendorId).FirstOrDefault<Vendor>();
                    dataContext.Vendors.Remove(ven);
                    dataContext.Entry(ven).State = System.Data.Entity.EntityState.Deleted;
                    dataContext.SaveChanges();
                }
            }
            catch (Exception )
            {
                return false;
                //throw;
            }
            return true;

        }
        public bool ChangeVendor(Vendors vendor)
        {
            using (ShopriteEntities dataContext = new ShopriteEntities())
            {
                var ven = dataContext.Vendors.Where(v => v.id == vendor.Id).FirstOrDefault<Vendor>();
                ven.VendorName = vendor.vendorName ;
                ven.VendorUserName = vendor.userName;
                ven.VendorPassWord = vendor.Password;
                dataContext.Entry(ven).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
                
            }


            return true;
        }

        public Shoprite.Models.Order GetOrder(string orderNumber)
        {
            using (ShopriteEntities dataContext = new ShopriteEntities())
            {
                var orders = dataContext.Orders.Where(order => order.OrderNumber == orderNumber).FirstOrDefault<Order>();
                var orderBatch = dataContext.OrderBatches.Where(orderbatch => orderbatch.Orders.Contains(orderNumber)).FirstOrDefault<OrderBatch>();
                var vendorRecord = dataContext.Vendors.Where(ven => ven.id == orderBatch.VendorID).FirstOrDefault<Vendor>();

                Shoprite.Models.Order ReturnOrder = new Models.Order();
                ReturnOrder.BatchId = orderBatch.id;
                ReturnOrder.Batch = orderBatch.Orders;
                ReturnOrder.BatchDate = orderBatch.DownloadDate.ToString();
                ReturnOrder.VendorId = (int)orderBatch.VendorID;

                ReturnOrder.OrderNumber = orders.OrderNumber;
                ReturnOrder.OrderProcessedDate = orders.ActionDate.ToString();
                ReturnOrder.OrderStatus = orders.status;
                ReturnOrder.Store = orders.Vendor;
                ReturnOrder.VendorName = vendorRecord.VendorName;

                return ReturnOrder;

            }
            return new Models.Order();
        }
        

    }
}

