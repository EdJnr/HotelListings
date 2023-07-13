using HotelListings.Data;
using HotelListings.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelListings.Repository
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context) 
        { 
            _context = context;
        }
        public IGenericRepository<Country> CountryRepository => new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> HotelRepository => new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            //Implement Garbage collection
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async void  Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
