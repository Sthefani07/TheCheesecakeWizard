using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheCheesecakeWizard.BL.Services.Interfaces;
using TheCheesecakeWizard.DAL;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.BL.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly TheCheesecakeWizardDbContext _context;

        public IngredientService(TheCheesecakeWizardDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }
        public async Task DeleteIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                throw new KeyNotFoundException("Ingredient not found");
            }
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }
        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                throw new KeyNotFoundException("Ingredient not found");
            }
            return ingredient;
        }
        public async Task<Ingredient> UpdateIngredientAsync(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                throw new ArgumentException("ID mismatch");
            }
            _context.Entry(ingredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ingredient;
        }
    }

}
