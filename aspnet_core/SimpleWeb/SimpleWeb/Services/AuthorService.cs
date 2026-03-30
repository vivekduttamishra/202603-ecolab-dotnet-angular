
namespace ConceptArchitect.BookManagement;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public string Biography { get; set; }
}

public class AuthorService
{
    int lastId=0;
    List<Author> authors=new List<Author>();

    public async Task<Author> AddAuthor(Author author)
    {
        author.Id=++lastId;
        authors.Add(author);
        return author;
    }

    public async Task<Author> GetAuthorById(int id)
    {
        // foreach(var author in authors)
        //     if(author.Id==id)
        //         return author;

        var author = authors.FirstOrDefault(a=> a.Id==id);
        if(author!=null)
            return author;
        else
            throw new InvalidIdException(id);
    }


    public async Task<List<Author>> GetAllAuthors()
    {
        return authors;
    }

    public async Task DeleteAuthor(int id)
    {
        var author = await GetAuthorById(id);
        authors.Remove(author);        
    }
}



public class DummyAuthorFiller
{
    AuthorService service ;
    public DummyAuthorFiller(AuthorService service)
    {
       // AddAuthors(service).Wait();
       this.service=service;
    }

    private async Task AddAuthors(AuthorService service)
    {
        await service.AddAuthor(new Author(){ Name="Mahatma Gandhi", Biography="The father of the nation, freedom figher and social reformer"});
        await service.AddAuthor(new Author(){ Name="Alexandre Dumas", Biography="One of the greatest french classic author"});
        await service.AddAuthor(new Author(){ Name="Vivek Dutta Mishra", Biography="Author of The Lost epic series"});
    }
}


[Serializable]
public  class InvalidIdException : Exception
{
    private int id;

    public InvalidIdException()
    {
    }

    public InvalidIdException(int id): base("Invalid Id")
    {
        this.id = id;
    }

    public InvalidIdException(string? message) : base(message)
    {
    }

    public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}