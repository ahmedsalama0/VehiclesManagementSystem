using EntityframeworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Console.Controllers
{
    internal class MotorcycleController
    {
        public VehicleDbContext _context;
        public MotorcycleController(VehicleDbContext db)
        {
            _context = db;
        }

        public async Task<List<Motorcycle>> GetAll()
        {
            return await _context.Motorcycles.ToListAsync();
        }

        public Motorcycle? GetById(int id)
        {
            return  _context.Motorcycles.Find(id);
        }

        public async void Add(Motorcycle entity)
        {
            await _context.Motorcycles.AddAsync(entity);
        }

        public async void Update(Motorcycle entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = this.GetById(id);
            if (item != null)
            {
                _context.Motorcycles.Remove(item);
                await _context.SaveChangesAsync();
            }
        }


    }
}
