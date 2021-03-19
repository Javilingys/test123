using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReadersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReadersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Reader>>> GetReaders([FromQuery] ReaderSpecParams booksParams)
        {
            var spec = new ReaderWithFiltersSpec(booksParams);

            return Ok(await _unitOfWork.Repository<Reader>().ListAsync(spec));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> GetReader(int id)
        {
            var spec = new ReaderWithFiltersSpec(id);

            return Ok(await _unitOfWork.Repository<Reader>().GetEntityWithSpec(spec));
        }

        [HttpPost]
        public async Task<ActionResult<Reader>> CreateReader(Reader productToCreate)
        {
            var reader = productToCreate;

            _unitOfWork.Repository<Reader>().Add(reader);

            var result = await _unitOfWork.CompleteAsync();

            return Ok(reader);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reader>> UpdateReader(int id, Reader productToUpdate)
        {
            var product = await _unitOfWork.Repository<Reader>().GetByIdAsync(id);

            product = productToUpdate;

            _unitOfWork.Repository<Reader>().Update(product);

            var result = await _unitOfWork.CompleteAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var product = await _unitOfWork.Repository<Reader>().GetByIdAsync(id);

            _unitOfWork.Repository<Reader>().Delete(product);

            var result = await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}