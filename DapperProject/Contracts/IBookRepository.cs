using DapperProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Contracts
{
    public interface IBookRepository
    {
        public Task DeleteBook(int id);

        public Task<int> UpdateBook(BookDetails bookDetails,int id);

        public Task<BookDetails> GetBookById(int id);

        public Task<IEnumerable<BookDetails>> GetBook();

        public Task<BookDetails> InsertBook(BookDetails bookDetails);
    }
}
