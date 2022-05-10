using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_asp.NET.Services
{
    public interface IRepository<T1, T2> where T1 : class
    {
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetSingle(T2 specifier);
        Task<T1> Add(T1 entity);
        Task<T1> Update(T1 entity);
        Task<T1> Delete(T1 entity);
        Task SaveChanges();
    }
}
