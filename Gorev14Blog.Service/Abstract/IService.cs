using Gorev14Blog.Core.Entities;
using Gorev14Blog.Data.Abstract;

namespace Gorev14Blog.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
