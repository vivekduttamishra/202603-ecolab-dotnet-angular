//using Microsoft.AspNetCore.Components;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWeb.Controllers
{
   
    public class AuthorsController:Controller
    {

        AuthorService service;
        public AuthorsController(AuthorService service)
        {
            this.service=service;
        }

        //we can call this using:  /authors/list    
       
        public async Task<int> Count()
        {
            var authors = await service.GetAllAuthors();
            return authors.Count;
        }

        public async Task<ActionResult> List()
        {
            var authors = await service.GetAllAuthors();

            return View(authors);
        }

        public async Task<ActionResult> Details(int id)
        {
            var author = await service.GetAuthorById(id);

            return View(author);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAuthor(id);

            return RedirectToAction("List");

        }
    }
}
