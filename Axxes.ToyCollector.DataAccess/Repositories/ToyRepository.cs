using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace Axxes.ToyCollector.DataAccess.Repositories
{
    public class ToyRepository : IToyRepository
    {
        private readonly ToyContext _context;

        public ToyRepository(ToyContext context)
        {
            _context = context;
        }
        public async Task<List<Toy>> GetAll()
        {
            return await _context.Toys.ToListAsync();
        }

        public async Task<Toy> GetById(int id)
        {
            var item = await _context.Toys.FindAsync(id);

            if (item == null)
                throw new ArgumentException($"Entity with ID {id} not found.");

            return item;
        }

        public async Task Create(Toy value)
        {
            await _context.Toys.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Toy value)
        {
            var item = await _context.Toys.FindAsync(id);

            if (item == null)
                throw new ArgumentException($"Entity with ID {id} not found.");

            if (value.GetType().IsInstanceOfType(item))
            {
                //TODO: updater logic
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var item = await _context.Toys.FindAsync(id);

            if (item == null)
                throw new ArgumentException($"Entity with ID {id} not found.");

            _context.Toys.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
