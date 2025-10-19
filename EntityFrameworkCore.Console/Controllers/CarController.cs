using System;
using System.Collections.Generic;
using System.IO;
using EntityframeworkCore.Data;
using EntityFrameworkCore.Console.Repository;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Console.Controllers
{
    internal class CarController
    {
        //GenericRepository<Car> _repo;
        //public CarController(GenericRepository<Car> repo) {
        //    this._repo = repo;
        //}

        public VehicleDbContext _context;
        public CarController(VehicleDbContext db)
        {
            _context = db;
        }

        public async Task<List<Car>> GetAll()
        {
            return await _context.Set<Car>().ToListAsync();
          

        }

        public Car? GetById(int id)
        {
            return  _context.Cars.Find(id);
        }

        public List<Car> GetByModelorBrand(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return null;
            List<Car> carLst = _context.Cars
                .Where(q => 
                EF.Functions.Like(q.Model, $"%{searchTerm}")
                || 
                EF.Functions.Like(q.Brand, $"%{searchTerm}%"))
                .ToList();
                return carLst;
        }

        public async void Add(Car entity)
        {
            await _context.Set<Car>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void Update(Car entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = this.GetById(id);
            if (item != null)
            {
                _context.Set<Car>().Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
