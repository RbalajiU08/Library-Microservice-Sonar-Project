using BookServices.Data;
using BookServices.UnitofWork.Repository;

namespace BookServices.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;
        public IBookRepository bookRepository { get; }
        public UnitofWork(AppDbContext context) 
        {
            _context = context;
            bookRepository = new BookRepository(_context);
        }
        

        public async Task SaveData()
        {
            await _context.SaveChangesAsync();
        }
    }
}
