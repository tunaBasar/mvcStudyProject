using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi.Controllers
{
    public class CourseController:Controller
    {

        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }

        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Apply([FromForm]Candidate model)
        {
            if (Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("","There is already an application for you" );
            } 
            if(ModelState.IsValid)
            {
                Repository.add(model);
                return View("Feedback",model);

            }
            return View();
            
        }
    }
}
