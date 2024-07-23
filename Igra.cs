using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VjezbaLinq
{
    internal class Igra
    {
      
        public string Ime { get; set; }
        public int Id { get; set; }
        public string Vrsta { get; set; }
        
  
    
        public Igra(string ime, int id, string vrsta)
        {
            Ime = ime;
            Id = id;
            Vrsta = vrsta;
        }
     
    }
}
