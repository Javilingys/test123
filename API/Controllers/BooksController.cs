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
    }
}