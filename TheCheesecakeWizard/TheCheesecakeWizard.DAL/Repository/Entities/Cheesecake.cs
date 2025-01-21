using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCheesecakeWizard.DAL.Repository.Entities
{
    public class Cheesecake
    {
        private int _id;
        public int Id 
        { 
            get => _id;
            set { _id = value; } 
        }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
