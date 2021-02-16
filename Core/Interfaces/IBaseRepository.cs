using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public  interface IBaseRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);
        Task Create(T Entity);
        void Update(T Entity);
        Task Delete(int id);

    }
}
