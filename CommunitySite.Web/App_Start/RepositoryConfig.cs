using System.Web;
using Gos.SimpleObjectStore;

namespace CommunitySite.Web.App_Start
{
    public class RepositoryConfig
    {
        public static void RegisterProvider()
        {
            ObjectStore.DefaultQueryProperty = "Id";
            ObjectStore.DataProvider = new DataProvider(HttpContext.Current.Server.MapPath("~/App_Data/"));
            ObjectStore.FormatOutput = true;
        }
    }
}