﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheesecakeWizard.DAL.Repository.Entities;

public class Cheesecake
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public ICollection<CheesecakeIngredient>? CheesecakeIngredients { get; set; } = new List<CheesecakeIngredient>();
}