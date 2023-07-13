using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using BookStore.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase{

        private readonly BookStoreContext repository;
        private readonly IMapper mapper;

        public AuthorController(BookStoreContext repository, IMapper mapper){
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAsync(){
            var authors = await repository.Authors.GetAllAsync();

            //da sam sada ovde pokusao da odhvatim book property od author onda bi ono ponovo odradilo query
            //i dohvatilo korespodentne vrijednosti za tog nekog autora
            //da uopste nema mogucnosti ja bih mogao obrisati tu listu

            return Ok(mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetByIdAsync(Guid id){
            var author = await repository.Authors.GetAsync(id);

            return author == null ? NotFound() : Ok(mapper.Map<AuthorDto>(author));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateAuthorDto createAuthorDto){
            if (!ModelState.IsValid){
                return BadRequest();
            }

            var author = mapper.Map<Author>(createAuthorDto);

            await repository.Authors.CreateAsync(author);

            return CreatedAtAction(nameof(GetByIdAsync), new {Id = author.Id}, mapper.Map<AuthorDto>(author));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateAuthorDto updateAuthorDto){
            if (!ModelState.IsValid){
                return BadRequest();
            }
            
            var existingAuthor = await repository.Authors.GetAsync(id);

            if (existingAuthor == null){
                return NotFound();
            }

            existingAuthor.Name = updateAuthorDto.Name;
            existingAuthor.Surname = updateAuthorDto.Surname;
            existingAuthor.Birtday = updateAuthorDto.Birthday;

            await repository.Authors.UpdateAsync(existingAuthor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id){
            var author = repository.Authors.GetAsync(id);

            if (author == null){
                return NotFound();
            }

            await repository.Authors.DeleteAsync(id);

            return NoContent();
        }

    }
}