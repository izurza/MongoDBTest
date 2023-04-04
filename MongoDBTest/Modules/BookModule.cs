using Carter;
using MongoDBTesting.Models;
using MongoDBTesting.Services;

namespace MongoDBTesting.Modules;

public class BookModule : CarterModule
{
    public BookModule() { }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var books = app.MapGroup("/Books").WithTags("Books");

        books.MapGet("/", async (BookService bookService) =>
        {
            return await bookService.GetAsync()
            is List<Book> books
            ? Results.Ok(books)
            : Results.NoContent();
        })
            .Produces<List<Book>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent);

        books.MapGet("/{id}", async (string id, BookService bookService) =>
        {
            return await bookService.GetAsync(id)
            is Book book
            ? Results.Ok(book)
            : Results.NotFound();
        })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        books.MapPost("/", async (Book newBook, BookService bookService) =>
        {
            await bookService.CreateAsync(newBook);

        });

        books.MapPut("/{id}", async (Book newBook, BookService bookService) =>
        {
            await bookService.UpdateAsync(newBook.Id, newBook);
        });

        books.MapDelete("/{id}", async (string id, BookService bookService) =>
        {
            await bookService.RemoveAsync(id);
        });

    }
}
