using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Drug
    {
        public int Id { get; set; } 
        public String Name { get; set; }
        public String Dose { get; set; }   
        public String Ingredients { get; set; } 
        public String Allergens { get; set; }

        public bool Approved { get; set; }  

        public Drug(int Id, String Name, String Dose, String Ingredients, String Allergens, bool Approved)
        {
            this.Id = Id;
            this.Name = Name;
            this.Dose = Dose;   
            this.Ingredients = Ingredients;
            this.Allergens = Allergens;
            this.Approved = Approved;   
        }
    }
}
