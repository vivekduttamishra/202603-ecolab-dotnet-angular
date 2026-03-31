//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWeb.Controllers
{
    public class AuthorsController:Controller
    {
        //we can call this using:  /authors/list        
        public string List()
        {
            return "List of Authors";
        }
    }
}
