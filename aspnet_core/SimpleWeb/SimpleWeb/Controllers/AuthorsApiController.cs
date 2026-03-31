


using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
using SimpleWeb;

[ApiController]
[Route("/api/authors")]   //---> answers to this base url
public class AuthorsApiController : ControllerBase
{
    AuthorService service ;
    public AuthorsApiController(AuthorService service)
    {
        this.service=service;
    }

    [HttpGet] //---> handles get request
    public async Task<List<Author>> GetAllAuthors()
    {
        return await service.GetAllAuthors();
    }

    [HttpPost]
    public async Task<Author> AddAuthor([FromBody] Author author)
    {
        var result = await service.AddAuthor(author);
        return result;
    }

    [HttpGet("{id:int}")] //---> base url /id
    public async Task<Author> GetAuthorById(int id)
    {
        return await service.GetAuthorById(id);   
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        if(Request.Headers["Role"]!="ADMIN")
            throw new NotAdminException("User Must be Admin to delete");

        await service.DeleteAuthor(id);

        return NoContent(); //status 204
    }




}

