using Microsoft.AspNetCore.Mvc;
namespace portfolio.Controllers;
    public class HelloController : Controller
    {
        [HttpGet("")]
        public string Index()
        {
            return "This is my Index!";
        }

        [HttpGet("projects")]
        public string projects()
        {
            return "These are my projects";
        }

        [HttpGet("contact")]
        public string contact()
        {
            return "This is my Contact!";
        }
    }

