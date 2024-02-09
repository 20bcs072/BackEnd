using Dapper;
using DapperProject.Context;
using DapperProject.Contracts;
using DapperProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Data;

namespace DapperProject.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly DapperContext _context;
        public BookRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<BookDetails> InsertBook(BookDetails bookDetails)
        {

            if (bookDetails.Publisheddate < bookDetails.Releaseddate)
            {
                var procedureName = "InsertBook";
                var parameters = new DynamicParameters();
                // parameters.Add("BookId", bookDetails.BookID, DbType.Int32);
                parameters.Add("@Title", bookDetails.Title, DbType.String);
                parameters.Add("@Author", bookDetails.Author, DbType.String);
                parameters.Add("@Publisher", bookDetails.Publisher, DbType.String);
                parameters.Add("@BookType", bookDetails.BookType, DbType.String);
                parameters.Add("@Publisheddate", bookDetails.Publisheddate, DbType.DateTime);
                parameters.Add("@Releaseddate", bookDetails.Releaseddate, DbType.DateTime);
                parameters.Add("@Price", bookDetails.Price, DbType.Int32);
                parameters.Add("@Stock", bookDetails.Stock, DbType.Int32);
                parameters.Add("@Sold", bookDetails.Sold, DbType.Int32);

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    return bookDetails;
                }
            }
            else {
                throw new InvalidOperationException("Release date should be less than publish date!!");
            }

        }
        public async Task DeleteBook(int id)
        {
            var query = "delete from BookDB where BookId=@id";
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, new { id });
              
            }
        }
        public async Task<IEnumerable<BookDetails>> GetBook()
        {
            var query = "select * from BookDB order by Title";
            using (var connection = _context.CreateConnection())
            {
                var books = await connection.QueryAsync<BookDetails>(query);
                return books.ToList();
            }
        }
        public async Task<int> UpdateBook(BookDetails bookDetails,int id)
        {
            // var query = "update BookDB set Title=@title,Author=@author,Publisher=@publisher,Booktype=@booktype,Publisheddate=@publisheddate,Releaseddate=@releaseddate,Price=@price,Stock=@stock,Sold=@sold where BookID=id";
            var procedureName = "UpdateBook";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32);
            parameters.Add("@Title", bookDetails.Title, DbType.String);
            parameters.Add("@Author", bookDetails.Author, DbType.String);
            parameters.Add("@Publisher", bookDetails.Publisher, DbType.String);
            parameters.Add("@BookType", bookDetails.BookType, DbType.String);
            parameters.Add("@Publisheddate", bookDetails.Publisheddate, DbType.DateTime);
            parameters.Add("@Releaseddate", bookDetails.Releaseddate, DbType.DateTime);
            parameters.Add("@Price", bookDetails.Price, DbType.Int32);
            parameters.Add("@Stock", bookDetails.Stock, DbType.Int32);
            parameters.Add("@Sold", bookDetails.Sold, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<BookDetails> GetBookById(int id)
        {
            var query = "select * from BookDB where BookID=@id";
            using (var connection = _context.CreateConnection())
            {
                var books = await connection.QueryFirstOrDefaultAsync<BookDetails>(query, new { id });
                return books;
            }
        }
    }
}