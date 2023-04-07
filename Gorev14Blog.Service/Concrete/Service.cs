using Gorev14Blog.Core.Entities;
using Gorev14Blog.Data;
using Gorev14Blog.Data.Concrete;
using Gorev14Blog.Service.Abstract;

namespace Gorev14Blog.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}
