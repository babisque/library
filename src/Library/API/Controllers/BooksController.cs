using System.ComponentModel.DataAnnotations;
using Application.Common.Exceptions;
using Application.DTOs.Book;
using Application.UseCases.Books.Command.CreateBook;
using Application.UseCases.Books.Command.DeleteBook;
using Application.UseCases.Books.Command.UpdateBook;
using Application.UseCases.Books.Queries.GetBookById;
using Application.UseCases.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAll()
    {
        var result = await _mediator.Send(new GetBooksQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetById(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetBookByIdQuery { Id = id });
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<BookDTO>> Create(CreateBookCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateBookCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteBookCommand { Id = id });
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}