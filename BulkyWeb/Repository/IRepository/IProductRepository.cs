using BulkyWeb.Models;
using System;
using System.Linq;
using System.Text;

namespace BulkyWeb.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Save();
        void Update(Product obj);
    }
}
