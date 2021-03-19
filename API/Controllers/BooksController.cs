using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Book>>> GetBooks([FromQuery] BookSpecParams booksParams)
        {
            var spec = new BookWithFiltersSpec(booksParams);

            return Ok(await _unitOfWork.Repository<Book>().ListAsync(spec));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var spec = new BookWithFiltersSpec(id);

            return Ok(await _unitOfWork.Repository<Book>().GetEntityWithSpec(spec));
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book productToCreate)
        {
            var book = productToCreate;

            _unitOfWork.Repository<Book>().Add(book);

            var result = await _unitOfWork.CompleteAsync();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book productToUpdate)
        {
            var product = await _unitOfWork.Repository<Book>().GetByIdAsync(id);

            product = productToUpdate;

            _unitOfWork.Repository<Book>().Update(product);

            var result = await _unitOfWork.CompleteAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var product = await _unitOfWork.Repository<Book>().GetByIdAsync(id);

            _unitOfWork.Repository<Book>().Delete(product);

            var result = await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}