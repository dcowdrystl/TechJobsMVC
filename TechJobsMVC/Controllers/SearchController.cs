using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
/*Create a new list of Job objects
 if search text box is empty, make the list equal to the output of the find all method found in JobData.cs
else plug the results of FindColumnAndValue method into the empty jobs list created below.  FindColumnAndValue also found in JobData.cs
parameters searchType and searchTerm are found in search/index.cshtml
Make the new jobs list a viewbag to be used in search/index.cshtml
Make the searchType a viewbag in order to use logic to make the users search type stay selected*/
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null || searchTerm.Equals("")) 
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }


            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.searchType = searchType;

            return View("Index");
        }
    }
}
