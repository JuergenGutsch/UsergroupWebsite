using System.Web;
using Gos.SimpleObjectStore;
using Gos.SimpleObjectStore.Providers;

namespace CommunitySite.Web.App_Start
{
    public class RepositoryConfig
    {
        public static void RegisterProvider()
        {
            ObjectStore.DataProvider = new DataProvider(HttpContext.Current.Server.MapPath("~/App_Data/"));
            ObjectStore.FormatOutput = true;
        }
    }
}