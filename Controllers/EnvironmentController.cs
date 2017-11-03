using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace CfWorkshopDotNetCore.Controllers
{
    public class EnvironmentController : Controller
    {
        CloudFoundryApplicationOptions ApplicationOptions { get; set; }
        CloudFoundryServicesOptions ServicesOptions { get; set; }

        /// <summary>
        /// Constructor for the Environment Controller
        /// </summary>
        /// <param name="applicationOptions">The CF application options</param>
        /// <param name="servicesOptions">The CF services options </param>
        public EnvironmentController(IOptions<CloudFoundryApplicationOptions> applicationOptions, 
            IOptions<CloudFoundryServicesOptions> servicesOptions)
        {
            ApplicationOptions = applicationOptions.Value;
            ServicesOptions = servicesOptions.Value;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["InstanceIndex"] = ApplicationOptions.InstanceIndex;
            ViewData["InstanceId"] = ApplicationOptions.InstanceId;
            ViewData["ApplicationName"] = ApplicationOptions.ApplicationName;
            ViewData["ApplicationUris"] = ApplicationOptions.ApplicationUris != null ? ApplicationOptions.ApplicationUris[0] : "none";

            foreach (var service in ServicesOptions.Services)
            {
                ViewData["BoundServices"] += service.Name + "\n";
            }

            return View();
        }

        // GET: /<controller>/Kill
        [HttpGet]
        public void Kill()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
