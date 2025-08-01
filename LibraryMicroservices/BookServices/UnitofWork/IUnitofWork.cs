using BookServices.UnitofWork.Repository;

namespace BookServices.UnitofWork
{
    public interface IUnitofWork
    {
        IBookRepository bookRepository { get; }
        Task SaveData();
    }
}
