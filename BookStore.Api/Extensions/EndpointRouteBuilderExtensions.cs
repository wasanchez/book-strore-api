using BookStore.Api.Handlers;

namespace BookStore.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterBooksEndpoints(this IEndpointRouteBuilder endpointRouteBuilder) 
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("/books");
        var booksWithIdEndpoints = booksEndpoints.MapGroup("/{id}");

        booksEndpoints.MapGet("", BooksHandlers.GetAsync);
        booksWithIdEndpoints.MapGet("", BooksHandlers.GetByIdAsync)
            .WithName("GetBook");
        booksEndpoints.MapPost("", BooksHandlers.PostAsync);
        booksWithIdEndpoints.MapPut("", BooksHandlers.PutAsync);
        booksEndpoints.MapDelete("", BooksHandlers.DeleteAsync);
    }
}
