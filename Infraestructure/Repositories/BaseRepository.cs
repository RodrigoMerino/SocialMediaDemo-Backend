using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
    {
        private readonly SocialMediaContext _Context;
        protected DbSet<T> _Entities;
        public BaseRepository(SocialMediaContext context)
        {
            _Context = context;
            _Entities = context.Set<T>();
        }
        public async Task Create(T Entity)
        {
           await  _Entities.AddAsync(Entity);
         // await _Context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _Entities.Remove(entity);
          //  await _Context.SaveChangesAsync();
        }

        public  IEnumerable<T> GetAll()
        {
            return _Entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _Entities.FindAsync(id);
        }

        public void Update(T Entity)
        {
            _Entities.Update(Entity);
           // await _Context.SaveChangesAsync();
        }
    }
}
