using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Repository.IRepository;

namespace BulkyWeb.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) { 
            _db = db;
        }
        void IProductRepository.Save()
        {
            _db.SaveChanges();
        }

        void IProductRepository.Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
