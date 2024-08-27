using InsuranceOffer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.EntityLayer.Concrete
{
    public class VerificationCodes:IEntity
    {
        [Key]
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
