using DapperProject.Contracts;
using DapperProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetBook()
        {

            try
            {
                var books = await _bookRepository.GetBook();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
 
        public async Task<IActionResult> GetBookById(int id)
        {

            try
            {
                var books = await _bookRepository.GetBookById(id);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBook(int id)
        {

            try
            {
                var companies = await _bookRepository.GetBookById(id);
                if (companies == null)
                    return NotFound();
                await _bookRepository.DeleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut("{id}")]
        

        public async Task<IActionResult> UpdateBook(BookDetails bookDetails, int id)
        {

            try
            {
                
                var companies=await _bookRepository.UpdateBook(bookDetails,id);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("InsertBook")]
        public async Task<IActionResult> InsertBook(BookDetails bookDetails)
        {
            try
            {
                var books = await _bookRepository.InsertBook(bookDetails);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
