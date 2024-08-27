using InsuranceOffer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.EntityLayer.Concrete
{
    public class PoliceAssurance:IEntity
    {
        [Key]
        public int PoliceAssuranceID { get; set; }
        public int PolicyID { get; set; }
        public virtual Policy Policy { get; set; }
       
        public Guid AssuranceCode { get; set; }
        public virtual Assurance Assurance { get; set; }
        public decimal Bedel { get; set; }
        public decimal Bonus { get; set; }



    }
}
