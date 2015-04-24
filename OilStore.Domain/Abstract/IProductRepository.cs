using System.Linq;
using OilStore.Domain.Entities;

namespace OilStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
