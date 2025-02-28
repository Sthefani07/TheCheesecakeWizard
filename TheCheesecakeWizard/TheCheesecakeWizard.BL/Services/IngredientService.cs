using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheesecakeWizard.BL.Services.Interfaces;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.BL.Services
{
    public class IngredientService : IIngredientService
    {
        public Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
        public Task DeleteIngredientAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Ingredient> UpdateIngredientAsync(int id, Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
