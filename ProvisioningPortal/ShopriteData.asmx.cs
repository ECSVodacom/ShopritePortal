using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;


namespace ProvisioningPortal
{
    /// <summary>
    /// Summary description for ShopriteData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ShopriteData : System.Web.Services.WebService
    {

        [WebMethod]
        public JsonResult GetShopriteVendors()
        {
            ShopriteDataContext dc = new ShopriteDataContext();
            var result = dc.Vendors.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
