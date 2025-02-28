using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.BL.Services.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
    Task<Ingredient> UpdateIngredientAsync(int id, Ingredient ingredient);
    Task DeleteIngredientAsync(int id);
}