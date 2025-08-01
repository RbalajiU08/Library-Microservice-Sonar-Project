using BookServices.Data;
using BookServices.Model;
using Microsoft.EntityFrameworkCore;

namespace BookServices.UnitofWork.Repository
{
    public class BookRepository(AppDbContext context) : IBookRepository
    {
        private readonly AppDbContext _context = context;
        public async Task DeleteBook(int id)
        {
            var book = await GetBookbyId(id);
            _context.Books.Remove(book);
        }

        public async Task<List<Book>> GetallBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookbyId(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task InsertBook(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task UpdateBook(Book book, int id)
        {
            var existingbook = await GetBookbyId(id);
            existingbook.BookTitle = book.BookTitle;
            existingbook.BookAuthor = book.BookAuthor;
        }
    }
}
