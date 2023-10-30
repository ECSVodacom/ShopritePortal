using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Shoprite.Models;
using System.Web.Script.Serialization;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;


namespace Shoprite.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ShopriteController : ApiController
    {
        /// <summary>
        /// Get Vendors
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public List<Vendors> GetVendors()
        {
            return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.GetVendors();
        }

        [HttpPost]
        public bool ChangeOrderState(int vendorId)
        {
            try
            {
                //Vendors TheVendor = new JavaScriptSerializer().Deserialize<Vendors>(vendorId);

                return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.ChangeOrderState(vendorId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public bool ChangeClaimState(int vendorId)
        {
            try
            {
                //Vendors TheVendor = new JavaScriptSerializer().Deserialize<Vendors>(vendorId);

                return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.ChangeClaimState(vendorId);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        public bool ChangeVendor(String vendor)
        {
            Vendors TheVendor = new JavaScriptSerializer().Deserialize<Vendors>(vendor);
            return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.ChangeVendor(TheVendor);
        }

        [HttpPost]
        public bool AddVendor(String vendor)
        {
            Vendors TheVendor = new JavaScriptSerializer().Deserialize<Vendors>(vendor);
            return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.AddVendor(TheVendor);
        }

        [HttpPost]
        public bool DeleteVendor(int vendorId)
        {
            return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.DeleteVendor(vendorId);
        }

        [HttpPost]
        public Shoprite.Models.Order GetOrder(String orderNumber)
        {
            return Shoprite.BusinessRules.ShopriteBusinessRules.Instance.GetOrder(orderNumber);
        }

        [HttpPost]
        public bool Authenticate(String UserName, String Password, String Domain)
        {
            bool validation;
            try
            {
                LdapConnection lcon = new LdapConnection
                        (new LdapDirectoryIdentifier((string)null, false, false));
                NetworkCredential nc = new NetworkCredential(UserName,
                       Password, Domain);

                lcon.Credential = nc;
                lcon.AuthType = AuthType.Negotiate;
                // user has authenticated at this point,
                // as the credentials were used to login to the dc.
                lcon.Bind(nc);
                validation = true;
            }
            catch (LdapException)
            {
                validation = false;
            }
            return validation;
        }
    }
}