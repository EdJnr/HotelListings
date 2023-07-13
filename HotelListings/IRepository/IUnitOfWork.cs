using HotelListings.Data;

namespace HotelListings.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Country> CountryRepository { get; }

        IGenericRepository<Hotel> HotelRepository { get; }

        void Save();
    }
}
