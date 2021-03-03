using AutoMapper;
using BookAPI.Data;
using BookAPI.Dtos;
using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookAPIRepo _repository;
        private readonly IMapper _mapper;
        public BooksController(IBookAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>>GetAllCommands()
        {
            var bookItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(bookItems));
        }

        [HttpGet("{id}")]
        public ActionResult<BookReadDto> GetCommandById(int id)
        {
            var bookItem = _repository.GetCommandById(id);

            if (bookItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookReadDto>(bookItem));
        }

        [HttpPost]
        public ActionResult<BookReadDto> CreateCommand(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);
            _repository.CreateCommand(bookModel);
            _repository.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = bookReadDto.Id }, bookReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, BookUpdateDto bookUpdateDto)
        {
            var bookModelFromRepo = _repository.GetCommandById(id);
            if (bookModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(bookUpdateDto, bookModelFromRepo);
            _repository.UpdateCommand(bookModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var bookModelFromRepo = _repository.GetCommandById(id);
            if (bookModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(bookModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
