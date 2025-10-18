using EntityframeworkCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Console.Repository
{
    internal class GenericRepository<TEntity> where TEntity : class
    {
        public VehicleDbContext _context;


        public GenericRepository(VehicleDbContext db)
        {
            _context = db;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async void Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = this.GetById(id);
            if (item != null)
            {
                _context.Set<TEntity>().Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}
