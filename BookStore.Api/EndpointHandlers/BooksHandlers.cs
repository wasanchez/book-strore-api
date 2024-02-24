using AutoMapper;
using BookStore.Api.Models;
using BookStore.Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.Api.Handlers;

public static class BooksHandlers
{
    public static async Task<Ok<List<Book>>> GetAsync(ILogger<BooksService> logger, BooksService booksService) 
    {
        logger.LogInformation("Getting Books...");
        return TypedResults.Ok( await booksService.GetAsync());
    }

    public static async Task<Results<NotFound, Ok<Book>>> GetByIdAsync(ILogger<BooksService> logger, BooksService booksService, string id) 
    {
        logger.LogInformation("Getting Book by id {0}", id);
        var book = await booksService.GetAsync(id);
        if (book == null) {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(book);
    }

    public static async Task<CreatedAtRoute<Book>> PostAsync(ILogger<BooksService> logger, BooksService booksService, Book newBook) 
    {
        logger.LogInformation("Getting Book by id {0}", newBook);
        await booksService.CreateAsync(newBook); 
        return TypedResults.CreatedAtRoute(newBook, "GetBook", new {id = newBook.Id}) ;
    }

    public static async Task<Results<NotFound, NoContent>> PutAsync(IMapper mapper, ILogger<BooksService> logger, BooksService booksService, string id, BookForUpdateDto bookToUpdate ) 
    {
        logger.LogInformation($"Updating Book id {id}");
        var book = await booksService.GetAsync(id);
        if (book == null) {
            return TypedResults.NotFound();
        }
        book = mapper.Map<Book>(bookToUpdate);

        await booksService.UpdateAsync(id, book);
        logger.LogInformation($"The Book  with id {id} has been updated.");
        return TypedResults.NoContent();

    }

    public static async Task<Results<NotFound, NoContent>> DeleteAsync(ILogger<BooksService> logger, BooksService booksService, string id) 
    {
        logger.LogInformation($"Deleting Book id {id}");
        var book = await booksService.GetAsync(id);
        if (book == null) {
            return TypedResults.NotFound();
        }

        await booksService.RemoveAsync(id);
        logger.LogInformation($"The Book with id {id} has been deleted.");
        return TypedResults.NoContent();
    }
}
