using System.Web;
using XmlRepository.DataProviders;

namespace CommunitySite.Web.App_Start
{
    public class RepositoryConfig
    {
        public static void RegisterProvider()
        {
            XmlRepository.XmlRepository.DefaultQueryProperty = "Id";
            XmlRepository.XmlRepository.DataProvider = new XmlFileProvider(HttpContext.Current.Server.MapPath("~/App_Data/"));
        }
    }
}