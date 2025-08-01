using BookServices.Data;
using BookServices.Model;
using BookServices.UnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookServices.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public BookController(IUnitofWork unitofwork)
        {
            _unitofWork = unitofwork;
        }
        [HttpGet]
        public async Task<IActionResult> Getalldata()
        {
            return Ok(await _unitofWork.bookRepository.GetallBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatabyId(int id)
        {
            var book = await _unitofWork.bookRepository.GetBookbyId(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> InsertData(Book book)
        {
            await _unitofWork.bookRepository.InsertBook(book);
            await _unitofWork.SaveData();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(int id,Book book)
        {
            await _unitofWork.bookRepository.UpdateBook(book,id);
            await _unitofWork.SaveData();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await _unitofWork.bookRepository.DeleteBook(id);
            await _unitofWork.SaveData();
            return NoContent();
        }
    }
}
