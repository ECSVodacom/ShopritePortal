using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoprite.DataLayer;
using Shoprite.Models;

namespace Shoprite.BusinessRules
{
    public class ShopriteBusinessRules
    {
        private static ShopriteBusinessRules _Instance;

        public ShopriteBusinessRules() { }

        public static ShopriteBusinessRules Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new ShopriteBusinessRules();
                }
                return _Instance;
            }

        }

        public List<Vendors> GetVendors()
        {
            return ShopriteDataLayer.Instance.GetVendors();
        }

        public bool ChangeOrderState(int vendorId)
        {

            return ShopriteDataLayer.Instance.ChangeOrderState(vendorId);

        }


        public bool ChangeClaimState(int vendorId)
        {

            return ShopriteDataLayer.Instance.ChangeClaimState(vendorId);

        }

        public bool ChangeVendor(Vendors vendor)
        {
            return ShopriteDataLayer.Instance.ChangeVendor(vendor);
        }

        public bool AddVendor(Vendors vendor)
        {
            
            return ShopriteDataLayer.Instance.AddVendor(vendor);
        }

        public bool DeleteVendor(int vendorId)
        {
            return ShopriteDataLayer.Instance.DeleteVendor(vendorId);
        }

        public Shoprite.Models.Order GetOrder(String orderNumber)
        {
            return ShopriteDataLayer.Instance.GetOrder(orderNumber);
        }

    }
}
