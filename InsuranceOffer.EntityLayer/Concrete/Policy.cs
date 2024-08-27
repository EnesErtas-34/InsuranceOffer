using InsuranceOffer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.EntityLayer.Concrete
{
    public class Policy:IEntity
    {
        [Key]
        public int PolicyID { get; set; }
        public int InsuredID { get; set; }
        public virtual Insured InsuredNo { get; set; }
        public int InsurerID { get; set; }
        public virtual Insured InsurerNo { get; set; }
        public virtual Pay Pay { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Offer { get; set; }

        public virtual ICollection<PoliceAssurance> PoliceAssurances { get; set; }





    }
}
