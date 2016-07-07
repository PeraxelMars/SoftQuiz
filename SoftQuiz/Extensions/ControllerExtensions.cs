using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;

namespace SoftQuiz.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetApplicationRootPath(this Controller controller)
        {
            // return controller.Server.MapPath("~");
            return GetApplicationRootPath();
        }
        public static string GetApplicationRootPath(this ApiController controller)
        {
            return GetApplicationRootPath();
        }

        private static string GetApplicationRootPath()
        {
            return HostingEnvironment.ApplicationPhysicalPath;
        }
    }
}