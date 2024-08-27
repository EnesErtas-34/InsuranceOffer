using InsuranceOffer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.EntityLayer.Concrete
{
    public class Assurance:IEntity
    {
        //[Key]
        //public string AssuranceCode { get; set; }
        //public string AssuranceName { get; set; }
        //public decimal AssurancePrice { get; set; }
        //public decimal Bonus { get; set; }
        //public virtual ICollection<PoliceAssurance> PoliceTeminats { get; set; }

        [Key]
        public Guid AssuranceCode { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isRequired { get; set; }
        public virtual ICollection<PoliceAssurance> PoliceTeminats { get; set; }
    }
}
