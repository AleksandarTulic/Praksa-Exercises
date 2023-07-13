using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using BookStore.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase{
        private readonly BookStoreContext repository;
        private readonly IMapper mapper;

        public BookController(BookStoreContext repository, IMapper mapper){
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllAsync(){
            var books = await repository.Books.GetAllAsync();

            return Ok(mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetByIdAsync(Guid id){
            var book = await repository.Books.GetAsync(id);

            return book == null ? NotFound() : Ok(mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> PostAsync(CreateBookDto createBookDto){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            var book = mapper.Map<Book>(createBookDto);

            await repository.Books.CreateAsync(book);

            book.Author = await repository.Authors.GetAsync(book.AuthorId);

            return CreatedAtAction(nameof(GetByIdAsync), new {Id = book.Id}, mapper.Map<BookDto>(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateBookDto updateBookDto){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            var existingBook = await repository.Books.GetAsync(id);

            if (existingBook == null){
                return NotFound();
            }

            existingBook.Title = updateBookDto.Title;
            existingBook.Description = updateBookDto.Description;
            existingBook.AuthorId = updateBookDto.AuthorId;

            await repository.Books.UpdateAsync(existingBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id){
            var book = await repository.Books.GetAsync(id);

            if (book == null){
                return NotFound();
            }

            await repository.Books.DeleteAsync(id);

            return NoContent();
        }
    }
}