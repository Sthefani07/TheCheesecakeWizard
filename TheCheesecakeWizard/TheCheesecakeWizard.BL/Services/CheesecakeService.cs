using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheesecakeWizard.BL.Services.Interfaces;
using TheCheesecakeWizard.DAL;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.BL.Services
{
    public class CheesecakeService : ICheesecakeService
    {
        private readonly TheCheesecakeWizardDbContext _context;

        public CheesecakeService(TheCheesecakeWizardDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cheesecake>> GetAllCheesecakesAsync()
        {
            var test = await _context.Cheesecakes.Include(c => c.CheesecakeIngredients).ToListAsync();

            foreach (var cheesecake in test)
            {
                var test2 = cheesecake.CheesecakeIngredients.ToList();
            }

            return await _context.Cheesecakes.Include(c => c.CheesecakeIngredients).ToListAsync();
        }

        public async Task<Cheesecake> GetCheesecakeByIdAsync(int id)
        {
            var cheesecake = await _context.Cheesecakes.FindAsync(id);
            if (cheesecake == null)
            {
                throw new KeyNotFoundException("Cheesecake not found");
            }
            return cheesecake;
        }

        public async Task<Cheesecake> CreateCheesecakeAsync(Cheesecake cheesecake)
        {
            _context.Cheesecakes.Add(cheesecake);
            await _context.SaveChangesAsync();
            return cheesecake;
        }

        public async Task<Cheesecake> UpdateCheesecakeAsync(int id, Cheesecake cheesecake)
        {
            if (id != cheesecake.Id)
            {
                throw new ArgumentException("ID mismatch");
            }
            _context.Entry(cheesecake).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cheesecake;
        }

        public async Task DeleteCheesecakeAsync(int id)
        {
            var cheesecake = await _context.Cheesecakes.FindAsync(id);
            if (cheesecake == null)
            {
                throw new KeyNotFoundException("Cheesecake not found");
            }
            _context.Cheesecakes.Remove(cheesecake);
            await _context.SaveChangesAsync();
        }
    }
}
