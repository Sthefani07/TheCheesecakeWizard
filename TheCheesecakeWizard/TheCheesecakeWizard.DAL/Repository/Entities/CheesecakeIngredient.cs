using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheesecakeWizard.DAL.Repository.Entities;

public class CheesecakeIngredient
{
    public int CheesecakeId { get; set; }
    public int IngredientId { get; set; }
    public Cheesecake Cheesecake { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
}