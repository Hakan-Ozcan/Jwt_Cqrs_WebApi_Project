using Back.Core.Application.Interfaces;

namespace Back.Persistance.Repositories
{
    public class Repository<T>:IRepository<T> where T :class,new()
    {
    }
}
