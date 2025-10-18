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
    internal class TruckController
    {
        public VehicleDbContext _context;
        public TruckController(VehicleDbContext db)
        {
            _context = db;
        }

        public async Task<List<Truck>> GetAll()
        {
            return await _context.Trucks.ToListAsync();
        }

        public Truck? GetById(int id)
        {
            return _context.Trucks.Find(id);
        }

        public async void Add(Truck entity)
        {
            await _context.Trucks.AddAsync(entity);
        }

        public async void Update(Truck entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = this.GetById(id);
            if (item != null)
            {
                _context.Trucks.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}
