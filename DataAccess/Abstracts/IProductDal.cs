using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IProductDal : IRepository<Product, int>, IAsyncRepository<Product, int>
    {


    }


}
