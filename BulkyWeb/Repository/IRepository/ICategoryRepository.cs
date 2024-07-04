using BulkyWeb.Models;
using System;
using System.Linq;
using System.Text;

namespace BulkyWeb.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}
