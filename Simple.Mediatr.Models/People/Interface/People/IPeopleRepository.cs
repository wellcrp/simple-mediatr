using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Mediatr.Repository.Interface.People
{
    public interface IPeopleRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T people);
        Task Edit(T people);
        Task Delete(int id);
    }
}
