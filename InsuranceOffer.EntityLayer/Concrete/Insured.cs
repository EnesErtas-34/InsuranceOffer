    using InsuranceOffer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InsuranceOffer.EntityLayer.Concrete
{
    public class Insured:IEntity
    {
        [Key]
        public int InsuredID { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public virtual ICollection<Policy> PoliciesAsInsured { get; set; }
        public virtual ICollection<Policy> PoliciesAsInsurer { get; set; }
        public virtual ICollection<Pay> Pays { get; set; }

    }
}
