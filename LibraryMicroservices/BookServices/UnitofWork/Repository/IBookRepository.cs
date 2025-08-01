using BookServices.Model;

namespace BookServices.UnitofWork.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetallBooks();
        Task<Book> GetBookbyId(int id);
        Task InsertBook(Book book);
        Task UpdateBook(Book book,int id);
        Task DeleteBook(int id);
    }
}
