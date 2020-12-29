using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VesizleWebService.DataAccess;

namespace VesizleWebService
{
    /// <summary>
    /// Summary description for CountWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CountWebService : System.Web.Services.WebService
    {

        private CountService _countService;

        public CountWebService()
        {
            _countService = new CountService();
        }

        [WebMethod]
        public int FavoriteCount(string userId)
        {
            return _countService.FavoriteCount(userId);
        }
        [WebMethod]
        public int WatchListCount(string userId)
        {
            return _countService.WatchListCount(userId);
        }
        [WebMethod]
        public int WatchedListCount(string userId)
        {
            return _countService.WatchedListCount(userId);
        }
    }
}
